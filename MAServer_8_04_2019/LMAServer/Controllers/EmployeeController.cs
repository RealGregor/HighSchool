using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.ComponentModel.DataAnnotations;
using LMA.Data.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using LMA.Data.UI.ViewModels.ViewModels;
using System.Windows.Forms;
using LMA.Services.Contracts;
using System.Security.Claims;
using System.Text;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LMAServer.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : Controller {
        private readonly IEmployeeService _employeeService;


        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult<ReturnViewModel>> GetEmployees() {
            var result = await _employeeService.GetEmployees();
            return result;
        }

        [HttpPost]
        [Route("employee")]
        public async Task<ActionResult<ReturnViewModel>> CreateEmployee([FromBody]EmployeeViewModel employee) {
            return await _employeeService.CreateEmployee(employee);
        }

        //Given user is going to be updated in database
        [HttpPut]
        public async Task<ActionResult<ReturnViewModel>> UpdateEmployee([FromBody]ChangeEmployeeViewModel model) {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return await _employeeService.Update(new Guid(guid), model);
        }

        //User with given id is going to bo deleted from database
        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult<ReturnViewModel>> Delete([FromBody]DeleteEmployeeViewModel model) {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return await _employeeService.Delete(new Guid(guid), model);
        }

    }
}
