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
    /// The medicationsuggestionService responsible for managing medicationsuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationsuggestion information.
    /// </remarks>
    public interface IMedicationSuggestionService
    {
        /// <summary>Retrieves a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <returns>The medicationsuggestion data</returns>
        MedicationSuggestion GetById(Guid id);

        /// <summary>Retrieves a list of medicationsuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationsuggestions</returns>
        List<MedicationSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationsuggestion</summary>
        /// <param name="model">The medicationsuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationSuggestion model);

        /// <summary>Updates a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <param name="updatedEntity">The medicationsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationSuggestion updatedEntity);

        /// <summary>Updates a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <param name="updatedEntity">The medicationsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationSuggestion> updatedEntity);

        /// <summary>Deletes a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationsuggestionService responsible for managing medicationsuggestion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationsuggestion information.
    /// </remarks>
    public class MedicationSuggestionService : IMedicationSuggestionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationSuggestion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationSuggestionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <returns>The medicationsuggestion data</returns>
        public MedicationSuggestion GetById(Guid id)
        {
            var entityData = _dbContext.MedicationSuggestion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationsuggestions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationsuggestions</returns>/// <exception cref="Exception"></exception>
        public List<MedicationSuggestion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationSuggestion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationsuggestion</summary>
        /// <param name="model">The medicationsuggestion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationSuggestion model)
        {
            model.Id = CreateMedicationSuggestion(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <param name="updatedEntity">The medicationsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationSuggestion updatedEntity)
        {
            UpdateMedicationSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <param name="updatedEntity">The medicationsuggestion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationSuggestion> updatedEntity)
        {
            PatchMedicationSuggestion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationsuggestion by its primary key</summary>
        /// <param name="id">The primary key of the medicationsuggestion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationSuggestion(id);
            return true;
        }
        #region
        private List<MedicationSuggestion> GetMedicationSuggestion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationSuggestion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationSuggestion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationSuggestion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationSuggestion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationSuggestion(MedicationSuggestion model)
        {
            _dbContext.MedicationSuggestion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationSuggestion(Guid id, MedicationSuggestion updatedEntity)
        {
            _dbContext.MedicationSuggestion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationSuggestion(Guid id)
        {
            var entityData = _dbContext.MedicationSuggestion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationSuggestion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationSuggestion(Guid id, JsonPatchDocument<MedicationSuggestion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationSuggestion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationSuggestion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}