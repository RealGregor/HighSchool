using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Globalization;
using System.Diagnostics;
using LMA.Data.DbProvider;

namespace LMA.Data.MSSQL.Writers
{
    public class UserWriter : BasePersistance, IWriter<UserModel>
    {
        public UserWriter(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        //Function that create a new user
        public async Task<int> Create(UserModel user)
        {
            int result = 0;
            user.Id = Guid.NewGuid();
            user.EmailConfirmed = true;
            using (var connection = connectionFactory.Create())
            {
                //PersonalTimeSettingsModel settings = await connection.QuerySingleOrDefaultAsync<PersonalTimeSettingsModel>(
                //    "SELECT id AS Id, maxDayUnavailableTime AS MaxDayUnavailableTime, maxSingleUnavailableTime AS MaxSingleUnavailableTime, minSingleAvailableTime AS MinSingleAvailableTime" +
                //    " FROM Tenant WHERE id='" + model.TenantId + "';");
                result += await connection.ExecuteScalarAsync<int>("INSERT INTO Users (id, password, name, surname, emailConfirmed, email, address, addressNumber, country, timeCreated, role, phoneNumber)  " +
                    "VALUES(@Id, @Password, @Name, @Surname, @EmailConfirmed, @Email, @Address, @AddressNumber, @Country, @TimeCreated, @Role, @PhoneNumber);", user);
                //result += await connection.ExecuteScalarAsync<int>("INSERT INTO UserData (id, status, timeUnavailable, timeAvailable, timeOffline, maxDayUnavailableTime, maxSingleUnavailableTime, minSingleAvailableTime)" +
                //    "VALUES('" + model.Id + "', 0, NULL, NULL, NULL,  @MaxDayUnavailableTime, @MaxSingleUnavailableTime, @minSingleAvailableTime)", settings);
            }
            return result;
        }

        //Function that delete existing user
        public async Task<long> Delete(Guid id)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {

				result = (await connection.ExecuteScalarAsync<long>("DELETE FROM Users WHERE id='" + id + "';"))
							+ (await connection.ExecuteScalarAsync<long>("DELETE FROM UserGroups WHERE user_Id='" + id + "';"))
							+ (await connection.ExecuteScalarAsync<long>("DELETE FROM UserData WHERE id='" + id + "';"))
							+ (await connection.ExecuteScalarAsync<long>("DELETE FROM GroupInvites WHERE user_Id='" + id + "';"))
							+ (await connection.ExecuteScalarAsync<long>("DELETE FROM Collaborators WHERE user_id='" + id + "' OR collaborator_Id='" + id + "';"));
			}
            return result;
        }

        //Function that update data of existing user
        public async Task<long> Update(UserModel model)
        {
            long result = 0;
            //DateTime time = DateTime.UtcNow;
            using (var connection = connectionFactory.Create())
            {
                result = await connection.ExecuteScalarAsync<long>("UPDATE Users " +
                    "SET password=@Password, name=@Name, surname=@Surname, emailConfirmed=@EmailConfirmed, email=@Email, address=@Address, addressNumber=@AddressNumber, country=@Country, phoneNumber=@PhoneNumber, profilePicture=@ProfilePicture" +
                    " WHERE id=@Id;", model);
            }
            return result;
        }
    }
}
