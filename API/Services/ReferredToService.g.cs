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
    /// The referredtoService responsible for managing referredto related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referredto information.
    /// </remarks>
    public interface IReferredToService
    {
        /// <summary>Retrieves a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <returns>The referredto data</returns>
        ReferredTo GetById(Guid id);

        /// <summary>Retrieves a list of referredtos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referredtos</returns>
        List<ReferredTo> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new referredto</summary>
        /// <param name="model">The referredto data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ReferredTo model);

        /// <summary>Updates a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <param name="updatedEntity">The referredto data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ReferredTo updatedEntity);

        /// <summary>Updates a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <param name="updatedEntity">The referredto data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ReferredTo> updatedEntity);

        /// <summary>Deletes a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The referredtoService responsible for managing referredto related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referredto information.
    /// </remarks>
    public class ReferredToService : IReferredToService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ReferredTo class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReferredToService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <returns>The referredto data</returns>
        public ReferredTo GetById(Guid id)
        {
            var entityData = _dbContext.ReferredTo.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of referredtos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referredtos</returns>/// <exception cref="Exception"></exception>
        public List<ReferredTo> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReferredTo(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new referredto</summary>
        /// <param name="model">The referredto data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ReferredTo model)
        {
            model.Id = CreateReferredTo(model);
            return model.Id;
        }

        /// <summary>Updates a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <param name="updatedEntity">The referredto data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ReferredTo updatedEntity)
        {
            UpdateReferredTo(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <param name="updatedEntity">The referredto data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ReferredTo> updatedEntity)
        {
            PatchReferredTo(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific referredto by its primary key</summary>
        /// <param name="id">The primary key of the referredto</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReferredTo(id);
            return true;
        }
        #region
        private List<ReferredTo> GetReferredTo(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ReferredTo.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ReferredTo>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ReferredTo), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ReferredTo, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateReferredTo(ReferredTo model)
        {
            _dbContext.ReferredTo.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateReferredTo(Guid id, ReferredTo updatedEntity)
        {
            _dbContext.ReferredTo.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReferredTo(Guid id)
        {
            var entityData = _dbContext.ReferredTo.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ReferredTo.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReferredTo(Guid id, JsonPatchDocument<ReferredTo> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ReferredTo.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ReferredTo.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}