using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Readers
{
    public interface IUserReader<IModel> where IModel : class
    {
        Task<UserModel> GetUser(string email);

        Task<UserModel> GetUserById(Guid id);
    }
}
