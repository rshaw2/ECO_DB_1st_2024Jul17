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
    /// The packagesubscriptionService responsible for managing packagesubscription related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packagesubscription information.
    /// </remarks>
    public interface IPackageSubscriptionService
    {
        /// <summary>Retrieves a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <returns>The packagesubscription data</returns>
        PackageSubscription GetById(Guid id);

        /// <summary>Retrieves a list of packagesubscriptions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagesubscriptions</returns>
        List<PackageSubscription> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new packagesubscription</summary>
        /// <param name="model">The packagesubscription data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PackageSubscription model);

        /// <summary>Updates a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <param name="updatedEntity">The packagesubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PackageSubscription updatedEntity);

        /// <summary>Updates a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <param name="updatedEntity">The packagesubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PackageSubscription> updatedEntity);

        /// <summary>Deletes a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The packagesubscriptionService responsible for managing packagesubscription related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting packagesubscription information.
    /// </remarks>
    public class PackageSubscriptionService : IPackageSubscriptionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PackageSubscription class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PackageSubscriptionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <returns>The packagesubscription data</returns>
        public PackageSubscription GetById(Guid id)
        {
            var entityData = _dbContext.PackageSubscription.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of packagesubscriptions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packagesubscriptions</returns>/// <exception cref="Exception"></exception>
        public List<PackageSubscription> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPackageSubscription(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new packagesubscription</summary>
        /// <param name="model">The packagesubscription data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PackageSubscription model)
        {
            model.Id = CreatePackageSubscription(model);
            return model.Id;
        }

        /// <summary>Updates a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <param name="updatedEntity">The packagesubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PackageSubscription updatedEntity)
        {
            UpdatePackageSubscription(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <param name="updatedEntity">The packagesubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PackageSubscription> updatedEntity)
        {
            PatchPackageSubscription(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific packagesubscription by its primary key</summary>
        /// <param name="id">The primary key of the packagesubscription</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePackageSubscription(id);
            return true;
        }
        #region
        private List<PackageSubscription> GetPackageSubscription(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PackageSubscription.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PackageSubscription>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PackageSubscription), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PackageSubscription, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePackageSubscription(PackageSubscription model)
        {
            _dbContext.PackageSubscription.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePackageSubscription(Guid id, PackageSubscription updatedEntity)
        {
            _dbContext.PackageSubscription.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePackageSubscription(Guid id)
        {
            var entityData = _dbContext.PackageSubscription.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PackageSubscription.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPackageSubscription(Guid id, JsonPatchDocument<PackageSubscription> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PackageSubscription.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PackageSubscription.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}