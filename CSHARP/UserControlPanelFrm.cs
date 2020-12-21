using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CSmysqlLogin
{
    public partial class UserControlPanelFrm : Form
    {
        public UserControlPanelFrm()
        {
            InitializeComponent();
        }

        private void UserControlPanelFrm_Load(object sender, EventArgs e)
        {
            if (!Settings.logined)
            {
                MessageBox.Show("Please login first.");
                Close();
            }
            lblWelcome.Text = "Hi, " + Settings.username + ". Welcome to your account.";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswd.Text))
            {
                MessageBox.Show("Please enter the new password.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPasswdConf.Text))
            {
                MessageBox.Show("Please confirm the password.");
                return;
            }
            if (txtPasswd.Text == txtPasswdConf.Text)
            {
                string newpasswd = Settings.SHA256Hash(txtPasswd.Text);
                MySqlConnection conn = new MySqlConnection(Settings.ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE users SET password = @newpass WHERE id = @uid";
                cmd.Parameters.AddWithValue("newpass", newpasswd);
                cmd.Parameters.AddWithValue("uid", Settings.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Settings.logined = false;
                Settings.username = string.Empty;
                Settings.id = 0;
                MessageBox.Show("Password reset is complete.");
                Close();
            }
            else
            {
                MessageBox.Show("Password did not match.");
                txtPasswd.Clear();
                txtPasswdConf.Clear();
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Settings.logined = false;
            Settings.username = string.Empty;
            Settings.id = 0;
            Close();
        }
    }
}
