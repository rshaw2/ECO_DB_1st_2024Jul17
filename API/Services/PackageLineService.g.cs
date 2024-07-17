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
    /// The packagelineService responsible for managing packageline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packageline information.
    /// </remarks>
    public interface IPackageLineService
    {
        /// <summary>Retrieves a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <returns>The packageline data</returns>
        PackageLine GetById(Guid id);

        /// <summary>Retrieves a list of packagelines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagelines</returns>
        List<PackageLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new packageline</summary>
        /// <param name="model">The packageline data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PackageLine model);

        /// <summary>Updates a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <param name="updatedEntity">The packageline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PackageLine updatedEntity);

        /// <summary>Updates a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <param name="updatedEntity">The packageline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PackageLine> updatedEntity);

        /// <summary>Deletes a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The packagelineService responsible for managing packageline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packageline information.
    /// </remarks>
    public class PackageLineService : IPackageLineService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PackageLine class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PackageLineService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <returns>The packageline data</returns>
        public PackageLine GetById(Guid id)
        {
            var entityData = _dbContext.PackageLine.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of packagelines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagelines</returns>/// <exception cref="Exception"></exception>
        public List<PackageLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPackageLine(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new packageline</summary>
        /// <param name="model">The packageline data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PackageLine model)
        {
            model.Id = CreatePackageLine(model);
            return model.Id;
        }

        /// <summary>Updates a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <param name="updatedEntity">The packageline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PackageLine updatedEntity)
        {
            UpdatePackageLine(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <param name="updatedEntity">The packageline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PackageLine> updatedEntity)
        {
            PatchPackageLine(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific packageline by its primary key</summary>
        /// <param name="id">The primary key of the packageline</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePackageLine(id);
            return true;
        }
        #region
        private List<PackageLine> GetPackageLine(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PackageLine.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PackageLine>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PackageLine), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PackageLine, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePackageLine(PackageLine model)
        {
            _dbContext.PackageLine.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePackageLine(Guid id, PackageLine updatedEntity)
        {
            _dbContext.PackageLine.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePackageLine(Guid id)
        {
            var entityData = _dbContext.PackageLine.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PackageLine.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPackageLine(Guid id, JsonPatchDocument<PackageLine> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PackageLine.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PackageLine.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}