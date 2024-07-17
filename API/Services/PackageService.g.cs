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
    /// The packageService responsible for managing package related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting package information.
    /// </remarks>
    public interface IPackageService
    {
        /// <summary>Retrieves a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <returns>The package data</returns>
        Package GetById(Guid id);

        /// <summary>Retrieves a list of packages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packages</returns>
        List<Package> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new package</summary>
        /// <param name="model">The package data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Package model);

        /// <summary>Updates a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <param name="updatedEntity">The package data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Package updatedEntity);

        /// <summary>Updates a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <param name="updatedEntity">The package data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Package> updatedEntity);

        /// <summary>Deletes a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The packageService responsible for managing package related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting package information.
    /// </remarks>
    public class PackageService : IPackageService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Package class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PackageService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <returns>The package data</returns>
        public Package GetById(Guid id)
        {
            var entityData = _dbContext.Package.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of packages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of packages</returns>/// <exception cref="Exception"></exception>
        public List<Package> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPackage(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new package</summary>
        /// <param name="model">The package data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Package model)
        {
            model.Id = CreatePackage(model);
            return model.Id;
        }

        /// <summary>Updates a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <param name="updatedEntity">The package data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Package updatedEntity)
        {
            UpdatePackage(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <param name="updatedEntity">The package data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Package> updatedEntity)
        {
            PatchPackage(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific package by its primary key</summary>
        /// <param name="id">The primary key of the package</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePackage(id);
            return true;
        }
        #region
        private List<Package> GetPackage(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Package.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Package>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Package), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Package, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePackage(Package model)
        {
            _dbContext.Package.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePackage(Guid id, Package updatedEntity)
        {
            _dbContext.Package.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePackage(Guid id)
        {
            var entityData = _dbContext.Package.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Package.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPackage(Guid id, JsonPatchDocument<Package> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Package.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Package.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}