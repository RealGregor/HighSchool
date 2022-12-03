using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

namespace LeaveMeAlone
{
    public partial class CarBatteriesLayout : UserControl
    {

        public CarBatteriesLayout()
        {
            InitializeComponent();
            
        }
        private string IsOk(string s)
        {
            string pattern = "[a-zA-Z0-9]";
            for (int i = 0; i < s.Length; i++)
            {
                if (!Regex.IsMatch("" + s[i], pattern))
                {
                    return "";
                }
            }
            return s;
        }
        public string[] GetInformation()
        {
            //string name = Regex.Replace(txtName.Text, @"\s+", "");//maybe don't do that because somebody can have 2 name.. name: P Diddy Pimp surname: lol
            //string surname = Regex.Replace(txtSurname.Text, @"\s+", "");
            //string email = Regex.Replace(txtEmail.Text, @"\s+", "");

            //name = IsOk(name);
            //surname = IsOk(surname);
            //email = IsOk(email);

            //txtName.Text = name;
            //txtSurname.Text = surname;
            //txtEmail.Text = email;

            //string[] info = { name, surname, email,/*txtPhone.Text.Trim()*/ };
            return null; //info;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //string name = Regex.Replace(txtName.Text, @"\s+", "");//maybe don't do that because somebody can have 2 name.. name: P Diddy Pimp surname: lol
            //string surname = Regex.Replace(txtSurname.Text, @"\s+", "");
            //string email = Regex.Replace(txtEmail.Text, @"\s+", "");

            //name = IsOk(name);
            //surname = IsOk(surname);
            //email = IsOk(email);

            //txtName.Text = name;
            //txtSurname.Text = surname;
            //txtEmail.Text = email;

            //formMain.mainForm.FunctionSummoner(3, name, surname, email);//summoning function which handles which function with which information to summon to requests data from a serve
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //string email = Regex.Replace(txtEmail.Text, @"\s+", "");
            //txtEmail.Text = email;

            //formMain.mainForm.FunctionSummoner(2, "", "", email);
        }

        private void panelControl1_SizeChanged(object sender, EventArgs e)
        {
            //searchButton.Location = new Point(panelControl1.Width/2-searchButton.Width/2-20, searchButton.Location.Y);
        }
    }
}
