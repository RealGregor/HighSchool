using AutoMapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMA.Services.Contracts;
using System.Linq;
using MoreLinq;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LMA.Services {
    public class EmployeeService : IEmployeeService {
        private readonly IEmployeeReader<EmployeeModel> _EmployeesReadService;
        private readonly IWriter<EmployeeModel> _EmployeesWriteService;
        private readonly IAdminReader<AdminModel> _adminReadService;
        private readonly IMapper _mapper;

        public EmployeeService( 
                            IEmployeeReader<EmployeeModel> EmployeesReadService,
                            IWriter<EmployeeModel> EmployeesWriteService,
                            IAdminReader<AdminModel> AdminReadService,
                            IMapper mapper
            ) {
            _EmployeesReadService = EmployeesReadService;
            _EmployeesWriteService = EmployeesWriteService;
            _adminReadService = AdminReadService;
            _mapper = mapper;
        }
        
        //Get all employees of avtomehanična delavnica Pelko
        public async Task<ReturnViewModel> GetEmployees() {//instead of usermodel put employee model?
            ReturnViewModel result = new ReturnViewModel();

            List<EmployeeModel> employees = await _EmployeesReadService.GetEmployees();

            List<EmployeeViewModel> employeesViewModel = _mapper.Map<List<EmployeeModel>, List<EmployeeViewModel>>(employees);

            result.Result.Object = employeesViewModel;
            //add message as well?
            return result;
        }

        //Add new employee
        public async Task<ReturnViewModel> CreateEmployee(EmployeeViewModel newEmployee) {
            ReturnViewModel result = new ReturnViewModel();
            //mapping from userNew -> user (UserModel)
            EmployeeModel employee = _mapper.Map<EmployeeViewModel, EmployeeModel>(newEmployee);


            //get user, that we are trying to add, from database
            EmployeeModel employeeFromDatabase = await _EmployeesReadService.GetEmployee(employee.Email);

            //Check if user already exists
            if (employeeFromDatabase == null)//we add user to database
            {
                await _EmployeesWriteService.Create(employee);
                //collab.User_Id = user.Id;
                //await _CollabWriteService.Create(collab);

                result.Result.Messages.Add(new MessageViewModel(3)); //CHANGE THE MESSAGE
                return result;
            } else {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(2));//CHANGE THE MESSAGE
                return result;
            }
        }

        //Call UserWriter to update data of given user
        public async Task<ReturnViewModel> Update(Guid adminID, ChangeEmployeeViewModel employeeNewInformation) {
            ReturnViewModel result = new ReturnViewModel();
            EmployeeModel updatedEmployee = await _EmployeesReadService.GetEmployee(employeeNewInformation.OldEmail);
            
            if (updatedEmployee == null) {
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

            if (admin.Password.Equals(employeeNewInformation.Password)) {
                if (!string.IsNullOrEmpty(employeeNewInformation.Name))
                    updatedEmployee.Name = employeeNewInformation.Name;
                if (!string.IsNullOrEmpty(employeeNewInformation.Surname))
                    updatedEmployee.Surname = employeeNewInformation.Surname;
                if (!string.IsNullOrEmpty(employeeNewInformation.Email))
                    updatedEmployee.Email = employeeNewInformation.Email;
                if (!string.IsNullOrEmpty(employeeNewInformation.PhoneNumber))
                    updatedEmployee.PhoneNumber = employeeNewInformation.PhoneNumber;
                if (!string.IsNullOrEmpty(employeeNewInformation.ProfilePicture))
                    updatedEmployee.ProfilePicture = Convert.FromBase64String(employeeNewInformation.ProfilePicture);

                await _EmployeesWriteService.Update(updatedEmployee);

                ChangeEmployeeViewModel res = _mapper.Map<EmployeeModel, ChangeEmployeeViewModel>(updatedEmployee);
                res.OldEmail = employeeNewInformation.OldEmail;

                result.Result.Object = res;
                result.Result.Messages.Add(new MessageViewModel(3));
                return result;
            } else {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(6));
                return result;
            }
        }

        //Delete user with given id, by checking the passwords credibility
        public async Task<ReturnViewModel> Delete(Guid adminID, DeleteEmployeeViewModel deleteEmployee) {
            ReturnViewModel result = new ReturnViewModel();
            AdminModel admin = await _adminReadService.GetAdminByID(adminID);

            EmployeeModel employee = await _EmployeesReadService.GetEmployee(deleteEmployee.Email);

            if (admin.Password == deleteEmployee.Password) {
                long x = await _EmployeesWriteService.Delete(employee.Id);
                DeleteEmployeeViewModel deletedEmployee = new DeleteEmployeeViewModel();
                deletedEmployee.Email = deleteEmployee.Email;

                result.Result.Object = deletedEmployee;
                result.Result.Messages.Add(new MessageViewModel(3));
                return result;
            } else {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(10));
                return result;
            }
        }
    }
}
