using System;
using System.Windows.Forms;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms.Views.CustomControls
{
    public partial class RegularProblemControl : UserControl
    {
        public RegularProblem SelectedProblem { get; private set; }
        public int Dimensions { get; private set; }

        public ViewErrorController ErrorController { get; set; }

        public RegularProblemControl()
        {
            InitializeComponent();

            ProblemDropDownList.DataSource = RegularProblemHandler.Instance.RegularProblems;
            ProblemDropDownList.ValueMember = "Problem";
            ErrorController = new ViewErrorController(errorProvider);
        }

        private void ProblemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProblem = (sender as ComboBox).SelectedItem as RegularProblem;
            DimensionsLabel.Enabled = SelectedProblem.HasDimensions;
            DimensionsInputTextBox.Enabled = SelectedProblem.HasDimensions;
            DimensionsInputTextBox.Value = SelectedProblem.DefaultDimensions;
        }

        private void DimensionsInputTextBox_ValueChanged(object sender, EventArgs e)
        {
            int dimensions = (int)(sender as NumericUpDown).Value;
            if(dimensions < 1)
            {
                ErrorController.SetError(DimensionsInputTextBox, Resources.TooFewDimensions);
            }
            else if(dimensions >= 20)
            {
                ErrorController.SetError(DimensionsInputTextBox, Resources.TooManyDimensions);
            }
            Dimensions = dimensions;
        }
    }
}
