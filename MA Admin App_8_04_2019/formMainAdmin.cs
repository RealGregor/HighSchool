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
using RestSharp;
using System.Net;
using System.Threading;
using DevExpress.XtraGrid;
using System.Security.Claims;
using LMA.Data.UI.ViewModels.ViewModels;
using RestSharp.Authenticators;
using System.IO;
using LeaveMeAlone._Groups;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Permissions;
using System.Collections;
using LMA.Data.UI.ViewModels.ClientResponseModels;
using LeaveMeAlone._Information;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;
using LeaveMeAlone._AutoParts.Tires;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using LeaveMeAlone._Cart;

namespace LeaveMeAlone
{
    public partial class formMainAdmin : Form
    {
        int panel = 0; // 1-friends  2-groups  3-settings
        public int friendPanelVisible = 0;//this is a test doodle
        public int groupPanelVisible = 0;
        public static bool showNotificationsChecked;//whether or not user will be notified
        private string currentActiveGroupID = null;
        private string currentActiveDeleteGroupID = null;

        private int inviteType = 0;

        private ImageFormat format = null;

        private Color original = Color.Orange;

        private int userStatus = 2;
        private bool logout = false;
        private string emailToBeRemoved;

        private EmployeeProfileViewFormAdmin userProfile = null;

        //============= CIRCULAR PROGRESS BAR FIX =============//
        private CircularProgressBar.CircularProgressBar circularProgressBarFix = null;
        private int maxTime = 0;

        private string currentCategory = "";

        public static formMainAdmin mainForm = null;

        //============= SO YOU GET YOUR GROUPS WHEN YOU WANT TO INVITE SOMEBODY TO YOUR GROUP WITHOUT SHOWING YOUR GROUPS -> JUST GETTING THEM =============//
        private bool dontShow = false;

        //============= BINDING LISTS =============//
        private BindingList<Employee> listEmployees = new BindingList<Employee>(); //for showing all employees in the company

        private BindingList<AutoPart> listTires = new BindingList<AutoPart>(); //for showing all tires 

        private BindingList<AutoPart> listLights = new BindingList<AutoPart>(); //for showing all tires 

        private BindingList<AutoPart> listOils = new BindingList<AutoPart>(); //for showing all tires 

        private BindingList<AutoPart> listFilters = new BindingList<AutoPart>(); //for showing all tires 
        
        private BindingList<Order> listOrders = new BindingList<Order>(); //for showing all tires 
        
        private BindingList<Employee> listDescriptions = new BindingList<Employee>();

        private Dictionary<string, int> friendStatus = new Dictionary<string, int>();

        private List<string> favouritesEmails = new List<string>();

        //private Dictionary<string, string> userProfilePicture= new Dictionary<string, string>();

        //=============  =============//


        private readonly string _Token;
        private readonly AdminViewModel _Admin;

        //============= RESPONSE DELEGATES =============//

        //TEMPORARY
        private delegate void OResponseDelegate(object response);

        private delegate void LMVMResponseDelegate(List<MessageViewModel> response);
        
        private OResponseDelegate DelShowEmployees;

        private OResponseDelegate DelShowAutoParts;
        private OResponseDelegate DelShowAutoPart;
        
        private OResponseDelegate DelShowOrders;
        
        private OResponseDelegate DelShowFavourites;

        private OResponseDelegate DelShowSelectedUserProfile;
        
        private OResponseDelegate DelSuccess;
        private LMVMResponseDelegate DelError;
        private OResponseDelegate DelChangePasswordSuccess;
        
        private OResponseDelegate DelDeleteSuccess;
        private LMVMResponseDelegate DelDeleteError;

        private OResponseDelegate DelDeleteEmployeeSuccess;
        private OResponseDelegate DelChangeEmployeeSuccess;

        private OResponseDelegate DelChangeAutoPartSuccess;
        private OResponseDelegate DelDeleteAutoPartSuccess;

        private OResponseDelegate DelChangeFavourite;
        
        private OResponseDelegate DelChangeInformationSuccess;
        
        private OResponseDelegate DelCreateEmployeeSuccess;
        private LMVMResponseDelegate DelCreateEmployeeError;

