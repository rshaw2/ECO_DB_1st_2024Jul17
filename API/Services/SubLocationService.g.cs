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
    /// The sublocationService responsible for managing sublocation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting sublocation information.
    /// </remarks>
    public interface ISubLocationService
    {
        /// <summary>Retrieves a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <returns>The sublocation data</returns>
        SubLocation GetById(Guid id);

        /// <summary>Retrieves a list of sublocations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of sublocations</returns>
        List<SubLocation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new sublocation</summary>
        /// <param name="model">The sublocation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SubLocation model);

        /// <summary>Updates a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <param name="updatedEntity">The sublocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SubLocation updatedEntity);

        /// <summary>Updates a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <param name="updatedEntity">The sublocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SubLocation> updatedEntity);

        /// <summary>Deletes a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The sublocationService responsible for managing sublocation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting sublocation information.
    /// </remarks>
    public class SubLocationService : ISubLocationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SubLocation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SubLocationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <returns>The sublocation data</returns>
        public SubLocation GetById(Guid id)
        {
            var entityData = _dbContext.SubLocation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of sublocations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of sublocations</returns>/// <exception cref="Exception"></exception>
        public List<SubLocation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSubLocation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new sublocation</summary>
        /// <param name="model">The sublocation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SubLocation model)
        {
            model.Id = CreateSubLocation(model);
            return model.Id;
        }

        /// <summary>Updates a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <param name="updatedEntity">The sublocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SubLocation updatedEntity)
        {
            UpdateSubLocation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <param name="updatedEntity">The sublocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SubLocation> updatedEntity)
        {
            PatchSubLocation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific sublocation by its primary key</summary>
        /// <param name="id">The primary key of the sublocation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSubLocation(id);
            return true;
        }
        #region
        private List<SubLocation> GetSubLocation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SubLocation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SubLocation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SubLocation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SubLocation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSubLocation(SubLocation model)
        {
            _dbContext.SubLocation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSubLocation(Guid id, SubLocation updatedEntity)
        {
            _dbContext.SubLocation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSubLocation(Guid id)
        {
            var entityData = _dbContext.SubLocation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SubLocation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSubLocation(Guid id, JsonPatchDocument<SubLocation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SubLocation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SubLocation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}