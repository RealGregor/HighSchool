using Dapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Readers
{
    public class AdminReader : BasePersistance, IAdminReader<AdminModel>
    {
        public AdminReader(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<AdminModel> GetAdmin(string username) {
            AdminModel admin;
            using (var connection = connectionFactory.Create()) {
                admin = await connection.QuerySingleOrDefaultAsync<AdminModel>(
                    "SELECT id AS Id, name AS Name, surname AS Surname, username AS Username, password AS Password" +
                    " FROM Administrators WHERE username='" + username + "';");
            }
            return admin;
        }

        public async Task<AdminModel> GetAdminByID(Guid adminID) {
            AdminModel admin;
            using (var connection = connectionFactory.Create()) {
                admin = await connection.QuerySingleOrDefaultAsync<AdminModel>(
                    "SELECT id AS Id, name AS Name, surname AS Surname, username AS Username, password AS Password" +
                    " FROM Administrators WHERE id='" + adminID + "';");
            }
            return admin;
        }
    }
}
