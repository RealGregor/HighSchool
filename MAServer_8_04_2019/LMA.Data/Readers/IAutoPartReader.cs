using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Readers
{
    public interface IAutoPartReader<IModel> where IModel : class
    {
        Task<AutoPartModel> GetAutoPartByID(Guid autoPartID);

        Task<AutoPartModel> GetAutoPartByName(string autoPartName);

        Task<List<AutoPartModel>> GetCategoryAutoParts(string category);

        Task<List<AutoPartModel>> GetSubCategoryAutoParts(string subCategory);

        Task<List<AutoPartModel>> GetSuitableCategoryAutoParts(string category, string query, decimal priceMin, decimal priceMax);
    }
}
