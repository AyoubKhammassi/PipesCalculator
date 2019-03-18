#region
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Winforms = System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
#endregion

namespace PipesCalculator
{
    public partial class Displayer : Winforms.Form
    {
        //a list of all the systems as a list of elements
        public List<Element> allSystems;
        //List of all thje results
        public List<CalculationResults> allResults;
        public UIDocument uidoc;


        public Displayer(UIDocument doc,List<Element> sys)
        {
            InitializeComponent();
            allSystems = sys;
            uidoc = doc;
            Utilities.AssignElementsToComboBox(systems, sys.Select(e => e.Name).ToList());
            systems.DropDownStyle = ComboBoxStyle.DropDownList;
            systems.SelectedIndex = 0;
            apply.Enabled = false;
            export.Enabled = false;
            buttonsPanel.Hide();
        }

        //empty constructor
        public Displayer()
        {
            InitializeComponent();
        }

        private void ChoiceButton_Click(object sender, EventArgs e)
        {
            Element choice = allSystems.Where(f => f.Name == systems.SelectedItem.ToString()).ToArray()[0];
            MEPSystem chosenSystem = (MEPSystem)choice;
            allResults = Utilities.CalculateForAllPipes(chosenSystem, chosenSystem.Document);
            Hide();
            DisplayNamesAndIDs();
            buttonsPanel.Show();
            header.Hide();
            Show();
        }

        public void DisplayNamesAndIDs()
        {
            
            //getting the rowstyle of the first row
            RowStyle temp = table.RowStyles[table.RowCount - 1];
            table.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));

            foreach (CalculationResults result in allResults)
            {
                //increasing the number of rows
                table.RowCount++;
                table.Controls.Add(new Label() { Text = result.pipe.Name }, 0, table.RowCount - 1);
                Label id = new Label() { Text = result.pipe.Id.ToString() };
                id.Click += (sender, e) => { HighlightPipe(sender, e, id.Text); };
                table.Controls.Add(id , 1, table.RowCount - 1);
                Winforms.ComboBox materialsComboBox = new Winforms.ComboBox();
                Utilities.AssignElementsToComboBox(materialsComboBox, new List<string>(Utilities.materials.Keys));
                materialsComboBox.SelectedIndex = 0;
                table.Controls.Add(materialsComboBox, 7, table.RowCount - 1);
            }
        }

        public void HighlightPipe(Object sender, EventArgs e, string id)
        {
            ElementId eid = new ElementId(int.Parse(id));
            List<ElementId> selected = new List<ElementId>();
            selected.Add(eid);
            uidoc.ShowElements(eid);
            uidoc.Selection.SetElementIds(selected);
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            Hide();
            string specifier = "F";
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
            for (int i = 0; i < allResults.Count; i++)
            {
                string chosenMaterial = ((Winforms.ComboBox)table.GetControlFromPosition(7, i + 1)).SelectedItem.ToString();
                allResults[i].material = chosenMaterial;
                Values v = Utilities.FindCommercialDiameter(chosenMaterial, allResults[i].diameter);
                allResults[i].commercialInternalDiameter = v.intd;
                allResults[i].commercialExternalDiameter = v.extd;
                table.Controls.Add(new Label() { Text = allResults[i].totalFlow.ToString(specifier,culture) }, 2, i+1);
                table.Controls.Add(new Label() { Text = allResults[i].numberOfFixtures.ToString() }, 3, i+1);
                table.Controls.Add(new Label() { Text = allResults[i].coeffecient.ToString(specifier, culture) }, 4, i+1);
                table.Controls.Add(new Label() { Text = Utilities.speed.ToString() }, 5, i + 1);
                table.Controls.Add(new Label() { Text = allResults[i].diameter.ToString(specifier, culture) }, 6, i + 1);
                table.Controls.Add(new Label() { Text = allResults[i].commercialInternalDiameter.ToString() + "/" + allResults[i].commercialExternalDiameter.ToString() }, 8, i + 1);
            }
            apply.Enabled = true;
            Show();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            foreach(CalculationResults cr in allResults)
            {
                double nominalDiameter = (cr.commercialExternalDiameter + cr.commercialInternalDiameter) / 2;
                Utilities.SetPipeSize(cr.pipe, nominalDiameter, cr.commercialInternalDiameter, cr.commercialExternalDiameter, cr.material);
            }
            apply.Enabled = false;
        }

        private void export_Click(object sender, EventArgs e)
        {

        }
    }
}
