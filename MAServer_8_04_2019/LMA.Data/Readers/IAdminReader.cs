using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Readers
{
    public interface IAdminReader<IModel> where IModel : class
    {
        Task<AdminModel> GetAdmin(string username);

        Task<AdminModel> GetAdminByID(Guid adminID);
    }
}
