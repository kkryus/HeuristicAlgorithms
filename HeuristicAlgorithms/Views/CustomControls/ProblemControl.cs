using System;
using System.Windows.Forms;
using HeuristicAlgorithms.Models.CustomControlUtilitiesClasses;
using HeuristicAlgorithms.Utilities;

namespace HeuristicAlgorithms.Views.CustomControls
{
    public partial class ProblemControl : UserControl
    {
        public event Action<Problem> ProblemChanged;
        public Problem SelectedProblem { get; private set; }
        public int Dimensions { get; private set; }

        public ViewErrorController ErrorController { get; set; }

        public ProblemControl()
        {
            InitializeComponent();

            ProblemDropDownList.DataSource = ProblemHandler.Instance.Problems;
            ProblemDropDownList.ValueMember = "ProblemName";
            ErrorController = new ViewErrorController(errorProvider);
        }

        public Problem GetProblem()
        {
            return new Problem(SelectedProblem.ProblemName, false, Dimensions, null);
        }

        private void ProblemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProblem = (sender as ComboBox).SelectedItem as Problem;
            DimensionsLabel.Enabled = SelectedProblem.HasDimensions;
            DimensionsInputTextBox.Enabled = SelectedProblem.HasDimensions;
            DimensionsInputTextBox.Value = SelectedProblem.DefaultDimensions;
            ProblemChanged?.Invoke(SelectedProblem);
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
            ProblemChanged?.Invoke(ProblemHandler.Instance.GetSuggestedProblemWithParameters(SelectedProblem.ProblemName, Dimensions));
        }
    }
}
