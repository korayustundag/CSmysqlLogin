using System;
using System.Windows.Forms;

namespace CSmysqlLogin
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginFrm loginFrm = new LoginFrm();
            loginFrm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterFrm registerFrm = new RegisterFrm();
            registerFrm.Show();
        }

        private void btnUserCP_Click(object sender, EventArgs e)
        {
            UserControlPanelFrm ucp = new UserControlPanelFrm();
            ucp.Show();
        }
    }
}
