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
    /// The loyaltyprogramService responsible for managing loyaltyprogram related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting loyaltyprogram information.
    /// </remarks>
    public interface ILoyaltyProgramService
    {
        /// <summary>Retrieves a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <returns>The loyaltyprogram data</returns>
        LoyaltyProgram GetById(Guid id);

        /// <summary>Retrieves a list of loyaltyprograms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of loyaltyprograms</returns>
        List<LoyaltyProgram> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new loyaltyprogram</summary>
        /// <param name="model">The loyaltyprogram data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(LoyaltyProgram model);

        /// <summary>Updates a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <param name="updatedEntity">The loyaltyprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, LoyaltyProgram updatedEntity);

        /// <summary>Updates a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <param name="updatedEntity">The loyaltyprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<LoyaltyProgram> updatedEntity);

        /// <summary>Deletes a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The loyaltyprogramService responsible for managing loyaltyprogram related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting loyaltyprogram information.
    /// </remarks>
    public class LoyaltyProgramService : ILoyaltyProgramService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the LoyaltyProgram class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LoyaltyProgramService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <returns>The loyaltyprogram data</returns>
        public LoyaltyProgram GetById(Guid id)
        {
            var entityData = _dbContext.LoyaltyProgram.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of loyaltyprograms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of loyaltyprograms</returns>/// <exception cref="Exception"></exception>
        public List<LoyaltyProgram> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLoyaltyProgram(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new loyaltyprogram</summary>
        /// <param name="model">The loyaltyprogram data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(LoyaltyProgram model)
        {
            model.Id = CreateLoyaltyProgram(model);
            return model.Id;
        }

        /// <summary>Updates a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <param name="updatedEntity">The loyaltyprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, LoyaltyProgram updatedEntity)
        {
            UpdateLoyaltyProgram(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <param name="updatedEntity">The loyaltyprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<LoyaltyProgram> updatedEntity)
        {
            PatchLoyaltyProgram(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific loyaltyprogram by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogram</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLoyaltyProgram(id);
            return true;
        }
        #region
        private List<LoyaltyProgram> GetLoyaltyProgram(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LoyaltyProgram.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LoyaltyProgram>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LoyaltyProgram), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LoyaltyProgram, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLoyaltyProgram(LoyaltyProgram model)
        {
            _dbContext.LoyaltyProgram.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLoyaltyProgram(Guid id, LoyaltyProgram updatedEntity)
        {
            _dbContext.LoyaltyProgram.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLoyaltyProgram(Guid id)
        {
            var entityData = _dbContext.LoyaltyProgram.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LoyaltyProgram.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLoyaltyProgram(Guid id, JsonPatchDocument<LoyaltyProgram> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LoyaltyProgram.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LoyaltyProgram.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}