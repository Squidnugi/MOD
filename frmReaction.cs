using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp6
{
    public partial class frmReaction : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        Timer timer = new Timer();
        bool pressed = false;

        public frmReaction()
        {
            InitializeComponent();
        }

        private void frmTimer_Load(object sender, EventArgs e)
        {
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
                label1.Text = "Well done";
                lblTime.Text = stopwatch.ElapsedMilliseconds.ToString();
                pressed = true;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }
    }
}
