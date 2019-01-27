using System;
using System.Windows.Forms;
using HeuristicAlgorithms.Utilities;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;
using System.Text.RegularExpressions;

namespace HeuristicAlgorithms.Views
{
    public partial class SAAlgorithmParameters : UserControl
    {
        #region Properties
        #region Parameters
        public double BeginingTemperatureValue
        {
            get
            {
                return (double)BeginingTemperatureInputTextBox.Value;
            }
            set
            {
                BeginingTemperatureInputTextBox.Value = (decimal)value;
            }
        }
        public double EndingTemperatureValue
        {
            get
            {
                return (double)EndingTemperatureInputTextBox.Value;
            }
            set
            {
                EndingTemperatureInputTextBox.Value = (decimal)value;
            }
        }
        public double CoolingValue
        {
            get
            {
                return (double)CoolingInputTextBox.Value;
            }
            set
            {
                CoolingInputTextBox.Value = (decimal)value;
            }
        }
        public int IterationsValue
        {
            get
            {
                return (int)IterationsInputTextBox.Value;
            }
            set
            {
                IterationsInputTextBox.Value = value;
            }
        }
        public string SatisfactionSolutionValue
        {
            get
            {
                return SatisfactionSolutionValueInputTextBox.Text;
            }
            set
            {
                SatisfactionSolutionValueInputTextBox.Text = value;
            }
        }
        #endregion

        public ViewErrorController ErrorController { get; set; }
        #endregion

        public SAAlgorithmParameters()
        {
            InitializeComponent();
            ErrorController = new ViewErrorController(errorProvider);
        }

        public bool SetParameters(SASolverParametersModel parameters)
        {
            BeginingTemperatureValue = parameters.BeginingTemperature;
            EndingTemperatureValue = parameters.EndingTemperature;
            IterationsValue = parameters.Iterations;
            CoolingValue = parameters.Cooling;
            return true;
        }

        public SASolverParametersModel GetParameters()
        {
            if(Double.TryParse(SatisfactionSolutionValue, out double satisfactionSolution))
            {
                return new SASolverParametersModel(BeginingTemperatureValue, EndingTemperatureValue, IterationsValue, CoolingValue, satisfactionSolution);
            }
            return new SASolverParametersModel(BeginingTemperatureValue, EndingTemperatureValue, IterationsValue, CoolingValue);
        }


        #region Events

        private void TemperatureInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            ValidateTemperatures();
        }

        private void SatisfactionSolutionValueInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            if (!(regex.Match("" + e.KeyChar).Success) && (e.KeyChar != ',') && (e.KeyChar != '-') && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ',' && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // only allow one minus
            if (e.KeyChar == '-' && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && SatisfactionSolutionValueInputTextBox.SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        private void SatisfactionSolutionValueInputTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateSatisfactionSolutionValue();
        }


        #endregion


        #region Private Methods

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
        private void ValidateTemperatures()
        {
            SetTemperaturesError(EndingTemperatureValue > BeginingTemperatureValue);
        }

        /// <summary>
        /// Validates satisfaction solution value
        /// </summary>
        private void ValidateSatisfactionSolutionValue()
        {
            try
            {
                Double.TryParse(SatisfactionSolutionValue, out double value);
                if (value > 10000000000000)
                {
                    ErrorController.SetError(SatisfactionSolutionValueInputTextBox, Resources.TooHighSatisfactionSolutionValue);
                }
                else if (value < -10000000000000)
                {
                    ErrorController.SetError(SatisfactionSolutionValueInputTextBox, Resources.TooLowSatisfactionSolutionValue);
                }
                else
                {
                    ErrorController.ClearError(SatisfactionSolutionValueInputTextBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to parse satisfaction solution value", "Information");
            }
        }

        #endregion

        #endregion

    }
}
