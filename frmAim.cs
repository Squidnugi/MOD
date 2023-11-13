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
        SqlConnection con = new SqlConnection("Data Source");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        List<int> lst_secs = new List<int>() { };
        int xmin = 12;
        int ymin = 66;
        int count = 10;
        int xdif = 155;
        int ydif = 146;
        int pstscore = 0;
        bool done = false;
        string user = frmLogin.loggeduser.ToString();
        public frmAim()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (count <= 0 && done == false)
            {
                
                stopwatch.Stop();
                label1.Text = "Count: " + count;
                lst_secs.Add((int)stopwatch.ElapsedMilliseconds);
                int average = (int)lst_secs.Average();
                label1.Text = "Score: "+average.ToString();
                done = true;
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
                            int stscor = dr.GetInt32(4);
                            if (stscor < average)
                            {
                                higher = false;
                            }
                        }
                    }
                }
                con.Close();
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

        private void frmAim_Load(object sender, EventArgs e)
        {
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

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            
            int randx = random.Next(xmin, width - xdif);
            int randy = random.Next(ymin, height - ydif);
            Target.Location = new Point(randx, randy);
            label1.Text = "Count: " + count;
            count--;
            stopwatch.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }
    }
}
