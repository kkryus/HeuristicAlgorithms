using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms.Views
{
    public partial class SAAlgorithmParameters : UserControl
    {
        #region Fields
        private double beginingTemperatureValue;
        private double endingTemperatureValue;
        private double coolingValue;
        private int iterationsValue;
        private double satisfactionSolutionValue;
        #endregion

        public ViewErrorController ErrorController { get; set; }

        public SAAlgorithmParameters()
        {           
            InitializeComponent();
            ErrorController = new ViewErrorController(errorProvider);
            ReadAllInputs();
        }

        private void BeginingTemperatureInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            double value = (double)(sender as NumericUpDown).Value;
            Console.WriteLine(value);
            if(value < endingTemperatureValue)
            {
                ErrorController.SetError(BeginingTemperatureInputTextBox, "oko");
            }
            else
            {
                ErrorController.ClearError(BeginingTemperatureInputTextBox);
            }
            beginingTemperatureValue = value;


        }

        private void EndingTemperatureInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            endingTemperatureValue = (double)(sender as NumericUpDown).Value;
            //ErrorController.SetError(BeginingTemperatureInputTextBox, "");
        }

        private void CoolingInputTextBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void IterationsInputTextBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SatisfactionSolutionValueInputTextBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ReadAllInputs()
        {
            beginingTemperatureValue = (double)BeginingTemperatureInputTextBox.Value;
            endingTemperatureValue = (double)EndingTemperatureInputTextBox.Value;
            coolingValue = (double)CoolingInputTextBox.Value;
            iterationsValue = (int)IterationsInputTextBox.Value;
            satisfactionSolutionValue = (double)SatisfactionSolutionValueInputTextBox.Value;
        }
    }
}
