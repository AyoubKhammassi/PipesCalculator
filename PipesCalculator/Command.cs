#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
#endregion

namespace PipesCalculator
{


    /// <summary>
    /// Allow selection of elements of type T only.
    /// </summary>
    public class ElementsOfClassSelectionFilter<T>
      : ISelectionFilter where T : Element
    {
        public bool AllowElement(Element e)
        {
            return e is T;
        }

        public bool AllowReference(Reference r, XYZ p)
        {
            return true;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {


        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {

                /*Reference selRef = uidoc.Selection.PickObject(ObjectType.Element, new ElementsOfClassSelectionFilter<Pipe>(), "Select A Pipe");
                Element selectd = doc.GetElement(selRef);*/

                using (Transaction transaction = new Transaction(doc))
                {
                    try
                    {
                        transaction.Start("Calculation");
                        /*if (!Utilities.dataIsExtracted)
                            Utilities.LoadAllData(doc);
                        //Opening the excel App
                        TraversalTree tree = new TraversalTree(doc, ((Pipe)selectd).MEPSystem);
                        /*List<Element> connectedFixtures = new List<Element>();
                        TreeNode selectedNode = tree.FindTargetNode(selectd);
                        tree.Traverse(selectedNode, ref connectedFixtures);
                        CalculationResults results = Utilities.Calculate(connectedFixtures);
                        results.pipe = (Pipe)selectd;*/
                        //tree.doc = doc;
                        //tree.ends = new List<Element>();
                        //tree.allResults = new List<CalculationResults>();
                        //tree.Traverse();


                        FilteredElementCollector collector = new FilteredElementCollector(doc);
                        collector.OfCategory(BuiltInCategory.OST_PipingSystem).WhereElementIsNotElementType();
                        List<Element> systems = collector.ToElements() as List<Element>;
                        MEPSystem s = (MEPSystem)systems[0];
                        Displayer form = new Displayer(uidoc, systems);
                        form.ShowDialog();
                  


                        //Utilities.WriteAllResultsToExcelFile(@"D:\Work\BIMINTOUCH\Water Supply", @"TEST.xlsx", "something", tree.allResults);
                        /*Main form = new Main(results);
                        form.ShowDialog();*/
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("somrthing");
                        Console.WriteLine(e.Source);
                    }
                    finally
                    {
                        transaction.Commit();
                        //Utilities.CloseExcelApp();
                    }

                }
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {

            }

            return Result.Succeeded;
        }
    }
}
