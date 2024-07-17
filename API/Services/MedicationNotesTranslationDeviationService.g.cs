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
    /// The medicationnotestranslationdeviationService responsible for managing medicationnotestranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationnotestranslationdeviation information.
    /// </remarks>
    public interface IMedicationNotesTranslationDeviationService
    {
        /// <summary>Retrieves a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <returns>The medicationnotestranslationdeviation data</returns>
        MedicationNotesTranslationDeviation GetById(Guid id);

        /// <summary>Retrieves a list of medicationnotestranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationnotestranslationdeviations</returns>
        List<MedicationNotesTranslationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationnotestranslationdeviation</summary>
        /// <param name="model">The medicationnotestranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationNotesTranslationDeviation model);

        /// <summary>Updates a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <param name="updatedEntity">The medicationnotestranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationNotesTranslationDeviation updatedEntity);

        /// <summary>Updates a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <param name="updatedEntity">The medicationnotestranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationNotesTranslationDeviation> updatedEntity);

        /// <summary>Deletes a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationnotestranslationdeviationService responsible for managing medicationnotestranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationnotestranslationdeviation information.
    /// </remarks>
    public class MedicationNotesTranslationDeviationService : IMedicationNotesTranslationDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationNotesTranslationDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationNotesTranslationDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <returns>The medicationnotestranslationdeviation data</returns>
        public MedicationNotesTranslationDeviation GetById(Guid id)
        {
            var entityData = _dbContext.MedicationNotesTranslationDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationnotestranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationnotestranslationdeviations</returns>/// <exception cref="Exception"></exception>
        public List<MedicationNotesTranslationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationNotesTranslationDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationnotestranslationdeviation</summary>
        /// <param name="model">The medicationnotestranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationNotesTranslationDeviation model)
        {
            model.Id = CreateMedicationNotesTranslationDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <param name="updatedEntity">The medicationnotestranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationNotesTranslationDeviation updatedEntity)
        {
            UpdateMedicationNotesTranslationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <param name="updatedEntity">The medicationnotestranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationNotesTranslationDeviation> updatedEntity)
        {
            PatchMedicationNotesTranslationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationnotestranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslationdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationNotesTranslationDeviation(id);
            return true;
        }
        #region
        private List<MedicationNotesTranslationDeviation> GetMedicationNotesTranslationDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationNotesTranslationDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationNotesTranslationDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationNotesTranslationDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationNotesTranslationDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationNotesTranslationDeviation(MedicationNotesTranslationDeviation model)
        {
            _dbContext.MedicationNotesTranslationDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationNotesTranslationDeviation(Guid id, MedicationNotesTranslationDeviation updatedEntity)
        {
            _dbContext.MedicationNotesTranslationDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationNotesTranslationDeviation(Guid id)
        {
            var entityData = _dbContext.MedicationNotesTranslationDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationNotesTranslationDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationNotesTranslationDeviation(Guid id, JsonPatchDocument<MedicationNotesTranslationDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationNotesTranslationDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationNotesTranslationDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}