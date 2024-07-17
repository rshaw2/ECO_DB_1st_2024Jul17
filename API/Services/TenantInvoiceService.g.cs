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
    /// The tenantinvoiceService responsible for managing tenantinvoice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantinvoice information.
    /// </remarks>
    public interface ITenantInvoiceService
    {
        /// <summary>Retrieves a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <returns>The tenantinvoice data</returns>
        TenantInvoice GetById(Guid id);

        /// <summary>Retrieves a list of tenantinvoices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantinvoices</returns>
        List<TenantInvoice> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new tenantinvoice</summary>
        /// <param name="model">The tenantinvoice data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(TenantInvoice model);

        /// <summary>Updates a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <param name="updatedEntity">The tenantinvoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, TenantInvoice updatedEntity);

        /// <summary>Updates a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <param name="updatedEntity">The tenantinvoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<TenantInvoice> updatedEntity);

        /// <summary>Deletes a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The tenantinvoiceService responsible for managing tenantinvoice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting tenantinvoice information.
    /// </remarks>
    public class TenantInvoiceService : ITenantInvoiceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the TenantInvoice class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public TenantInvoiceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <returns>The tenantinvoice data</returns>
        public TenantInvoice GetById(Guid id)
        {
            var entityData = _dbContext.TenantInvoice.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of tenantinvoices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tenantinvoices</returns>/// <exception cref="Exception"></exception>
        public List<TenantInvoice> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetTenantInvoice(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new tenantinvoice</summary>
        /// <param name="model">The tenantinvoice data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(TenantInvoice model)
        {
            model.Id = CreateTenantInvoice(model);
            return model.Id;
        }

        /// <summary>Updates a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <param name="updatedEntity">The tenantinvoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, TenantInvoice updatedEntity)
        {
            UpdateTenantInvoice(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <param name="updatedEntity">The tenantinvoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<TenantInvoice> updatedEntity)
        {
            PatchTenantInvoice(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific tenantinvoice by its primary key</summary>
        /// <param name="id">The primary key of the tenantinvoice</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteTenantInvoice(id);
            return true;
        }
        #region
        private List<TenantInvoice> GetTenantInvoice(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TenantInvoice.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TenantInvoice>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TenantInvoice), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TenantInvoice, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateTenantInvoice(TenantInvoice model)
        {
            _dbContext.TenantInvoice.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateTenantInvoice(Guid id, TenantInvoice updatedEntity)
        {
            _dbContext.TenantInvoice.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteTenantInvoice(Guid id)
        {
            var entityData = _dbContext.TenantInvoice.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TenantInvoice.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchTenantInvoice(Guid id, JsonPatchDocument<TenantInvoice> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TenantInvoice.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TenantInvoice.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}