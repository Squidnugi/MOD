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
using System.Net.Http.Headers;

namespace WindowsFormsApp6
{
    public partial class frmLogin : Form
    {
        //stores user login
        public static String loggeduser { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }
        //sql connections
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\henry\\Source\\Repos\\Squidnugi\\MOD\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();


        //changes the password character wheb check box is clicked
        private void CheckbxShowPas_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
        //takes user to the register page
        private void label6_Click_1(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
        //clears inputs
        private void button3_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }
        //logs the user in if information matches
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            //gets information from database
            string login = "SELECT * FROM tbl_users WHERE username = '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();
            //if values in the database this activates
            if (dr.Read() == true)
            {
                loggeduser=txtUsername.Text;
                new main().Show();
                this.Hide();
            }
            //if values not in database this activates
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
            con.Close();
        }
    }
}
