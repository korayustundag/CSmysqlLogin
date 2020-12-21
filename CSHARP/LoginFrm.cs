using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CSmysqlLogin
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Clear();
                MessageBox.Show("Please enter username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Clear();
                MessageBox.Show("Please enter your password.");
                return;
            }
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.ConnectionString);
                MySqlDataReader dr;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT id, username, password FROM users WHERE username = @uname";
                cmd.Parameters.AddWithValue("@uname", txtUsername.Text);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Settings.SHA256Hash(txtPassword.Text) == dr.GetString(2))
                    {
                        Settings.logined = true;
                        Settings.id = dr.GetInt32(0);
                        Settings.username = dr.GetString(1);
                        conn.Close();
                        UserControlPanelFrm ucp = new UserControlPanelFrm();
                        ucp.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("The password you entered was not valid.");
                        txtPassword.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("No account found with that username.");
                    Clear();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = Settings.ConnectionString;
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Database Connection Error");
                Close();
            }
            */
        }
    }
}
