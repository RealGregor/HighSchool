using Dapper;
using LMA.Data.Contracts.Writers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Writers {
    public class EmployeeWriter : BasePersistance, IWriter<EmployeeModel> {
        public EmployeeWriter(IDbConnectionFactory connectionFactory) : base(connectionFactory) {
        }

        //Function that create a new user
        public async Task<int> Create(EmployeeModel employee) {
            int result = 0;
            employee.Id = Guid.NewGuid();
            using (var connection = connectionFactory.Create()) {
                result += await connection.ExecuteScalarAsync<int>("INSERT INTO Employees (id, name, surname, email, profilePicture, phoneNumber)  " +
                    "VALUES(@Id, @Name, @Surname, @Email, @ProfilePicture, @PhoneNumber);", employee);
            }
            return result;
        }

        //Function that delete existing user
        public async Task<long> Delete(Guid id) {
            long result = 0;
            using (var connection = connectionFactory.Create()) {

                result = (await connection.ExecuteScalarAsync<long>("DELETE FROM Employees WHERE id='" + id + "';"));
                            //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM UserGroups WHERE user_Id='" + id + "';"))
                            //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM UserData WHERE id='" + id + "';"))
                            //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM GroupInvites WHERE user_Id='" + id + "';"))
                            //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM Collaborators WHERE user_id='" + id + "' OR collaborator_Id='" + id + "';"));
            }
            return result;
        }

        //Function that update data of existing user
        public async Task<long> Update(EmployeeModel employee) {
            long result = 0;
            using (var connection = connectionFactory.Create()) {
                result = await connection.ExecuteScalarAsync<long>("UPDATE Employees " +
                    "SET name=@Name, surname=@Surname, email=@Email, phoneNumber=@PhoneNumber, profilePicture=@ProfilePicture" +
                    " WHERE id=@Id;", employee);
            }
            return result;
        }
    }
}
