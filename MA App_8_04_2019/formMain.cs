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
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;
using LeaveMeAlone._AutoParts.Tires;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LeaveMeAlone._Cart;
using LMA.Data.UI.ViewModels.ViewModels.Order;

namespace LeaveMeAlone
{
    public partial class formMain : Form
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

        private UserProfileViewForm userProfile = null;
        
        private int maxTime = 0;

        private string currentCategory;

        public static formMain mainForm = null;

        //============= SO YOU GET YOUR GROUPS WHEN YOU WANT TO INVITE SOMEBODY TO YOUR GROUP WITHOUT SHOWING YOUR GROUPS -> JUST GETTING THEM =============//
        private bool dontShow = false;

        //============= BINDING LISTS =============//
        private BindingList<Employee> listEmployees = new BindingList<Employee>(); //for showing all employees in the company

        private BindingList<AutoPart> listTires = new BindingList<AutoPart>(); //for showing all tires 

        private BindingList<AutoPart> listLights = new BindingList<AutoPart>(); //for showing all lights

        private BindingList<AutoPart> listOils = new BindingList<AutoPart>(); //for showing all oils

        private BindingList<AutoPart> listFilters = new BindingList<AutoPart>(); //for showing all filters

        private BindingList<CartItem> listCart = new BindingList<CartItem>(); //for showing all cart items

        private BindingList<Order> listOrders = new BindingList<Order>(); //for showing all orders

        private BindingList<Employee> listDescriptions = new BindingList<Employee>();

        private Dictionary<string, int> friendStatus = new Dictionary<string, int>();

        private List<string> favouritesEmails = new List<string>();

        //private Dictionary<string, string> userProfilePicture= new Dictionary<string, string>();

        //=============  =============//


        private readonly string _Token;
        private readonly UserViewModel _User;

        //============= RESPONSE DELEGATES =============//

        //TEMPORARY
        private delegate void OResponseDelegate(object response);

        private delegate void LMVMResponseDelegate(List<MessageViewModel> response);

        private OResponseDelegate DelShowFriends;

        //private UVMResponseDelegate DelShowFriends;
        private OResponseDelegate DelShowSuitableUsers;
        private OResponseDelegate DelShowGroupMembers;

        private OResponseDelegate DelShowEmployees;
        private OResponseDelegate DelShowAutoParts;

        // CART
        private OResponseDelegate DelAddToCart;
        private OResponseDelegate DelRemoveSomeFromCart;
        private OResponseDelegate DelRemoveFromCart;
        private OResponseDelegate DelShowCartItems;

        // ORDER
        private OResponseDelegate DelAddOrder;
        private OResponseDelegate DelShowOrders;

        private OResponseDelegate DelShowFavourites;

        private OResponseDelegate DelShowSelectedUserProfile;


        private OResponseDelegate DelSuccess;
        private LMVMResponseDelegate DelError;
        private OResponseDelegate DelFriendRequestSuccess;
        private LMVMResponseDelegate DelFriendRequestError;
        private OResponseDelegate DelCreateGroupSuccess;
        private LMVMResponseDelegate DelCreateGroupError;
        private OResponseDelegate DelDeleteFriendSuccess;
        private LMVMResponseDelegate DelDeleteFriendError;
        private OResponseDelegate DelJoinGroupSuccess;
        private LMVMResponseDelegate DelJoinGroupError;
        private OResponseDelegate DelLeaveGroupSuccess;
        private OResponseDelegate DelAcc_RejGroupRequestSuccess;
        private OResponseDelegate DelChangePasswordSuccess;
        private OResponseDelegate DelSendInviteSuccess;
        private LMVMResponseDelegate DelSendInviteError;

        private OResponseDelegate DelAcceptFriendSuccess;//used both for accept friend request and reject friend request
        private LMVMResponseDelegate DelAcceptFriendError;//used both for accept friend request and reject friend request


        private OResponseDelegate DelShowGroups;
        private OResponseDelegate DelShowSuitableGroups;
        private OResponseDelegate DelShowGroupsWithouGivenUser;


        private OResponseDelegate DelDeleteSuccess;
        private LMVMResponseDelegate DelDeleteError;

        private OResponseDelegate DelChangeFavourite;

        //private delegate void FIVMResponseDelegate(IRestResponse<List<FriendInviteViewModel>> response);
        //private FIVMResponseDelegate DelShowReceivedFriendRequests;
        //private FIVMResponseDelegate DelShowSentFriendRequests;


