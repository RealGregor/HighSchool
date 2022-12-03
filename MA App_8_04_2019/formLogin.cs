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
using Microsoft.AspNet.SignalR.Client;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using RestSharp.Authenticators;
using LMA.Data.UI.ViewModels.ViewModels;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using LMA.Data.UI.ViewModels.ClientResponseModels;

namespace LeaveMeAlone
{
    public partial class formLogin : Form
    {

        private delegate void MResponseDelegate(object response);

        private delegate void LMVMResponseDelegate(List<MessageViewModel> response);

        private MResponseDelegate DelSuccess;
        private LMVMResponseDelegate DelError;

        private int x = 0;

        private bool allowChange = false;

        public formLogin()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            DelSuccess = this.OnSuccess;
            DelError = this.OnError;

            passwordCorrect.ForeColor = Color.Red;
            usernameCorrect.ForeColor = Color.Red;
            txtPassword.PasswordChar = '*';
            if (File.Exists(@"C:\Users\Public\RememberMe2.txt"))
            {
                x = 0;
                try
                {
                    DecryptFile(@"C:\Users\Public\RememberMe2.txt", @"C:\Users\Public\RememberMe.txt");
                }
                catch (Exception e)
                {
                    File.Delete(@"C:\Users\Public\RememberMe.txt");
                    File.Delete(@"C:\Users\Public\RememberMe2.txt");

                    var myFile = File.Create(@"C:\Users\Public\RememberMe.txt");
                    myFile.Close();
                    var myFile2 = File.Create(@"C:\Users\Public\RememberMe2.txt");
                    myFile2.Close();
                }
                if (x == 0)
                {
                    string text = File.ReadAllText(@"C:\Users\Public\RememberMe.txt");
                    bool wasChecked;
                    bool.TryParse(text.Substring(text.IndexOf("=") + 1, 4), out wasChecked);
                    rememberMeCheckBox.Checked = wasChecked;
                    if (wasChecked)
                    {
                        this.ActiveControl = btnLogin;
                        text = text.Substring(text.IndexOf("=") + 1);
                        text = text.Substring(text.IndexOf("="));
                        string email, pass;
                        string[] values;
                        values = text.Split(';');
                        email = values[0].Substring(values[0].IndexOf("=") + 1);
                        pass = values[1].Substring(values[1].IndexOf("=") + 1);
                        txtEmail.Text = email;
                        txtEmail.BackColor = Color.Khaki;
                        txtPassword.Text = pass;
                        txtPassword.BackColor = Color.Khaki;
                        allowChange = true;
                    }
                    else
                    {
                        this.ActiveControl = txtEmail;
                    }
                }
                else
                {
                    var myFile = File.Create(@"C:\Users\Public\RememberMe.txt");
                    myFile.Close();
                    var myFile2 = File.Create(@"C:\Users\Public\RememberMe2.txt");
                    myFile2.Close();
                }
            }
        }
       
        //============= LOGIN BUTTON CLICK ============//
        private void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            passwordCorrect.Text = "";
            usernameCorrect.Text = "";

            btnLogin.Enabled = false;
            btnNewUser.Enabled = false;
            //loadingIndicator.Visible = true;

            var client = new RestClient("http://localhost:5000");//https://leavemealone.azurewebsites.net
            client.Authenticator = new HttpBasicAuthenticator(txtEmail.Text.Trim(), txtPassword.Text.Trim());

            var request = new RestRequest("api/auth/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            client.ExecuteAsync<ClientResponseViewModel<AuthenticationResponseViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                {
                    this.Invoke(DelSuccess, response.Data.Object);
                }
                else
                {
                try {
                    this.Invoke(DelError, response.Data.Messages);
                } catch (Exception ex) {
                    this.Invoke(DelError, new List<MessageViewModel>(){new MessageViewModel("Unavaliable")});
                    }
                }
            });
        }

        protected virtual void OnSuccess(object response)
        {
            if (rememberMeCheckBox.Checked)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\RememberMe.txt"))
                {
                    writer.Write("state=true;Email=" + txtEmail.Text.Trim() + ";Password=" + txtPassword.Text.Trim());
                }
                EncryptFile(@"C:\Users\Public\RememberMe.txt", @"C:\Users\Public\RememberMe2.txt");
                UpdateFile(@"C:\Users\Public\RememberMe.txt");
            }
            else { UpdateFile(@"C:\Users\Public\RememberMe.txt"); }

            btnLogin.Enabled = true;
            btnNewUser.Enabled = true;
            //loadingIndicator.Visible = false;
            
            
            formMain objFormMain = new formMain(((AuthenticationResponseViewModel)response).Token, ((AuthenticationResponseViewModel)response).User);
            objFormMain.Show();
            this.Hide();
        }
        protected virtual void OnError(List<MessageViewModel> response)
        {
            if (true)
            {
                if (response[0].Code == 13)
                {
                    passwordCorrect.Text = "Incorrect password";
                }
                else if (response[0].Code == 17)
                {
                    usernameCorrect.Text = "Invalid email adress";
                }
            }

            btnLogin.Enabled = true;
            btnNewUser.Enabled = true;
            //loadingIndicator.Visible = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            UpdateFile(@"C:\Users\Public\RememberMe.txt");
            EncryptFile(@"C:\Users\Public\RememberMe.txt", @"C:\Users\Public\RememberMe2.txt");
            this.Close();
            Application.Exit();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            rememberMeCheckBox.Checked = false;
            UpdateFile(@"C:\Users\Public\RememberMe.txt");
            EncryptFile(@"C:\Users\Public\RememberMe.txt", @"C:\Users\Public\RememberMe2.txt");
            formNewUser objFormNewUser = new formNewUser();
            this.Hide();
            objFormNewUser.Show();
        }

        private void exit_topRight_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private bool mouseDown;
        private Point lastLocation;

        private void formLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void formLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void formLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange || txtEmail.BackColor == Color.White) {
                return;
            }
            txtEmail.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
        }


        /*updating file when user goes on to another form or exits the login form*/
        private void UpdateFile(string file) {  using (StreamWriter writer = new StreamWriter(file)){
                writer.Write("state=false");
            }
        }

        private void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"Yo089eti"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);
                
                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("Encryption failed!", "Error");
            }
        }
        ///<summary>
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        private void DecryptFile(string inputFile, string outputFile)
        {
            FileStream fsCrypt = null;
            CryptoStream cs = null;
            FileStream fsOut = null;
            try {
                string password = @"Yo089eti"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                using (fsCrypt = new FileStream(inputFile, FileMode.Open))
                {

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    using (cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateDecryptor(key, key),
                        CryptoStreamMode.Read))
                    {

                        using (fsOut = new FileStream(outputFile, FileMode.Create))
                        {

                            int data;
                            while ((data = cs.ReadByte()) != -1)
                                fsOut.WriteByte((byte)data);
                        }
                    }
                }
            } catch (Exception e) {
                x = 1;
            }
        }




        T ConvertToWanted<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                char c = char.ToUpper(kv.Key[0]);
                string s = c + kv.Key.Substring(1);

                Type t = (type.GetProperty(s).PropertyType);
                if (t.Name.Equals("Guid")) {
                    type.GetProperty(s).SetValue(obj, new Guid((string)kv.Value));
                    continue;
                }
                type.GetProperty(s).SetValue(obj, Convert.ChangeType(kv.Value, t));
            }
            return (T)obj;
        }
    }
}
