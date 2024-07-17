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
    /// The smokingService responsible for managing smoking related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting smoking information.
    /// </remarks>
    public interface ISmokingService
    {
        /// <summary>Retrieves a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <returns>The smoking data</returns>
        Smoking GetById(Guid id);

        /// <summary>Retrieves a list of smokings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of smokings</returns>
        List<Smoking> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new smoking</summary>
        /// <param name="model">The smoking data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Smoking model);

        /// <summary>Updates a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <param name="updatedEntity">The smoking data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Smoking updatedEntity);

        /// <summary>Updates a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <param name="updatedEntity">The smoking data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Smoking> updatedEntity);

        /// <summary>Deletes a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The smokingService responsible for managing smoking related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting smoking information.
    /// </remarks>
    public class SmokingService : ISmokingService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Smoking class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SmokingService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <returns>The smoking data</returns>
        public Smoking GetById(Guid id)
        {
            var entityData = _dbContext.Smoking.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of smokings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of smokings</returns>/// <exception cref="Exception"></exception>
        public List<Smoking> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSmoking(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new smoking</summary>
        /// <param name="model">The smoking data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Smoking model)
        {
            model.Id = CreateSmoking(model);
            return model.Id;
        }

        /// <summary>Updates a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <param name="updatedEntity">The smoking data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Smoking updatedEntity)
        {
            UpdateSmoking(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <param name="updatedEntity">The smoking data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Smoking> updatedEntity)
        {
            PatchSmoking(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific smoking by its primary key</summary>
        /// <param name="id">The primary key of the smoking</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSmoking(id);
            return true;
        }
        #region
        private List<Smoking> GetSmoking(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Smoking.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Smoking>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Smoking), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Smoking, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSmoking(Smoking model)
        {
            _dbContext.Smoking.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSmoking(Guid id, Smoking updatedEntity)
        {
            _dbContext.Smoking.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSmoking(Guid id)
        {
            var entityData = _dbContext.Smoking.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Smoking.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSmoking(Guid id, JsonPatchDocument<Smoking> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Smoking.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Smoking.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}