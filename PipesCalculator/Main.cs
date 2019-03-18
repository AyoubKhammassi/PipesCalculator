#region
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Winforms = System.Windows.Forms;
#endregion

namespace PipesCalculator
{
    public partial class Main : System.Windows.Forms.Form
    {
        public CalculationResults currentResults;

        public Main(CalculationResults results)
        {
            InitializeComponent();
            currentResults = results;
            //setting the pipe name
            PipeName.Text = "Nom Du Tube Sélectionné: " + results.pipe.Name;
            //displaying the list of fixturs connected to the pipe
            Utilities.AssignElementsToListBox(listOfFixtures, results.fixtures);
            //assigning list of available materials to the materials combobox
            Utilities.AssignElementsToComboBox(MaterialsList ,new List<string>(Utilities.materials.Keys));
            //assigning the default value of the combobox
            MaterialsList.DropDownStyle = ComboBoxStyle.DropDownList;
            MaterialsList.SelectedIndex = 0;
            //disabling the apply button before doing the calculations
            Apply.Enabled = false;
        }

        public void DisplayCalculations(CalculationResults results)
        {
            layout.GetControlFromPosition(1, 0).Text = results.totalFlow.ToString();
            layout.GetControlFromPosition(1, 1).Text = results.numberOfFixtures.ToString();
            layout.GetControlFromPosition(1, 2).Text = results.coeffecient.ToString();
            layout.GetControlFromPosition(1, 3).Text = results.possibleflow.ToString();
            layout.GetControlFromPosition(1, 4).Text = Utilities.speed.ToString();
            layout.GetControlFromPosition(1, 5).Text = results.diameter.ToString();
            layout.GetControlFromPosition(1, 6).Text = MaterialsList.SelectedItem.ToString();
            layout.GetControlFromPosition(1, 7).Text = results.commercialInternalDiameter.ToString() + "/" + results.commercialExternalDiameter.ToString();
            layout.GetControlFromPosition(1, 8).Text = results.realSpeed.ToString();
        }
        /*public Main(Element element)
        {

            //creating the transaction that will handle all the changes
            this.element = element;
            PipeName.Text = element.ToString();
            parameters = element.Parameters.Cast<Parameter>().ToList<Parameter>();
            foreach (Parameter param in parameters)
            {
                if (!param.IsReadOnly)
                    listOfFixtures.Items.Add(param.Definition.Name);
            }

            InitializeComponent();
        }*/

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void PipeName_Click(object sender, EventArgs e)
        {

        }

        private void PipeParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string name = listOfFixtures.SelectedItem.ToString();
            parameter = parameters.Find(para => para.Definition.Name == name);*/


            /*ParameterName.Text = name;
            ParameterValue.Text = parameter.AsValueString();*/
        }



        //Utilities Methods
        public bool AssignElementsToListBox(ListBox listBox, List<Element> elements)
        {
            try
            {
                foreach(Element element in elements)
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

        public bool AssignElementsToComboBox(Winforms.ComboBox comboBox, List<string> elements)
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Values v = Utilities.FindCommercialDiameter(MaterialsList.SelectedItem.ToString(), currentResults.diameter);
            currentResults.commercialInternalDiameter = v.intd;
            currentResults.commercialExternalDiameter = v.extd;
            currentResults.realSpeed = Utilities.CalculateSpeed(v.section, currentResults.possibleflow);
            DisplayCalculations(currentResults);
            Apply.Enabled = true;
        }

        private void Apply_Click(object sender, EventArgs e)
        {

            double nominalDiameter = (currentResults.commercialExternalDiameter + currentResults.commercialInternalDiameter) / 2;
            Utilities.SetPipeSize(currentResults.pipe, nominalDiameter, currentResults.commercialInternalDiameter, currentResults.commercialExternalDiameter, MaterialsList.SelectedItem.ToString());
        }
    }
}
