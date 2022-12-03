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
using LMA.Data.UI.ViewModels.ViewModels;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using LeaveMeAlone._Information;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LeaveMeAlone
{
    public partial class Employees : UserControl
    {
        private DeleteUserAccountConfirmation_ deleteForm;
        public static Employees employees = null;
        private BindingList<Employee> listAddUsers = new BindingList<Employee>();

        private EmployeeProfileViewFormAdmin userProfileViewForm;

        private ImageFormat format = null;
        private bool firstTime = true;

        public Employees()
        {
            InitializeComponent();
            employees = this;
        }

        public void SetEmployeesDataControlSource(BindingList<Employee> listEmployees) {
            if (firstTime) {
                firstTime = !firstTime;

                employeesData.RowHeadersVisible = false;
                //employeesData.Enabled = false;
                employeesData.DefaultCellStyle.SelectionBackColor = employeesData.DefaultCellStyle.BackColor;
                employeesData.DefaultCellStyle.SelectionForeColor = employeesData.DefaultCellStyle.ForeColor;
                employeesData.AllowUserToResizeRows = false;
                employeesData.AllowUserToResizeColumns = false;
                employeesData.CellMouseClick += EmployeesData_CellMouseClick;

                employeesData.RowTemplate.MinimumHeight = 80;
                employeesData.RowTemplate.ReadOnly = true;

                employeesData.DataSource = listEmployees;

                employeesData.Columns[5].Visible = false;

                employeesData.Columns[0].HeaderText = "Profilna Slika";
                employeesData.Columns[1].HeaderText = "Ime";
                employeesData.Columns[2].HeaderText = "Priimek";
                employeesData.Columns[3].HeaderText = "Elektronski naslov";
                employeesData.Columns[4].HeaderText = "Telefonska številka";

                foreach (DataGridViewColumn data in employeesData.Columns) {
                    data.DefaultCellStyle.Font = new Font("Microsoft YaHei", 16);
                    if (data.Name.Equals("Email")) {
                        data.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        continue;
                    }
                    data.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                }
            }





        }

        private void EmployeesData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) { return; }
            Employee employee = (Employee)(employeesData.Rows[e.RowIndex].DataBoundItem);


            EmployeeViewModel employeeData = new EmployeeViewModel();
            employeeData.Name = employee.Name;
            employeeData.Surname = employee.Surname;
            employeeData.ProfilePicture = employee.StringProfilePicture;
            employeeData.Email = employee.Email;
            employeeData.PhoneNumber = employee.PhoneNumber;

            if (userProfileViewForm != null) {
                userProfileViewForm.Close();
            }
            userProfileViewForm = new EmployeeProfileViewFormAdmin(employeeData);
            userProfileViewForm.Show();
        }
    }
}
