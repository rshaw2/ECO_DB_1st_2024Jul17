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
    /// The diagnosissuggestionService responsible for managing diagnosissuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosissuggestion information.
    /// </remarks>
    public interface IDiagnosisSuggestionService
    {
        /// <summary>Retrieves a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <returns>The diagnosissuggestion data</returns>
        DiagnosisSuggestion GetById(Guid id);

        /// <summary>Retrieves a list of diagnosissuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosissuggestions</returns>
        List<DiagnosisSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new diagnosissuggestion</summary>
        /// <param name="model">The diagnosissuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DiagnosisSuggestion model);

        /// <summary>Updates a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <param name="updatedEntity">The diagnosissuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DiagnosisSuggestion updatedEntity);

        /// <summary>Updates a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <param name="updatedEntity">The diagnosissuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DiagnosisSuggestion> updatedEntity);

        /// <summary>Deletes a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The diagnosissuggestionService responsible for managing diagnosissuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosissuggestion information.
    /// </remarks>
    public class DiagnosisSuggestionService : IDiagnosisSuggestionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DiagnosisSuggestion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DiagnosisSuggestionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <returns>The diagnosissuggestion data</returns>
        public DiagnosisSuggestion GetById(Guid id)
        {
            var entityData = _dbContext.DiagnosisSuggestion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of diagnosissuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosissuggestions</returns>/// <exception cref="Exception"></exception>
        public List<DiagnosisSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDiagnosisSuggestion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new diagnosissuggestion</summary>
        /// <param name="model">The diagnosissuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DiagnosisSuggestion model)
        {
            model.Id = CreateDiagnosisSuggestion(model);
            return model.Id;
        }

        /// <summary>Updates a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <param name="updatedEntity">The diagnosissuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DiagnosisSuggestion updatedEntity)
        {
            UpdateDiagnosisSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <param name="updatedEntity">The diagnosissuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DiagnosisSuggestion> updatedEntity)
        {
            PatchDiagnosisSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific diagnosissuggestion by its primary key</summary>
        /// <param name="id">The primary key of the diagnosissuggestion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDiagnosisSuggestion(id);
            return true;
        }
        #region
        private List<DiagnosisSuggestion> GetDiagnosisSuggestion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DiagnosisSuggestion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DiagnosisSuggestion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DiagnosisSuggestion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DiagnosisSuggestion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDiagnosisSuggestion(DiagnosisSuggestion model)
        {
            _dbContext.DiagnosisSuggestion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDiagnosisSuggestion(Guid id, DiagnosisSuggestion updatedEntity)
        {
            _dbContext.DiagnosisSuggestion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDiagnosisSuggestion(Guid id)
        {
            var entityData = _dbContext.DiagnosisSuggestion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DiagnosisSuggestion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDiagnosisSuggestion(Guid id, JsonPatchDocument<DiagnosisSuggestion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DiagnosisSuggestion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DiagnosisSuggestion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}