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
    /// The roleoperationscopeService responsible for managing roleoperationscope related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roleoperationscope information.
    /// </remarks>
    public interface IRoleOperationScopeService
    {
        /// <summary>Retrieves a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <returns>The roleoperationscope data</returns>
        RoleOperationScope GetById(Guid id);

        /// <summary>Retrieves a list of roleoperationscopes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roleoperationscopes</returns>
        List<RoleOperationScope> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new roleoperationscope</summary>
        /// <param name="model">The roleoperationscope data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(RoleOperationScope model);

        /// <summary>Updates a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <param name="updatedEntity">The roleoperationscope data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, RoleOperationScope updatedEntity);

        /// <summary>Updates a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <param name="updatedEntity">The roleoperationscope data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<RoleOperationScope> updatedEntity);

        /// <summary>Deletes a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The roleoperationscopeService responsible for managing roleoperationscope related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roleoperationscope information.
    /// </remarks>
    public class RoleOperationScopeService : IRoleOperationScopeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the RoleOperationScope class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RoleOperationScopeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <returns>The roleoperationscope data</returns>
        public RoleOperationScope GetById(Guid id)
        {
            var entityData = _dbContext.RoleOperationScope.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of roleoperationscopes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roleoperationscopes</returns>/// <exception cref="Exception"></exception>
        public List<RoleOperationScope> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRoleOperationScope(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new roleoperationscope</summary>
        /// <param name="model">The roleoperationscope data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(RoleOperationScope model)
        {
            model.Id = CreateRoleOperationScope(model);
            return model.Id;
        }

        /// <summary>Updates a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <param name="updatedEntity">The roleoperationscope data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, RoleOperationScope updatedEntity)
        {
            UpdateRoleOperationScope(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <param name="updatedEntity">The roleoperationscope data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<RoleOperationScope> updatedEntity)
        {
            PatchRoleOperationScope(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific roleoperationscope by its primary key</summary>
        /// <param name="id">The primary key of the roleoperationscope</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRoleOperationScope(id);
            return true;
        }
        #region
        private List<RoleOperationScope> GetRoleOperationScope(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RoleOperationScope.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RoleOperationScope>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RoleOperationScope), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RoleOperationScope, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateRoleOperationScope(RoleOperationScope model)
        {
            _dbContext.RoleOperationScope.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateRoleOperationScope(Guid id, RoleOperationScope updatedEntity)
        {
            _dbContext.RoleOperationScope.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRoleOperationScope(Guid id)
        {
            var entityData = _dbContext.RoleOperationScope.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RoleOperationScope.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRoleOperationScope(Guid id, JsonPatchDocument<RoleOperationScope> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RoleOperationScope.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RoleOperationScope.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}