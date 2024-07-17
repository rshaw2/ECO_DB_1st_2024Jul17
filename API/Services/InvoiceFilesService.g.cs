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
    /// The invoicefilesService responsible for managing invoicefiles related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting invoicefiles information.
    /// </remarks>
    public interface IInvoiceFilesService
    {
        /// <summary>Retrieves a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <returns>The invoicefiles data</returns>
        InvoiceFiles GetById(Guid id);

        /// <summary>Retrieves a list of invoicefiless based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of invoicefiless</returns>
        List<InvoiceFiles> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new invoicefiles</summary>
        /// <param name="model">The invoicefiles data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvoiceFiles model);

        /// <summary>Updates a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <param name="updatedEntity">The invoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvoiceFiles updatedEntity);

        /// <summary>Updates a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <param name="updatedEntity">The invoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvoiceFiles> updatedEntity);

        /// <summary>Deletes a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The invoicefilesService responsible for managing invoicefiles related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting invoicefiles information.
    /// </remarks>
    public class InvoiceFilesService : IInvoiceFilesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvoiceFiles class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvoiceFilesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <returns>The invoicefiles data</returns>
        public InvoiceFiles GetById(Guid id)
        {
            var entityData = _dbContext.InvoiceFiles.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of invoicefiless based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of invoicefiless</returns>/// <exception cref="Exception"></exception>
        public List<InvoiceFiles> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvoiceFiles(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new invoicefiles</summary>
        /// <param name="model">The invoicefiles data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvoiceFiles model)
        {
            model.Id = CreateInvoiceFiles(model);
            return model.Id;
        }

        /// <summary>Updates a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <param name="updatedEntity">The invoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvoiceFiles updatedEntity)
        {
            UpdateInvoiceFiles(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <param name="updatedEntity">The invoicefiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvoiceFiles> updatedEntity)
        {
            PatchInvoiceFiles(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific invoicefiles by its primary key</summary>
        /// <param name="id">The primary key of the invoicefiles</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvoiceFiles(id);
            return true;
        }
        #region
        private List<InvoiceFiles> GetInvoiceFiles(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvoiceFiles.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvoiceFiles>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvoiceFiles), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvoiceFiles, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvoiceFiles(InvoiceFiles model)
        {
            _dbContext.InvoiceFiles.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvoiceFiles(Guid id, InvoiceFiles updatedEntity)
        {
            _dbContext.InvoiceFiles.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvoiceFiles(Guid id)
        {
            var entityData = _dbContext.InvoiceFiles.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvoiceFiles.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvoiceFiles(Guid id, JsonPatchDocument<InvoiceFiles> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvoiceFiles.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvoiceFiles.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}