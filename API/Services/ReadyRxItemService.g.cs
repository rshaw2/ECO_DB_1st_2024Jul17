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
    /// The readyrxitemService responsible for managing readyrxitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting readyrxitem information.
    /// </remarks>
    public interface IReadyRxItemService
    {
        /// <summary>Retrieves a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <returns>The readyrxitem data</returns>
        ReadyRxItem GetById(Guid id);

        /// <summary>Retrieves a list of readyrxitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of readyrxitems</returns>
        List<ReadyRxItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new readyrxitem</summary>
        /// <param name="model">The readyrxitem data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ReadyRxItem model);

        /// <summary>Updates a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <param name="updatedEntity">The readyrxitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ReadyRxItem updatedEntity);

        /// <summary>Updates a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <param name="updatedEntity">The readyrxitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ReadyRxItem> updatedEntity);

        /// <summary>Deletes a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The readyrxitemService responsible for managing readyrxitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting readyrxitem information.
    /// </remarks>
    public class ReadyRxItemService : IReadyRxItemService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ReadyRxItem class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReadyRxItemService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <returns>The readyrxitem data</returns>
        public ReadyRxItem GetById(Guid id)
        {
            var entityData = _dbContext.ReadyRxItem.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of readyrxitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of readyrxitems</returns>/// <exception cref="Exception"></exception>
        public List<ReadyRxItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReadyRxItem(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new readyrxitem</summary>
        /// <param name="model">The readyrxitem data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ReadyRxItem model)
        {
            model.Id = CreateReadyRxItem(model);
            return model.Id;
        }

        /// <summary>Updates a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <param name="updatedEntity">The readyrxitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ReadyRxItem updatedEntity)
        {
            UpdateReadyRxItem(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <param name="updatedEntity">The readyrxitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ReadyRxItem> updatedEntity)
        {
            PatchReadyRxItem(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific readyrxitem by its primary key</summary>
        /// <param name="id">The primary key of the readyrxitem</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReadyRxItem(id);
            return true;
        }
        #region
        private List<ReadyRxItem> GetReadyRxItem(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ReadyRxItem.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ReadyRxItem>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ReadyRxItem), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ReadyRxItem, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateReadyRxItem(ReadyRxItem model)
        {
            _dbContext.ReadyRxItem.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateReadyRxItem(Guid id, ReadyRxItem updatedEntity)
        {
            _dbContext.ReadyRxItem.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReadyRxItem(Guid id)
        {
            var entityData = _dbContext.ReadyRxItem.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ReadyRxItem.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReadyRxItem(Guid id, JsonPatchDocument<ReadyRxItem> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ReadyRxItem.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ReadyRxItem.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}