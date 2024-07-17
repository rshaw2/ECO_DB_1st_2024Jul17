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
    /// The druginteractionlogService responsible for managing druginteractionlog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druginteractionlog information.
    /// </remarks>
    public interface IDrugInteractionLogService
    {
        /// <summary>Retrieves a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <returns>The druginteractionlog data</returns>
        DrugInteractionLog GetById(Guid id);

        /// <summary>Retrieves a list of druginteractionlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druginteractionlogs</returns>
        List<DrugInteractionLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new druginteractionlog</summary>
        /// <param name="model">The druginteractionlog data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugInteractionLog model);

        /// <summary>Updates a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <param name="updatedEntity">The druginteractionlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugInteractionLog updatedEntity);

        /// <summary>Updates a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <param name="updatedEntity">The druginteractionlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugInteractionLog> updatedEntity);

        /// <summary>Deletes a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The druginteractionlogService responsible for managing druginteractionlog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druginteractionlog information.
    /// </remarks>
    public class DrugInteractionLogService : IDrugInteractionLogService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugInteractionLog class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugInteractionLogService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <returns>The druginteractionlog data</returns>
        public DrugInteractionLog GetById(Guid id)
        {
            var entityData = _dbContext.DrugInteractionLog.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of druginteractionlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druginteractionlogs</returns>/// <exception cref="Exception"></exception>
        public List<DrugInteractionLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugInteractionLog(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new druginteractionlog</summary>
        /// <param name="model">The druginteractionlog data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugInteractionLog model)
        {
            model.Id = CreateDrugInteractionLog(model);
            return model.Id;
        }

        /// <summary>Updates a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <param name="updatedEntity">The druginteractionlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugInteractionLog updatedEntity)
        {
            UpdateDrugInteractionLog(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <param name="updatedEntity">The druginteractionlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugInteractionLog> updatedEntity)
        {
            PatchDrugInteractionLog(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific druginteractionlog by its primary key</summary>
        /// <param name="id">The primary key of the druginteractionlog</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugInteractionLog(id);
            return true;
        }
        #region
        private List<DrugInteractionLog> GetDrugInteractionLog(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugInteractionLog.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugInteractionLog>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugInteractionLog), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugInteractionLog, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugInteractionLog(DrugInteractionLog model)
        {
            _dbContext.DrugInteractionLog.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugInteractionLog(Guid id, DrugInteractionLog updatedEntity)
        {
            _dbContext.DrugInteractionLog.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugInteractionLog(Guid id)
        {
            var entityData = _dbContext.DrugInteractionLog.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugInteractionLog.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugInteractionLog(Guid id, JsonPatchDocument<DrugInteractionLog> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugInteractionLog.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugInteractionLog.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}