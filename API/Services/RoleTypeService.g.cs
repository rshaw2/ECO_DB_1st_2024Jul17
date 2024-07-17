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
    /// The roletypeService responsible for managing roletype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roletype information.
    /// </remarks>
    public interface IRoleTypeService
    {
        /// <summary>Retrieves a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <returns>The roletype data</returns>
        RoleType GetById(Guid id);

        /// <summary>Retrieves a list of roletypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roletypes</returns>
        List<RoleType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new roletype</summary>
        /// <param name="model">The roletype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(RoleType model);

        /// <summary>Updates a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <param name="updatedEntity">The roletype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, RoleType updatedEntity);

        /// <summary>Updates a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <param name="updatedEntity">The roletype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<RoleType> updatedEntity);

        /// <summary>Deletes a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The roletypeService responsible for managing roletype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roletype information.
    /// </remarks>
    public class RoleTypeService : IRoleTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the RoleType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RoleTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <returns>The roletype data</returns>
        public RoleType GetById(Guid id)
        {
            var entityData = _dbContext.RoleType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of roletypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roletypes</returns>/// <exception cref="Exception"></exception>
        public List<RoleType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRoleType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new roletype</summary>
        /// <param name="model">The roletype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(RoleType model)
        {
            model.Id = CreateRoleType(model);
            return model.Id;
        }

        /// <summary>Updates a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <param name="updatedEntity">The roletype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, RoleType updatedEntity)
        {
            UpdateRoleType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <param name="updatedEntity">The roletype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<RoleType> updatedEntity)
        {
            PatchRoleType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific roletype by its primary key</summary>
        /// <param name="id">The primary key of the roletype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRoleType(id);
            return true;
        }
        #region
        private List<RoleType> GetRoleType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RoleType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RoleType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RoleType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RoleType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateRoleType(RoleType model)
        {
            _dbContext.RoleType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateRoleType(Guid id, RoleType updatedEntity)
        {
            _dbContext.RoleType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRoleType(Guid id)
        {
            var entityData = _dbContext.RoleType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RoleType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRoleType(Guid id, JsonPatchDocument<RoleType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RoleType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RoleType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}