        private OResponseDelegate DelShowSentGroupRequests;
        private OResponseDelegate DelShowReceivedGroupRequests;
        private OResponseDelegate DelShowSentGroupInvites;
        private OResponseDelegate DelShowReceivedGroupInvites;


        private OResponseDelegate DelChangeInformationSuccess;

        
        private LMVMResponseDelegate DelBadRequestSameStatus1;
        private LMVMResponseDelegate DelBadRequestSameStatus2;//MAKE ROUND IMAGE AND SENT THAT TO SERVER INSTEAD OF DOING IT EVERY TIME YOU'0RE SHOWING A FRINED

        public formMain(string token, UserViewModel user)
        {
            InitializeComponent();
            
            original = settingsButton.FlatAppearance.BorderColor;
            //panel2.SendToBack(); panel1.SendToBack();
            //friendsLayout.BringToFront();//not sure if neccesary
            //settingsLayout.BringToFront();
            //groupsLayout.BringToFront();
            //companyLayout.BringToFront();
            //favouritesLayout.BringToFront();

            //============= COMPANY - COLLEAGUES =============//
            DelShowEmployees = this.ShowEmployees;
            
            //============= SELECTED USER PROFILE =============//
            DelShowSelectedUserProfile = this.ShowSelectedUserProfile;

            //============= MY PROFILE =============//
            DelDeleteSuccess = this.ShowDeleteSuccess;
            DelDeleteError = this.ShowDeleteError;

            DelChangeInformationSuccess = this.ChangeMyInformation;
            DelChangePasswordSuccess = this.ChangePasswordSuccess;

            //=============  =============//
            //DelError = this.OnError;
            //DelSuccess = this.OnSuccess;

            //============= AUTO PARTS =============//
            DelShowAutoParts = this.ShowAutoParts;

            //============= CART - AUTOPARTS =============//
            DelAddToCart = this.ShowAddToCart;
            DelRemoveSomeFromCart = this.ShowRemoveSomeFromCart;
            DelRemoveFromCart = this.ShowRemoveFromCart;
            DelShowCartItems = this.ShowCartItems;

            //============= ORDER =============//
            DelAddOrder = this.ShowAddOrder;
            DelShowOrders = this.ShowOrders;

            _MainErrorMessageHandler.SetMainForm(this);

            mainForm = this;

            _Token = token;
            _User = user;
            userStatus = 2;

            notifyIcon1.Icon = Properties.Resources.GreenIcon;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            //FunctionSummoner(29, userStatus: userStatus);
            //FunctionSummoner(32);
            //FunctionSummoner(31);
            //FunctionSummoner(36);//get availbality constraints

            nameAndSurnameText.Text = "Pozdravljeni, " + _User.Name + " " + _User.Surname;

            if (_User.ProfilePicture != null && !_User.ProfilePicture.Equals(""))
            {
                profilePicture.BackgroundImage = stringToImage(_User.ProfilePicture);
            }

            settingsLayout.SetMyProfileInformation(_User, profilePicture.BackgroundImage);
        }
        
