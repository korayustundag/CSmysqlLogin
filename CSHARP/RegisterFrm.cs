using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CSmysqlLogin
{
    public partial class RegisterFrm : Form
    {
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPasswdConfirm.Text))
            {
                MessageBox.Show("Please confirm password.");
                return;
            }
            if (txtPassword.Text != txtPasswdConfirm.Text)
            {
                MessageBox.Show("Password did not match.");
                return;
            }
            MySqlConnection conn = new MySqlConnection(Settings.ConnectionString);
            MySqlDataReader dr;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT id FROM users WHERE username = @uname";
            cmd.Parameters.AddWithValue("uname", txtUsername.Text);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("This username is already taken.");
                conn.Close();
            }
            else
            {
                conn.Close();
                MySqlConnection iconn = new MySqlConnection(Settings.ConnectionString);
                MySqlCommand icmd = new MySqlCommand();
                icmd.Connection = iconn;
                icmd.CommandText = "INSERT INTO users (username, password) VALUES (@uname, @upass)";
                icmd.Parameters.AddWithValue("uname",txtUsername.Text);
                icmd.Parameters.AddWithValue("upass",Settings.SHA256Hash(txtPassword.Text));
                iconn.Open();
                icmd.ExecuteNonQuery();
                iconn.Close();
                MessageBox.Show("The registration process has been completed successfully.");
                Close();
            }
        }
    }
}
