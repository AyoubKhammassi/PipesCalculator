#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
#endregion

namespace PipesCalculator
{
    /// <summary>
    /// Data structure of the traversal
    /// </summary>
    public class TraversalTree
    {
        #region Member variables
        // Active document of Revit
        private Document m_document;
        // The MEP system of the traversal
        private MEPSystem m_system;
        // The flag whether the MEP system of the traversal is a mechanical system or piping system
        private Boolean m_isMechanicalSystem;
        // The starting element node
        private TreeNode m_startingElementNode;

        //added to calculate recursevily
        public Document doc;
        public List<CalculationResults> allResults;
        //public List<Element> ends;
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="activeDocument">Revit document</param>
        /// <param name="system">The MEP system to traverse</param>
        public TraversalTree(Document activeDocument, MEPSystem system)
        {
            m_document = activeDocument;
            m_system = system;
            m_isMechanicalSystem = (system is MechanicalSystem);
        }

        /// <summary>
        /// Traverse the system
        /// </summary>
        public void Traverse()
        {
            // Get the starting element node
            m_startingElementNode = GetStartingElementNode();
            allResults = new List<CalculationResults>();
            List<Element> allEnds = new List<Element>();
            // Traverse the system recursively
            Traverse(m_startingElementNode, ref allEnds);
        }

        /// <summary>
        /// Get the starting element node.
        /// If the system has base equipment then get it;
        /// Otherwise get the owner of the open connector in the system
        /// </summary>
        /// <returns>The starting element node</returns>
        private TreeNode GetStartingElementNode()
        {
            TreeNode startingElementNode = null;

            FamilyInstance equipment = m_system.BaseEquipment;
            //
            // If the system has base equipment then get it;
            // Otherwise get the owner of the open connector in the system
            if (equipment != null)
            {
                startingElementNode = new TreeNode(m_document, equipment.Id);
            }
            else
            {
                startingElementNode = new TreeNode(m_document, GetOwnerOfOpenConnector().Id);
            }

            startingElementNode.Parent = null;
            startingElementNode.InputConnector = null;

            return startingElementNode;
        }

        /// <summary>
        /// Get the owner of the open connector as the starting element
        /// </summary>
        /// <returns>The owner</returns>
        private Element GetOwnerOfOpenConnector()
        {
            Element element = null;

            //
            // Get an element from the system's terminals
            ElementSet elements = m_system.Elements;
            foreach (Element ele in elements)
            {
                element = ele;
                break;
            }

            // Get the open connector recursively
            Connector openConnector = GetOpenConnector(element, null);

            return openConnector.Owner;
        }

        /// <summary>
        /// Get the open connector of the system if the system has no base equipment
        /// </summary>
        /// <param name="element">An element in the system</param>
        /// <param name="inputConnector">The connector of the previous element 
        /// to which the element is connected </param>
        /// <returns>The found open connector</returns>
        private Connector GetOpenConnector(Element element, Connector inputConnector)
        {
            Connector openConnector = null;
            ConnectorManager cm = null;
            //
            // Get the connector manager of the element
            if (element is FamilyInstance)
            {
                FamilyInstance fi = element as FamilyInstance;
                cm = fi.MEPModel.ConnectorManager;
            }
            else
            {
                MEPCurve mepCurve = element as MEPCurve;
                cm = mepCurve.ConnectorManager;
            }

            foreach (Connector conn in cm.Connectors)
            {
                // Ignore the connector does not belong to any MEP System or belongs to another different MEP system
                if (conn.MEPSystem == null || !conn.MEPSystem.Id.IntegerValue.Equals(m_system.Id.IntegerValue))
                {
                    continue;
                }

                // If the connector is connected to the input connector, they will have opposite flow directions.
                if (inputConnector != null && conn.IsConnectedTo(inputConnector))
                {
                    continue;
                }

                // If the connector is not connected, it is the open connector
                if (!conn.IsConnected)
                {
                    openConnector = conn;
                    break;
                }

                //
                // If open connector not found, then look for it from elements connected to the element
                foreach (Connector refConnector in conn.AllRefs)
                {
                    // Ignore non-EndConn connectors and connectors of the current element
                    if (refConnector.ConnectorType != ConnectorType.End ||
                        refConnector.Owner.Id.IntegerValue.Equals(conn.Owner.Id.IntegerValue))
                    {
                        continue;
                    }

                    // Ignore connectors of the previous element
                    if (inputConnector != null && refConnector.Owner.Id.IntegerValue.Equals(inputConnector.Owner.Id.IntegerValue))
                    {
                        continue;
                    }

                    openConnector = GetOpenConnector(refConnector.Owner, conn);
                    if (openConnector != null)
                    {
                        return openConnector;
                    }
                }
            }

            return openConnector;
        }

