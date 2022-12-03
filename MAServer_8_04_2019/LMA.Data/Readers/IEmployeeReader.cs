using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Readers
{
    public interface IEmployeeReader<IModel> where IModel : class
    {
        Task<List<IModel>> GetEmployees();

        Task<IModel> GetEmployee(string email);
    }
}
