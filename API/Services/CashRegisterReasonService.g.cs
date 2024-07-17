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
    /// The cashregisterreasonService responsible for managing cashregisterreason related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregisterreason information.
    /// </remarks>
    public interface ICashRegisterReasonService
    {
        /// <summary>Retrieves a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <returns>The cashregisterreason data</returns>
        CashRegisterReason GetById(Guid id);

        /// <summary>Retrieves a list of cashregisterreasons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregisterreasons</returns>
        List<CashRegisterReason> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cashregisterreason</summary>
        /// <param name="model">The cashregisterreason data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CashRegisterReason model);

        /// <summary>Updates a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <param name="updatedEntity">The cashregisterreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CashRegisterReason updatedEntity);

        /// <summary>Updates a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <param name="updatedEntity">The cashregisterreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CashRegisterReason> updatedEntity);

        /// <summary>Deletes a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The cashregisterreasonService responsible for managing cashregisterreason related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregisterreason information.
    /// </remarks>
    public class CashRegisterReasonService : ICashRegisterReasonService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CashRegisterReason class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CashRegisterReasonService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <returns>The cashregisterreason data</returns>
        public CashRegisterReason GetById(Guid id)
        {
            var entityData = _dbContext.CashRegisterReason.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of cashregisterreasons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregisterreasons</returns>/// <exception cref="Exception"></exception>
        public List<CashRegisterReason> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCashRegisterReason(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cashregisterreason</summary>
        /// <param name="model">The cashregisterreason data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CashRegisterReason model)
        {
            model.Id = CreateCashRegisterReason(model);
            return model.Id;
        }

        /// <summary>Updates a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <param name="updatedEntity">The cashregisterreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CashRegisterReason updatedEntity)
        {
            UpdateCashRegisterReason(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <param name="updatedEntity">The cashregisterreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CashRegisterReason> updatedEntity)
        {
            PatchCashRegisterReason(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cashregisterreason by its primary key</summary>
        /// <param name="id">The primary key of the cashregisterreason</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCashRegisterReason(id);
            return true;
        }
        #region
        private List<CashRegisterReason> GetCashRegisterReason(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CashRegisterReason.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CashRegisterReason>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CashRegisterReason), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CashRegisterReason, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCashRegisterReason(CashRegisterReason model)
        {
            _dbContext.CashRegisterReason.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCashRegisterReason(Guid id, CashRegisterReason updatedEntity)
        {
            _dbContext.CashRegisterReason.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCashRegisterReason(Guid id)
        {
            var entityData = _dbContext.CashRegisterReason.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CashRegisterReason.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCashRegisterReason(Guid id, JsonPatchDocument<CashRegisterReason> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CashRegisterReason.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CashRegisterReason.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}