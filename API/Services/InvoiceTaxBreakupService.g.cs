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
    /// The invoicetaxbreakupService responsible for managing invoicetaxbreakup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting invoicetaxbreakup information.
    /// </remarks>
    public interface IInvoiceTaxBreakupService
    {
        /// <summary>Retrieves a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <returns>The invoicetaxbreakup data</returns>
        InvoiceTaxBreakup GetById(Guid id);

        /// <summary>Retrieves a list of invoicetaxbreakups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of invoicetaxbreakups</returns>
        List<InvoiceTaxBreakup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new invoicetaxbreakup</summary>
        /// <param name="model">The invoicetaxbreakup data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvoiceTaxBreakup model);

        /// <summary>Updates a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <param name="updatedEntity">The invoicetaxbreakup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvoiceTaxBreakup updatedEntity);

        /// <summary>Updates a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <param name="updatedEntity">The invoicetaxbreakup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvoiceTaxBreakup> updatedEntity);

        /// <summary>Deletes a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The invoicetaxbreakupService responsible for managing invoicetaxbreakup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting invoicetaxbreakup information.
    /// </remarks>
    public class InvoiceTaxBreakupService : IInvoiceTaxBreakupService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvoiceTaxBreakup class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvoiceTaxBreakupService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <returns>The invoicetaxbreakup data</returns>
        public InvoiceTaxBreakup GetById(Guid id)
        {
            var entityData = _dbContext.InvoiceTaxBreakup.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of invoicetaxbreakups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of invoicetaxbreakups</returns>/// <exception cref="Exception"></exception>
        public List<InvoiceTaxBreakup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvoiceTaxBreakup(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new invoicetaxbreakup</summary>
        /// <param name="model">The invoicetaxbreakup data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvoiceTaxBreakup model)
        {
            model.Id = CreateInvoiceTaxBreakup(model);
            return model.Id;
        }

        /// <summary>Updates a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <param name="updatedEntity">The invoicetaxbreakup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvoiceTaxBreakup updatedEntity)
        {
            UpdateInvoiceTaxBreakup(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <param name="updatedEntity">The invoicetaxbreakup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvoiceTaxBreakup> updatedEntity)
        {
            PatchInvoiceTaxBreakup(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific invoicetaxbreakup by its primary key</summary>
        /// <param name="id">The primary key of the invoicetaxbreakup</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvoiceTaxBreakup(id);
            return true;
        }
        #region
        private List<InvoiceTaxBreakup> GetInvoiceTaxBreakup(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvoiceTaxBreakup.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvoiceTaxBreakup>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvoiceTaxBreakup), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvoiceTaxBreakup, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvoiceTaxBreakup(InvoiceTaxBreakup model)
        {
            _dbContext.InvoiceTaxBreakup.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvoiceTaxBreakup(Guid id, InvoiceTaxBreakup updatedEntity)
        {
            _dbContext.InvoiceTaxBreakup.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvoiceTaxBreakup(Guid id)
        {
            var entityData = _dbContext.InvoiceTaxBreakup.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvoiceTaxBreakup.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvoiceTaxBreakup(Guid id, JsonPatchDocument<InvoiceTaxBreakup> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvoiceTaxBreakup.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvoiceTaxBreakup.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}