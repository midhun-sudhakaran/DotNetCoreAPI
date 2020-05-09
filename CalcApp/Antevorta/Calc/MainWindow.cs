using Calc.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close the application ?", "Close", MessageBoxButtons.OKCancel);
            if(dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleList obj = new frmVehicleList();
            obj.ShowDialog();
        }

        private void addVendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
