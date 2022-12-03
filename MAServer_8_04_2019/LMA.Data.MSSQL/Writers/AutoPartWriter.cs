using Dapper;
using LMA.Data.Contracts.Writers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Writers
{
    public class AutoPartWriter : BasePersistance, IWriter<AutoPartModel>
    {
        public AutoPartWriter(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<int> Create(AutoPartModel autoPart)
        {
            int result = 0;
            autoPart.Id = Guid.NewGuid();
            autoPart.SubCategory = "d";//delete sometime
            using (var connection = connectionFactory.Create())
            {
                await connection.ExecuteScalarAsync("INSERT INTO AutoParts (id, name, category, subCategory, " +
                    "description, technicalDetails, producerName, deliveryDeadline, price, picture) " +
                    "VALUES(@Id, @Name, @Category, @SubCategory, @Description, @TechnicalDetails, " +
                    "@ProducerName, @DeliveryDeadline, @Price, @Picture);", autoPart);
            }
            return result;
        }

        public async Task<long> Delete(Guid autoPartID)
        {
            long result = 0;
            using (var connection = connectionFactory.Create()) {

                result = (await connection.ExecuteScalarAsync<long>("DELETE FROM AutoParts WHERE id='" + autoPartID + "';"))
                +(await connection.ExecuteScalarAsync<long>("DELETE FROM CartItems WHERE autoPartID='" + autoPartID + "';"));
                //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM UserData WHERE id='" + id + "';"))
                //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM GroupInvites WHERE user_Id='" + id + "';"))
                //+ (await connection.ExecuteScalarAsync<long>("DELETE FROM Collaborators WHERE user_id='" + id + "' OR collaborator_Id='" + id + "';"));
            }
            return result;
        }

        public async Task<long> Update(AutoPartModel model)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {
                await connection.ExecuteScalarAsync<long>("UPDATE AutoParts " +
                                        "SET name=@Name, description=@Description, technicalDetails=@TechnicalDetails, " +
                                        "producerName=@ProducerName, deliveryDeadline=@DeliveryDeadline, price=@Price," +
                                        "picture=@Picture WHERE id=@Id;", model);
            }
            return result;
        }
    }
}
