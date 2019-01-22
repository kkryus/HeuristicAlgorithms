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

        #region Events

        private void BeginingTemperatureInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            double value = (double)(sender as NumericUpDown).Value;
            beginingTemperatureValue = value;
            ValidateTemperature();
        }

        private void EndingTemperatureInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            double value = (double)(sender as NumericUpDown).Value;
            endingTemperatureValue = value;
            ValidateTemperature();
        }

        private void CoolingInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            double value = (double)(sender as NumericUpDown).Value;
            coolingValue = value;
            ValidateCooling();
        }

        private void IterationsInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)(sender as NumericUpDown).Value;
            iterationsValue = value;
            ValidateIterations();
        }

        private void SatisfactionSolutionValueInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            double value = (double)(sender as NumericUpDown).Value;
            satisfactionSolutionValue = value;
            ValidateSatisfactionSolutionValue();
        }
        #endregion


        #region Private Methods
        /// <summary>
        /// Writes all input values to private fields
        /// </summary>
        private void ReadAllInputs()
        {
            beginingTemperatureValue = (double)BeginingTemperatureInputTextBox.Value;
            endingTemperatureValue = (double)EndingTemperatureInputTextBox.Value;
            coolingValue = (double)CoolingInputTextBox.Value;
            iterationsValue = (int)IterationsInputTextBox.Value;
            satisfactionSolutionValue = (double)SatisfactionSolutionValueInputTextBox.Value;
        }

        /// <summary>
        /// Sets or clears errors depending on parameter to temperature text boxes
        /// </summary>
        /// <param name="shouldSet">Whether set or clear errors</param>
        private void SetTemperaturesError(bool shouldSet)
        {
            if (shouldSet)
            {
                ErrorController.SetError(BeginingTemperatureInputTextBox, Resources.BeginingLowerThanEndingTemperature);
                ErrorController.SetError(EndingTemperatureInputTextBox, Resources.BeginingLowerThanEndingTemperature);
            }
            else
            {
                ErrorController.ClearError(BeginingTemperatureInputTextBox);
                ErrorController.ClearError(EndingTemperatureInputTextBox);
            }
        }

        #region Validators

        /// <summary>
        /// Validates begining and ending temperatures.
        /// </summary>
        private void ValidateTemperature()
        {
            SetTemperaturesError(endingTemperatureValue >= beginingTemperatureValue);
            if (beginingTemperatureValue <= 0)
            {
                ErrorController.SetError(BeginingTemperatureInputTextBox, Resources.TooLowTemperature);
            }
            if (endingTemperatureValue <= 0)
            {
                ErrorController.SetError(EndingTemperatureInputTextBox, Resources.TooLowTemperature);
            }          
        }

        /// <summary>
        /// Validates cooling factor.
        /// </summary>
        private void ValidateCooling()
        {
            if (coolingValue <= 0)
            {
                ErrorController.SetError(CoolingInputTextBox, Resources.TooLowCooling);
            }
            else if (coolingValue >= 1)
            {
                ErrorController.SetError(CoolingInputTextBox, Resources.TooHighCooling);
            }
        }

        /// <summary>
        /// Validates iterations.
        /// </summary>
        private void ValidateIterations()
        {
            if (iterationsValue <= 0)
            {
                ErrorController.SetError(IterationsInputTextBox, Resources.TooFewIterations);
            }
            else if (iterationsValue >= 1000000)
            {
                ErrorController.SetError(IterationsInputTextBox, Resources.TooMuchIterations);
            }
        }
        
        /// <summary>
        /// Validates satisfaction solution value
        /// </summary>
        private void ValidateSatisfactionSolutionValue()
        {
            if (satisfactionSolutionValue < 0)
            {
                ErrorController.SetError(SatisfactionSolutionValueInputTextBox, Resources.BeginingLowerThanEndingTemperature);
            }
            else if (satisfactionSolutionValue > 10000)
            {
                ErrorController.SetError(SatisfactionSolutionValueInputTextBox, Resources.BeginingLowerThanEndingTemperature);
            }
        }

        #endregion
        
        #endregion
    }
}
