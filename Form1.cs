using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        //sql connections
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\henry\\Source\\Repos\\Squidnugi\\MOD\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        //registers the user if fields are correct
        private void button1_Click(object sender, EventArgs e)
        {
            //checks if the fields are empty
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //checks if password and confirm password are the same
            else if (txtPassword.Text == txtComPassword.Text)
            {
                string user = txtUsername.Text;
                string pass = txtPassword.Text;
                con.Open();
                //get's information from database
                string check = "SELECT * FROM tbl_users WHERE username = '"+user+"'";
                cmd = new SqlCommand(check, con);
                SqlDataReader dr = cmd.ExecuteReader();
                bool match = false;
                //checks if username already exits
                if(dr.Read() == true)
                {
                    match = true;
                }
                con.Close();
                //gives error box and clears fields if username already exits
                if (match)
                {
                    MessageBox.Show("Username exists, please use a different one", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtComPassword.Text = "";
                    txtPassword.Focus();
                }
                else
                {
                    //checks if the user is using the correct email domain
                    if (user.Contains("@mod.co.uk"))
                    {
                        //inputs user data into database
                        string register = "INSERT INTO tbl_users (username, password) VALUES (@val1, @val2)";
                        cmd = new SqlCommand(register, con);
                        cmd.Parameters.AddWithValue("@val1", user);
                        cmd.Parameters.AddWithValue("@val2", pass);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtComPassword.Text = "";

                        MessageBox.Show("Your Account has been Successfully Created", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //gives error box and clears fields if username already exits
                    else
                    {
                        MessageBox.Show("username does does not contain the correct email domain, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtComPassword.Text = "";
                        txtPassword.Focus();
                    }
                }
                

            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
