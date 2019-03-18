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
    /// A TreeNode object represents an element in the system
    /// </summary>
    public class TreeNode
    {
        #region Member variables
        /// <summary>
        /// Id of the element
        /// </summary>
        private Autodesk.Revit.DB.ElementId m_Id;
        /// <summary>
        /// Flow direction of the node
        /// For the starting element of the traversal, the direction will be the same as the connector
        /// connected to its following element; Otherwise it will be the direction of the connector connected to
        /// its previous element
        /// </summary>
        private FlowDirectionType m_direction;
        /// <summary>
        /// The parent node of the current node.
        /// </summary>
        private TreeNode m_parent;
        /// <summary>
        /// The connector of the previous element to which current element is connected
        /// </summary>
        private Connector m_inputConnector;
        /// <summary>
        /// The first-level child nodes of the current node
        /// </summary>
        private List<TreeNode> m_childNodes;
        /// <summary>
        /// Active document of Revit
        /// </summary>
        private Document m_document;
        #endregion

        #region Properties
        /// <summary>
        /// Id of the element
        /// </summary>
        public Autodesk.Revit.DB.ElementId Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// Flow direction of the node
        /// </summary>
        public FlowDirectionType Direction
        {
            get
            {
                return m_direction;
            }
            set
            {
                m_direction = value;
            }
        }

        /// <summary>
        /// Gets and sets the parent node of the current node.
        /// </summary>
        public TreeNode Parent
        {
            get
            {
                return m_parent;
            }
            set
            {
                m_parent = value;
            }
        }

        /// <summary>
        /// Gets and sets the first-level child nodes of the current node
        /// </summary>
        public List<TreeNode> ChildNodes
        {
            get
            {
                return m_childNodes;
            }
            set
            {
                m_childNodes = value;
            }
        }

        /// <summary>
        /// The connector of the previous element to which current element is connected
        /// </summary>
        public Connector InputConnector
        {
            get
            {
                return m_inputConnector;
            }
            set
            {
                m_inputConnector = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doc">Revit document</param>
        /// <param name="id">Element's Id</param>
        public TreeNode(Document doc, Autodesk.Revit.DB.ElementId id)
        {
            m_document = doc;
            m_Id = id;
            m_childNodes = new List<TreeNode>();
        }

        /// <summary>
        /// Get Element by its Id
        /// </summary>
        /// <param name="eid">Element's Id</param>
        /// <returns>Element</returns>
        private Element GetElementById(Autodesk.Revit.DB.ElementId eid)
        {
            return m_document.GetElement(eid);
        }

        /// <summary>
        /// Dump the node into XML file
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        public void DumpIntoXML(XmlWriter writer)
        {
            // Write node information
            Element element = GetElementById(m_Id);
            FamilyInstance fi = element as FamilyInstance;
            if (fi != null)
            {
                MEPModel mepModel = fi.MEPModel;
                String type = String.Empty;
                if (mepModel is MechanicalEquipment)
                {
                    type = "MechanicalEquipment";
                    writer.WriteStartElement(type);
                }
                else if (mepModel is MechanicalFitting)
                {
                    MechanicalFitting mf = mepModel as MechanicalFitting;
                    type = "MechanicalFitting";
                    writer.WriteStartElement(type);
                    writer.WriteAttributeString("Category", element.Category.Name);
                    writer.WriteAttributeString("PartType", mf.PartType.ToString());
                }
                else
                {
                    type = "FamilyInstance";
                    writer.WriteStartElement(type);
                    writer.WriteAttributeString("Category", element.Category.Name);
                }

                writer.WriteAttributeString("Name", element.Name);
                writer.WriteAttributeString("Id", element.Id.IntegerValue.ToString());
                writer.WriteAttributeString("Direction", m_direction.ToString());
                writer.WriteEndElement();
            }
            else
            {
                String type = element.GetType().Name;

                writer.WriteStartElement(type);
                writer.WriteAttributeString("Name", element.Name);
                writer.WriteAttributeString("Id", element.Id.IntegerValue.ToString());
                writer.WriteAttributeString("Direction", m_direction.ToString());
                writer.WriteEndElement();
            }

            foreach (TreeNode node in m_childNodes)
            {
                if (m_childNodes.Count > 1)
                {
                    writer.WriteStartElement("Path");
                }

                node.DumpIntoXML(writer);

                if (m_childNodes.Count > 1)
                {
                    writer.WriteEndElement();
                }
            }
        }
        #endregion
    }
}
