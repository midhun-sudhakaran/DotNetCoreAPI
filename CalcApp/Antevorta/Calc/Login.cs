using Cacl.Business.Model;
using Cacl.Business.Request;
using Calc.Business;
using Calc.Business.Interfaces;
using System;
using System.Windows.Forms;

namespace Calc
{
    /// <summary>
    /// Login Page
    /// </summary>
    public partial class Login : Form
    {
        #region Constructor
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GetLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        #endregion

        #region Private Methods
        void Cancel()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to cancel the applcation", "Cancel !!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        void GetLogin()
        {
            var user = GetUser(new UserRequest() { UserName = txtUsername.Text.Trim(), Password = txtPassword.Text });
            if(user != null)
            {
                MainWindow obj = new MainWindow();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User or Password incorrect !!", "Warning", MessageBoxButtons.OK);
            }
        }

        UserInfo GetUser(UserRequest userRequest)
        {
            IAuthentication authentication = new Authentication();
            return authentication.GetUserInfo(userRequest);
        }
        #endregion
    }
}