        public formMainAdmin(string token, AdminViewModel admin)
        {
            InitializeComponent();
            
            original = settingsButton.FlatAppearance.BorderColor;
            //panel2.SendToBack(); panel1.SendToBack();
            //friendsLayout.BringToFront();//not sure if neccesary
            //settingsLayout.BringToFront();
            //groupsLayout.BringToFront();
            //companyLayout.BringToFront();
            //favouritesLayout.BringToFront();

            //============= EMPLOYEE =============//
            DelCreateEmployeeSuccess = this.CreateEmployeeSuccess;
            DelCreateEmployeeError = this.CreateEmployeeError;
            DelShowEmployees = this.ShowEmployees;
            
            //============= SELECTED USER PROFILE =============//
            DelShowSelectedUserProfile = this.ShowSelectedUserProfile;
            
            //============= MY PROFILE =============//
            DelDeleteSuccess = this.ShowDeleteSuccess;
            DelDeleteError = this.ShowDeleteError;

            //============= CHANGE & DELETE EMPLOYEE =============//
            DelChangeEmployeeSuccess = this.ChangeEmployeeSuccess;
            DelDeleteEmployeeSuccess = this.DeleteEmployeeSuccess;

            DelChangeInformationSuccess = this.ChangeMyInformation;
            DelChangePasswordSuccess = this.ChangePasswordSuccess;



            //============= AUTO PARTS =============//
            DelShowAutoParts = this.ShowAutoParts;
            DelChangeAutoPartSuccess = this.ChangeAutoPartSuccess;
            DelDeleteAutoPartSuccess = this.DeleteAutoPartSuccess;
            DelShowAutoPart = this.ShowAutoPart;

            //============= AUTO PARTS =============//
            DelShowOrders = this.ShowOrders;


            //=============  =============//
            //DelError = this.OnError;
            //DelSuccess = this.OnSuccess;

            

            _MainErrorMessageHandler.SetMainForm(this);

            mainForm = this;

            _Token = token;
            _Admin = admin;
            userStatus = 2;

            notifyIcon1.Icon = Properties.Resources.GreenIcon;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            //FunctionSummoner(29, userStatus: userStatus);
            //FunctionSummoner(32);
            //FunctionSummoner(31);
            //FunctionSummoner(36);//get availbality constraints

            nameAndSurnameText.Text = "Pozdravljeni, " + _Admin.Name + " " + _Admin.Surname;
            //emailText.Text = _Admin.Email;

            //if (_User.ProfilePicture != null && !_User.ProfilePicture.Equals(""))
            //{
            //    profilePicture.BackgroundImage = stringToImage(_User.ProfilePicture);
            //}

            settingsLayout.SetMyProfileInformation(_Admin, profilePicture.BackgroundImage);
        }

        //
        //CLIENT-SERVER COMMUNICATION FUNCTIONS
        //
        /**/
        //============= GET FRIENDS =============//
        //private void GetFriends()//function id = 1
        //{
        //    var client = new RestClient("http://localhost:5000");

        //    var request = new RestRequest("api/Friend/with_status", Method.GET);

