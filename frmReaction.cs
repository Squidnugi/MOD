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
        //class wide veriables
        Stopwatch stopwatch = new Stopwatch();
        Timer timer = new Timer();
        bool pressed = false;
        string user = frmLogin.loggeduser.ToString();


        public frmReaction()
        {
            InitializeComponent();
        }
        //sql connections
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\henry\\Source\\Repos\\Squidnugi\\MOD\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        //activities when form loads
        private void frmTimer_Load(object sender, EventArgs e)
        {
            //gets the users current high score
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
            // sets a random value for the countdown timer and starts the timer
            Random random = new Random();
            int min = 2000;
            int max = 4000;
            int randomNumber = random.Next(min, max + 1);
            timer.Interval = randomNumber;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        //activates when timer is done
        private void timer_Tick(object sender, EventArgs e)
        {
            //changes label and button also starts the stopwatch
            label1.Text = "Click";
            btnReact.BackColor = Color.Green;
            timer.Stop();
            stopwatch.Start();
        }
        //activates when button is clicked
        private void btnReact_Click(object sender, EventArgs e)
        {
            //checks if the butt is green
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
                int numtime = Convert.ToInt32(time);
                label1.Text = "Well done";
                lblTime.Text = time;
                //value to stop pseudo loop
                pressed = true;
                //this part compares the current high score and changes if the new high score is better
                bool higher = true;
                string queryString = "SELECT * FROM tbl_users WHERE username = @user";
                cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@user", user);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(3))
                        {
                            int stscor = dr.GetInt32(3);
                            if (stscor < numtime)
                            {
                                higher = false;
                            }
                        }
                    }
                }
                con.Close();
                //only activates if score is changed
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
        //takes user back to the menu when the home button is clicked
        private void btnHome_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }
    }
}
