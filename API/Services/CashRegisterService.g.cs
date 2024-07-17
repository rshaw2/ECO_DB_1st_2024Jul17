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
    /// The cashregisterService responsible for managing cashregister related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregister information.
    /// </remarks>
    public interface ICashRegisterService
    {
        /// <summary>Retrieves a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <returns>The cashregister data</returns>
        CashRegister GetById(Guid id);

        /// <summary>Retrieves a list of cashregisters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregisters</returns>
        List<CashRegister> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cashregister</summary>
        /// <param name="model">The cashregister data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CashRegister model);

        /// <summary>Updates a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <param name="updatedEntity">The cashregister data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CashRegister updatedEntity);

        /// <summary>Updates a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <param name="updatedEntity">The cashregister data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CashRegister> updatedEntity);

        /// <summary>Deletes a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The cashregisterService responsible for managing cashregister related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cashregister information.
    /// </remarks>
    public class CashRegisterService : ICashRegisterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CashRegister class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CashRegisterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <returns>The cashregister data</returns>
        public CashRegister GetById(Guid id)
        {
            var entityData = _dbContext.CashRegister.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of cashregisters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cashregisters</returns>/// <exception cref="Exception"></exception>
        public List<CashRegister> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCashRegister(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cashregister</summary>
        /// <param name="model">The cashregister data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CashRegister model)
        {
            model.Id = CreateCashRegister(model);
            return model.Id;
        }

        /// <summary>Updates a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <param name="updatedEntity">The cashregister data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CashRegister updatedEntity)
        {
            UpdateCashRegister(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <param name="updatedEntity">The cashregister data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CashRegister> updatedEntity)
        {
            PatchCashRegister(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cashregister by its primary key</summary>
        /// <param name="id">The primary key of the cashregister</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCashRegister(id);
            return true;
        }
        #region
        private List<CashRegister> GetCashRegister(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CashRegister.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CashRegister>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CashRegister), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CashRegister, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCashRegister(CashRegister model)
        {
            _dbContext.CashRegister.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCashRegister(Guid id, CashRegister updatedEntity)
        {
            _dbContext.CashRegister.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCashRegister(Guid id)
        {
            var entityData = _dbContext.CashRegister.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CashRegister.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCashRegister(Guid id, JsonPatchDocument<CashRegister> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CashRegister.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CashRegister.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}