using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    public partial class DeleteUserAccountConfirmation_ : Form
    {
        public static bool shouldClose = true;

        public DeleteUserAccountConfirmation_()
        {
            InitializeComponent();
            txtConfirmPassword.Properties.PasswordChar = '*';

        }

        private void cancelButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton2_MouseEnter(object sender, EventArgs e)
        {
            cancelButton2.BackgroundImage = Properties.Resources.icons8_close_window_24_Hover;
        }

        private void cancelButton2_MouseLeave(object sender, EventArgs e)
        {
            cancelButton2.BackgroundImage = Properties.Resources.icons8_close_window_24;
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            if (formMainAdmin.mainForm == null) { return; }
            formMainAdmin.mainForm.FunctionSummoner(9, "", "", "", "", txtConfirmPassword.Text.Trim());
        }
        private void DeleteUserAccountConfirmation__Deactivate(object sender, EventArgs e)
        {
            if (!shouldClose) { shouldClose = true; return; }
            this.Close();
        }
    }
}
