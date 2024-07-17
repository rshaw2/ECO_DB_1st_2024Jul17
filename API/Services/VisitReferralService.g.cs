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
    /// The visitreferralService responsible for managing visitreferral related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitreferral information.
    /// </remarks>
    public interface IVisitReferralService
    {
        /// <summary>Retrieves a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <returns>The visitreferral data</returns>
        VisitReferral GetById(Guid id);

        /// <summary>Retrieves a list of visitreferrals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitreferrals</returns>
        List<VisitReferral> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitreferral</summary>
        /// <param name="model">The visitreferral data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitReferral model);

        /// <summary>Updates a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <param name="updatedEntity">The visitreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitReferral updatedEntity);

        /// <summary>Updates a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <param name="updatedEntity">The visitreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitReferral> updatedEntity);

        /// <summary>Deletes a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitreferralService responsible for managing visitreferral related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitreferral information.
    /// </remarks>
    public class VisitReferralService : IVisitReferralService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitReferral class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitReferralService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <returns>The visitreferral data</returns>
        public VisitReferral GetById(Guid id)
        {
            var entityData = _dbContext.VisitReferral.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitreferrals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitreferrals</returns>/// <exception cref="Exception"></exception>
        public List<VisitReferral> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitReferral(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitreferral</summary>
        /// <param name="model">The visitreferral data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitReferral model)
        {
            model.Id = CreateVisitReferral(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <param name="updatedEntity">The visitreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitReferral updatedEntity)
        {
            UpdateVisitReferral(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <param name="updatedEntity">The visitreferral data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitReferral> updatedEntity)
        {
            PatchVisitReferral(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitreferral by its primary key</summary>
        /// <param name="id">The primary key of the visitreferral</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitReferral(id);
            return true;
        }
        #region
        private List<VisitReferral> GetVisitReferral(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitReferral.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitReferral>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitReferral), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitReferral, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitReferral(VisitReferral model)
        {
            _dbContext.VisitReferral.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitReferral(Guid id, VisitReferral updatedEntity)
        {
            _dbContext.VisitReferral.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitReferral(Guid id)
        {
            var entityData = _dbContext.VisitReferral.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitReferral.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitReferral(Guid id, JsonPatchDocument<VisitReferral> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitReferral.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitReferral.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}