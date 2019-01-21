using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeuristicAlgorithms
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Resize(object sender, EventArgs e)
        {
            this.tabsControl.ItemSize = new Size(this.tabsControl.Width / 2 - 2, this.tabsControl.ItemSize.Height);
        }
    }
}
