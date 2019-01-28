namespace HeuristicAlgorithms
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcessHandler = new HeuristicAlgorithms.Views.CustomControls.ProcessHandler();
            this.ProblemControl = new HeuristicAlgorithms.Views.CustomControls.ProblemControl();
            this.SaAlgorithmParameters = new HeuristicAlgorithms.Views.SAAlgorithmParameters();
            this.SuspendLayout();
            // 
            // ProcessHandler
            // 
            this.ProcessHandler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProcessHandler.Location = new System.Drawing.Point(16, 275);
            this.ProcessHandler.Margin = new System.Windows.Forms.Padding(7);
            this.ProcessHandler.Name = "ProcessHandler";
            this.ProcessHandler.Size = new System.Drawing.Size(379, 301);
            this.ProcessHandler.TabIndex = 2;
            // 
            // ProblemControl
            // 
            this.ProblemControl.Location = new System.Drawing.Point(12, 228);
            this.ProblemControl.Name = "ProblemControl";
            this.ProblemControl.Size = new System.Drawing.Size(383, 37);
            this.ProblemControl.TabIndex = 1;
            // 
            // SaAlgorithmParameters
            // 
            this.SaAlgorithmParameters.BeginingTemperatureValue = 0.5D;
            this.SaAlgorithmParameters.CoolingValue = 0.99D;
            this.SaAlgorithmParameters.EndingTemperatureValue = 0.01D;
            this.SaAlgorithmParameters.IterationsValue = 1;
            this.SaAlgorithmParameters.Location = new System.Drawing.Point(12, 12);
            this.SaAlgorithmParameters.Name = "SaAlgorithmParameters";
            this.SaAlgorithmParameters.SatisfactionSolutionValue = "";
            this.SaAlgorithmParameters.Size = new System.Drawing.Size(383, 210);
            this.SaAlgorithmParameters.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(411, 583);
            this.Controls.Add(this.ProcessHandler);
            this.Controls.Add(this.ProblemControl);
            this.Controls.Add(this.SaAlgorithmParameters);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 140);
            this.Name = "MainView";
            this.Text = "Simulated Annealing Program";
            this.Resize += new System.EventHandler(this.MainView_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.SAAlgorithmParameters SaAlgorithmParameters;
        private Views.CustomControls.ProblemControl ProblemControl;
        private Views.CustomControls.ProcessHandler ProcessHandler;
    }
}