        /**/
        //============= GET WANTED USER =============//
        private void GetWantedUser(string email)//function id = 4
        {
            if (email.Equals(_User.Email))
            {
                return;
            }
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
                newInfo.ProfilePicture
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
        //============= GET ALL AUTOPART OF THE GIVEN CATEGORY =============// function id = 37
        private void GetAutoParts(string category)//function id = 37
        {
            currentCategory = category;
            category = System.Web.HttpUtility.UrlEncode(category);

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/AutoPart/category", Method.GET);

            request.AddHeader("category", category);


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
        //============= GET ALL AUTOPARTS THAT MATCH THE FILTERS =============// function id = 38
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
        //============= ADD AUTO PART TO CART =============//
        private void AddAutoPartToCart(AutoPartViewModel autoPart, int amount)//function id = 39
        {
            CartItemViewModel addPart = new CartItemViewModel();

            addPart.AutoPartID = autoPart.ID;
            addPart.Amount = amount;

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Cart/item", Method.POST);//CHANGE 

            request.AddJsonBody(addPart);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<CartItemViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelAddToCart, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= REMOVE AUTOPART AMOUNT FROM CART =============//
        private void RemoveAutoPartFromCart(AutoPartViewModel autoPart, int amount)//function id = 41
        {
            CartItemViewModel removePart = new CartItemViewModel();

            removePart.AutoPartID = autoPart.ID;
            removePart.Amount = amount;

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Cart/removeSome", Method.PUT);//CHANGE 

            request.AddJsonBody(removePart);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<CartItemViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelRemoveSomeFromCart, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= REMOVE ALL AUTOPART FROM CART =============//
        private void RemoveAllAutoPartFromCart(AutoPartViewModel autoPart)//function id = 41
        {
            CartItemViewModel removePart = new CartItemViewModel();

            removePart.AutoPartID = autoPart.ID;

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Cart/removeAll", Method.DELETE);//CHANGE 

            request.AddJsonBody(removePart);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<CartItemViewModel>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelRemoveFromCart, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= GET CART ITEMS FOR THIS USER =============//
        private void GetCartItems()//function id = 42
        {
            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Cart/myItems", Method.GET);//CHANGE 

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<List<CartItemViewModel>>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelShowCartItems, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= ADD ORDER FOR THIS USER =============//
        private void AddOrder(string password)//function id = 43
        {
            AddOrderViewModel order = new AddOrderViewModel();
            order.CartItems = new List<CartItemViewModel>();

            foreach (var v in listCart) {
                order.CartItems.Add(v.cartItem);
            }

            order.Password = password;

            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Order/addOrder", Method.POST);//CHANGE 

            request.AddJsonBody(order);

            request.AddParameter("Authorization", string.Format("Bearer " + _Token), ParameterType.HttpHeader);
            client.ExecuteAsync<ClientResponseViewModel<object>>(request, (response) => {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                    this.Invoke(DelAddOrder, response.Data.Object);
                } else {
                    MessageBox.Show(response.Data.Messages[0].Message);
                }
            });
        }
        //============= GET ORDERS FOR THIS USER =============//
        private void GetOrders()//function id = 44
        {
            var client = new RestClient("http://localhost:5000");

            var request = new RestRequest("api/Order/myOrders", Method.GET);//CHANGE 

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
            EmployeeViewModel selectedUserProfile = (EmployeeViewModel)result;

            if (selectedUserProfile == null)
            {//could happen if the list isn't updated and somebody deletes his account and you click his acccount...
                //tell user that that user does not exist anymore
                return;
            }


            if (panel == 1)
            {
                //autoPartsLayout.ShowThisUserProfile(selectedUserProfile);
            }
            else if (panel == 2)
            {
                //checkoutLayout.ShowThisUserProfile(selectedUserProfile);
            }
            else if (panel == 4)
            {
                //show status here too
                informationLayout.ShowThisUserProfile(selectedUserProfile);
            }
            else if (panel == 5)
            {
                //show status here too
                servicesLayout.ShowThisUserProfile(selectedUserProfile);
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
            informationLayout.SetEmployeesDataControlSource(listEmployees);
        }
        //============= SHOW AUTOPARTS =============//
        protected virtual void ShowAutoParts(object result) {
            List<AutoPartViewModel> listOfAutoParts = (List<AutoPartViewModel>)result;

            BindingList<AutoPart> listReference = null;
            if (listOfAutoParts == null) {
                return;
            }
            switch (currentCategory) {
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
        //============= SHOW CART ITEMS =============//
        protected virtual void ShowCartItems(object result) {
            List<CartItemViewModel> autoParts = (List<CartItemViewModel>)result;

            listCart.Clear();

            if (autoParts != null) {
                foreach (var cartItem in autoParts) {
                    listCart.Add(new CartItem(cartItem));
                }
            }

            cartLayout.SetCartItemsDataControlSource(listCart);
        }
        //============= SHOW AUTOPART ADDED FROM CART LIST =============//
        protected virtual void ShowAddToCart(object result) {
            CartItemViewModel cartItem = (CartItemViewModel)result;
            CartItem item = listCart.SingleOrDefault(f => f.cartItem.AutoPartID.Equals(cartItem.AutoPartID));
            if (item != null) {
                listCart.Remove(item);
            }
            CartItem newItem = new CartItem(cartItem);
            listCart.Add(newItem);

            switch (cartItem.AutoPart.Category) {
                case "Tire": TireViewForm.tireViewFormAdmin.SetCartSuccess(newItem, 1); break;
                case "Light": LightViewForm.lightViewForm.SetCartSuccess(newItem, 1); break;
                case "Oil": OilViewForm.oilViewForm.SetCartSuccess(newItem, 1); break;
                case "Filter": FilterViewForm.filterViewForm.SetCartSuccess(newItem, 1); break;
                //add default if somehow value wouldn't be as intended
            }
        }
        //============= SHOW AUTOPART REMOVES ALL FROM CART LIST =============//
        protected virtual void ShowRemoveFromCart(object result) {
            CartItemViewModel cartItem = (CartItemViewModel)result;

            listCart.Remove(listCart.SingleOrDefault(f => f.cartItem.AutoPartID.Equals(cartItem.AutoPartID)));

            switch (cartItem.AutoPart.Category) {
                case "Tire": TireViewForm.tireViewFormAdmin.SetCartSuccess(null, 3) ; break;
                case "Light": LightViewForm.lightViewForm.SetCartSuccess(null, 3) ; break;
                case "Oil": OilViewForm.oilViewForm.SetCartSuccess(null, 3) ; break;
                case "Filter": FilterViewForm.filterViewForm.SetCartSuccess(null, 3); break;
                //add default if somehow value wouldn't be as intended
            }
        }
        //============= SHOW AUTOPART REMOVES SOME FROM CART LIST =============//
        protected virtual void ShowRemoveSomeFromCart(object result) {
            CartItemViewModel cartItem = (CartItemViewModel)result;

            listCart.Remove(listCart.SingleOrDefault(f => f.cartItem.AutoPartID.Equals(cartItem.AutoPartID)));

            CartItem item = new CartItem(cartItem);

            listCart.Add(item);

            switch (cartItem.AutoPart.Category) {
                case "Tire": TireViewForm.tireViewFormAdmin.SetCartSuccess(item, 2); break;
                case "Light": LightViewForm.lightViewForm.SetCartSuccess(item, 2); break;
                case "Oil": OilViewForm.oilViewForm.SetCartSuccess(item, 2); break;
                case "Filter": FilterViewForm.filterViewForm.SetCartSuccess(item, 2); break;
                    //add default if somehow value wouldn't be as intended
            }
        }
        //============= SHOW ORDER ADDED =============//
        protected virtual void ShowAddOrder(object result) {
            listCart.Clear();
            MessageBox.Show("Naročilo je bilo oddano. :)");


            //switch (cartItem.AutoPart.Category) {
            //    case "Tire": TireViewForm.tireViewFormAdmin.SetCartSuccess(newItem, 1); break;
            //    case "Light": LightViewForm.lightViewForm.SetCartSuccess(newItem, 1); break;
            //    case "Oil": OilViewForm.oilViewForm.SetCartSuccess(newItem, 1); break;
            //    case "Filter": FilterViewForm.filterViewForm.SetCartSuccess(newItem, 1); break;
            //        //add default if somehow value wouldn't be as intended
            //}
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
                    realOrders.Add(order.OrderID, new List<OrderViewModel> {order});
                }
            }
            if (orders != null) {
                foreach (var order in realOrders.Values) {
                    listOrders.Add(new Order(order));
                }
            }
            cartLayout.SetOrdersDataControlSource(listOrders);
        }
        //=============SERVER-CLIENT COMMUNICATION FUNCTION SUMMONER=============//         **********INSTEAD OF SPECIFYING, JUST PUT VIEWMODELS IN HERE
        public void FunctionSummoner(int functionID, string name = "", string surname = "",
            string email = "", string groupName = "", string password = "", int privacy = 0,
            string groupID = "", bool owner = false, bool dontShow = false,
            string newPassword = null, int userStatus = 2, Image image = null,
            bool favourite = false, UserViewModel user = null, UserProfileViewForm userProfile = null,
            List<string> groupsIDs = null, string phoneNumber = null, List<string> emails = null,
            int inviteType = 0, ChangeUserViewModel newInfo = null, string category = null,
            string technicalDescription = null, decimal priceMin = 0, decimal priceMax = 0,
            AutoPartViewModel autoPart = null, int amount = 0)
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
                case 37: GetAutoParts(category);break;
                case 38: GetSuitableAutoParts(category, technicalDescription, priceMin, priceMax);break;
                case 39: AddAutoPartToCart(autoPart, amount);break;
                case 40: RemoveAutoPartFromCart(autoPart, amount);break;
                case 41: RemoveAllAutoPartFromCart(autoPart);break;
                case 42: GetCartItems(); break;
                case 43: AddOrder(password); break;
                case 44: GetOrders(); break;
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
            formLogin loginForm = new formLogin();
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
            ChangeUserViewModel user = (ChangeUserViewModel)response;
            
            _User.Name = user.Name;
            _User.Surname = user.Surname;
            _User.PhoneNumber = user.PhoneNumber;
            _User.Address = user.Address;
            _User.AddressNumber = user.AddressNumber;
            _User.Country = user.Country;

            if (user.ProfilePicture != null)
            {
                _User.ProfilePicture = user.ProfilePicture;
                profilePicture.BackgroundImage = stringToImage(user.ProfilePicture);
            }
            
            MyProfile.myProfile.setInformation(_User);
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
            return _User.Email;
        }
        
        //============= CHECKS IF THE AUTOPART IS IN THE CHECKOUT LIST ============// - was too lazy to make 2 delegates so i mae this function its the same shit just works a bit slower i believe (not gonna feel)
        public bool IsInCheckoutList(AutoPartViewModel autoPart) {
            if (listCart.SingleOrDefault(f => f.cartItem.AutoPartID.Equals(autoPart.ID)) != null) {
                return true;
            }
            return false;
        }


        //======== IMAGE CONVERTION, SETTING FORMAT FUNCTIONS ========// 
        ////////////////////////////////////////////////////////////////
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
        ////////////////////////////////////////////////////////////////




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

        //======== AUTOPARTS BUTTON ========// 
        ////////////////////////////////////////////////////////////////
        //============= AUTOPARTS BUTTON MOUSE ENTER ============//
        private void autoPartsButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 1) { return; }
            autoPartsButton.ForeColor = Color.White;
        }
        //============= AUTOPARTS BUTTON MOUSE LEAVE ============//
        private void autoPartsButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 1) { return; }
            autoPartsButton.ForeColor = Color.Gainsboro;
        }
        //============= AUTOPARTS BUTTON CLICK ============//
        private void autoPartsButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel == 2) { Revert(cartButton); }
            else if (panel == 3) { Revert(settingsButton); }
            else if (panel == 4) { Revert(informationButton); }
            else if (panel == 5) { Revert(servicesButton); }
            panel = 1;

