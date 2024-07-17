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
    /// The aiinteractionService responsible for managing aiinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiinteraction information.
    /// </remarks>
    public interface IAiInteractionService
    {
        /// <summary>Retrieves a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <returns>The aiinteraction data</returns>
        AiInteraction GetById(Guid id);

        /// <summary>Retrieves a list of aiinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiinteractions</returns>
        List<AiInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new aiinteraction</summary>
        /// <param name="model">The aiinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AiInteraction model);

        /// <summary>Updates a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <param name="updatedEntity">The aiinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AiInteraction updatedEntity);

        /// <summary>Updates a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <param name="updatedEntity">The aiinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AiInteraction> updatedEntity);

        /// <summary>Deletes a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The aiinteractionService responsible for managing aiinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting aiinteraction information.
    /// </remarks>
    public class AiInteractionService : IAiInteractionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AiInteraction class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AiInteractionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <returns>The aiinteraction data</returns>
        public AiInteraction GetById(Guid id)
        {
            var entityData = _dbContext.AiInteraction.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of aiinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aiinteractions</returns>/// <exception cref="Exception"></exception>
        public List<AiInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAiInteraction(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new aiinteraction</summary>
        /// <param name="model">The aiinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AiInteraction model)
        {
            model.Id = CreateAiInteraction(model);
            return model.Id;
        }

        /// <summary>Updates a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <param name="updatedEntity">The aiinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AiInteraction updatedEntity)
        {
            UpdateAiInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <param name="updatedEntity">The aiinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AiInteraction> updatedEntity)
        {
            PatchAiInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific aiinteraction by its primary key</summary>
        /// <param name="id">The primary key of the aiinteraction</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAiInteraction(id);
            return true;
        }
        #region
        private List<AiInteraction> GetAiInteraction(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AiInteraction.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AiInteraction>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AiInteraction), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AiInteraction, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAiInteraction(AiInteraction model)
        {
            _dbContext.AiInteraction.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAiInteraction(Guid id, AiInteraction updatedEntity)
        {
            _dbContext.AiInteraction.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAiInteraction(Guid id)
        {
            var entityData = _dbContext.AiInteraction.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AiInteraction.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAiInteraction(Guid id, JsonPatchDocument<AiInteraction> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AiInteraction.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AiInteraction.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}