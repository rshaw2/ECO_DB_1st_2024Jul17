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
    /// The addresstypeService responsible for managing addresstype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting addresstype information.
    /// </remarks>
    public interface IAddressTypeService
    {
        /// <summary>Retrieves a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <returns>The addresstype data</returns>
        AddressType GetById(Guid id);

        /// <summary>Retrieves a list of addresstypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of addresstypes</returns>
        List<AddressType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new addresstype</summary>
        /// <param name="model">The addresstype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AddressType model);

        /// <summary>Updates a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <param name="updatedEntity">The addresstype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AddressType updatedEntity);

        /// <summary>Updates a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <param name="updatedEntity">The addresstype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AddressType> updatedEntity);

        /// <summary>Deletes a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The addresstypeService responsible for managing addresstype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting addresstype information.
    /// </remarks>
    public class AddressTypeService : IAddressTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AddressType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AddressTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <returns>The addresstype data</returns>
        public AddressType GetById(Guid id)
        {
            var entityData = _dbContext.AddressType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of addresstypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of addresstypes</returns>/// <exception cref="Exception"></exception>
        public List<AddressType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAddressType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new addresstype</summary>
        /// <param name="model">The addresstype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AddressType model)
        {
            model.Id = CreateAddressType(model);
            return model.Id;
        }

        /// <summary>Updates a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <param name="updatedEntity">The addresstype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AddressType updatedEntity)
        {
            UpdateAddressType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <param name="updatedEntity">The addresstype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AddressType> updatedEntity)
        {
            PatchAddressType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific addresstype by its primary key</summary>
        /// <param name="id">The primary key of the addresstype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAddressType(id);
            return true;
        }
        #region
        private List<AddressType> GetAddressType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AddressType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AddressType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AddressType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AddressType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAddressType(AddressType model)
        {
            _dbContext.AddressType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAddressType(Guid id, AddressType updatedEntity)
        {
            _dbContext.AddressType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAddressType(Guid id)
        {
            var entityData = _dbContext.AddressType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AddressType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAddressType(Guid id, JsonPatchDocument<AddressType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AddressType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AddressType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}