            autoPartsLayout.Visible = true;

            cartLayout.Visible = false;
            settingsLayout.Visible = false;
            informationLayout.Visible = false;
            servicesLayout.Visible = false;
            listUsers.Visible = false;

            //autoPartsLayout.BringToFront();
            

            autoPartsButton.BackColor = Color.FromArgb(43, 43, 43);
            autoPartsButton.ForeColor = Color.Orange;
            autoPartsButton.FlatAppearance.BorderColor = autoPartsButton.ForeColor;

        }
        ////////////////////////////////////////////////////////////////

        //======== CART BUTTON ========// 
        ////////////////////////////////////////////////////////////////
        //============= CART BUTTON MOUSE ENTER ============//
        private void cartButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 2) { return; }
            cartButton.ForeColor = Color.White;
        }
        //============= CART BUTTON MOUSE LEAVE ============//
        private void cartButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 2) { return; }
            cartButton.ForeColor = Color.Gainsboro;
        }
        //============= CART BUTTON CLICK ============//
        private void cartButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout, 1); }
            else if (panel == 3) { Revert(settingsButton); ResetVisibility(cartLayout, 3); }
            else if (panel == 4) { Revert(informationButton); ResetVisibility(informationLayout, 4); }
            else if (panel == 5) { Revert(servicesButton); ResetVisibility(servicesLayout, 5); }
            panel = 2;


            cartLayout.Visible = true;
            autoPartsLayout.Visible = false;
            settingsLayout.Visible = false;
            informationLayout.Visible = false;
            servicesLayout.Visible = false;
            listUsers.Visible = false;

            //cartLayout.BringToFront();
            //tle true
            

            if (cartLayout.which == 1)
            {
                FunctionSummoner(42);
            }
            else if (cartLayout.which == 2)
            {
                FunctionSummoner(43);
            }

            cartButton.BackColor = Color.FromArgb(43, 43, 43);
            cartButton.ForeColor = Color.Orange;
            cartButton.FlatAppearance.BorderColor = cartButton.ForeColor;
        }
        ////////////////////////////////////////////////////////////////

        //======== SETTINGS BUTTON ========// 
        ////////////////////////////////////////////////////////////////
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
            else if (panel == 2) { Revert(cartButton); ResetVisibility(cartLayout, 2); }
            else if (panel == 4) { Revert(informationButton); ResetVisibility(informationLayout, 4); }
            else if (panel == 5) { Revert(servicesButton); ResetVisibility(servicesLayout, 5); }
            panel = 3;

            autoPartsLayout.Visible = false;
            cartLayout.Visible = false;
            informationLayout.Visible = false;
            listUsers.Visible = false;
            servicesLayout.Visible = false;

            settingsLayout.BringToFront();

            settingsLayout.Visible = true;
            

            settingsButton.BackColor = Color.FromArgb(43, 43, 43);
            settingsButton.ForeColor = Color.Orange;
            settingsButton.FlatAppearance.BorderColor = settingsButton.ForeColor;

        }
        ////////////////////////////////////////////////////////////////

        //======== INFORMATION BUTTON ========// 
        ////////////////////////////////////////////////////////////////
        //============= INFORMATION BUTTON MOUSE ENTER ============//
        private void informationButton_MouseEnter(object sender, EventArgs e)
        {
            if (panel == 4) { return; }
            informationButton.ForeColor = Color.White;
        }
        //============= INFORMATION BUTTON MOUSE LEAVE ============//
        private void informationButton_MouseLeave(object sender, EventArgs e)
        {
            if (panel == 4) { return; }
            informationButton.ForeColor = Color.Gainsboro;
        }
        //============= INFORMATION BUTTON CLICK ============//
        private void informationButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout, 1); }
            else if (panel == 2) { Revert(cartButton); ResetVisibility(cartLayout, 2); }
            else if (panel == 3) { Revert(settingsButton); ResetVisibility(settingsButton, 3); }
            else if (panel == 5) { Revert(servicesButton); ResetVisibility(servicesLayout, 5); }

            panel = 4;

            if (informationLayout.which <= 1)
            {
                ////FunctionSummoner(31);
                //companyLayout.SetEmployeesDataControlSource(listEmployees);
            }

            listUsers.Visible = false;
            autoPartsLayout.Visible = false;
            cartLayout.Visible = false;
            settingsLayout.Visible = false;
            servicesLayout.Visible = false;

            informationLayout.BringToFront();

            informationLayout.Visible = true;



            informationButton.BackColor = Color.FromArgb(43, 43, 43);
            informationButton.ForeColor = Color.Orange;
            informationButton.FlatAppearance.BorderColor = informationButton.ForeColor;

        }
        ////////////////////////////////////////////////////////////////

        //======== SERVICES BUTTON ========// 
        ////////////////////////////////////////////////////////////////
        //============= SERVICES BUTTON MOUSE ENTER ============//
        private void servicesButton_MouseEnter(object sender, EventArgs e)
        {

        }
        //============= SERVICES BUTTON MOUSE LEAVE ============//
        private void servicesButton_MouseLeave(object sender, EventArgs e)
        {

        }
        //============= SERVICES BUTTON CLICK ============//
        private void servicesButton_Click(object sender, EventArgs e)
        {
            //revert color changes on the button that was active before
            if (panel <= 1) { Revert(autoPartsButton); ResetVisibility(autoPartsLayout, 1); }
            else if (panel == 2) { Revert(cartButton); ResetVisibility(cartLayout, 2); }
            else if (panel == 3) { Revert(settingsButton); ResetVisibility(settingsButton, 3); }
            else if (panel == 4) { Revert(informationButton); ResetVisibility(informationLayout, 4); }

            panel = 5;

            if (servicesLayout.which <= 1)
            {
                //FunctionSummoner(32);//don't need to call this everytime since i've already got the list and
                //only this user can change that data so its independant to other user's doing
                //servicesLayout.SetFavouritesDataControlSource(listFavourites);
            }

            listUsers.Visible = false;
            autoPartsLayout.Visible = false;
            cartLayout.Visible = false;
            settingsLayout.Visible = false;
            informationLayout.Visible = false;

            servicesLayout.BringToFront();

            servicesLayout.Visible = true;

            servicesButton.BackColor = Color.FromArgb(43, 43, 43);
            servicesButton.ForeColor = Color.Orange;
            servicesButton.FlatAppearance.BorderColor = servicesButton.ForeColor;

        }
        ////////////////////////////////////////////////////////////////


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
                case 2: cartLayout.ResetVisibility();break;
                case 3: settingsLayout.ResetVisibility(); break;
                case 4: informationLayout.ResetVisibility(); break;
                case 5: servicesLayout.ResetVisibility(); break;
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
            logout = true;
            formLogin formLoginObj = new formLogin();
            formLoginObj.Show();
            this.Close();
        }

         //============= FORM MAIN CLOSED ============//
        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //notifyIcon1.Dispose();
            if (!logout) { Application.Exit(); }
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
