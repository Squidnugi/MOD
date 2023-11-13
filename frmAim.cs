using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp6
{
    public partial class frmAim : Form
    {
        //sql connections
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\henry\\Source\\Repos\\Squidnugi\\MOD\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        //class wide values
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        List<int> lst_secs = new List<int>() { };
        int xmin = 12;
        int ymin = 66;
        int count = 10;
        int xdif = 155;
        int ydif = 146;
        bool done = false;
        string user = frmLogin.loggeduser.ToString();
        public frmAim()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //checks if count is zero and if this section has already been ran before
            if (count <= 0 && done == false)
            {
                
                stopwatch.Stop();
                label1.Text = "Count: " + count;
                //adds stopwatch time to list
                lst_secs.Add((int)stopwatch.ElapsedMilliseconds);
                //get's the avrage number from the number within the list
                int average = (int)lst_secs.Average();
                label1.Text = "Score: "+average.ToString();
                done = true;
                //get's information from database
                bool higher = true;
                string queryString = "SELECT * FROM tbl_users WHERE username = @user";
                cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@user", user);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(4))
                        {
                            //checks if the new score is better than current high score
                            int stscor = dr.GetInt32(4);
                            if (stscor < average)
                            {
                                higher = false;
                            }
                        }
                    }
                }
                con.Close();
                //uptates if new score is better that high score
                if (higher)
                {
                    string score = "UPDATE tbl_users SET AimScore=@time WHERE username = @user";
                    cmd = new SqlCommand(score, con);
                    cmd.Parameters.AddWithValue("@time", average);
                    cmd.Parameters.AddWithValue("@user", user);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            //adds timer to the list of times, updates count, and changes target to a random location
            else if (done == false)
            {
                stopwatch.Stop();
                lst_secs.Add((int)stopwatch.ElapsedMilliseconds);
                int width = this.ClientSize.Width;
                int height = this.ClientSize.Height;
                int randx = random.Next(xmin, width-xdif);
                int randy = random.Next(ymin, height-ydif);
                Target.Location = new Point(randx, randy);
                label1.Text = "Count: " + count;
                count--;
                stopwatch.Restart();
                stopwatch.Start();
            }
        }
        //activates when page opens
        private void frmAim_Load(object sender, EventArgs e)
        {
            //get's information from database
            string queryString = "SELECT * FROM tbl_users WHERE username = @user";
            cmd = new SqlCommand(queryString, con);
            cmd.Parameters.AddWithValue("@user", user);
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    label2.Text = "Current high score: " + dr[4].ToString();
                }
            }

            con.Close();
            //set's random location to be inside of the form
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            //creates random location
            int randx = random.Next(xmin, width - xdif);
            int randy = random.Next(ymin, height - ydif);
            //set's target to random location, starts the count, and starts the stopwatch
            Target.Location = new Point(randx, randy);
            label1.Text = "Count: " + count;
            count--;
            stopwatch.Start();
        }
        //takes user to menu if home button is clicked
        private void btnHome_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }
    }
}
