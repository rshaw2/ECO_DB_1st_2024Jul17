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
    /// The medicationshortfrequencyService responsible for managing medicationshortfrequency related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationshortfrequency information.
    /// </remarks>
    public interface IMedicationShortFrequencyService
    {
        /// <summary>Retrieves a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <returns>The medicationshortfrequency data</returns>
        MedicationShortFrequency GetById(Guid id);

        /// <summary>Retrieves a list of medicationshortfrequencys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationshortfrequencys</returns>
        List<MedicationShortFrequency> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationshortfrequency</summary>
        /// <param name="model">The medicationshortfrequency data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationShortFrequency model);

        /// <summary>Updates a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <param name="updatedEntity">The medicationshortfrequency data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationShortFrequency updatedEntity);

        /// <summary>Updates a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <param name="updatedEntity">The medicationshortfrequency data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationShortFrequency> updatedEntity);

        /// <summary>Deletes a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationshortfrequencyService responsible for managing medicationshortfrequency related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationshortfrequency information.
    /// </remarks>
    public class MedicationShortFrequencyService : IMedicationShortFrequencyService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationShortFrequency class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationShortFrequencyService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <returns>The medicationshortfrequency data</returns>
        public MedicationShortFrequency GetById(Guid id)
        {
            var entityData = _dbContext.MedicationShortFrequency.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationshortfrequencys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationshortfrequencys</returns>/// <exception cref="Exception"></exception>
        public List<MedicationShortFrequency> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationShortFrequency(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationshortfrequency</summary>
        /// <param name="model">The medicationshortfrequency data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationShortFrequency model)
        {
            model.Id = CreateMedicationShortFrequency(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <param name="updatedEntity">The medicationshortfrequency data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationShortFrequency updatedEntity)
        {
            UpdateMedicationShortFrequency(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <param name="updatedEntity">The medicationshortfrequency data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationShortFrequency> updatedEntity)
        {
            PatchMedicationShortFrequency(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationshortfrequency by its primary key</summary>
        /// <param name="id">The primary key of the medicationshortfrequency</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationShortFrequency(id);
            return true;
        }
        #region
        private List<MedicationShortFrequency> GetMedicationShortFrequency(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationShortFrequency.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationShortFrequency>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationShortFrequency), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationShortFrequency, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationShortFrequency(MedicationShortFrequency model)
        {
            _dbContext.MedicationShortFrequency.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationShortFrequency(Guid id, MedicationShortFrequency updatedEntity)
        {
            _dbContext.MedicationShortFrequency.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationShortFrequency(Guid id)
        {
            var entityData = _dbContext.MedicationShortFrequency.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationShortFrequency.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationShortFrequency(Guid id, JsonPatchDocument<MedicationShortFrequency> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationShortFrequency.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationShortFrequency.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}