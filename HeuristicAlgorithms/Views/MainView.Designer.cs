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
            this.tabsControl = new System.Windows.Forms.TabControl();
            this.regularTabPage = new System.Windows.Forms.TabPage();
            this.ihcpTabPage = new System.Windows.Forms.TabPage();
            this.saAlgorithmParameters1 = new HeuristicAlgorithms.Views.SAAlgorithmParameters();
            this.saAlgorithmParameters2 = new HeuristicAlgorithms.Views.SAAlgorithmParameters();
            this.tabsControl.SuspendLayout();
            this.regularTabPage.SuspendLayout();
            this.ihcpTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsControl
            // 
            this.tabsControl.Controls.Add(this.regularTabPage);
            this.tabsControl.Controls.Add(this.ihcpTabPage);
            this.tabsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabsControl.ItemSize = new System.Drawing.Size(398, 34);
            this.tabsControl.Location = new System.Drawing.Point(0, 0);
            this.tabsControl.Name = "tabsControl";
            this.tabsControl.SelectedIndex = 0;
            this.tabsControl.Size = new System.Drawing.Size(800, 450);
            this.tabsControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabsControl.TabIndex = 1;
            // 
            // regularTabPage
            // 
            this.regularTabPage.Controls.Add(this.saAlgorithmParameters1);
            this.regularTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.regularTabPage.Location = new System.Drawing.Point(4, 38);
            this.regularTabPage.Name = "regularTabPage";
            this.regularTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.regularTabPage.Size = new System.Drawing.Size(792, 408);
            this.regularTabPage.TabIndex = 0;
            this.regularTabPage.Text = "REGULAR";
            this.regularTabPage.UseVisualStyleBackColor = true;
            // 
            // ihcpTabPage
            // 
            this.ihcpTabPage.Controls.Add(this.saAlgorithmParameters2);
            this.ihcpTabPage.Location = new System.Drawing.Point(4, 38);
            this.ihcpTabPage.Name = "ihcpTabPage";
            this.ihcpTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ihcpTabPage.Size = new System.Drawing.Size(792, 408);
            this.ihcpTabPage.TabIndex = 1;
            this.ihcpTabPage.Text = "IHCP";
            this.ihcpTabPage.UseVisualStyleBackColor = true;
            // 
            // saAlgorithmParameters1
            // 
            this.saAlgorithmParameters1.Location = new System.Drawing.Point(-4, 0);
            this.saAlgorithmParameters1.Name = "saAlgorithmParameters1";
            this.saAlgorithmParameters1.Size = new System.Drawing.Size(415, 236);
            this.saAlgorithmParameters1.TabIndex = 0;
            // 
            // saAlgorithmParameters2
            // 
            this.saAlgorithmParameters2.Location = new System.Drawing.Point(-4, 0);
            this.saAlgorithmParameters2.Name = "saAlgorithmParameters2";
            this.saAlgorithmParameters2.Size = new System.Drawing.Size(415, 236);
            this.saAlgorithmParameters2.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabsControl);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(300, 140);
            this.Name = "MainView";
            this.Text = "MainView";
            this.Resize += new System.EventHandler(this.MainView_Resize);
            this.tabsControl.ResumeLayout(false);
            this.regularTabPage.ResumeLayout(false);
            this.ihcpTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabsControl;
        private System.Windows.Forms.TabPage regularTabPage;
        private System.Windows.Forms.TabPage ihcpTabPage;
        private Views.SAAlgorithmParameters saAlgorithmParameters1;
        private Views.SAAlgorithmParameters saAlgorithmParameters2;
    }
}