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
    /// The purchaseorderfileService responsible for managing purchaseorderfile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting purchaseorderfile information.
    /// </remarks>
    public interface IPurchaseOrderFileService
    {
        /// <summary>Retrieves a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <returns>The purchaseorderfile data</returns>
        PurchaseOrderFile GetById(Guid id);

        /// <summary>Retrieves a list of purchaseorderfiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchaseorderfiles</returns>
        List<PurchaseOrderFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new purchaseorderfile</summary>
        /// <param name="model">The purchaseorderfile data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PurchaseOrderFile model);

        /// <summary>Updates a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <param name="updatedEntity">The purchaseorderfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PurchaseOrderFile updatedEntity);

        /// <summary>Updates a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <param name="updatedEntity">The purchaseorderfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PurchaseOrderFile> updatedEntity);

        /// <summary>Deletes a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The purchaseorderfileService responsible for managing purchaseorderfile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting purchaseorderfile information.
    /// </remarks>
    public class PurchaseOrderFileService : IPurchaseOrderFileService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PurchaseOrderFile class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PurchaseOrderFileService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <returns>The purchaseorderfile data</returns>
        public PurchaseOrderFile GetById(Guid id)
        {
            var entityData = _dbContext.PurchaseOrderFile.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of purchaseorderfiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchaseorderfiles</returns>/// <exception cref="Exception"></exception>
        public List<PurchaseOrderFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPurchaseOrderFile(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new purchaseorderfile</summary>
        /// <param name="model">The purchaseorderfile data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PurchaseOrderFile model)
        {
            model.Id = CreatePurchaseOrderFile(model);
            return model.Id;
        }

        /// <summary>Updates a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <param name="updatedEntity">The purchaseorderfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PurchaseOrderFile updatedEntity)
        {
            UpdatePurchaseOrderFile(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <param name="updatedEntity">The purchaseorderfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PurchaseOrderFile> updatedEntity)
        {
            PatchPurchaseOrderFile(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific purchaseorderfile by its primary key</summary>
        /// <param name="id">The primary key of the purchaseorderfile</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePurchaseOrderFile(id);
            return true;
        }
        #region
        private List<PurchaseOrderFile> GetPurchaseOrderFile(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PurchaseOrderFile.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PurchaseOrderFile>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PurchaseOrderFile), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PurchaseOrderFile, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePurchaseOrderFile(PurchaseOrderFile model)
        {
            _dbContext.PurchaseOrderFile.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePurchaseOrderFile(Guid id, PurchaseOrderFile updatedEntity)
        {
            _dbContext.PurchaseOrderFile.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePurchaseOrderFile(Guid id)
        {
            var entityData = _dbContext.PurchaseOrderFile.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PurchaseOrderFile.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPurchaseOrderFile(Guid id, JsonPatchDocument<PurchaseOrderFile> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PurchaseOrderFile.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PurchaseOrderFile.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}