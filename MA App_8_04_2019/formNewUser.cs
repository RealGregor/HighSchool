using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;
using System.Text.RegularExpressions;
using LMA.Data.UI.ViewModels.ViewModels;
using RestSharp;
using System.Net;
using RestSharp.Authenticators;
using System.IO;

namespace LeaveMeAlone
{
    public partial class formNewUser : Form
    {
        private delegate void RVMResponseDelegate(IRestResponse<ResponseViewModel> response);
        private RVMResponseDelegate DelSuccess;
        private RVMResponseDelegate DelError;

        
        //private ARVMResponseDelegate DelLoginSuccess;
        //private ARVMResponseDelegate DelLoginError;


        public formNewUser()
        {
            InitializeComponent();
            this.ActiveControl = txtName;
            txtPassword1.PasswordChar = '*';
            txtPassword2.PasswordChar = '*';

            DelSuccess = this.OnSuccess;
            DelError = this.OnError;

            //DelLoginSuccess = this.LoginSuccess;
            //DelLoginError = this.LoginError;


        }
        //============= CREATE USER BUTTON CLICK ============//
        private void btnCreate_Click(object sender, EventArgs e)
        {
            foreach (var v in this.Controls.OfType<TextBox>().ToList()) {
                if (string.IsNullOrEmpty(v.Text.Trim())) {
                    MessageBox.Show("Izpolnite vsa polja.");
                    return;
                }
            }
            //if (txtName.Text.Trim().Length == 0) {
            //    nameError.Text = "Missing name";
            //} else if (txtSurname.Text.Trim().Length == 0)
            //{
            //    surnameError.Text = "Missing surname";
            //} else if (invalidEmail(txtEmail.Text.Trim())) {
            //    return;
            //}
            //if (txtPassword1.Text.Trim().Length == 0)
            //{
            //    passwordError.Text = "Missing password";
            //} else if (passwordValid(txtPassword1.Text.Trim())) {
            //    return;
            //}
            //else if (!txtPassword1.Text.Equals(txtPassword2.Text))
            //{
            //    passwordError.Text = "Password are not identical";
            //    return;
            //}
            //else if (txtPassword1.Text.Trim().Length < 6)
            //{
            //    passwordError.Text = "Length of your password has to be at least 6 characters long";
            //    return;
            //} 
            
            //else if (txtCompanyName.Text.Trim().Length == 0) {
            //    //company error text -> Invalid company name

            //} else if (/*txt company entry key null*/false) {

            //}else
            {
                CreateUserViewModel user = new CreateUserViewModel();
                user.Name = txtName.Text.Trim();
                user.Surname = txtSurname.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.Address = txtAdress.Text.Trim();
                user.AddressNumber = txtAdressNumber.Text.Trim();
                user.Country = txtCountry.Text.Trim();
                user.Password = txtPassword1.Text.Trim();
                user.ConfirmPassword = txtPassword2.Text.Trim();
                //user.TenantName = txtCompanyName.Text.Trim();
                //put entry key somewhere




                var client = new RestClient("http://localhost:5000");
                var request = new RestRequest("api/user", Method.POST);
                request.AddJsonBody(user);
                client.ExecuteAsync<ResponseViewModel>(request, (response) => {
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                    {
                        this.Invoke(DelSuccess, response);
                    }
                    else
                    {
                        this.Invoke(DelError, response);
                    }
                });
            }
        }
        protected virtual void OnSuccess(IRestResponse<ResponseViewModel> response)
        {
            //if (response.Data.Message != null)
            //{
            //    MessageBox.Show(response.Data.Message);
            //}
            //else
            //{
            //if (response.Data.Message.Equals("Success")) {
            //    LoginUser();
            //    return;
            //}
            formLogin objLogin = new formLogin();
            objLogin.Show();
            this.Hide();

            //}
        }
        protected virtual void OnError(IRestResponse<ResponseViewModel> response)
        {
            //_NewUserErrorMessageHandler.RecieveError(response.Data.StatusCode);//handle it differently
        }
        private bool invalidEmail(string email) {
            if (email.Length == 0) {
                emailError.Text = "Missing email adresss";
                return true;
            }
            /*
             preveri veljavnost email naslova - obstaja in ze v uporabi
             */
            return false;
        }
        private bool passwordValid(string pass) {
            string pattern = "[a-zA-Z0-9]";
            for (int i = 0; i < pass.Length; i++) {
                if (!Regex.IsMatch(""+pass[i], pattern)) {
                    passwordError.Text = "Only english letters and number are allowed";
                    return true;
                }
            }
            //password must contain at least 1 uppercase letter
            return false;
        }


        //private void LoginUser() {//not needed
        //    var client = new RestClient("http://localhost:5000");
        //    client.Authenticator = new HttpBasicAuthenticator(txtEmail.Text.Trim(), txtPassword1.Text.Trim());

        //    var request = new RestRequest("api/auth/", Method.POST);
        //    client.ExecuteAsync<AuthenticationResponseViewModel>(request, (response) => {
        //        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
        //        {
        //            this.Invoke(DelLoginSuccess, response);
        //        }
        //        else
        //        {
        //            this.Invoke(DelLoginError, response);
        //        }
        //    });
        //}


        //protected virtual void LoginSuccess(IRestResponse<ResponseViewModel> response)
        //{
        //    formMain objFormMain = new formMain(response.Data.Token, response.Data.User);
        //    objFormMain.Show();
        //    this.Close();
        //}
        //protected virtual void LoginError(IRestResponse<ResponseViewModel> response)
        //{
        //    MessageBox.Show("Unavailable");//handle it differently
        //}


        



        private void btnBack_Click(object sender, EventArgs e)
        {
            formLogin objLogin = new formLogin();
            this.Hide();
            objLogin.Show();
        }

        private void exit_topRightSignUp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private bool mouseDown;
        private Point lastLocation;

        private void formNewUser_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void formNewUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void formNewUser_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
