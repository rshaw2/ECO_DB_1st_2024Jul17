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
    /// The invoicecounterService responsible for managing invoicecounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting invoicecounter information.
    /// </remarks>
    public interface IInvoiceCounterService
    {
        /// <summary>Retrieves a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <returns>The invoicecounter data</returns>
        InvoiceCounter GetById(Guid id);

        /// <summary>Retrieves a list of invoicecounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of invoicecounters</returns>
        List<InvoiceCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new invoicecounter</summary>
        /// <param name="model">The invoicecounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(InvoiceCounter model);

        /// <summary>Updates a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <param name="updatedEntity">The invoicecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvoiceCounter updatedEntity);

        /// <summary>Updates a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <param name="updatedEntity">The invoicecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvoiceCounter> updatedEntity);

        /// <summary>Deletes a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The invoicecounterService responsible for managing invoicecounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting invoicecounter information.
    /// </remarks>
    public class InvoiceCounterService : IInvoiceCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvoiceCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvoiceCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <returns>The invoicecounter data</returns>
        public InvoiceCounter GetById(Guid id)
        {
            var entityData = _dbContext.InvoiceCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of invoicecounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of invoicecounters</returns>/// <exception cref="Exception"></exception>
        public List<InvoiceCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvoiceCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new invoicecounter</summary>
        /// <param name="model">The invoicecounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(InvoiceCounter model)
        {
            model.TenantId = CreateInvoiceCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <param name="updatedEntity">The invoicecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvoiceCounter updatedEntity)
        {
            UpdateInvoiceCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <param name="updatedEntity">The invoicecounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvoiceCounter> updatedEntity)
        {
            PatchInvoiceCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific invoicecounter by its primary key</summary>
        /// <param name="id">The primary key of the invoicecounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvoiceCounter(id);
            return true;
        }
        #region
        private List<InvoiceCounter> GetInvoiceCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvoiceCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvoiceCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvoiceCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvoiceCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateInvoiceCounter(InvoiceCounter model)
        {
            _dbContext.InvoiceCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateInvoiceCounter(Guid id, InvoiceCounter updatedEntity)
        {
            _dbContext.InvoiceCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvoiceCounter(Guid id)
        {
            var entityData = _dbContext.InvoiceCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvoiceCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvoiceCounter(Guid id, JsonPatchDocument<InvoiceCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvoiceCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvoiceCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}