        //    request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
        //    client.ExecuteAsync<List<StatusTempViewModel>>(request, (response) => {
        //        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
        //        {
        //            try
        //            {
        //                this.Invoke(DelShowFriends, response);
        //            }
        //            catch (Exception e) {

        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Unavailable");
        //        }
        //    });
        //}
        /**/
        //============= GET WANTED USER =============//
        private void GetWantedUser(string email)//function id = 4
        {
            //if (email.Equals(_User.Email))
            //{
            //    return;
            //}
            var client = new RestClient("http://localhost:5000");

            //UserViewModel wantedUser = new UserViewModel();
            //wantedUser.Email = email;
            var request = new RestRequest("api/user", Method.GET);
            request.AddHeader("Email", email);
            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<UserViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                {
                    this.Invoke(DelShowSelectedUserProfile, response.Data.Object);
                }
                else
                {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
       //============= DELETE USER =============//
        private void DeleteThisUser(string password)//function id = 9
        {
            DeleteUserViewModel deleteUser = new DeleteUserViewModel();
            deleteUser.Password = password;

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/user/", Method.DELETE);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            request.AddJsonBody(deleteUser);

            client.ExecuteAsync<ClientResponseViewModel<object>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK/*|| response.StatusCode == HttpStatusCode.NoContent*/)
                {
                    this.Invoke(DelDeleteSuccess, response.Data.Object);
                }
                else
                {
                    this.Invoke(DelDeleteError, response.Data.Messages);
                }
            });
        }
       // ============= CHANGE USER INFORMATION ============= //
        private void ChangeUserInformation(ChangeUserViewModel newInfo, Image image)//function id = 26
        {
            if (newInfo == null) { newInfo = new ChangeUserViewModel(); }

            if (image != null)
            {
                profilePicture.BackgroundImage = image;
            }
            if (image != null) { newInfo.ProfilePicture = ImageToByteArray(image); }

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/user/", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                newInfo.Name,
                newInfo.Surname,
                newInfo.ProfilePicture,
                });


            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);

            client.ExecuteAsync<ClientResponseViewModel<ChangeUserViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                {
                    this.Invoke(DelChangeInformationSuccess, response.Data.Object);
                }
                else
                {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        // ============= CHANGE USER PASSWORD ============= //
        private void ChangePassword(string newPassword, string confirmPassword)//function id = 27
        {
            ChangePasswordViewModel changePassword = new ChangePasswordViewModel();

            changePassword.Password = newPassword;
            changePassword.ConfirmPassword = confirmPassword;

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/user/password", Method.PUT);

            request.AddJsonBody(changePassword);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<object>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                {
                    MessageBox.Show(response.Data.Messages[0].Message);
                    this.Invoke(DelChangePasswordSuccess, response.Data.Object);
                }
                else
                {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= GET COMPANY EMPLOYEES =============// MA APPLICATION
        private void GetCompanyEmployees()//function id = 31
        {
            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Employee/employees", Method.GET);//CHANGE 

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<List<UserViewModel>>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                {
                    this.Invoke(DelShowEmployees, response.Data.Object);
                }
                else
                {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        // ============= CREATE EMPLOYEE =============
        private void CreateEmployee(EmployeeViewModel employee)//function id = 37
        {
            
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/Employee/employee", Method.POST);

            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);


            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);

            client.ExecuteAsync<ClientResponseViewModel<object>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelCreateEmployeeSuccess, response.Data.Object);
                } else {
                    //LIKE THIS
                    MessageBox.Show(response.Data.Messages[0].Message);
                    
                    //OR THIS
                    //this.Invoke(DelCreateEmployeeSuccess, response.Data.Messages[0].Message);
                }
            });
        }
        // ============= CREATE AUTOPART =============
        private void AddAutoPart(AutoPartViewModel autoPart)//function id = 38
        {

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/AutoPart/addAutoPart", Method.POST);

            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(autoPart);


            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);

            client.ExecuteAsync<ClientResponseViewModel<object>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    MessageBox.Show("Del je bil dodan v podatkovno bazo.");
                    /*INSERT THE AUTO PART INTO THE LIST? - currently, NO */
                    //this.Invoke(DelCreateAutoPartSuccess, response.Data.Object);
                } else {
                    //LIKE THIS
                    MessageBox.Show(response.Data.Messages[0].Message);

                    //OR THIS
                    //this.Invoke(DelCreateEmployeeSuccess, response.Data.Messages[0].Message);
                }
            });
        }
        // ============= CHANGE EMPLOYEE INFORMATION ============= //
        private void ChangeEmployee(ChangeEmployeeViewModel changeEmployee)//function id = 39
        {
            
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/Employee", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(changeEmployee);


            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);

            client.ExecuteAsync<ClientResponseViewModel<ChangeEmployeeViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    //this.Invoke(DelChangeInformationSuccess, response.Data.Object);
                    this.Invoke(DelChangeAutoPartSuccess, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= DELETE GIVEN EMPLOYEE =============//
        private void DeleteEmployee(DeleteEmployeeViewModel deleteEmployee)//function id = 40
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/Employee", Method.DELETE);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            request.AddJsonBody(deleteEmployee);

            client.ExecuteAsync<ClientResponseViewModel<CartItemViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK/*|| response.StatusCode == HttpStatusCode.NoContent*/) {
                    this.Invoke(DelDeleteEmployeeSuccess, response.Data.Object);
                    //TODO
                } else {
                    this.Invoke(DelDeleteError, response.Data.Messages);
                }
            });
        }
        //============= GET ALL AUTOPARTS THAT MATCH THE FILTERS =============// function id = 41
        private void GetSuitableAutoParts(string category, string technicalDescription, decimal priceMin, decimal priceMax)//function id = 38
        {
            currentCategory = category;

            if (priceMax == 0) { priceMax = decimal.MaxValue; }

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/AutoPart/categoryFilter", Method.POST);

            //COULDN'T SEND Š TROUGH HEADER SO I USED A NEW MODEL INSTEAD

            AutoPartFiltersViewModel filters = new AutoPartFiltersViewModel();
            filters.Category = category;
            filters.TechnicalDetails = technicalDescription;
            filters.priceMin = "" + priceMin;
            filters.priceMax = "" + priceMax;

            request.AddJsonBody(filters);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<List<AutoPartViewModel>>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    //this.Invoke(DelShowSuitableUsers, response.Data.Object);
                    this.Invoke(DelShowAutoParts, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        // ============= CHANGE EMPLOYEE INFORMATION ============= //
        private void ChangeAutoPart(ChangeAutoPartViewModel changeAutoPart)//function id = 42
        {

            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/AutoPart", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(changeAutoPart);


            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);

            client.ExecuteAsync<ClientResponseViewModel<ChangeAutoPartViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    //this.Invoke(DelChangeInformationSuccess, response.Data.Object);
                    this.Invoke(DelChangeAutoPartSuccess, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= DELETE GIVEN EMPLOYEE =============//
        private void DeleteAutoPart(DeleteAutoPartViewModel deleteAutoPart)//function id = 43
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("api/AutoPart", Method.DELETE);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            request.AddJsonBody(deleteAutoPart);

            client.ExecuteAsync<ClientResponseViewModel<DeleteAutoPartViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK/*|| response.StatusCode == HttpStatusCode.NoContent*/) {
                    this.Invoke(DelDeleteAutoPartSuccess, response.Data.Object);
                    //TODO
                } else {
                    this.Invoke(DelDeleteError, response.Data.Messages);
                }
            });
        }
        //============= GET ALL AUTOPARTS THAT MATCH THE FILTERS =============// function id = 41
        private void GetAutoPart(string autoPartID)//function id = 44
        {
            /*just returning for now, could do some kind of a message to the user etcccc*/
            if (string.IsNullOrEmpty(autoPartID)) { return; }

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/AutoPart/byID", Method.GET);

            //COULDN'T SEND Š TROUGH HEADER SO I USED A NEW MODEL INSTEAD -> or just encode the š value into somehting else
            
            request.AddHeader("autoPartID", autoPartID);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<AutoPartViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    //this.Invoke(DelShowSuitableUsers, response.Data.Object);
                    this.Invoke(DelShowAutoPart, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= GET ORDERS FOR THIS USER =============//
        private void GetOrdersOnThisDate(string date)//function id = 45
        {
            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Order/ordersOnThisDate", Method.GET);//CHANGE 

            request.AddHeader("Date", date);;

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<List<OrderViewModel>>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelShowOrders, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }

        //
        //
        //
        //
        //

        //============= SHOW SELECTED USER PROFILE =============//
        protected virtual void ShowSelectedUserProfile(object result)
        {
            EmployeeViewModel selectedEmployee = (EmployeeViewModel)result;

            if (selectedEmployee == null)
            {//could happen if the list isn't updated and somebody deletes his account and you click his acccount...
                //tell user that that user does not exist anymore
                return;
            }


            if (panel == 1)
            {
                autoPartsLayout.ShowThisEmployeeProfile(selectedEmployee);
            }
            else if (panel == 2)
            {
                //groupsLayout.ShowThisUserProfile(selectedEmployee);
            }
            else if (panel == 4)
            {
                //companyLayout.ShowThisUserProfile(selectedEmployee);
            }
            else if (panel == 5)
            {
                //favouritesLayout.ShowThisUserProfile(selectedEmployee);
            }

        }
        //============= SHOW EMPLOYEES =============//
        protected virtual void ShowEmployees(object result)
        {
            List<UserViewModel> listOfEmployees = (List<UserViewModel>)result;

            listEmployees.Clear();
            if (listOfEmployees != null)
            {
                foreach (UserViewModel employee in listOfEmployees)
                {
                    listEmployees.Add(new Employee(employee));
                }
            }
            companyLayout.SetEmployeesDataControlSource(listEmployees);
        }
        //============= SHOW AUTOPARTS =============// MULTIPLE AUTO PARTS - LIST
        protected virtual void ShowAutoParts(object result) {
            List<AutoPartViewModel> listOfAutoParts = (List<AutoPartViewModel>)result;

            BindingList<AutoPart> listReference = null;

            //if (listOfAutoParts == null || listOfAutoParts.Count == 0) {
            //    return;
            //}

            switch (this.currentCategory) {
                case "Tire": listReference = listTires; break;
                case "Light": listReference = listLights; break;
                case "Oil": listReference = listOils; break;
                case "Filter": listReference = listFilters; break;
                    //add default if somehow value wouldn't be as intended
            }

            listReference.Clear();
            foreach (AutoPartViewModel autoPart in listOfAutoParts) {
                listReference.Add(new AutoPart(autoPart));
            }
            autoPartsLayout.SetAutoPartsDataControlSource(listReference, this.currentCategory);
        }
        //============= SHOW AUTOPART =============// ONE AUTO PART
        protected virtual void ShowAutoPart(object result) {
            autoPartsLayout.SetAutoPartData((AutoPartViewModel)result);
        }
        //============= SHOW ORDERS =============//
        protected virtual void ShowOrders(object result) {
            List<OrderViewModel> orders = (List<OrderViewModel>)result;

            listOrders.Clear();

            Dictionary<Guid, List<OrderViewModel>> realOrders = new Dictionary<Guid, List<OrderViewModel>>();

            foreach (var order in orders) {
                if (realOrders.ContainsKey(order.OrderID)) {
                    realOrders[order.OrderID].Add(order);
                } else {
                    realOrders.Add(order.OrderID, new List<OrderViewModel> { order });
                }
            }
            if (orders != null) {
                foreach (var order in realOrders.Values) {
                    listOrders.Add(new Order(order));
                }
            }
            ordersLayout.SetOrdersDataControlSource(listOrders);
        }
        //=============SERVER-CLIENT COMMUNICATION FUNCTION SUMMONER=============//         **********INSTEAD OF SPECIFYING, JUST PUT VIEWMODELS IN HERE
        public void FunctionSummoner(int functionID, string name = "", string surname = "",
            string email = "", string groupName = "", string password = "", int privacy = 0,
            string groupID = "", bool owner = false, bool dontShow = false,
            string newPassword = null, int userStatus = 2, Image image = null,
            bool favourite = false, UserViewModel user = null, EmployeeProfileViewFormAdmin userProfile = null,
            List<string> groupsIDs = null, string phoneNumber = null, List<string> emails = null,
            int inviteType = 0, ChangeUserViewModel newInfo = null, EmployeeViewModel employee = null,
            AutoPartViewModel autoPart = null, ChangeEmployeeViewModel changeEmployee = null,
            DeleteEmployeeViewModel deleteEmployee = null, string category = "", string technicalDescription = "",
            decimal priceMin = 0, decimal priceMax = 0, ChangeAutoPartViewModel changeAutoPart = null,
            DeleteAutoPartViewModel deleteAutoPart = null, string autoPartID = null,
            string date = null)
        {
            switch (functionID)
            {
                //case 1: GetFriends(); break;
                case 2:; break;//change the request
                //case 3: GetSuitablePeople(name, surname, email, phoneNumber); break;
                case 4: GetWantedUser(email); break;
                //case 5: GetReceivedFriendRequests(); break;
                //case 6: GetGroups(dontShow); break;
                //case 7: GetGroupMembers(groupID); break;
                //case 8: GetSuitableGroups(groupName, email); break;
                case 9: DeleteThisUser(password); break;
                //case 10: SendFriendRequest(email); break;
                //case 11: CreateAGroup(groupName, privacy); break;
                //case 12: AcceptFriendRequest(email); break;
                //case 13: RejectFriendRequest(email, owner); break;
                //case 14: DeleteFriend(email); break;
                //case 15: SendGroupRequest(groupID); break;
                //case 16: GetSentGroupRequests(); break;
                //case 17: GetReceivedGroupRequests(groupID); break;
                //case 18: SendGroupInvite(groupID, email); break;
                //case 19: GetSentFriendRequests(); break;
                //case 20: AcceptGroupRequest(groupID, email, inviteType); break;
                //case 21: RejectGroupRequest(groupID, email, inviteType); break;
                //case 22: LeaveGroup(groupID, email); break;//currently using for leaving the group and removing an user from a group
                //case 23: DeleteGroup(groupID); break;
                //case 24: GetSentGroupInvites(); break;
                //case 25: GetReceivedGroupInvites(); break;
                case 26: ChangeUserInformation(newInfo, image); break;
                case 27: ChangePassword(newPassword, password); break;
                //case 28: GetGroupsWithoutGivenUser(email, userProfile); break;
                //case 29: UpdateMyStatus(userStatus); break;
                //case 30: RemoveUserFromGroup(email, groupID); break;
                case 31: GetCompanyEmployees(); break;
                //case 32: GetFavourites(); break;
                //case 33: ChangeFavourite(user, favourite); break;
                //case 34: SendGroupInvites(email, groupsIDs); break;
                //case 35: SendGroupInvitesMultipleUsers(emails);break;//groupID is already in currentActiveGroupID variable
                //case 36: GetTenantData();break;
                case 37: CreateEmployee(employee); break;
                case 38: AddAutoPart(autoPart); break;
                case 39: ChangeEmployee(changeEmployee); break;
                case 40: DeleteEmployee(deleteEmployee); break;
                case 41: GetSuitableAutoParts(category, technicalDescription, priceMin, priceMax); break;
                case 42: ChangeAutoPart(changeAutoPart); break;
                case 43: DeleteAutoPart(deleteAutoPart); break;
                case 44: GetAutoPart(autoPartID); break;
                case 45: GetOrdersOnThisDate(date); break;
                //case 29: GetFriendsWithStatus();break;
                //case 29: SetGroupAdmin(email);break;// Not yet implemented

                default: MessageBox.Show("Function id does not exist"); break;
            }
        }

        //============= DELETE ACCOUNT SUCCESS ============//
        private void ShowDeleteSuccess(object response)
        {
            /*delete everything from the file that saves name etc..*/
            File.Delete(@"C:\Users\Public\RememberMe.txt");
            File.Delete(@"C:\Users\Public\RememberMe2.txt");
            DeleteUserAccountConfirmation_.shouldClose = false;
            MessageBox.Show("Your account has been successfully deleted");
            this.Close();
            formLoginAdmin loginForm = new formLoginAdmin();
            loginForm.Show();
        }
        //============= DELETE ACCOUNT ERROR ============//
        private void ShowDeleteError(List<MessageViewModel> response)
        {
            DeleteUserAccountConfirmation_.shouldClose = false;
            MessageBox.Show(response[0].Message);
        }
        //============= CHANGE INFORMATION SUCCESS ============//
        private void ChangeMyInformation(object response)
        {
            AdminViewModel admin = (AdminViewModel)response;


            _Admin.Name = admin.Name;
            _Admin.Surname = admin.Surname;

            if (MyProfile.myProfile == null) { return; }//unnecessary
            MyProfile.myProfile.setNewInformation(_Admin);
        }
        //============= CHANGE PASSWORD SUCCESS ============//
        private void ChangePasswordSuccess(object response)
        {
            //if problem -> if(message == success).... 

            File.Delete(@"C:\Users\Public\RememberMe.txt");
            File.Delete(@"C:\Users\Public\RememberMe2.txt");
            //delete previous information remembered in file and rewrite new information - not needed
            //encrypt into rememberme2
        }
        //============= CHANGE EMPLOYEE INFORMATION SUCCESS ============//
        private void ChangeEmployeeSuccess(object response) {

            ChangeEmployeeViewModel employee = (ChangeEmployeeViewModel)response;
            Employee oldEmployee = listEmployees.SingleOrDefault(f => f.Email.Equals(employee.OldEmail));
            int employeeIndex =  listEmployees.IndexOf(oldEmployee);
            listEmployees.RemoveAt(employeeIndex);

            //CHANGE THIS IN THE FUTUEW
            UserViewModel newEmployeeModel = new UserViewModel();
            //ADD NEW AUTO MAPPING SHIT
            newEmployeeModel.Name = employee.Name;
            newEmployeeModel.Surname = employee.Surname;
            newEmployeeModel.Email = employee.Email;
            newEmployeeModel.PhoneNumber = employee.PhoneNumber;
            newEmployeeModel.ProfilePicture = employee.ProfilePicture;

            Employee newEmployee = new Employee(newEmployeeModel);
            

            listEmployees.Insert(employeeIndex, newEmployee);

        }
        //============= DELETE EMPLOYEE SUCCESS ============//
        private void DeleteEmployeeSuccess(object response) {

            listEmployees.Remove(listEmployees.SingleOrDefault(f => f.Email.Equals(((DeleteEmployeeViewModel)response).Email)));
            
            MessageBox.Show("Zaposleni je bil izbrisan");
        }
        //============= CHANGE EMPLOYEE INFORMATION SUCCESS ============//
        private void ChangeAutoPartSuccess(object response) {

            ChangeAutoPartViewModel autoPart = (ChangeAutoPartViewModel)response;

            BindingList<AutoPart> listReference = null;

            switch (autoPart.Category) {
                case "Tire": listReference = listTires; break;
                case "Light": listReference = listLights; break;
                case "Oil": listReference = listOils; break;
                case "Filter": listReference = listFilters; break;
                    //add default if somehow value wouldn't be as intended
            }

            AutoPart oldAutoPart = listReference.SingleOrDefault(f => f.autoPart.ID.Equals(autoPart.ID));
            if (oldAutoPart == null) {
                return;
            }
            int autoPartIndex = listReference.IndexOf(oldAutoPart);

            listReference.RemoveAt(autoPartIndex);

            //CHANGE THIS IN THE FUTUEW --> AUTO MAPPER
            AutoPartViewModel newAutoPartViewModel = new AutoPartViewModel();
            //ADD NEW AUTO MAPPING SHIT
            newAutoPartViewModel.Name = autoPart.Name;
            newAutoPartViewModel.Category = oldAutoPart.autoPart.Category;
            newAutoPartViewModel.DeliveryDeadline = autoPart.DeliveryDeadline;
            newAutoPartViewModel.Description = autoPart.Description;
            newAutoPartViewModel.ID = autoPart.ID;
            newAutoPartViewModel.Picture = autoPart.Picture;
            newAutoPartViewModel.Price = autoPart.Price;
            newAutoPartViewModel.ProducerName = autoPart.ProducerName;
            newAutoPartViewModel.TechnicalDetails = autoPart.TechnicalDetails;
            newAutoPartViewModel.Category = autoPart.Category;


            AutoPart newAutoPart = new AutoPart(newAutoPartViewModel);

            listReference.Insert(autoPartIndex, newAutoPart);

            if (oldAutoPart.autoPart.ID.Equals(autoPartsLayout.GetActiveAutoPartID())) {
                autoPartsLayout.SetAutoPartData(newAutoPartViewModel);
            }
            MessageBox.Show("Podatki avto dela so bili spremenjeni.");
            TireViewFormAdmin.shouldClose = true;
        }
        //============= DELETE EMPLOYEE SUCCESS ============//
        private void DeleteAutoPartSuccess(object response) {

            DeleteAutoPartViewModel autoPart = (DeleteAutoPartViewModel)response;

            BindingList<AutoPart> listReference = null;

            switch (autoPart.Category) {
                case "Tire": listReference = listTires; break;
                case "Light": listReference = listLights; break;
                case "Oil": listReference = listOils; break;
                case "Filter": listReference = listFilters; break;
                    //add default if somehow value wouldn't be as intended
            }

            if (listReference.SingleOrDefault(f => f.autoPart.ID.Equals(autoPart.ID)) == null) {
                return;
            }

            listReference.Remove(listReference.SingleOrDefault(f => f.autoPart.ID.Equals(autoPart.ID)));

            if (autoPart.ID.Equals(autoPartsLayout.GetActiveAutoPartID())) {
                autoPartsLayout.ClearAutoPartData();
            }

            MessageBox.Show("Izdelek je bil izbrisan");
        }
        
        //============= CREATE EMPLOYEE SUCCESS ============//
        private void CreateEmployeeSuccess(object response) {
            MessageBox.Show("Nov zaposlen je bil dodan v podatkovno bazo.");
        }
        //============= CREATE EMPLOYEE ERROR ============//
        private void CreateEmployeeError(object response) {
            MessageBox.Show("Narobe neki.");
        }
        
        //============= NOTIFY ICON CLICK ============//
        /*private void notifyIcon1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    circularProgressBarFix.Dispose();
                    WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                    return;
                }
                WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;

                circularProgressBarFix = new CircularProgressBar.CircularProgressBar();
                circularProgressBarFix.Visible = false;
                circularProgressBarFix.Size = new Size(77, 77); circularProgressBarFix.Location = new Point(currentStatus.Location.X - 9, currentStatus.Location.Y - 9);
                circularProgressBarFix.BackColor = Color.Transparent; circularProgressBarFix.ForeColor = Color.FromArgb(64, 64, 64);
                circularProgressBarFix.InnerColor = Color.FromArgb(73, 129, 206); circularProgressBarFix.OuterColor = Color.FromArgb(73, 129, 206);
                //circularProgressBarFix.SubscriptColor = Color.Transparent; circularProgressBarFix.SuperscriptColor = Color.Transparent;
                circularProgressBarFix.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner; circularProgressBarFix.AnimationSpeed = 500;
                circularProgressBarFix.InnerMargin = 2; circularProgressBarFix.InnerWidth = -1; circularProgressBarFix.OuterMargin = -25;
                circularProgressBarFix.OuterWidth = 25; circularProgressBarFix.ProgressWidth = 4; circularProgressBarFix.StartAngle = 270;
                circularProgressBarFix.Anchor = AnchorStyles.None;
                circularProgressBarFix.Anchor = AnchorStyles.Top; circularProgressBarFix.Anchor = AnchorStyles.Bottom;

                panel1.Controls.Add(circularProgressBarFix);

                circularProgressBarFix.Minimum = 0;
                circularProgressBarFix.Maximum = maxTime;
                circularProgressBarFix.Step = 1;

                int time = timeEdit1.Time.Hour * 3600 + timeEdit1.Time.Minute * 60 + timeEdit1.Time.Second;
                if (time >= 0)
                {
                    circularProgressBarFix.Value = maxTime - time;
                }
                if (time > 0)
                {
                    if (userStatus == 2)
                    {
                        circularProgressBarFix.ProgressColor = Color.Chartreuse;
                    }
                    else
                    {
                        circularProgressBarFix.ProgressColor = Color.Red;
                    }
                    circularProgressBarFix.SendToBack();
                    circularProgressBarFix.Visible = true;
                }




                return;
            }

            StatusButtonClick();
        }*/
        
            //============= GET USER EMAIL ============//
        public string GetUserEmail()
        {
            return "";// _User.Email;
        }
        
        //============= SET IMAGE FORMAT ============//
        public void SetImageFormat(ImageFormat imageFormat)
        {
            format = imageFormat;
        }


        //=============  IMAGE INTO STRING ============//
        public string ImageToByteArray(System.Drawing.Image imageIn)
        {
            byte[] arr;
            using (var ms = new MemoryStream())
            {
                if (format == null)
                {
                    imageIn.Save(ms, imageIn.RawFormat);
                }
                else
                {
                    imageIn.Save(ms, format);
                    format = null;
                }

                arr = ms.ToArray();
            }
            string s = Convert.ToBase64String(arr);
            return s;
        }
        //=============  STRING INTO IMAGE ============//
        public Bitmap stringToImage(string inputString)
        {
            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            return new Bitmap(ms);
        }





        //error and success handling
        protected virtual void OnSuccess(object response)
        {
            //if (response.Data.Message != null)
            //{
            //    MessageBox.Show(response.Data.Message);
            //}
        }
        protected virtual void OnError(List<MessageViewModel> response)
        {
            MessageBox.Show(response[0].Message);
        }


        //============= AUTO PARTS BUTTON MOUSE ENTER ============//
        private void autoPartsButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 1) { return; }
            autoPartsButton.ForeColor = Color.White;
        }
        //============= AUTO PARTS BUTTON MOUSE LEAVE ============//
        private void autoPartsButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 1) { return; }
            autoPartsButton.ForeColor = Color.Gainsboro;
        }
        //============= AUTO PARTS BUTTON CLICK ============//
        private void autoPartsButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel == 2) { Revert(historyButton); }
            else if (panel == 3) { Revert(settingsButton); }
            else if (panel == 4) { Revert(employeesButton); }
            else if (panel == 5) { Revert(ordersButton); }
            panel = 1;

            historyLayout.Visible = false;
            settingsLayout.Visible = false;
            companyLayout.Visible = false;
            ordersLayout.Visible = false;
            listUsers.Visible = false;

            autoPartsLayout.BringToFront();

            autoPartsLayout.Visible = true;

            if (friendPanelVisible <= 1)
            {
                //FunctionSummoner(1);
            }
            else if (friendPanelVisible == 2)
            {
                //string[] addingFriendsInformation = friendsLayout.SendInformationForAddingFriends();
                //FunctionSummoner(3, name: addingFriendsInformation[0], surname: addingFriendsInformation[1], email: addingFriendsInformation[2]);
            }
            else if (friendPanelVisible == 3)
            {
                //if (FriendRequestsLayout.which == 1)
                //{
                //    FunctionSummoner(19);
                //}
                //else
                //{
                //    FunctionSummoner(5);
                //}
            }


            autoPartsButton.BackColor = Color.FromArgb(43, 43, 43);
            autoPartsButton.ForeColor = Color.Orange;
            autoPartsButton.FlatAppearance.BorderColor = autoPartsButton.ForeColor;
        }


        //============= HISTORY BUTTON MOUSE ENTER ============//
        private void historyButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 2) { return; }
            historyButton.ForeColor = Color.White;
        }
        //============= HISTORY BUTTON MOUSE LEAVE ============//
        private void historyButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 2) { return; }
            historyButton.ForeColor = Color.Gainsboro;
        }
        //============= HISTORY BUTTON CLICK ============//
        private void historyButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout, 1); }
            else if (panel == 3) { Revert(settingsButton); ResetVisibility(historyLayout, 3); }
            else if (panel == 4) { Revert(employeesButton); ResetVisibility(companyLayout, 4); }
            else if (panel == 5) { Revert(ordersButton); ResetVisibility(ordersLayout, 5); }
            panel = 2;

            autoPartsLayout.Visible = false;
            settingsLayout.Visible = false;
            companyLayout.Visible = false;
            ordersLayout.Visible = false;
            listUsers.Visible = false;

            historyLayout.BringToFront();

            historyLayout.Visible = true;

            if (groupPanelVisible <= 1) {

            } else if (groupPanelVisible == 2) {

            } else {

            }


            historyButton.BackColor = Color.FromArgb(43, 43, 43);
            historyButton.ForeColor = Color.Orange;
            historyButton.FlatAppearance.BorderColor = historyButton.ForeColor;
        }


        //============= SETTING BUTTON MOUSE ENTER ============//
        private void settingsButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 3) { return; }
            settingsButton.ForeColor = Color.White;
        }
        //============= SETTING BUTTON MOUSE LEAVE ============//
        private void settingsButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 3) { return; }
            settingsButton.ForeColor = Color.Gainsboro;
        }
        //============= SETTING BUTTON CLICK ============//
        private void settingsButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout,1); }
            else if (panel == 2) { Revert(historyButton); ResetVisibility(historyLayout, 2); }
            else if (panel == 4) { Revert(employeesButton); ResetVisibility(companyLayout, 4); }
            else if (panel == 5) { Revert(ordersButton); ResetVisibility(ordersLayout, 5); }
            panel = 3;

            autoPartsLayout.Visible = false;
            historyLayout.Visible = false;
            companyLayout.Visible = false;
            listUsers.Visible = false;
            ordersLayout.Visible = false;

            settingsLayout.BringToFront();

            settingsLayout.Visible = true;
            

            settingsButton.BackColor = Color.FromArgb(43, 43, 43);
            settingsButton.ForeColor = Color.Orange;
            settingsButton.FlatAppearance.BorderColor = settingsButton.ForeColor;

        }


        //============= EMPLOYEES BUTTON MOUSE ENTER ============//
        private void employeesButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 4) { return; }
            employeesButton.ForeColor = Color.White;
        }
        //============= EMPLOYEES BUTTON MOUSE LEAVE ============//
        private void employeesButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 4) { return; }
            employeesButton.ForeColor = Color.Gainsboro;
        }
        //============= EMPLOYEES BUTTON CLICK ============//
        private void employeesButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout, 1); }
            else if (panel == 2) { Revert(historyButton); ResetVisibility(historyLayout, 2); }
            else if (panel == 3) { Revert(settingsButton); ResetVisibility(settingsButton, 3); }
            else if (panel == 5) { Revert(ordersButton); ResetVisibility(ordersLayout, 5); }

            panel = 4;

            if (companyLayout.which <= 1)
            {
                ////FunctionSummoner(31);
                //companyLayout.SetEmployeesDataControlSource(listEmployees);
            }

            listUsers.Visible = false;
            autoPartsLayout.Visible = false;
            historyLayout.Visible = false;
            settingsLayout.Visible = false;
            ordersLayout.Visible = false;

            companyLayout.BringToFront();

            companyLayout.Visible = true;



            employeesButton.BackColor = Color.FromArgb(43, 43, 43);
            employeesButton.ForeColor = Color.Orange;
            employeesButton.FlatAppearance.BorderColor = employeesButton.ForeColor;

        }


        //============= ORDERS BUTTON MOUSE ENTER ============//
        private void ordersButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 5) { return; }
            ordersButton.ForeColor = Color.White;
        }
        //============= ORDERS BUTTON MOUSE LEAVE ============//
        private void ordersButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 5) { return; }
            ordersButton.ForeColor = Color.Gainsboro;
        }
        //============= ORDERS BUTTON CLICK ============//
        private void ordersButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout, 1); }
            else if (panel == 2) { Revert(historyButton); ResetVisibility(historyLayout, 2); }
            else if (panel == 3) { Revert(settingsButton); ResetVisibility(settingsButton, 3); }
            else if (panel == 4) { Revert(employeesButton); ResetVisibility(companyLayout, 4); }

            panel = 5;

            //if (ordersLayout.which <= 1)
            //{
            //    //FunctionSummoner(32);//don't need to call this everytime since i've already got the list and
            //    //only this user can change that data so its independant to other user's doing
            //    ordersLayout.SetFavouritesDataControlSource(listFavourites);
            //}

            listUsers.Visible = false;
            autoPartsLayout.Visible = false;
            historyLayout.Visible = false;
            settingsLayout.Visible = false;
            companyLayout.Visible = false;

            ordersLayout.BringToFront();

            ordersLayout.Visible = true;

            ordersButton.BackColor = Color.FromArgb(43, 43, 43);
            ordersButton.ForeColor = Color.Orange;
            ordersButton.FlatAppearance.BorderColor = ordersButton.ForeColor;

        }



        //============= EXIT TOP RIGHT CLICK ============//
        private void exitButton_Click(object sender, EventArgs e)
        {
            userStatus = 0;
            FunctionSummoner(29, userStatus: 0);
            this.Close();
            Application.Exit();
        }









        //============= REVERT BUTTON TO ORIGINAL COLOR ============//
        private void Revert(Button b)
        {
            b.ForeColor = Color.Gainsboro;
            b.BackColor = Color.FromArgb(64, 64, 64);
            b.FlatAppearance.BorderColor = original;
        }
        //============= RESET THE VISIBILITY OF THE GIVEN LAYOUT ============//
        private void ResetVisibility(object layout, int layoutHandle)
        {
            switch (layoutHandle) {
                //case 1: ()
                //case 2: historyLayout.ResetVisibility();break;
                case 3: settingsLayout.ResetVisibility(); break;
                case 4: companyLayout.ResetVisibility(); break;
                //case 5: ordersLayout.ResetVisibility(); break;
            }
        }


        //moving the form around anyyywhere you want
        private bool mouseDown;
        private Point lastLocation;

        //============= FORM MAIN ============//
        private void formMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        //============= FORM MAIN MOVE ============//
        private void formMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        //============= FORM MAIN MOUSE UP ============//
        private void formMain_MouseUp(object sender, MouseEventArgs e) { mouseDown = false; }

        //============= LOGOUT ============//
        private void logoutButton_Click(object sender, EventArgs e)
        {
            userStatus = 0;
            FunctionSummoner(29, userStatus: 0);

            logout = true;
            formLoginAdmin formLoginObj = new formLoginAdmin();
            formLoginObj.Show();
            this.Close();
        }

        //============= GET FRIENDS STATUS EVERY 2 SECONDS ============//
        private void timer1_Tick(object sender, EventArgs e)
        {
            //FunctionSummoner(1);
        }

        //============= FORM MAIN CLOSED ============//
        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!logout) { Application.Exit(); }
            notifyIcon1.Dispose();
        }



        //============= MINIMIZIN THE FORM ============//
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        circularProgressBarFix.Dispose();
                        this.WindowState = FormWindowState.Minimized;
                        this.ShowInTaskbar = false;
                    }
                    // If you don't want to do the default action then break
                    break;
            }
            base.WndProc(ref m);
        }
    }
}
