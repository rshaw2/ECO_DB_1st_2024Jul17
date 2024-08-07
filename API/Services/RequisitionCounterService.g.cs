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
    /// The requisitioncounterService responsible for managing requisitioncounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting requisitioncounter information.
    /// </remarks>
    public interface IRequisitionCounterService
    {
        /// <summary>Retrieves a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <returns>The requisitioncounter data</returns>
        RequisitionCounter GetById(Guid id);

        /// <summary>Retrieves a list of requisitioncounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of requisitioncounters</returns>
        List<RequisitionCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new requisitioncounter</summary>
        /// <param name="model">The requisitioncounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(RequisitionCounter model);

        /// <summary>Updates a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <param name="updatedEntity">The requisitioncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, RequisitionCounter updatedEntity);

        /// <summary>Updates a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <param name="updatedEntity">The requisitioncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<RequisitionCounter> updatedEntity);

        /// <summary>Deletes a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The requisitioncounterService responsible for managing requisitioncounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting requisitioncounter information.
    /// </remarks>
    public class RequisitionCounterService : IRequisitionCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the RequisitionCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RequisitionCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <returns>The requisitioncounter data</returns>
        public RequisitionCounter GetById(Guid id)
        {
            var entityData = _dbContext.RequisitionCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of requisitioncounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of requisitioncounters</returns>/// <exception cref="Exception"></exception>
        public List<RequisitionCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRequisitionCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new requisitioncounter</summary>
        /// <param name="model">The requisitioncounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(RequisitionCounter model)
        {
            model.TenantId = CreateRequisitionCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <param name="updatedEntity">The requisitioncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, RequisitionCounter updatedEntity)
        {
            UpdateRequisitionCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <param name="updatedEntity">The requisitioncounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<RequisitionCounter> updatedEntity)
        {
            PatchRequisitionCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific requisitioncounter by its primary key</summary>
        /// <param name="id">The primary key of the requisitioncounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRequisitionCounter(id);
            return true;
        }
        #region
        private List<RequisitionCounter> GetRequisitionCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RequisitionCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RequisitionCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RequisitionCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RequisitionCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateRequisitionCounter(RequisitionCounter model)
        {
            _dbContext.RequisitionCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateRequisitionCounter(Guid id, RequisitionCounter updatedEntity)
        {
            _dbContext.RequisitionCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRequisitionCounter(Guid id)
        {
            var entityData = _dbContext.RequisitionCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RequisitionCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRequisitionCounter(Guid id, JsonPatchDocument<RequisitionCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RequisitionCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RequisitionCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}