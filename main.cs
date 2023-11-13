using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        //when page loads set label1 to user's username
        private void main_Load(object sender, EventArgs e)
        {
            label1.Text = frmLogin.loggeduser.ToString();
        }
        //opens reacion test form and closes this form
        private void button1_Click(object sender, EventArgs e)
        {
            new frmReaction().Show();
            this.Hide();
        }
        //opens aim trainer form and closes this form
        private void btnAim_Click(object sender, EventArgs e)
        {
            new frmAim().Show();
            this.Hide();
        }
        //logs the user out, opens the login form, and closes this form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin.loggeduser = "";
            new frmLogin().Show();
            this.Hide();
        }

    }
}
