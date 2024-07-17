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
    /// The investigationordercounterService responsible for managing investigationordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationordercounter information.
    /// </remarks>
    public interface IInvestigationOrderCounterService
    {
        /// <summary>Retrieves a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <returns>The investigationordercounter data</returns>
        InvestigationOrderCounter GetById(Guid id);

        /// <summary>Retrieves a list of investigationordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationordercounters</returns>
        List<InvestigationOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationordercounter</summary>
        /// <param name="model">The investigationordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(InvestigationOrderCounter model);

        /// <summary>Updates a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <param name="updatedEntity">The investigationordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationOrderCounter updatedEntity);

        /// <summary>Updates a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <param name="updatedEntity">The investigationordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationOrderCounter> updatedEntity);

        /// <summary>Deletes a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationordercounterService responsible for managing investigationordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationordercounter information.
    /// </remarks>
    public class InvestigationOrderCounterService : IInvestigationOrderCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationOrderCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationOrderCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <returns>The investigationordercounter data</returns>
        public InvestigationOrderCounter GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationordercounters</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationOrderCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationordercounter</summary>
        /// <param name="model">The investigationordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(InvestigationOrderCounter model)
        {
            model.TenantId = CreateInvestigationOrderCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <param name="updatedEntity">The investigationordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationOrderCounter updatedEntity)
        {
            UpdateInvestigationOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <param name="updatedEntity">The investigationordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationOrderCounter> updatedEntity)
        {
            PatchInvestigationOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationordercounter by its primary key</summary>
        /// <param name="id">The primary key of the investigationordercounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationOrderCounter(id);
            return true;
        }
        #region
        private List<InvestigationOrderCounter> GetInvestigationOrderCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationOrderCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationOrderCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationOrderCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationOrderCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateInvestigationOrderCounter(InvestigationOrderCounter model)
        {
            _dbContext.InvestigationOrderCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateInvestigationOrderCounter(Guid id, InvestigationOrderCounter updatedEntity)
        {
            _dbContext.InvestigationOrderCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationOrderCounter(Guid id)
        {
            var entityData = _dbContext.InvestigationOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationOrderCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationOrderCounter(Guid id, JsonPatchDocument<InvestigationOrderCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationOrderCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationOrderCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}