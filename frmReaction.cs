using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp6
{
    public partial class frmReaction : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        Timer timer = new Timer();
        bool pressed = false;
        string user = frmLogin.loggeduser.ToString();


        public frmReaction()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\henry\\Source\\Repos\\Squidnugi\\WindowsFormsApp6\\db_mod.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        private void frmTimer_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM tbl_users WHERE username = @user";
            cmd = new SqlCommand(queryString, con);
            cmd.Parameters.AddWithValue("@user", user);
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader()) 
            {
                while (dr.Read())
                {
                    label2.Text = "Current high score: " + dr[3].ToString();
                }
            }
            
            con.Close();
            Random random = new Random();
            int min = 2000;
            int max = 4000;
            int randomNumber = random.Next(min, max + 1);
            timer.Interval = randomNumber;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            
            label1.Text = "Click";
            btnReact.BackColor = Color.Green;
            timer.Stop();
            stopwatch.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReact_Click(object sender, EventArgs e)
        {
            if (btnReact.BackColor == Color.Brown)
            {
                MessageBox.Show("Too Fast", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new frmReaction().Show();
                this.Hide();
            }
            else if (btnReact.BackColor == Color.Green && pressed == false)
            {
                stopwatch.Stop();
                string time = stopwatch.ElapsedMilliseconds.ToString();
                label1.Text = "Well done";
                lblTime.Text = time;
                pressed = true;
                bool higher = true;
                string queryString = "SELECT * FROM tbl_users WHERE username = @user";
                cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@user", user);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if ((int)dr[3] < Int32.Parse(time))
                        {
                            higher = false;
                        }
                    }
                }
                con.Close();
                if (higher)
                {
                    string score = "UPDATE tbl_users SET ReactScore=@time WHERE username = @user";
                    cmd = new SqlCommand(score, con);
                    cmd.Parameters.AddWithValue("@time", Int32.Parse(time));
                    cmd.Parameters.AddWithValue("@user", user);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }
    }
}
