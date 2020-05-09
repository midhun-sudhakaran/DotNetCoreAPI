using Calc.Base;
using Calc.Business;
using System;
using System.Windows.Forms;

namespace Calc.Vehicle
{
    public partial class frmVehicleList : Form
    {
        public frmVehicleList()
        {
            InitializeComponent();
        }

        private void frmVehicleList_Load(object sender, EventArgs e)
        {
            Authentication obj = new Authentication();
            var list = obj.GetUserInfos();
            dgvVehicleList.DataSource = list;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Close the window ?", "Warning", MessageBoxButtons.OK);
            if (dr == DialogResult.OK)
            {
                Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
