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
    /// The loyaltyprogramruleService responsible for managing loyaltyprogramrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting loyaltyprogramrule information.
    /// </remarks>
    public interface ILoyaltyProgramRuleService
    {
        /// <summary>Retrieves a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <returns>The loyaltyprogramrule data</returns>
        LoyaltyProgramRule GetById(Guid id);

        /// <summary>Retrieves a list of loyaltyprogramrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of loyaltyprogramrules</returns>
        List<LoyaltyProgramRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new loyaltyprogramrule</summary>
        /// <param name="model">The loyaltyprogramrule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(LoyaltyProgramRule model);

        /// <summary>Updates a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <param name="updatedEntity">The loyaltyprogramrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, LoyaltyProgramRule updatedEntity);

        /// <summary>Updates a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <param name="updatedEntity">The loyaltyprogramrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<LoyaltyProgramRule> updatedEntity);

        /// <summary>Deletes a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The loyaltyprogramruleService responsible for managing loyaltyprogramrule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting loyaltyprogramrule information.
    /// </remarks>
    public class LoyaltyProgramRuleService : ILoyaltyProgramRuleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the LoyaltyProgramRule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LoyaltyProgramRuleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <returns>The loyaltyprogramrule data</returns>
        public LoyaltyProgramRule GetById(Guid id)
        {
            var entityData = _dbContext.LoyaltyProgramRule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of loyaltyprogramrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of loyaltyprogramrules</returns>/// <exception cref="Exception"></exception>
        public List<LoyaltyProgramRule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLoyaltyProgramRule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new loyaltyprogramrule</summary>
        /// <param name="model">The loyaltyprogramrule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(LoyaltyProgramRule model)
        {
            model.Id = CreateLoyaltyProgramRule(model);
            return model.Id;
        }

        /// <summary>Updates a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <param name="updatedEntity">The loyaltyprogramrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, LoyaltyProgramRule updatedEntity)
        {
            UpdateLoyaltyProgramRule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <param name="updatedEntity">The loyaltyprogramrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<LoyaltyProgramRule> updatedEntity)
        {
            PatchLoyaltyProgramRule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific loyaltyprogramrule by its primary key</summary>
        /// <param name="id">The primary key of the loyaltyprogramrule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLoyaltyProgramRule(id);
            return true;
        }
        #region
        private List<LoyaltyProgramRule> GetLoyaltyProgramRule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LoyaltyProgramRule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LoyaltyProgramRule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LoyaltyProgramRule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LoyaltyProgramRule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLoyaltyProgramRule(LoyaltyProgramRule model)
        {
            _dbContext.LoyaltyProgramRule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLoyaltyProgramRule(Guid id, LoyaltyProgramRule updatedEntity)
        {
            _dbContext.LoyaltyProgramRule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLoyaltyProgramRule(Guid id)
        {
            var entityData = _dbContext.LoyaltyProgramRule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LoyaltyProgramRule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLoyaltyProgramRule(Guid id, JsonPatchDocument<LoyaltyProgramRule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LoyaltyProgramRule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LoyaltyProgramRule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}