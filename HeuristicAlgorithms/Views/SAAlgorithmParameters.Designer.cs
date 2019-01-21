namespace HeuristicAlgorithms.Views
{
    partial class SAAlgorithmParameters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.beginingTemperatureLabel = new System.Windows.Forms.Label();
            this.endingTemperatureLabel = new System.Windows.Forms.Label();
            this.coolingLabel = new System.Windows.Forms.Label();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.satisfactionSolutionValueLabel = new System.Windows.Forms.Label();
            this.BeginingTemperatureInputTextBox = new System.Windows.Forms.NumericUpDown();
            this.EndingTemperatureInputTextBox = new System.Windows.Forms.NumericUpDown();
            this.CoolingInputTextBox = new System.Windows.Forms.NumericUpDown();
            this.IterationsInputTextBox = new System.Windows.Forms.NumericUpDown();
            this.SatisfactionSolutionValueInputTextBox = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BeginingTemperatureInputTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndingTemperatureInputTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoolingInputTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationsInputTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SatisfactionSolutionValueInputTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.parametersLabel.Location = new System.Drawing.Point(3, 0);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(137, 29);
            this.parametersLabel.TabIndex = 0;
            this.parametersLabel.Text = "Parameters";
            // 
            // beginingTemperatureLabel
            // 
            this.beginingTemperatureLabel.AutoSize = true;
            this.beginingTemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.beginingTemperatureLabel.Location = new System.Drawing.Point(25, 53);
            this.beginingTemperatureLabel.Name = "beginingTemperatureLabel";
            this.beginingTemperatureLabel.Size = new System.Drawing.Size(166, 20);
            this.beginingTemperatureLabel.TabIndex = 1;
            this.beginingTemperatureLabel.Text = "Begining Temperature";
            // 
            // endingTemperatureLabel
            // 
            this.endingTemperatureLabel.AutoSize = true;
            this.endingTemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endingTemperatureLabel.Location = new System.Drawing.Point(25, 88);
            this.endingTemperatureLabel.Name = "endingTemperatureLabel";
            this.endingTemperatureLabel.Size = new System.Drawing.Size(154, 20);
            this.endingTemperatureLabel.TabIndex = 2;
            this.endingTemperatureLabel.Text = "Ending Temperature";
            // 
            // coolingLabel
            // 
            this.coolingLabel.AutoSize = true;
            this.coolingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.coolingLabel.Location = new System.Drawing.Point(25, 123);
            this.coolingLabel.Name = "coolingLabel";
            this.coolingLabel.Size = new System.Drawing.Size(62, 20);
            this.coolingLabel.TabIndex = 3;
            this.coolingLabel.Text = "Cooling";
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iterationsLabel.Location = new System.Drawing.Point(25, 158);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(76, 20);
            this.iterationsLabel.TabIndex = 4;
            this.iterationsLabel.Text = "Iterations";
            // 
            // satisfactionSolutionValueLabel
            // 
            this.satisfactionSolutionValueLabel.AutoSize = true;
            this.satisfactionSolutionValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.satisfactionSolutionValueLabel.Location = new System.Drawing.Point(25, 193);
            this.satisfactionSolutionValueLabel.Name = "satisfactionSolutionValueLabel";
            this.satisfactionSolutionValueLabel.Size = new System.Drawing.Size(200, 20);
            this.satisfactionSolutionValueLabel.TabIndex = 5;
            this.satisfactionSolutionValueLabel.Text = "Satisfaction Solution Value";
            // 
            // BeginingTemperatureInputTextBox
            // 
            this.BeginingTemperatureInputTextBox.DecimalPlaces = 5;
            this.BeginingTemperatureInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BeginingTemperatureInputTextBox.Location = new System.Drawing.Point(251, 47);
            this.BeginingTemperatureInputTextBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BeginingTemperatureInputTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.BeginingTemperatureInputTextBox.Name = "BeginingTemperatureInputTextBox";
            this.BeginingTemperatureInputTextBox.Size = new System.Drawing.Size(132, 26);
            this.BeginingTemperatureInputTextBox.TabIndex = 6;
            this.BeginingTemperatureInputTextBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            327680});
            this.BeginingTemperatureInputTextBox.ValueChanged += new System.EventHandler(this.BeginingTemperatureInputTextBox_ValueChanged);
            // 
            // EndingTemperatureInputTextBox
            // 
            this.EndingTemperatureInputTextBox.DecimalPlaces = 5;
            this.EndingTemperatureInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EndingTemperatureInputTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.EndingTemperatureInputTextBox.Location = new System.Drawing.Point(251, 83);
            this.EndingTemperatureInputTextBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EndingTemperatureInputTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.EndingTemperatureInputTextBox.Name = "EndingTemperatureInputTextBox";
            this.EndingTemperatureInputTextBox.Size = new System.Drawing.Size(132, 26);
            this.EndingTemperatureInputTextBox.TabIndex = 7;
            this.EndingTemperatureInputTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.EndingTemperatureInputTextBox.ValueChanged += new System.EventHandler(this.EndingTemperatureInputTextBox_ValueChanged);
            // 
            // CoolingInputTextBox
            // 
            this.CoolingInputTextBox.DecimalPlaces = 5;
            this.CoolingInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CoolingInputTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.CoolingInputTextBox.Location = new System.Drawing.Point(251, 119);
            this.CoolingInputTextBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            327680});
            this.CoolingInputTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.CoolingInputTextBox.Name = "CoolingInputTextBox";
            this.CoolingInputTextBox.Size = new System.Drawing.Size(132, 26);
            this.CoolingInputTextBox.TabIndex = 8;
            this.CoolingInputTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.CoolingInputTextBox.ValueChanged += new System.EventHandler(this.CoolingInputTextBox_ValueChanged);
            // 
            // IterationsInputTextBox
            // 
            this.IterationsInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IterationsInputTextBox.Location = new System.Drawing.Point(251, 155);
            this.IterationsInputTextBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.IterationsInputTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IterationsInputTextBox.Name = "IterationsInputTextBox";
            this.IterationsInputTextBox.Size = new System.Drawing.Size(132, 26);
            this.IterationsInputTextBox.TabIndex = 9;
            this.IterationsInputTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IterationsInputTextBox.ValueChanged += new System.EventHandler(this.IterationsInputTextBox_ValueChanged);
            // 
            // SatisfactionSolutionValueInputTextBox
            // 
            this.SatisfactionSolutionValueInputTextBox.DecimalPlaces = 5;
            this.SatisfactionSolutionValueInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SatisfactionSolutionValueInputTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.SatisfactionSolutionValueInputTextBox.Location = new System.Drawing.Point(251, 191);
            this.SatisfactionSolutionValueInputTextBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SatisfactionSolutionValueInputTextBox.Name = "SatisfactionSolutionValueInputTextBox";
            this.SatisfactionSolutionValueInputTextBox.Size = new System.Drawing.Size(132, 26);
            this.SatisfactionSolutionValueInputTextBox.TabIndex = 10;
            this.SatisfactionSolutionValueInputTextBox.ValueChanged += new System.EventHandler(this.SatisfactionSolutionValueInputTextBox_ValueChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SAAlgorithmParameters
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.SatisfactionSolutionValueInputTextBox);
            this.Controls.Add(this.IterationsInputTextBox);
            this.Controls.Add(this.CoolingInputTextBox);
            this.Controls.Add(this.EndingTemperatureInputTextBox);
            this.Controls.Add(this.BeginingTemperatureInputTextBox);
            this.Controls.Add(this.satisfactionSolutionValueLabel);
            this.Controls.Add(this.iterationsLabel);
            this.Controls.Add(this.coolingLabel);
            this.Controls.Add(this.endingTemperatureLabel);
            this.Controls.Add(this.beginingTemperatureLabel);
            this.Controls.Add(this.parametersLabel);
            this.Name = "SAAlgorithmParameters";
            this.Size = new System.Drawing.Size(415, 236);
            ((System.ComponentModel.ISupportInitialize)(this.BeginingTemperatureInputTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndingTemperatureInputTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoolingInputTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationsInputTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SatisfactionSolutionValueInputTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.Label beginingTemperatureLabel;
        private System.Windows.Forms.Label endingTemperatureLabel;
        private System.Windows.Forms.Label coolingLabel;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label satisfactionSolutionValueLabel;
        private System.Windows.Forms.NumericUpDown BeginingTemperatureInputTextBox;
        private System.Windows.Forms.NumericUpDown EndingTemperatureInputTextBox;
        private System.Windows.Forms.NumericUpDown CoolingInputTextBox;
        private System.Windows.Forms.NumericUpDown IterationsInputTextBox;
        private System.Windows.Forms.NumericUpDown SatisfactionSolutionValueInputTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
