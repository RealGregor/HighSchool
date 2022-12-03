using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services.Contracts
{
    public interface IAutoPartService
    {
        //Task<AutoPartViewModel> GetTenantDataById(Guid Tenant_Id);

        //Task<AutoPartViewModel> GetTenantDataByName(string Tenant_Name);

        //Task<Guid> GetIdOfTenant(string Tenant_Name);

        //Task<ReturnViewModel> SetTenantData(Guid User_Id, AutoPartViewModel model);



        Task<ReturnViewModel> AddAutoPart(AutoPartViewModel autoPart);

        Task<ReturnViewModel> DeleteAutoPart(Guid adminID, DeleteAutoPartViewModel deleteAutoPart);

        Task<ReturnViewModel> UpdateAutoPart(Guid adminID, ChangeAutoPartViewModel changeAutoPart);



  //      Task<ReturnViewModel> GetTenantTimeParametersOfUser(Guid User_Id);

		//Task<ReturnViewModel> GetCustomTimeParametersOfUser(Guid User_Id);



        Task<ReturnViewModel> GetSubCategoryAutoParts(string subCategory);

        Task<ReturnViewModel> GetCategoryAutoParts(string category);

        Task<ReturnViewModel> GetSuitableCategoryAutoParts(string category, string technicalDescription, decimal priceMin, decimal priceMax);

        Task<ReturnViewModel> GetAutoPartByID(Guid autoPartID);
    }
}
