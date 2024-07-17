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
    /// The integrationuserService responsible for managing integrationuser related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integrationuser information.
    /// </remarks>
    public interface IIntegrationUserService
    {
        /// <summary>Retrieves a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <returns>The integrationuser data</returns>
        IntegrationUser GetById(Guid id);

        /// <summary>Retrieves a list of integrationusers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integrationusers</returns>
        List<IntegrationUser> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new integrationuser</summary>
        /// <param name="model">The integrationuser data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(IntegrationUser model);

        /// <summary>Updates a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <param name="updatedEntity">The integrationuser data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, IntegrationUser updatedEntity);

        /// <summary>Updates a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <param name="updatedEntity">The integrationuser data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<IntegrationUser> updatedEntity);

        /// <summary>Deletes a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The integrationuserService responsible for managing integrationuser related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integrationuser information.
    /// </remarks>
    public class IntegrationUserService : IIntegrationUserService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the IntegrationUser class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public IntegrationUserService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <returns>The integrationuser data</returns>
        public IntegrationUser GetById(Guid id)
        {
            var entityData = _dbContext.IntegrationUser.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of integrationusers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integrationusers</returns>/// <exception cref="Exception"></exception>
        public List<IntegrationUser> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetIntegrationUser(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new integrationuser</summary>
        /// <param name="model">The integrationuser data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(IntegrationUser model)
        {
            model.Id = CreateIntegrationUser(model);
            return model.Id;
        }

        /// <summary>Updates a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <param name="updatedEntity">The integrationuser data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, IntegrationUser updatedEntity)
        {
            UpdateIntegrationUser(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <param name="updatedEntity">The integrationuser data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<IntegrationUser> updatedEntity)
        {
            PatchIntegrationUser(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific integrationuser by its primary key</summary>
        /// <param name="id">The primary key of the integrationuser</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteIntegrationUser(id);
            return true;
        }
        #region
        private List<IntegrationUser> GetIntegrationUser(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.IntegrationUser.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<IntegrationUser>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(IntegrationUser), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<IntegrationUser, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateIntegrationUser(IntegrationUser model)
        {
            _dbContext.IntegrationUser.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateIntegrationUser(Guid id, IntegrationUser updatedEntity)
        {
            _dbContext.IntegrationUser.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteIntegrationUser(Guid id)
        {
            var entityData = _dbContext.IntegrationUser.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.IntegrationUser.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchIntegrationUser(Guid id, JsonPatchDocument<IntegrationUser> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.IntegrationUser.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.IntegrationUser.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}