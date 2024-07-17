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
    /// The mobileverificationService responsible for managing mobileverification related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting mobileverification information.
    /// </remarks>
    public interface IMobileVerificationService
    {
        /// <summary>Retrieves a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <returns>The mobileverification data</returns>
        MobileVerification GetById(Guid id);

        /// <summary>Retrieves a list of mobileverifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of mobileverifications</returns>
        List<MobileVerification> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new mobileverification</summary>
        /// <param name="model">The mobileverification data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MobileVerification model);

        /// <summary>Updates a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <param name="updatedEntity">The mobileverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MobileVerification updatedEntity);

        /// <summary>Updates a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <param name="updatedEntity">The mobileverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MobileVerification> updatedEntity);

        /// <summary>Deletes a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The mobileverificationService responsible for managing mobileverification related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting mobileverification information.
    /// </remarks>
    public class MobileVerificationService : IMobileVerificationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MobileVerification class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MobileVerificationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <returns>The mobileverification data</returns>
        public MobileVerification GetById(Guid id)
        {
            var entityData = _dbContext.MobileVerification.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of mobileverifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of mobileverifications</returns>/// <exception cref="Exception"></exception>
        public List<MobileVerification> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMobileVerification(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new mobileverification</summary>
        /// <param name="model">The mobileverification data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MobileVerification model)
        {
            model.Id = CreateMobileVerification(model);
            return model.Id;
        }

        /// <summary>Updates a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <param name="updatedEntity">The mobileverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MobileVerification updatedEntity)
        {
            UpdateMobileVerification(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <param name="updatedEntity">The mobileverification data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MobileVerification> updatedEntity)
        {
            PatchMobileVerification(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific mobileverification by its primary key</summary>
        /// <param name="id">The primary key of the mobileverification</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMobileVerification(id);
            return true;
        }
        #region
        private List<MobileVerification> GetMobileVerification(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MobileVerification.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MobileVerification>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MobileVerification), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MobileVerification, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMobileVerification(MobileVerification model)
        {
            _dbContext.MobileVerification.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMobileVerification(Guid id, MobileVerification updatedEntity)
        {
            _dbContext.MobileVerification.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMobileVerification(Guid id)
        {
            var entityData = _dbContext.MobileVerification.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MobileVerification.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMobileVerification(Guid id, JsonPatchDocument<MobileVerification> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MobileVerification.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MobileVerification.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}