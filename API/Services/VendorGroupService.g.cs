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
    /// The vendorgroupService responsible for managing vendorgroup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting vendorgroup information.
    /// </remarks>
    public interface IVendorGroupService
    {
        /// <summary>Retrieves a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <returns>The vendorgroup data</returns>
        VendorGroup GetById(Guid id);

        /// <summary>Retrieves a list of vendorgroups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of vendorgroups</returns>
        List<VendorGroup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new vendorgroup</summary>
        /// <param name="model">The vendorgroup data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VendorGroup model);

        /// <summary>Updates a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <param name="updatedEntity">The vendorgroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VendorGroup updatedEntity);

        /// <summary>Updates a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <param name="updatedEntity">The vendorgroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VendorGroup> updatedEntity);

        /// <summary>Deletes a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The vendorgroupService responsible for managing vendorgroup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting vendorgroup information.
    /// </remarks>
    public class VendorGroupService : IVendorGroupService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VendorGroup class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VendorGroupService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <returns>The vendorgroup data</returns>
        public VendorGroup GetById(Guid id)
        {
            var entityData = _dbContext.VendorGroup.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of vendorgroups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of vendorgroups</returns>/// <exception cref="Exception"></exception>
        public List<VendorGroup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVendorGroup(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new vendorgroup</summary>
        /// <param name="model">The vendorgroup data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VendorGroup model)
        {
            model.Id = CreateVendorGroup(model);
            return model.Id;
        }

        /// <summary>Updates a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <param name="updatedEntity">The vendorgroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VendorGroup updatedEntity)
        {
            UpdateVendorGroup(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <param name="updatedEntity">The vendorgroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VendorGroup> updatedEntity)
        {
            PatchVendorGroup(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific vendorgroup by its primary key</summary>
        /// <param name="id">The primary key of the vendorgroup</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVendorGroup(id);
            return true;
        }
        #region
        private List<VendorGroup> GetVendorGroup(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VendorGroup.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VendorGroup>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VendorGroup), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VendorGroup, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVendorGroup(VendorGroup model)
        {
            _dbContext.VendorGroup.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVendorGroup(Guid id, VendorGroup updatedEntity)
        {
            _dbContext.VendorGroup.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVendorGroup(Guid id)
        {
            var entityData = _dbContext.VendorGroup.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VendorGroup.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVendorGroup(Guid id, JsonPatchDocument<VendorGroup> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VendorGroup.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VendorGroup.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}