        /// <summary>
        /// Traverse the system recursively by analyzing each element
        /// </summary>
        /// <param name="elementNode">The element to be analyzed</param>
        public void Traverse(TreeNode elementNode, ref List<Element> ends)
        {
            List<Element> localEnds = new List<Element>();
            // Find all child nodes and analyze them recursively
            AppendChildren(elementNode, ref localEnds);
            foreach (TreeNode node in elementNode.ChildNodes)
            {
                //use this code to find a specific elemnt
                /*if(targetPipe.Id.IntegerValue == node.Id.IntegerValue)
                {
                    targetNode = node;
                    return;
                }*/
                /*Element element = doc.GetElement(node.Id);
                if (element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PlumbingFixtures)
                {
                    ends.Add(element);
                    continue;
                }*/

                Traverse(node, ref localEnds);
            }

            if ((GetElementById(elementNode.Id).Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeFitting))
            {
                if (localEnds.Count == 0)
                    return;

                if(GetElementById(elementNode.InputConnector.Owner.Id) is Pipe)
                {
                    CalculationResults result = Utilities.Calculate(localEnds);
                    result.pipe = GetElementById(elementNode.InputConnector.Owner.Id) as Pipe;
                    allResults.Add(result);
                }
            }
           

            ends.AddRange(localEnds);

        }

        /// <summary>
        /// Find all child nodes of the specified element node
        /// </summary>
        /// <param name="elementNode">The specified element node to be analyzed</param>
        public void AppendChildren(TreeNode elementNode, ref List<Element> ends)
        {
            List<TreeNode> nodes = elementNode.ChildNodes;
            ConnectorSet connectors;
            //
            // Get connector manager
            Element element = GetElementById(elementNode.Id);
            FamilyInstance fi = element as FamilyInstance;
            if (fi != null)
            {
                connectors = fi.MEPModel.ConnectorManager.Connectors;
            }
            else
            {
                MEPCurve mepCurve = element as MEPCurve;
                connectors = mepCurve.ConnectorManager.Connectors;
            }

            // Find connected connector for each connector
            foreach (Connector connector in connectors)
            {
                MEPSystem mepSystem = connector.MEPSystem;
                // Ignore the connector does not belong to any MEP System or belongs to another different MEP system
                if (mepSystem == null || !mepSystem.Id.IntegerValue.Equals(m_system.Id.IntegerValue))
                {
                    continue;
                }

                //
                // Get the direction of the TreeNode object
                if (elementNode.Parent == null)
                {
                    if (connector.IsConnected)
                    {
                        elementNode.Direction = connector.Direction;
                    }
                }
                else
                {
                    // If the connector is connected to the input connector, they will have opposite flow directions.
                    // Then skip it.
                    if (connector.IsConnectedTo(elementNode.InputConnector))
                    {
                        elementNode.Direction = connector.Direction;
                        continue;
                    }
                }



                // Get the connector connected to current connector
                Connector connectedConnector = GetConnectedConnector(connector);
                
                /*******************************************************/
                if (connectedConnector != null)
                {
                    if(connectedConnector.Owner.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PlumbingFixtures)
                    {
                        ends.Add(connectedConnector.Owner);
                        /*if (GetElementById(elementNode.Id) is Pipe)
                        {
                            CalculationResults result = Utilities.Calculate(ends);
                            result.pipe = GetElementById(elementNode.Id) as Pipe;
                            allResults.Add(result);
                        }*/
                    }
                    /**********************************************************/
                    TreeNode node = new TreeNode(m_document, connectedConnector.Owner.Id);
                    node.InputConnector = connector;
                    node.Parent = elementNode;
                    nodes.Add(node);
                }
            }


            nodes.Sort(delegate (TreeNode t1, TreeNode t2)
            {
                return t1.Id.IntegerValue > t2.Id.IntegerValue ? 1 : (t1.Id.IntegerValue < t2.Id.IntegerValue ? -1 : 0);
            }
                );
        }

