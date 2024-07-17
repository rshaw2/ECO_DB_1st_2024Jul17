using ECODB1st2024Jul17.Models;
using ECODB1st2024Jul17.Data;
using ECODB1st2024Jul17.Filter;
using ECODB1st2024Jul17.Entities;
using ECODB1st2024Jul17.Logger;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace ECODB1st2024Jul17.Services
{
    /// <summary>
    /// The cashregistervarianceService responsible for managing cashregistervariance related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregistervariance information.
    /// </remarks>
    public interface ICashRegisterVarianceService
    {
        /// <summary>Retrieves a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <returns>The cashregistervariance data</returns>
        CashRegisterVariance GetById(Guid id);

        /// <summary>Retrieves a list of cashregistervariances based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregistervariances</returns>
        List<CashRegisterVariance> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cashregistervariance</summary>
        /// <param name="model">The cashregistervariance data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CashRegisterVariance model);

        /// <summary>Updates a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <param name="updatedEntity">The cashregistervariance data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CashRegisterVariance updatedEntity);

        /// <summary>Updates a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <param name="updatedEntity">The cashregistervariance data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CashRegisterVariance> updatedEntity);

        /// <summary>Deletes a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The cashregistervarianceService responsible for managing cashregistervariance related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregistervariance information.
    /// </remarks>
    public class CashRegisterVarianceService : ICashRegisterVarianceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CashRegisterVariance class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CashRegisterVarianceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <returns>The cashregistervariance data</returns>
        public CashRegisterVariance GetById(Guid id)
        {
            var entityData = _dbContext.CashRegisterVariance.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of cashregistervariances based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregistervariances</returns>/// <exception cref="Exception"></exception>
        public List<CashRegisterVariance> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCashRegisterVariance(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cashregistervariance</summary>
        /// <param name="model">The cashregistervariance data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CashRegisterVariance model)
        {
            model.Id = CreateCashRegisterVariance(model);
            return model.Id;
        }

        /// <summary>Updates a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <param name="updatedEntity">The cashregistervariance data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CashRegisterVariance updatedEntity)
        {
            UpdateCashRegisterVariance(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <param name="updatedEntity">The cashregistervariance data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CashRegisterVariance> updatedEntity)
        {
            PatchCashRegisterVariance(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cashregistervariance by its primary key</summary>
        /// <param name="id">The primary key of the cashregistervariance</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCashRegisterVariance(id);
            return true;
        }
        #region
        private List<CashRegisterVariance> GetCashRegisterVariance(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CashRegisterVariance.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CashRegisterVariance>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CashRegisterVariance), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CashRegisterVariance, object>>(Expression.Convert(property, typeof(object)), parameter);
                if (sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderBy(lambda);
                }
                else if (sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderByDescending(lambda);
                }
                else
                {
                    throw new ApplicationException("Invalid sort order. Use 'asc' or 'desc'");
                }
            }

            var paginatedResult = result.Skip(skip).Take(pageSize).ToList();
            return paginatedResult;
        }

        private Guid CreateCashRegisterVariance(CashRegisterVariance model)
        {
            _dbContext.CashRegisterVariance.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCashRegisterVariance(Guid id, CashRegisterVariance updatedEntity)
        {
            _dbContext.CashRegisterVariance.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCashRegisterVariance(Guid id)
        {
            var entityData = _dbContext.CashRegisterVariance.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CashRegisterVariance.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCashRegisterVariance(Guid id, JsonPatchDocument<CashRegisterVariance> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CashRegisterVariance.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CashRegisterVariance.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}