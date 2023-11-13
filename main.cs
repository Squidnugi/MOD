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

        private void main_Load(object sender, EventArgs e)
        {
            label1.Text = frmLogin.loggeduser.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmReaction().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAim_Click(object sender, EventArgs e)
        {
            new frmAim().Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin.loggeduser = "";
            new frmLogin().Show();
            this.Hide();
        }

    }
}