        /// <summary>
        /// Get the connected connector of one connector
        /// </summary>
        /// <param name="connector">The connector to be analyzed</param>
        /// <returns>The connected connector</returns>
        static private Connector GetConnectedConnector(Connector connector)
        {
            Connector connectedConnector = null;
            ConnectorSet allRefs = connector.AllRefs;
            foreach (Connector conn in allRefs)
            {
                // Ignore non-EndConn connectors and connectors of the current element
                if (conn.ConnectorType != ConnectorType.End ||
                    conn.Owner.Id.IntegerValue.Equals(connector.Owner.Id.IntegerValue))
                {
                    continue;
                }

                connectedConnector = conn;
                break;
            }

            return connectedConnector;
        }

        /// <summary>
        /// Get element by its id
        /// </summary>
        private Element GetElementById(Autodesk.Revit.DB.ElementId eid)
        {
            return m_document.GetElement(eid);
        }

        /// <summary>
        /// Dump the traversal into an XML file
        /// </summary>
        /// <param name="fileName">Name of the XML file</param>
        public void DumpIntoXML(String fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            // Write the root element
            String mepSystemType = String.Empty;
            mepSystemType = (m_system is MechanicalSystem ? "MechanicalSystem" : "PipingSystem");
            writer.WriteStartElement(mepSystemType);

            // Write basic information of the MEP system
            WriteBasicInfo(writer);
            // Write paths of the traversal
            WritePaths(writer);

            // Close the root element
            writer.WriteEndElement();

            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Write basic information of the MEP system into the XML file
        /// </summary>
        /// <param name="writer">XMLWriter object</param>
        private void WriteBasicInfo(XmlWriter writer)
        {
            MechanicalSystem ms = null;
            PipingSystem ps = null;
            if (m_isMechanicalSystem)
            {
                ms = m_system as MechanicalSystem;
            }
            else
            {
                ps = m_system as PipingSystem;
            }

            // Write basic information of the system
            writer.WriteStartElement("BasicInformation");

            // Write Name property
            writer.WriteStartElement("Name");
            writer.WriteString(m_system.Name);
            writer.WriteEndElement();

            // Write Id property
            writer.WriteStartElement("Id");
            writer.WriteValue(m_system.Id.IntegerValue);
            writer.WriteEndElement();

            // Write UniqueId property
            writer.WriteStartElement("UniqueId");
            writer.WriteString(m_system.UniqueId);
            writer.WriteEndElement();

            // Write SystemType property
            writer.WriteStartElement("SystemType");
            if (m_isMechanicalSystem)
            {
                writer.WriteString(ms.SystemType.ToString());
            }
            else
            {
                writer.WriteString(ps.SystemType.ToString());
            }
            writer.WriteEndElement();

            // Write Category property
            writer.WriteStartElement("Category");
            writer.WriteAttributeString("Id", m_system.Category.Id.IntegerValue.ToString());
            writer.WriteAttributeString("Name", m_system.Category.Name);
            writer.WriteEndElement();

            // Write IsWellConnected property
            writer.WriteStartElement("IsWellConnected");
            if (m_isMechanicalSystem)
            {
                writer.WriteValue(ms.IsWellConnected);
            }
            else
            {
                writer.WriteValue(ps.IsWellConnected);
            }
            writer.WriteEndElement();

            // Write HasBaseEquipment property
            writer.WriteStartElement("HasBaseEquipment");
            bool hasBaseEquipment = ((m_system.BaseEquipment == null) ? false : true);
            writer.WriteValue(hasBaseEquipment);
            writer.WriteEndElement();

            // Write TerminalElementsCount property
            writer.WriteStartElement("TerminalElementsCount");
            writer.WriteValue(m_system.Elements.Size);
            writer.WriteEndElement();

            // Write Flow property
            writer.WriteStartElement("Flow");
            if (m_isMechanicalSystem)
            {
                writer.WriteValue(ms.GetFlow());
            }
            else
            {
                writer.WriteValue(ps.GetFlow());
            }
            writer.WriteEndElement();

            // Close basic information
            writer.WriteEndElement();
        }

        /// <summary>
        /// Write paths of the traversal into the XML file
        /// </summary>
        /// <param name="writer">XMLWriter object</param>
        private void WritePaths(XmlWriter writer)
        {
            writer.WriteStartElement("Path");
            m_startingElementNode.DumpIntoXML(writer);
            writer.WriteEndElement();
        }


        //added code to find the correspondent TreeNode of an elemnt
        
        /*public Element targetPipe;
        public TreeNode targetNode;
        public TreeNode FindTargetNode(Element element)
        {
            targetPipe = element;
            targetNode = new TreeNode(targetPipe.Document, targetPipe.Id);
            Traverse();
            return targetNode;
        }*/
        #endregion
    }
}
