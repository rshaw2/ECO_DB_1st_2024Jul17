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
    /// The packagelinesubgroupfeatureService responsible for managing packagelinesubgroupfeature related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packagelinesubgroupfeature information.
    /// </remarks>
    public interface IPackageLineSubGroupFeatureService
    {
        /// <summary>Retrieves a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <returns>The packagelinesubgroupfeature data</returns>
        PackageLineSubGroupFeature GetById(Guid id);

        /// <summary>Retrieves a list of packagelinesubgroupfeatures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagelinesubgroupfeatures</returns>
        List<PackageLineSubGroupFeature> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new packagelinesubgroupfeature</summary>
        /// <param name="model">The packagelinesubgroupfeature data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PackageLineSubGroupFeature model);

        /// <summary>Updates a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PackageLineSubGroupFeature updatedEntity);

        /// <summary>Updates a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PackageLineSubGroupFeature> updatedEntity);

        /// <summary>Deletes a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The packagelinesubgroupfeatureService responsible for managing packagelinesubgroupfeature related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packagelinesubgroupfeature information.
    /// </remarks>
    public class PackageLineSubGroupFeatureService : IPackageLineSubGroupFeatureService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PackageLineSubGroupFeature class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PackageLineSubGroupFeatureService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <returns>The packagelinesubgroupfeature data</returns>
        public PackageLineSubGroupFeature GetById(Guid id)
        {
            var entityData = _dbContext.PackageLineSubGroupFeature.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of packagelinesubgroupfeatures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagelinesubgroupfeatures</returns>/// <exception cref="Exception"></exception>
        public List<PackageLineSubGroupFeature> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPackageLineSubGroupFeature(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new packagelinesubgroupfeature</summary>
        /// <param name="model">The packagelinesubgroupfeature data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PackageLineSubGroupFeature model)
        {
            model.Id = CreatePackageLineSubGroupFeature(model);
            return model.Id;
        }

        /// <summary>Updates a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PackageLineSubGroupFeature updatedEntity)
        {
            UpdatePackageLineSubGroupFeature(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeature data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PackageLineSubGroupFeature> updatedEntity)
        {
            PatchPackageLineSubGroupFeature(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific packagelinesubgroupfeature by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeature</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePackageLineSubGroupFeature(id);
            return true;
        }
        #region
        private List<PackageLineSubGroupFeature> GetPackageLineSubGroupFeature(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PackageLineSubGroupFeature.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PackageLineSubGroupFeature>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PackageLineSubGroupFeature), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PackageLineSubGroupFeature, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePackageLineSubGroupFeature(PackageLineSubGroupFeature model)
        {
            _dbContext.PackageLineSubGroupFeature.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePackageLineSubGroupFeature(Guid id, PackageLineSubGroupFeature updatedEntity)
        {
            _dbContext.PackageLineSubGroupFeature.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePackageLineSubGroupFeature(Guid id)
        {
            var entityData = _dbContext.PackageLineSubGroupFeature.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PackageLineSubGroupFeature.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPackageLineSubGroupFeature(Guid id, JsonPatchDocument<PackageLineSubGroupFeature> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PackageLineSubGroupFeature.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PackageLineSubGroupFeature.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}