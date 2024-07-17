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
    /// The tenantinvoicefilesService responsible for managing tenantinvoicefiles related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantinvoicefiles information.
    /// </remarks>
    public interface ITenantInvoiceFilesService
    {
        /// <summary>Retrieves a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <returns>The tenantinvoicefiles data</returns>
        TenantInvoiceFiles GetById(Guid id);

        /// <summary>Retrieves a list of tenantinvoicefiless based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantinvoicefiless</returns>
        List<TenantInvoiceFiles> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantinvoicefiles</summary>
        /// <param name="model">The tenantinvoicefiles data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantInvoiceFiles model);

        /// <summary>Updates a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <param name="updatedEntity">The tenantinvoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantInvoiceFiles updatedEntity);

        /// <summary>Updates a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <param name="updatedEntity">The tenantinvoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantInvoiceFiles> updatedEntity);

        /// <summary>Deletes a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantinvoicefilesService responsible for managing tenantinvoicefiles related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantinvoicefiles information.
    /// </remarks>
    public class TenantInvoiceFilesService : ITenantInvoiceFilesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantInvoiceFiles class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantInvoiceFilesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <returns>The tenantinvoicefiles data</returns>
        public TenantInvoiceFiles GetById(Guid id)
        {
            var entityData = _dbContext.TenantInvoiceFiles.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantinvoicefiless based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantinvoicefiless</returns>/// <exception cref="Exception"></exception>
        public List<TenantInvoiceFiles> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantInvoiceFiles(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantinvoicefiles</summary>
        /// <param name="model">The tenantinvoicefiles data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantInvoiceFiles model)
        {
            model.Id = CreateTenantInvoiceFiles(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <param name="updatedEntity">The tenantinvoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantInvoiceFiles updatedEntity)
        {
            UpdateTenantInvoiceFiles(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <param name="updatedEntity">The tenantinvoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantInvoiceFiles> updatedEntity)
        {
            PatchTenantInvoiceFiles(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantinvoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoicefiles</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantInvoiceFiles(id);
            return true;
        }
        #region
        private List<TenantInvoiceFiles> GetTenantInvoiceFiles(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantInvoiceFiles.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantInvoiceFiles>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantInvoiceFiles), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantInvoiceFiles, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantInvoiceFiles(TenantInvoiceFiles model)
        {
            _dbContext.TenantInvoiceFiles.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantInvoiceFiles(Guid id, TenantInvoiceFiles updatedEntity)
        {
            _dbContext.TenantInvoiceFiles.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantInvoiceFiles(Guid id)
        {
            var entityData = _dbContext.TenantInvoiceFiles.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantInvoiceFiles.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantInvoiceFiles(Guid id, JsonPatchDocument<TenantInvoiceFiles> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantInvoiceFiles.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantInvoiceFiles.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}