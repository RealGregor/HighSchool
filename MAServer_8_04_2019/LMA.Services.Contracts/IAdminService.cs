using LMA.Data.UI.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services.Contracts
{
    public interface IAdminService
    {
        Task<ReturnViewModel> Authenticate(string username, string password);
    }
}
