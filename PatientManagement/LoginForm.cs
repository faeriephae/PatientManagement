using Microsoft.VisualBasic;
using PatientManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPassword.Text.Length == 0 || tbUsername.Text.Length == 0)
                {
                    MessageBox.Show("Fill out all the boxes.");
                }
                else
                {
                    LoginDto user = new() { Username = tbUsername.Text, Password = tbPassword.Text };
                    if (LoginAccessLayer.Login(user)) this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch(Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }
    }
}
