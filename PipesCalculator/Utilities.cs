#region namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Microsoft.Office.Interop.Excel;
using ExcelLibrary = Microsoft.Office.Interop.Excel;
using RevitLibrary = Autodesk.Revit.DB;
using System.Text;
using Winforms = System.Windows.Forms;
#endregion

namespace PipesCalculator
{
    /// <summary>
    /// Allow selection of elements of type T only.
    /// </summary>
    public class CalculationResults
    {
        public Pipe pipe;
        public List<Element> fixtures;
        public double totalFlow;
        public int numberOfFixtures;
        public double coeffecient;
        public double possibleflow;
        public double section;
        public double diameter;
        public string material;
        public double commercialInternalDiameter;
        public double commercialExternalDiameter;
        public double realSpeed;

        //default constructor
        public CalculationResults() { }
        //copy constructor
        public CalculationResults(CalculationResults copy)
        {
            pipe = copy.pipe;
            fixtures = copy.fixtures;
            totalFlow = copy.totalFlow;
            numberOfFixtures = copy.numberOfFixtures;
            coeffecient = copy.coeffecient;
            possibleflow = copy.possibleflow;
            section = copy.section;
            diameter = copy.diameter;
            material = copy.material;
            commercialExternalDiameter = copy.commercialExternalDiameter;
            commercialInternalDiameter = copy.commercialInternalDiameter;
            realSpeed = copy.realSpeed;
        }
    }   


    //a struct used to store all types of pipes of a specific material
    struct Values
    {
        public double intd;
        public double extd;
        public double section;
    }


    class Utilities
    {

        #region Fields
        //Attributes
        //Excel Attributes
        public static ExcelLibrary.Application excelApp = new ExcelLibrary.Application();
        public static Workbooks wbs = excelApp.Workbooks;
        public static Workbook wb;
        public static Worksheet ws;
        const double PI = 3.14159265359;
        //data loaded from excel files and stored into dictionaries
        public static Dictionary<string, double> fixturesFlow;
        public static Dictionary<string, double> fixturesCoeff;
        //array that contains minimum diameters or each integer coeffecient
        public static double[] minimumDiameters;
        public static Dictionary<string, List<Values>> materials;
        //List of all created pipe types
        public static List<PipeType> pipeTypes;
        //List of created segments
        public static Dictionary<string, PipeSegment> segments;
        //whether the data is extracted from the excel file or not
        public static bool dataIsExtracted = false;

        //Schedule used to create segments
        public static PipeScheduleType calculationsSchedule;
        //speed used in calculations
        public static double speed = 1.5;


        //Utilities properties 
        //document that the plugin will work on
        public static Document doc;
        //using this pipe type to duplicate it and create new pipe types
        public static FamilySymbol standardPipeType;
        //MEPSystem that the plugin is currntly working on
        public static MEPSystem calculatedSystem;
        #endregion


