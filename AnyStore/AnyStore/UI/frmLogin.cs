using AnyStore.BLL;
using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtpassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();


            bool sucess = dal.LoginCheck(l);

            if (sucess == true)
            {
                MessageBox.Show("Login Successfull");
            }

            else
            {
                MessageBox.Show("Login Failed");
            }


        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
