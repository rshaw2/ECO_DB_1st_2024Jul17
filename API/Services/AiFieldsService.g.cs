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
    /// The aifieldsService responsible for managing aifields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aifields information.
    /// </remarks>
    public interface IAiFieldsService
    {
        /// <summary>Retrieves a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <returns>The aifields data</returns>
        AiFields GetById(Guid id);

        /// <summary>Retrieves a list of aifieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aifieldss</returns>
        List<AiFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new aifields</summary>
        /// <param name="model">The aifields data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AiFields model);

        /// <summary>Updates a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <param name="updatedEntity">The aifields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AiFields updatedEntity);

        /// <summary>Updates a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <param name="updatedEntity">The aifields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AiFields> updatedEntity);

        /// <summary>Deletes a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The aifieldsService responsible for managing aifields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aifields information.
    /// </remarks>
    public class AiFieldsService : IAiFieldsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AiFields class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AiFieldsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <returns>The aifields data</returns>
        public AiFields GetById(Guid id)
        {
            var entityData = _dbContext.AiFields.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of aifieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aifieldss</returns>/// <exception cref="Exception"></exception>
        public List<AiFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAiFields(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new aifields</summary>
        /// <param name="model">The aifields data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AiFields model)
        {
            model.Id = CreateAiFields(model);
            return model.Id;
        }

        /// <summary>Updates a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <param name="updatedEntity">The aifields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AiFields updatedEntity)
        {
            UpdateAiFields(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <param name="updatedEntity">The aifields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AiFields> updatedEntity)
        {
            PatchAiFields(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific aifields by its primary key</summary>
        /// <param name="id">The primary key of the aifields</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAiFields(id);
            return true;
        }
        #region
        private List<AiFields> GetAiFields(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AiFields.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AiFields>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AiFields), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AiFields, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAiFields(AiFields model)
        {
            _dbContext.AiFields.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAiFields(Guid id, AiFields updatedEntity)
        {
            _dbContext.AiFields.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAiFields(Guid id)
        {
            var entityData = _dbContext.AiFields.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AiFields.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAiFields(Guid id, JsonPatchDocument<AiFields> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AiFields.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AiFields.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}