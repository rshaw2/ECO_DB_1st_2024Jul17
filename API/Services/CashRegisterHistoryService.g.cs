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
    /// The cashregisterhistoryService responsible for managing cashregisterhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregisterhistory information.
    /// </remarks>
    public interface ICashRegisterHistoryService
    {
        /// <summary>Retrieves a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <returns>The cashregisterhistory data</returns>
        CashRegisterHistory GetById(Guid id);

        /// <summary>Retrieves a list of cashregisterhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregisterhistorys</returns>
        List<CashRegisterHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cashregisterhistory</summary>
        /// <param name="model">The cashregisterhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CashRegisterHistory model);

        /// <summary>Updates a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <param name="updatedEntity">The cashregisterhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CashRegisterHistory updatedEntity);

        /// <summary>Updates a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <param name="updatedEntity">The cashregisterhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CashRegisterHistory> updatedEntity);

        /// <summary>Deletes a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The cashregisterhistoryService responsible for managing cashregisterhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregisterhistory information.
    /// </remarks>
    public class CashRegisterHistoryService : ICashRegisterHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CashRegisterHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CashRegisterHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <returns>The cashregisterhistory data</returns>
        public CashRegisterHistory GetById(Guid id)
        {
            var entityData = _dbContext.CashRegisterHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of cashregisterhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregisterhistorys</returns>/// <exception cref="Exception"></exception>
        public List<CashRegisterHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCashRegisterHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cashregisterhistory</summary>
        /// <param name="model">The cashregisterhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CashRegisterHistory model)
        {
            model.Id = CreateCashRegisterHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <param name="updatedEntity">The cashregisterhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CashRegisterHistory updatedEntity)
        {
            UpdateCashRegisterHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <param name="updatedEntity">The cashregisterhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CashRegisterHistory> updatedEntity)
        {
            PatchCashRegisterHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cashregisterhistory by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCashRegisterHistory(id);
            return true;
        }
        #region
        private List<CashRegisterHistory> GetCashRegisterHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CashRegisterHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CashRegisterHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CashRegisterHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CashRegisterHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCashRegisterHistory(CashRegisterHistory model)
        {
            _dbContext.CashRegisterHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCashRegisterHistory(Guid id, CashRegisterHistory updatedEntity)
        {
            _dbContext.CashRegisterHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCashRegisterHistory(Guid id)
        {
            var entityData = _dbContext.CashRegisterHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CashRegisterHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCashRegisterHistory(Guid id, JsonPatchDocument<CashRegisterHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CashRegisterHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CashRegisterHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}