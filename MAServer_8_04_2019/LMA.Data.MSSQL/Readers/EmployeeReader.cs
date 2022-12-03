using LMA.Data.Contracts.Readers;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using LMA.Data.DbProvider;

namespace LMA.Data.MSSQL.Readers
{
    public class EmployeeReader : BasePersistance, IEmployeeReader<EmployeeModel>
    {
        public EmployeeReader(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<List<EmployeeModel>> GetEmployees() {
            List<EmployeeModel> employees = null;
            using (var connection = connectionFactory.Create()) {
                employees = (await connection.QueryAsync<EmployeeModel>(
                    @"SELECT id AS Id, name AS Name, surname AS Surname, email AS Email, phoneNumber AS PhoneNumber, profilePicture AS ProfilePicture FROM Employees
                      ;")).ToList();
            }
            return employees;
        }

        public async Task<EmployeeModel> GetEmployee(string email) {
            EmployeeModel employee = null;
            using (var connection = connectionFactory.Create()) {
                employee = await connection.QuerySingleOrDefaultAsync<EmployeeModel>(
                    @"SELECT id AS Id, name AS Name, surname AS Surname, email AS Email, phoneNumber AS PhoneNumber, profilePicture AS ProfilePicture FROM Employees
                    WHERE email = '" + email + "';");
            }
            return employee;
        }
    }
}
