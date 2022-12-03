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
    public class UserReader : BasePersistance, IUserReader<UserModel>
    {
        public UserReader(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        //Return user with given email
        public async Task<UserModel> GetUser(string email)
        {
            UserModel user;
            using (var connection = connectionFactory.Create())
            {
                user = await connection.QuerySingleOrDefaultAsync<UserModel>(
                    "SELECT id AS Id, name AS Name, surname AS Surname, email AS Email, address AS Address, addressNumber AS AddressNumber, country AS Country, password AS Password, timeCreated AS TimeCreated, role AS Role, profilePicture as ProfilePicture, phoneNumber as PhoneNumber" +
                    " FROM Users WHERE email='" + email + "';");
            }
            return user;
        }

        //Get all data of user with given id
        public async Task<UserModel> GetUserById(Guid id)
        {
            UserModel user;
            using (var connection = connectionFactory.Create())
            {
                user = await connection.QuerySingleOrDefaultAsync<UserModel>(
                    "SELECT id AS Id, name AS Name, surname AS Surname, emailConfirmed AS EmailConfirmed, email AS Email, address AS Address, addressNumber AS AddressNumber, country AS Country, password AS Password, timeCreated AS TimeCreated, role AS Role, profilePicture AS ProfilePicture, phoneNumber AS PhoneNumber" +
                    " FROM Users WHERE id='" + id + "';");
            }
            return user;
        }
    }
}
