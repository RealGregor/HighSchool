using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services.Contracts {
    public interface IEmployeeService {

        Task<ReturnViewModel> CreateEmployee(EmployeeViewModel employee);

        Task<ReturnViewModel> GetEmployees();

        Task<ReturnViewModel> Update(Guid adminID, ChangeEmployeeViewModel changeEmployee);

        Task<ReturnViewModel> Delete(Guid adminID, DeleteEmployeeViewModel deleteEmployee);
    }
}
