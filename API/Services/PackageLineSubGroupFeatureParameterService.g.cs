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
    /// The packagelinesubgroupfeatureparameterService responsible for managing packagelinesubgroupfeatureparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packagelinesubgroupfeatureparameter information.
    /// </remarks>
    public interface IPackageLineSubGroupFeatureParameterService
    {
        /// <summary>Retrieves a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <returns>The packagelinesubgroupfeatureparameter data</returns>
        PackageLineSubGroupFeatureParameter GetById(Guid id);

        /// <summary>Retrieves a list of packagelinesubgroupfeatureparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagelinesubgroupfeatureparameters</returns>
        List<PackageLineSubGroupFeatureParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new packagelinesubgroupfeatureparameter</summary>
        /// <param name="model">The packagelinesubgroupfeatureparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PackageLineSubGroupFeatureParameter model);

        /// <summary>Updates a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PackageLineSubGroupFeatureParameter updatedEntity);

        /// <summary>Updates a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PackageLineSubGroupFeatureParameter> updatedEntity);

        /// <summary>Deletes a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The packagelinesubgroupfeatureparameterService responsible for managing packagelinesubgroupfeatureparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packagelinesubgroupfeatureparameter information.
    /// </remarks>
    public class PackageLineSubGroupFeatureParameterService : IPackageLineSubGroupFeatureParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PackageLineSubGroupFeatureParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PackageLineSubGroupFeatureParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <returns>The packagelinesubgroupfeatureparameter data</returns>
        public PackageLineSubGroupFeatureParameter GetById(Guid id)
        {
            var entityData = _dbContext.PackageLineSubGroupFeatureParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of packagelinesubgroupfeatureparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagelinesubgroupfeatureparameters</returns>/// <exception cref="Exception"></exception>
        public List<PackageLineSubGroupFeatureParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPackageLineSubGroupFeatureParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new packagelinesubgroupfeatureparameter</summary>
        /// <param name="model">The packagelinesubgroupfeatureparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PackageLineSubGroupFeatureParameter model)
        {
            model.Id = CreatePackageLineSubGroupFeatureParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PackageLineSubGroupFeatureParameter updatedEntity)
        {
            UpdatePackageLineSubGroupFeatureParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <param name="updatedEntity">The packagelinesubgroupfeatureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PackageLineSubGroupFeatureParameter> updatedEntity)
        {
            PatchPackageLineSubGroupFeatureParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific packagelinesubgroupfeatureparameter by its primary key</summary>
        /// <param name="id">The primary key of the packagelinesubgroupfeatureparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePackageLineSubGroupFeatureParameter(id);
            return true;
        }
        #region
        private List<PackageLineSubGroupFeatureParameter> GetPackageLineSubGroupFeatureParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PackageLineSubGroupFeatureParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PackageLineSubGroupFeatureParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PackageLineSubGroupFeatureParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PackageLineSubGroupFeatureParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePackageLineSubGroupFeatureParameter(PackageLineSubGroupFeatureParameter model)
        {
            _dbContext.PackageLineSubGroupFeatureParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePackageLineSubGroupFeatureParameter(Guid id, PackageLineSubGroupFeatureParameter updatedEntity)
        {
            _dbContext.PackageLineSubGroupFeatureParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePackageLineSubGroupFeatureParameter(Guid id)
        {
            var entityData = _dbContext.PackageLineSubGroupFeatureParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PackageLineSubGroupFeatureParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPackageLineSubGroupFeatureParameter(Guid id, JsonPatchDocument<PackageLineSubGroupFeatureParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PackageLineSubGroupFeatureParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PackageLineSubGroupFeatureParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}