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
    /// The medicationnotestranslationService responsible for managing medicationnotestranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationnotestranslation information.
    /// </remarks>
    public interface IMedicationNotesTranslationService
    {
        /// <summary>Retrieves a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <returns>The medicationnotestranslation data</returns>
        MedicationNotesTranslation GetById(Guid id);

        /// <summary>Retrieves a list of medicationnotestranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationnotestranslations</returns>
        List<MedicationNotesTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationnotestranslation</summary>
        /// <param name="model">The medicationnotestranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationNotesTranslation model);

        /// <summary>Updates a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <param name="updatedEntity">The medicationnotestranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationNotesTranslation updatedEntity);

        /// <summary>Updates a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <param name="updatedEntity">The medicationnotestranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationNotesTranslation> updatedEntity);

        /// <summary>Deletes a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationnotestranslationService responsible for managing medicationnotestranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationnotestranslation information.
    /// </remarks>
    public class MedicationNotesTranslationService : IMedicationNotesTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationNotesTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationNotesTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <returns>The medicationnotestranslation data</returns>
        public MedicationNotesTranslation GetById(Guid id)
        {
            var entityData = _dbContext.MedicationNotesTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationnotestranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationnotestranslations</returns>/// <exception cref="Exception"></exception>
        public List<MedicationNotesTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationNotesTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationnotestranslation</summary>
        /// <param name="model">The medicationnotestranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationNotesTranslation model)
        {
            model.Id = CreateMedicationNotesTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <param name="updatedEntity">The medicationnotestranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationNotesTranslation updatedEntity)
        {
            UpdateMedicationNotesTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <param name="updatedEntity">The medicationnotestranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationNotesTranslation> updatedEntity)
        {
            PatchMedicationNotesTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationnotestranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationnotestranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationNotesTranslation(id);
            return true;
        }
        #region
        private List<MedicationNotesTranslation> GetMedicationNotesTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationNotesTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationNotesTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationNotesTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationNotesTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationNotesTranslation(MedicationNotesTranslation model)
        {
            _dbContext.MedicationNotesTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationNotesTranslation(Guid id, MedicationNotesTranslation updatedEntity)
        {
            _dbContext.MedicationNotesTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationNotesTranslation(Guid id)
        {
            var entityData = _dbContext.MedicationNotesTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationNotesTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationNotesTranslation(Guid id, JsonPatchDocument<MedicationNotesTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationNotesTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationNotesTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}