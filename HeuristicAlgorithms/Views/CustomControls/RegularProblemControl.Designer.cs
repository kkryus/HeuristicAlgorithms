namespace HeuristicAlgorithms.Views.CustomControls
{
    partial class RegularProblemControl
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
            this.ProblemLabel = new System.Windows.Forms.Label();
            this.ProblemDropDownList = new System.Windows.Forms.ComboBox();
            this.DimensionsLabel = new System.Windows.Forms.Label();
            this.DimensionsInputTextBox = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DimensionsInputTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ProblemLabel
            // 
            this.ProblemLabel.AutoSize = true;
            this.ProblemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ProblemLabel.Location = new System.Drawing.Point(3, 5);
            this.ProblemLabel.Name = "ProblemLabel";
            this.ProblemLabel.Size = new System.Drawing.Size(67, 20);
            this.ProblemLabel.TabIndex = 0;
            this.ProblemLabel.Text = "Problem";
            // 
            // ProblemDropDownList
            // 
            this.ProblemDropDownList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ProblemDropDownList.FormattingEnabled = true;
            this.ProblemDropDownList.Location = new System.Drawing.Point(78, 2);
            this.ProblemDropDownList.Name = "ProblemDropDownList";
            this.ProblemDropDownList.Size = new System.Drawing.Size(123, 28);
            this.ProblemDropDownList.TabIndex = 1;
            this.ProblemDropDownList.SelectedIndexChanged += new System.EventHandler(this.ProblemDropDownList_SelectedIndexChanged);
            // 
            // DimensionsLabel
            // 
            this.DimensionsLabel.AutoSize = true;
            this.DimensionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DimensionsLabel.Location = new System.Drawing.Point(209, 5);
            this.DimensionsLabel.Name = "DimensionsLabel";
            this.DimensionsLabel.Size = new System.Drawing.Size(92, 20);
            this.DimensionsLabel.TabIndex = 2;
            this.DimensionsLabel.Text = "Dimensions";
            // 
            // DimensionsInputTextBox
            // 
            this.DimensionsInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DimensionsInputTextBox.Location = new System.Drawing.Point(309, 3);
            this.DimensionsInputTextBox.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.DimensionsInputTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DimensionsInputTextBox.Name = "DimensionsInputTextBox";
            this.DimensionsInputTextBox.Size = new System.Drawing.Size(51, 26);
            this.DimensionsInputTextBox.TabIndex = 3;
            this.DimensionsInputTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DimensionsInputTextBox.ValueChanged += new System.EventHandler(this.DimensionsInputTextBox_ValueChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RegularProblemControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.DimensionsInputTextBox);
            this.Controls.Add(this.DimensionsLabel);
            this.Controls.Add(this.ProblemDropDownList);
            this.Controls.Add(this.ProblemLabel);
            this.Name = "RegularProblemControl";
            this.Size = new System.Drawing.Size(375, 37);
            ((System.ComponentModel.ISupportInitialize)(this.DimensionsInputTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProblemLabel;
        private System.Windows.Forms.ComboBox ProblemDropDownList;
        private System.Windows.Forms.Label DimensionsLabel;
        private System.Windows.Forms.NumericUpDown DimensionsInputTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
