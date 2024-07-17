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
    /// The procedureordercounterService responsible for managing procedureordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureordercounter information.
    /// </remarks>
    public interface IProcedureOrderCounterService
    {
        /// <summary>Retrieves a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <returns>The procedureordercounter data</returns>
        ProcedureOrderCounter GetById(Guid id);

        /// <summary>Retrieves a list of procedureordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureordercounters</returns>
        List<ProcedureOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new procedureordercounter</summary>
        /// <param name="model">The procedureordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(ProcedureOrderCounter model);

        /// <summary>Updates a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <param name="updatedEntity">The procedureordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureOrderCounter updatedEntity);

        /// <summary>Updates a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <param name="updatedEntity">The procedureordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureOrderCounter> updatedEntity);

        /// <summary>Deletes a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The procedureordercounterService responsible for managing procedureordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureordercounter information.
    /// </remarks>
    public class ProcedureOrderCounterService : IProcedureOrderCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureOrderCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureOrderCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <returns>The procedureordercounter data</returns>
        public ProcedureOrderCounter GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of procedureordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureordercounters</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureOrderCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new procedureordercounter</summary>
        /// <param name="model">The procedureordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(ProcedureOrderCounter model)
        {
            model.TenantId = CreateProcedureOrderCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <param name="updatedEntity">The procedureordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureOrderCounter updatedEntity)
        {
            UpdateProcedureOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <param name="updatedEntity">The procedureordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureOrderCounter> updatedEntity)
        {
            PatchProcedureOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific procedureordercounter by its primary key</summary>
        /// <param name="id">The primary key of the procedureordercounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureOrderCounter(id);
            return true;
        }
        #region
        private List<ProcedureOrderCounter> GetProcedureOrderCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureOrderCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureOrderCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureOrderCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureOrderCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateProcedureOrderCounter(ProcedureOrderCounter model)
        {
            _dbContext.ProcedureOrderCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateProcedureOrderCounter(Guid id, ProcedureOrderCounter updatedEntity)
        {
            _dbContext.ProcedureOrderCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureOrderCounter(Guid id)
        {
            var entityData = _dbContext.ProcedureOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureOrderCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureOrderCounter(Guid id, JsonPatchDocument<ProcedureOrderCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureOrderCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureOrderCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}