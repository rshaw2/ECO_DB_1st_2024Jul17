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
    /// The roleoperationService responsible for managing roleoperation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roleoperation information.
    /// </remarks>
    public interface IRoleOperationService
    {
        /// <summary>Retrieves a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <returns>The roleoperation data</returns>
        RoleOperation GetById(Guid id);

        /// <summary>Retrieves a list of roleoperations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roleoperations</returns>
        List<RoleOperation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new roleoperation</summary>
        /// <param name="model">The roleoperation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(RoleOperation model);

        /// <summary>Updates a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <param name="updatedEntity">The roleoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, RoleOperation updatedEntity);

        /// <summary>Updates a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <param name="updatedEntity">The roleoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<RoleOperation> updatedEntity);

        /// <summary>Deletes a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The roleoperationService responsible for managing roleoperation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roleoperation information.
    /// </remarks>
    public class RoleOperationService : IRoleOperationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the RoleOperation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RoleOperationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <returns>The roleoperation data</returns>
        public RoleOperation GetById(Guid id)
        {
            var entityData = _dbContext.RoleOperation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of roleoperations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roleoperations</returns>/// <exception cref="Exception"></exception>
        public List<RoleOperation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRoleOperation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new roleoperation</summary>
        /// <param name="model">The roleoperation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(RoleOperation model)
        {
            model.Id = CreateRoleOperation(model);
            return model.Id;
        }

        /// <summary>Updates a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <param name="updatedEntity">The roleoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, RoleOperation updatedEntity)
        {
            UpdateRoleOperation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <param name="updatedEntity">The roleoperation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<RoleOperation> updatedEntity)
        {
            PatchRoleOperation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific roleoperation by its primary key</summary>
        /// <param name="id">The primary key of the roleoperation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRoleOperation(id);
            return true;
        }
        #region
        private List<RoleOperation> GetRoleOperation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RoleOperation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RoleOperation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RoleOperation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RoleOperation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateRoleOperation(RoleOperation model)
        {
            _dbContext.RoleOperation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateRoleOperation(Guid id, RoleOperation updatedEntity)
        {
            _dbContext.RoleOperation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRoleOperation(Guid id)
        {
            var entityData = _dbContext.RoleOperation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RoleOperation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRoleOperation(Guid id, JsonPatchDocument<RoleOperation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RoleOperation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RoleOperation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}