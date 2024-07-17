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
    /// The thirdpartyintegrationService responsible for managing thirdpartyintegration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting thirdpartyintegration information.
    /// </remarks>
    public interface IThirdPartyIntegrationService
    {
        /// <summary>Retrieves a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <returns>The thirdpartyintegration data</returns>
        ThirdPartyIntegration GetById(Guid id);

        /// <summary>Retrieves a list of thirdpartyintegrations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of thirdpartyintegrations</returns>
        List<ThirdPartyIntegration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new thirdpartyintegration</summary>
        /// <param name="model">The thirdpartyintegration data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ThirdPartyIntegration model);

        /// <summary>Updates a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <param name="updatedEntity">The thirdpartyintegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ThirdPartyIntegration updatedEntity);

        /// <summary>Updates a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <param name="updatedEntity">The thirdpartyintegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ThirdPartyIntegration> updatedEntity);

        /// <summary>Deletes a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The thirdpartyintegrationService responsible for managing thirdpartyintegration related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting thirdpartyintegration information.
    /// </remarks>
    public class ThirdPartyIntegrationService : IThirdPartyIntegrationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ThirdPartyIntegration class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ThirdPartyIntegrationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <returns>The thirdpartyintegration data</returns>
        public ThirdPartyIntegration GetById(Guid id)
        {
            var entityData = _dbContext.ThirdPartyIntegration.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of thirdpartyintegrations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of thirdpartyintegrations</returns>/// <exception cref="Exception"></exception>
        public List<ThirdPartyIntegration> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetThirdPartyIntegration(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new thirdpartyintegration</summary>
        /// <param name="model">The thirdpartyintegration data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ThirdPartyIntegration model)
        {
            model.Id = CreateThirdPartyIntegration(model);
            return model.Id;
        }

        /// <summary>Updates a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <param name="updatedEntity">The thirdpartyintegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ThirdPartyIntegration updatedEntity)
        {
            UpdateThirdPartyIntegration(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <param name="updatedEntity">The thirdpartyintegration data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ThirdPartyIntegration> updatedEntity)
        {
            PatchThirdPartyIntegration(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific thirdpartyintegration by its primary key</summary>
        /// <param name="id">The primary key of the thirdpartyintegration</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteThirdPartyIntegration(id);
            return true;
        }
        #region
        private List<ThirdPartyIntegration> GetThirdPartyIntegration(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ThirdPartyIntegration.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ThirdPartyIntegration>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ThirdPartyIntegration), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ThirdPartyIntegration, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateThirdPartyIntegration(ThirdPartyIntegration model)
        {
            _dbContext.ThirdPartyIntegration.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateThirdPartyIntegration(Guid id, ThirdPartyIntegration updatedEntity)
        {
            _dbContext.ThirdPartyIntegration.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteThirdPartyIntegration(Guid id)
        {
            var entityData = _dbContext.ThirdPartyIntegration.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ThirdPartyIntegration.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchThirdPartyIntegration(Guid id, JsonPatchDocument<ThirdPartyIntegration> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ThirdPartyIntegration.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ThirdPartyIntegration.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}