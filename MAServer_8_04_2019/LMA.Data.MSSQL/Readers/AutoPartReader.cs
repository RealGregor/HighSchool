using Dapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LMA.Data.MSSQL.Readers
{
    public class AutoPartReader : BasePersistance, IAutoPartReader<AutoPartModel>
    {
        public AutoPartReader(IDbConnectionFactory connectionFactory) : base(connectionFactory) {
        }

        public async Task<List<AutoPartModel>> GetSubCategoryAutoParts(string subCategory) {
            List<AutoPartModel> matchingSubCategoryAutoParts = null;
            using (var connection = connectionFactory.Create()) {
                matchingSubCategoryAutoParts = (await connection.QueryAsync<AutoPartModel>(
                     @"SELECT id AS Id, name AS Name, category AS Category, subCategory AS SubCategory,  descrition AS Description, technicalDetails AS TechnicalDetails,
                        producerName AS ProducerName, deliveryDeadline AS DeliveryDeadline, price AS Price
                        FROM AutoParts WHERE SubCategory = '" + subCategory + "';")).ToList();
            }
            return matchingSubCategoryAutoParts;
        }

        public async Task<List<AutoPartModel>> GetCategoryAutoParts(string category) {
            List<AutoPartModel> matchingCategoryAutoParts = null;
            using (var connection = connectionFactory.Create()) {
                matchingCategoryAutoParts = (await connection.QueryAsync<AutoPartModel>(
                     @"SELECT id AS Id, name AS Name, category AS Category, subCategory AS SubCategory,  descrition AS Description, technicalDetails AS TechnicalDetails,
                        producerName AS ProducerName, deliveryDeadline AS DeliveryDeadline, price AS Price, picture AS Picture
                        FROM AutoParts WHERE Category = '" + category + "';")).ToList();
            }
            return matchingCategoryAutoParts;
        }

        public async Task<List<AutoPartModel>> GetSuitableCategoryAutoParts(string category, string query, decimal priceMine, decimal priceMax) {
            List<AutoPartModel> matchingSuitableCategoryAutoParts = null;
            using (var connection = connectionFactory.Create()) {
                matchingSuitableCategoryAutoParts = (await connection.QueryAsync<AutoPartModel>(
                     @"SELECT id AS Id, name AS Name, category AS Category, subCategory AS SubCategory,  description AS Description, technicalDetails AS TechnicalDetails,
                        producerName AS ProducerName, deliveryDeadline AS DeliveryDeadline, price AS Price, picture AS Picture
                        FROM AutoParts WHERE Category = '" + category + "' AND " + query + " AND Price BETWEEN " + priceMine + " AND " + priceMax + " ;")).ToList();
            }
            return matchingSuitableCategoryAutoParts;
        }

        public async Task<AutoPartModel> GetAutoPartByID(Guid autoPartID)
        {
            AutoPartModel autoPart;
            using (var connection = connectionFactory.Create()) {
                autoPart = await connection.QuerySingleOrDefaultAsync<AutoPartModel>(
                    "SELECT id AS Id, name AS Name, category AS Category, subCategory AS SubCategory," +
                    "description AS Description, technicalDetails AS TechnicalDetails, " +
                    "producerName AS ProducerName, deliveryDeadline AS DeliveryDeadline," +
                    "price AS Price, picture AS Picture FROM AutoParts " +
                    "WHERE id='" + autoPartID + "';");

            }
            return autoPart;
        }

        public async Task<AutoPartModel> GetAutoPartByName(string autoPartName)
        {
            AutoPartModel autoPart;
            using (var connection = connectionFactory.Create())
            {
                autoPart = await connection.QuerySingleOrDefaultAsync<AutoPartModel>(
                    "SELECT id AS Id, name AS Name, category AS Category, subCategory AS SubCategory," +
                    "description AS Description, technicalDetails AS TechnicalDetails, " +
                    "producerName AS ProducerName, deliveryDeadline AS DeliveryDeadline," +
                    "price AS Price, picture AS Picture FROM AutoParts " +
                    "WHERE name='" + autoPartName + "';");

            }
            return autoPart;
        }
    }
}
