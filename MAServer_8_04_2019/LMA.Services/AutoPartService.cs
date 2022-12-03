using AutoMapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;
using LMA.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services
{
    public class AutoPartService : IAutoPartService
    {
        private readonly IWriter<AutoPartModel> _AutoPartWriteService;
        private readonly IAutoPartReader<AutoPartModel> _AutoPartReadService;
        private readonly IAdminReader<AdminModel> _adminReadService;
        private readonly IMapper _mapper;
        private readonly UserService _UserService;

        public AutoPartService(IWriter<AutoPartModel> AutoPartWriteService,
                            IAutoPartReader<AutoPartModel> AutoPartReadService,
                            IAdminReader<AdminModel> adminReadService,
                            IMapper Mapper,
                            UserService UserService
            )
        {
            _AutoPartWriteService = AutoPartWriteService;
            _AutoPartReadService = AutoPartReadService;
            _adminReadService = adminReadService;
            _mapper = Mapper;
            _UserService = UserService;
        }

        public async Task<ReturnViewModel> AddAutoPart(AutoPartViewModel newAutoPart)
        {
			ReturnViewModel result = new ReturnViewModel();
            AutoPartModel autoPartExists = await _AutoPartReadService.GetAutoPartByName(newAutoPart.Name);

            if (autoPartExists == null) {
                AutoPartModel autoPart = _mapper.Map<AutoPartViewModel, AutoPartModel>(newAutoPart);

                await _AutoPartWriteService.Create(autoPart);

                result.Result.Messages.Add(new MessageViewModel(3)); //CHANGE THE MESSAGE
                return result;
            }
            result.Ok = false;
            result.Result.Messages.Add(new MessageViewModel(2));//CHANGE THE MESSAGE
            return result;
        }

        public async Task<ReturnViewModel> UpdateAutoPart(Guid adminID, ChangeAutoPartViewModel changeAutoPart)
        {
			ReturnViewModel result = new ReturnViewModel();

            AutoPartModel newAutoPartInfo = await _AutoPartReadService.GetAutoPartByID(changeAutoPart.ID);

            if (newAutoPartInfo == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(6));
                return result;
            }

            AdminModel admin = await _adminReadService.GetAdminByID(adminID);

            if (admin == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(6));
                return result;
            }

            if (admin.Password.Equals(changeAutoPart.Password)){
                if (!string.IsNullOrEmpty(changeAutoPart.Name))
                    newAutoPartInfo.Name = changeAutoPart.Name;
                if (newAutoPartInfo.Price > 0)
                    newAutoPartInfo.Price = changeAutoPart.Price;
                if (!string.IsNullOrEmpty(changeAutoPart.ProducerName))
                    newAutoPartInfo.ProducerName = changeAutoPart.ProducerName;
                if (!string.IsNullOrEmpty(changeAutoPart.TechnicalDetails))
                    newAutoPartInfo.TechnicalDetails = changeAutoPart.TechnicalDetails;
                if (changeAutoPart.DeliveryDeadline > 0)
                    newAutoPartInfo.DeliveryDeadline = changeAutoPart.DeliveryDeadline;
                if (!string.IsNullOrEmpty(changeAutoPart.Description))
                    newAutoPartInfo.Description = changeAutoPart.Description;
                if (!string.IsNullOrEmpty(changeAutoPart.Picture))
                    newAutoPartInfo.Picture = Convert.FromBase64String(changeAutoPart.Picture);

                result.Result.Object = await _AutoPartWriteService.Update(newAutoPartInfo);

                ChangeAutoPartViewModel res = _mapper.Map<AutoPartModel, ChangeAutoPartViewModel>(newAutoPartInfo);

                result.Result.Object = res;
                result.Result.Messages.Add(new MessageViewModel(3));
                return result;
            }
            else
            {
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(35));
            }
            return result;
        }

        public async Task<ReturnViewModel> DeleteAutoPart(Guid adminID, DeleteAutoPartViewModel deleteAutoPart) {
            ReturnViewModel result = new ReturnViewModel();
            AdminModel admin = await _adminReadService.GetAdminByID(adminID);

            AutoPartModel autoPart = await _AutoPartReadService.GetAutoPartByID(deleteAutoPart.ID);

            if (admin.Password == deleteAutoPart.Password) {
                long x = await _AutoPartWriteService.Delete(deleteAutoPart.ID);
                DeleteAutoPartViewModel deletedAutoPart = new DeleteAutoPartViewModel();
                deletedAutoPart.ID = deleteAutoPart.ID;
                deletedAutoPart.Category = autoPart.Category;

                result.Result.Object = deletedAutoPart;
                result.Result.Messages.Add(new MessageViewModel(3));
                return result;
            } else {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(10));
                return result;
            }
        }
        

  //      public async Task<Guid> GetAutoPartByName(string autoPartName)
  //      {
  //          AutoPartModel model = await _AutoPartReadService.GetAutoPartByName(autoPartName);
  //          return model.Id;
  //      }

  //      public async Task<AutoPartViewModel> GetTenantDataById(Guid Tenant_Id)
  //      {
  //          AutoPartModel model = await _AutoPartReadService.GetAutoPartByID(Tenant_Id);
  //          AutoPartViewModel result = _mapper.Map<AutoPartModel, AutoPartViewModel>(model);
  //          return result;
  //      }

  //      public async Task<AutoPartViewModel> GetTenantDataByName(string Tenant_Name)
  //      {
  //          AutoPartModel model = await _AutoPartReadService.GetAutoPartByName(Tenant_Name);
  //          AutoPartViewModel result = _mapper.Map<AutoPartModel, AutoPartViewModel>(model);
  //          return result;
  //      }

		//public async Task<ReturnViewModel> SetTenantData(Guid User_Id, AutoPartViewModel model)
  //      {
		//	ReturnViewModel result = new ReturnViewModel();
  //          AutoPartModel tenant = _mapper.Map<AutoPartViewModel, AutoPartModel>(model);
  //          //UserViewModel user = await _UserService.GetUserById(User_Id);
  //          UserViewModel user = new UserViewModel();
  //          if (user.Role == "Master")
  //          {
  //              result.Result.Object = await _AutoPartWriteService.Update(tenant);
		//		result.Result.Messages.Add(new MessageViewModel(3));
  //          }
  //          else
  //          {
		//		result.Ok = false;
		//		result.Result.Messages.Add(new MessageViewModel(35));
		//	}
  //          return result;
  //      }

		//public async Task<ReturnViewModel> GetTenantTimeParametersOfUser(Guid User_Id)
		//{
		//	ReturnViewModel result = new ReturnViewModel();
		//	AutoPartModel res = await _AutoPartReadService.GetTenantDataOfUser(User_Id);
		//	if (res == null)
		//	{
		//		result.Ok = false;
		//		result.Result.Messages.Add(new MessageViewModel(28));
		//		return result;
		//	}

		//	TimeSettingsViewModel tmp = _mapper.Map<AutoPartModel, TimeSettingsViewModel>(res);
		//	result.Result.Object = tmp;
		//	result.Result.Messages.Add(new MessageViewModel(3));
		//	return result;
		//}

		//public async Task<ReturnViewModel> GetCustomTimeParametersOfUser(Guid User_Id)
		//{
  //          ReturnViewModel result = new ReturnViewModel();

  //          UserDataModel temp = await _UserService.GetDataOfUser(User_Id);
  //          AutoPartModel tenantData = await _AutoPartReadService.GetTenantDataOfUser(User_Id);

  //          TimeSettingsViewModel CustomSettings = _mapper.Map<UserDataModel, TimeSettingsViewModel>(temp);
  //          TimeSettingsViewModel TenantSettings = _mapper.Map<AutoPartModel, TimeSettingsViewModel>(tenantData);
  //          AllTimeSettingsViewModel res = new AllTimeSettingsViewModel() { TenantTime = TenantSettings, CustomTime = CustomSettings };
  //          result.Result.Object = res;
  //          result.Result.Messages.Add(new MessageViewModel(3));
  //          return result;
  //      }

            

        public async Task<ReturnViewModel> GetSubCategoryAutoParts(string subCategory) {
            ReturnViewModel result = new ReturnViewModel();

            List<AutoPartModel> autoParts = await _AutoPartReadService.GetSubCategoryAutoParts(subCategory);

            List<AutoPartViewModel> autoPartViewModel = _mapper.Map<List<AutoPartModel>, List<AutoPartViewModel>>(autoParts);

            result.Result.Object = autoPartViewModel;
            //add message as well?
            return result;
        }

        public async Task<ReturnViewModel> GetCategoryAutoParts(string category) {
            ReturnViewModel result = new ReturnViewModel();

            List<AutoPartModel> autoParts = await _AutoPartReadService.GetCategoryAutoParts(category);

            List<AutoPartViewModel> autoPartViewModel = _mapper.Map<List<AutoPartModel>, List<AutoPartViewModel>>(autoParts);

            result.Result.Object = autoPartViewModel;
            //add message as well?
            return result;
        }

        public async Task<ReturnViewModel> GetSuitableCategoryAutoParts(string category, string technicalDescription, decimal priceMin, decimal priceMax) {
            string[] descriptions = technicalDescription.Split(",");
            string query = "";
            /*could add protection against SQL Injection here???*/
            foreach (var v in descriptions) {
                if (string.IsNullOrEmpty(query)) {
                    query += "TechnicalDetails LIKE '%" + v + "%'";
                    continue;
                }
                query += " AND TechnicalDetails LIKE '%" + v + "%'";
            }

            ReturnViewModel result = new ReturnViewModel();

            List<AutoPartModel> autoParts = await _AutoPartReadService.GetSuitableCategoryAutoParts(category, query, priceMin, priceMax);

            List<AutoPartViewModel> autoPartViewModel = _mapper.Map<List<AutoPartModel>, List<AutoPartViewModel>>(autoParts);

            result.Result.Object = autoPartViewModel;
            //add message as well?
            return result;
        }

        public async Task<ReturnViewModel> GetAutoPartByID(Guid autoPartID) {
            
            ReturnViewModel result = new ReturnViewModel();

            if (autoPartID.Equals(Guid.Empty)) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(2));//CHANGE THE MESSAGE
                return result;
            }

            AutoPartModel autoPart = await _AutoPartReadService.GetAutoPartByID(autoPartID);

            if (autoPart == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(2));//CHANGE THE MESSAGE
                return result;
            }

            AutoPartViewModel autoPartViewModel = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

            result.Result.Object = autoPartViewModel;
            //add message as well?
            return result;
        }
    }
}
