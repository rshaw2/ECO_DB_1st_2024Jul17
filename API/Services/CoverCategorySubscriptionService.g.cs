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
    /// The covercategorysubscriptionService responsible for managing covercategorysubscription related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategorysubscription information.
    /// </remarks>
    public interface ICoverCategorySubscriptionService
    {
        /// <summary>Retrieves a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <returns>The covercategorysubscription data</returns>
        CoverCategorySubscription GetById(Guid id);

        /// <summary>Retrieves a list of covercategorysubscriptions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategorysubscriptions</returns>
        List<CoverCategorySubscription> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covercategorysubscription</summary>
        /// <param name="model">The covercategorysubscription data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CoverCategorySubscription model);

        /// <summary>Updates a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <param name="updatedEntity">The covercategorysubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CoverCategorySubscription updatedEntity);

        /// <summary>Updates a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <param name="updatedEntity">The covercategorysubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CoverCategorySubscription> updatedEntity);

        /// <summary>Deletes a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covercategorysubscriptionService responsible for managing covercategorysubscription related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covercategorysubscription information.
    /// </remarks>
    public class CoverCategorySubscriptionService : ICoverCategorySubscriptionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CoverCategorySubscription class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CoverCategorySubscriptionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <returns>The covercategorysubscription data</returns>
        public CoverCategorySubscription GetById(Guid id)
        {
            var entityData = _dbContext.CoverCategorySubscription.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covercategorysubscriptions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covercategorysubscriptions</returns>/// <exception cref="Exception"></exception>
        public List<CoverCategorySubscription> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCoverCategorySubscription(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covercategorysubscription</summary>
        /// <param name="model">The covercategorysubscription data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CoverCategorySubscription model)
        {
            model.Id = CreateCoverCategorySubscription(model);
            return model.Id;
        }

        /// <summary>Updates a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <param name="updatedEntity">The covercategorysubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CoverCategorySubscription updatedEntity)
        {
            UpdateCoverCategorySubscription(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <param name="updatedEntity">The covercategorysubscription data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CoverCategorySubscription> updatedEntity)
        {
            PatchCoverCategorySubscription(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covercategorysubscription by its primary key</summary>
        /// <param name="id">The primary key of the covercategorysubscription</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCoverCategorySubscription(id);
            return true;
        }
        #region
        private List<CoverCategorySubscription> GetCoverCategorySubscription(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CoverCategorySubscription.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CoverCategorySubscription>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CoverCategorySubscription), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CoverCategorySubscription, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCoverCategorySubscription(CoverCategorySubscription model)
        {
            _dbContext.CoverCategorySubscription.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCoverCategorySubscription(Guid id, CoverCategorySubscription updatedEntity)
        {
            _dbContext.CoverCategorySubscription.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCoverCategorySubscription(Guid id)
        {
            var entityData = _dbContext.CoverCategorySubscription.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CoverCategorySubscription.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCoverCategorySubscription(Guid id, JsonPatchDocument<CoverCategorySubscription> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CoverCategorySubscription.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CoverCategorySubscription.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}