        #region Excel Methods
        //Excel Methods
        public static bool OpenExcelApp(string filePath)
        {
            try
            {
                wb = excelApp.Workbooks.Open(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void CloseExcelApp()
        {
            if (ws != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);

            wb.Close(0);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);

            if (wbs != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wbs);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
        public static bool OpenExcelSheet(int sheetNumber)
        {
            try
            {
                /*if(ws != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);*/
                ws = wb.Worksheets[sheetNumber];
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        //get the data from a specific cell
        public static string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            else
                return "";
        }

        //writes the data to a specific cell
        public static bool WriteCell(int i, int j, string data)
        {
            try
            {
                ws.Cells[i, j] = data;

                wb.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //writes a list of Calculation results to an output excel file
        public static void WriteAllResultsToExcelFile(string filePath, string fileName, string sheet, List<CalculationResults> allResults)
        {
            try
            {
                excelApp = new ExcelLibrary.Application();
                excelApp.Visible = true;

                //Get a new workbook.
                wb = (ExcelLibrary.Workbook)(excelApp.Workbooks.Add(@filePath + @"\" + @fileName));
                ws = (ExcelLibrary.Worksheet)wb.ActiveSheet;

                //starting withy headers
                WriteCell(1, 1, "Nom");
                WriteCell(1, 2, "Nombre Totale");
                WriteCell(1, 3, "Coeffecient De Simultanité");
                WriteCell(1, 4, "Débit Brut (l/s)");
                WriteCell(1, 5, "Débit Probable (l/s)");
                WriteCell(1, 6, "Vitesse (m/s)");
                WriteCell(1, 7, "Diamètre calculé (mm)");
                WriteCell(1, 8, "Tube");
                WriteCell(1, 9, "Diamètre Commercial");
                WriteCell(1, 10, "Vitesse Réelle");
                //ws.get_Range("A1", "A10").EntireRow.AutoFit();
                //ws.get_Range("A1", "A10").EntireRow.Font.Bold = true;

                int i = 1;
                foreach(CalculationResults cr in allResults)
                {
                    i++;
                    WriteCell(i, 1, (cr.pipe != null) ? cr.pipe.Id.ToString() : "");
                    WriteCell(i, 2, cr.numberOfFixtures.ToString());
                    WriteCell(i, 3, cr.coeffecient.ToString());
                    WriteCell(i, 4, cr.totalFlow.ToString());
                    WriteCell(i, 5, cr.possibleflow.ToString());
                    WriteCell(i, 6, Utilities.speed.ToString());
                    WriteCell(i, 7, cr.diameter.ToString());
                    WriteCell(i, 8, "Cuivre");
                    WriteCell(i, 9, cr.commercialInternalDiameter.ToString());
                    WriteCell(i, 10, cr.realSpeed.ToString());

                }



            }
            catch (Exception)
            {

            }
        }
        //use this to load the flow (débit) or the coeffecient data from the excel file
        //use index=1 to load flow data
        //use index=2 to load coeffecients
        public static void LoadFromExcel(int sheetNumber)
        {
            fixturesFlow = new Dictionary<string, double>();
            fixturesCoeff = new Dictionary<string, double>();
            minimumDiameters = new double[15];
            OpenExcelSheet(sheetNumber);
            int i = 0;
            while(ReadCell(i,0) != "")
            {
                fixturesFlow.Add(ReadCell(i, 0), Convert.ToDouble(ReadCell(i, 1)));
                fixturesCoeff.Add(ReadCell(i, 0), Convert.ToDouble(ReadCell(i, 2)));
                if(i<=14)
                    minimumDiameters[i] = Convert.ToDouble(ReadCell(i, 5));
                i++;
            }
        }
        //use this to load materials data from excel
        public static Dictionary<string, List<Values>> LoadMaterialsFromExcel()
        {
            Dictionary<string, List<Values>> materials = new Dictionary<string, List<Values>>();
            foreach (Worksheet sheet in wb.Worksheets)
            {
                if(sheet.Name.Contains("Tube"))
                {
                    OpenExcelSheet(sheet.Index);
                    List<Values> values = new List<Values>();
                    int i = 0;
                    while (ReadCell(i, 0) != "")
                    {
                        Values buffer = new Values();
                        Double.TryParse(ReadCell(i, 0), out buffer.intd);
                        Double.TryParse(ReadCell(i, 1), out buffer.extd);
                        Double.TryParse(ReadCell(i, 2), out buffer.section);
                        values.Add(buffer);
                        i++;
                    }
                    materials.Add(sheet.Name, values);
                }
            }
            return materials;
        }
        public static void LoadAllData()
        {
            OpenExcelApp(@"D:\Work\BIMINTOUCH\Water Supply\DATA.xlsx");
            //load data from excel file if it's not already loaded
            //loading fixtures flow
            if (fixturesFlow == null)
                LoadFromExcel(1);
            //loading materials
            if (materials == null)
                materials = LoadMaterialsFromExcel();
            if (pipeTypes == null)
                LoadBimitPipeTypes();
            //initializing vars
            calculationsSchedule = PipeScheduleType.Create(doc, string.Concat(calculatedSystem.Name, DateTime.Now.ToString("yyyyMMddHHmmss")));
            List<string> matNames = new List<string>(materials.Keys);
            segments = new Dictionary<string, PipeSegment>();
            foreach(string matName in matNames)
            {
                ElementId matId;

                var existingMat = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Materials).FirstOrDefault(x => string.Compare(x.Name, matName.Remove(0, 5), true) == 0).Id;
                if (existingMat == null)
                    matId = Material.Create(doc, matName.Remove(0, 5));
                else
                    matId = existingMat;
                /*else
                    matId = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Materials).FirstOrDefault(x => x.Name == matName).Id;*/
                /*FamilySymbol newPipeType = CreateNewPipeType(standardPipeType, matName, matId);
                pipeTypes.Add(newPipeType);*/
                Values defaultSize = materials[matName][0];
                double nd = (defaultSize.intd + defaultSize.extd) / 2;
                MEPSize size = new MEPSize(nd / 304.8, defaultSize.intd / 304.8, defaultSize.extd / 304.8, true, true);
                List<MEPSize> sizes = new List<MEPSize>();
                sizes.Add(size);
                PipeSegment seg = PipeSegment.Create(doc, matId, calculationsSchedule.Id, sizes);
                segments.Add(matName, seg);
            }

            CloseExcelApp();
            dataIsExtracted = true;

        }
        #endregion

        #region Revit Methods
        //Revit Methods
        //returns all the elements of a specific category in an active view
        public static List<Element> GetElementsInView(ElementId viewId, BuiltInCategory category)
        {
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(category);
            FilteredElementCollector coll = new FilteredElementCollector(doc, viewId).WherePasses(categoryFilter);
            return coll.ToElements() as List<Element>;
        }
        //set the value of a parameter
        public static void SetParameterValue(ref RevitLibrary.Parameter p, object value)
        {
            try
            {
                if (value.GetType().Equals(typeof(string)))
                {

                    if (p.SetValueString(value as string))
                        return;
                }

                switch (p.StorageType)
                {
                    case StorageType.None:
                        break;
                    case StorageType.Double:
                        if (value.GetType().Equals(typeof(string)))
                        {
                            p.Set(double.Parse(value as string));
                        }
                        else
                        {
                            p.Set(Convert.ToDouble(value));
                        }
                        break;
                    case StorageType.Integer:
                        if (value.GetType().Equals(typeof(string)))
                        {
                            p.Set(int.Parse(value as string));
                        }
                        else
                        {
                            p.Set(Convert.ToInt32(value));
                        }
                        break;
                    case StorageType.ElementId:
                        if (value.GetType().Equals(typeof(ElementId)))
                        {
                            p.Set(value as ElementId);
                        }
                        else if (value.GetType().Equals(typeof(string)))
                        {
                            p.Set(new ElementId(int.Parse(value as string)));
                        }
                        else
                        {
                            p.Set(new ElementId(Convert.ToInt32(value)));
                        }
                        break;
                    case StorageType.String:
                        p.Set(value.ToString());
                        break;
                }
            }
            catch
            {
                throw new Exception("Invalid Value Input!");

            }
        }

        public static void ChangePipeType(CalculationResults cr)
        {
            PipeType newPipeType = pipeTypes.FirstOrDefault(x => x.Name.Contains(cr.material.Remove(0,5)));
            cr.pipe.ChangeTypeId(newPipeType.Id);
        }

        //Set the sizes of a pipe
        public static void SetPipeSize(Pipe pipe, double nominalDiameter, double innerDiameter, double outerDiameter, string materialName)
        {
            //get the correspondent segment : material + schedule Type

            MEPSize size = new MEPSize(nominalDiameter / 304.8, innerDiameter / 304.8, outerDiameter / 304.8, true, true);
            try { segments[materialName].AddSize(size);}
            catch { }
            if (pipe.get_Parameter(BuiltInParameter.RBS_PIPE_SEGMENT_PARAM).Set(segments[materialName].Id))
                pipe.get_Parameter(BuiltInParameter.RBS_PIPE_SEGMENT_PARAM).Set(segments[materialName].Id);

            pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).SetValueString(nominalDiameter.ToString());
        }
        public static void SetPipeDiameter(Pipe pipe, double diameter)
        {
            RevitLibrary.Parameter parameter = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
            Console.Write(parameter.DisplayUnitType);
            double value = UnitUtils.Convert(diameter, DisplayUnitType.DUT_MILLIMETERS, parameter.DisplayUnitType);
            parameter.Set(value);
        }
        //returns a list of elements that have the same value for a specific parameter
        public static List<Element> GetElementsWithTheSameParameterValue(BuiltInParameter parameter, string value)
        {
            List<Element> elements = new List<Element>();
            ParameterValueProvider provider = new ParameterValueProvider(new ElementId((int)parameter));
            FilterStringRule rule1 = new FilterStringRule(provider, new FilterStringEquals(), value, false);
            ElementParameterFilter filter1 = new ElementParameterFilter(rule1, false);

            return
                (new FilteredElementCollector(doc))
                .WherePasses(filter1)
                .ToElements() as List<Element>;
        }

        //Create, assign variable to and traverse the tree correspondent to a specific MEPSystem
        public static List<CalculationResults> CalculateForAllPipes(MEPSystem targetSystem)
        {
            //loading necessary data first
            if (!dataIsExtracted)
                LoadAllData();
            TraversalTree tree = new TraversalTree(doc, targetSystem);
            tree.doc = doc;
            tree.allResults = new List<CalculationResults>();
            tree.Traverse();
            return tree.allResults;

        }

        public static FamilySymbol CreateNewPipeType(FamilySymbol oldType, string newTypeName, ElementId matId)
        {
            ElementType newElementType = oldType.Duplicate(newTypeName);
            FamilySymbol sym = newElementType as FamilySymbol;


            /*Element material_glass = Util.FindElementByName(
              sym.Document, typeof(Material), "Glass");*/


            sym.get_Parameter(BuiltInParameter.MATERIAL_ID_PARAM).Set(matId);

            return sym;
        }

        //load all pipe types types related to BIMIT from document 
        public static void LoadBimitPipeTypes()
        {
            pipeTypes = new List<PipeType>();
            var lookup = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves)
                .OfClass(typeof(PipeType)).ToList<Element>();
            foreach(Element e in lookup)
            {
                if (e.Name.Contains("BIMIT"))
                    pipeTypes.Add((PipeType)e);
            }
        }

        #endregion

        #region calculations methods
        //Calculations methods
        //Calculer le débit totale
        public static double CalculateTotalFlow(List<Element> fixtures, out int numberOfFixtures)
        {
            double sum = 0;
            numberOfFixtures = 0;
            List<Element> temp = new List<Element>();
            foreach(KeyValuePair<string,double> fixtureFlow in fixturesFlow)
            {
                temp = fixtures.FindAll(e => { return e.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains(fixtureFlow.Key); });
                sum += fixtureFlow.Value * temp.Count;
                numberOfFixtures += temp.Count();
            }

            return sum;
        }

        //Calculer le diameter en mm à partir de section
        public static double GetDiameterFromSection(double section) => (Math.Sqrt((4 * section) / PI) * 1000);
        

        //calculer la section en m*m à partir de vitesse
        public static double CalculateSection(double flow)
        {
            try
            {
                return (flow * 0.001) / speed;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        //Calculer la vitesse à partir de section
        //section in mm2
        //flow in l/s
        public static double CalculateSpeed(double section, double flow) => (flow * 0.001) / (section * Math.Pow(10, -6));

        //Calculer la coeffecient de simultanité pour un nombre des appareils superieur à 5
        public static double CalculateCoeffecient(int numberOfFixtures)
        {
            return (0.8 / Math.Sqrt(numberOfFixtures - 1));
        }

        //Calculer la coeffecient de simultanité pour un nombre des appareils inferieur à 5
        public static double CalculateCoeffecient(List<Element> fixtures)
        {
            double sum = 0;
            List<Element> temp = new List<Element>();
            foreach (KeyValuePair<string, double> fixtureCoeff in fixturesCoeff)
            {
                temp = fixtures.FindAll(e => { return e.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains(fixtureCoeff.Key); });
                sum += fixtureCoeff.Value * temp.Count;
            }

            return sum;
        }

        //map the value of a float from range R1 to another R2
        public static double Map(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        //return the minumum diameter from the calculated coeffecient, this is used only if the number of fixtures is less than 5
        public static double GetMinimumDiameterFromCoeff(double coeff)
        {
            int sup = (int)Math.Ceiling(coeff);
            int inf = (int)Math.Floor(coeff);
            if (sup == inf)
                return minimumDiameters[sup];

            return Map(coeff, inf, sup, minimumDiameters[inf], minimumDiameters[sup]);
        }


        //Calculate everything
        public static CalculationResults Calculate(List<Element> fixtures)
        {
            CalculationResults r = new CalculationResults();
            r.fixtures = fixtures;
            r.totalFlow = Utilities.CalculateTotalFlow(fixtures, out r.numberOfFixtures);
            if(r.numberOfFixtures > 5)
            {
                r.coeffecient = Utilities.CalculateCoeffecient(r.numberOfFixtures);
                r.possibleflow = r.totalFlow * r.coeffecient;
                r.section = Utilities.CalculateSection(r.possibleflow);
                r.diameter = Utilities.GetDiameterFromSection(r.section);
            }
            else
            {
                r.coeffecient = Utilities.CalculateCoeffecient(fixtures);
                r.diameter = Utilities.GetMinimumDiameterFromCoeff(r.coeffecient);
            }
           
            return r;
        }

        //Find the commercial diameter 
        public static Values FindCommercialDiameter(string material, double calculatedDiameter)
        {

            List<Values> valuesList = materials[material];
            foreach(Values value in valuesList)
            {
                if (value.intd >= calculatedDiameter)
                    return value;
            }
            Values failValue = new Values();
            failValue.intd = -1;
            return failValue;
        }

        #endregion

        #region winForms methods
        public static bool AssignElementsToListBox(Winforms.ListBox listBox, List<Element> elements)
        {
            try
            {
                foreach (Element element in elements)
                {
                    listBox.Items.Add(element.Name);
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AssignElementsToComboBox(Winforms.ComboBox comboBox, List<string> elements)
        {
            try
            {
                foreach (string element in elements)
                {
                    comboBox.Items.Add(element);
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion 
    }
}
