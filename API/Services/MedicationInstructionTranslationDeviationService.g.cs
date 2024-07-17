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
    /// The medicationinstructiontranslationdeviationService responsible for managing medicationinstructiontranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationinstructiontranslationdeviation information.
    /// </remarks>
    public interface IMedicationInstructionTranslationDeviationService
    {
        /// <summary>Retrieves a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <returns>The medicationinstructiontranslationdeviation data</returns>
        MedicationInstructionTranslationDeviation GetById(Guid id);

        /// <summary>Retrieves a list of medicationinstructiontranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationinstructiontranslationdeviations</returns>
        List<MedicationInstructionTranslationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationinstructiontranslationdeviation</summary>
        /// <param name="model">The medicationinstructiontranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationInstructionTranslationDeviation model);

        /// <summary>Updates a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationInstructionTranslationDeviation updatedEntity);

        /// <summary>Updates a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationInstructionTranslationDeviation> updatedEntity);

        /// <summary>Deletes a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationinstructiontranslationdeviationService responsible for managing medicationinstructiontranslationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationinstructiontranslationdeviation information.
    /// </remarks>
    public class MedicationInstructionTranslationDeviationService : IMedicationInstructionTranslationDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationInstructionTranslationDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationInstructionTranslationDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <returns>The medicationinstructiontranslationdeviation data</returns>
        public MedicationInstructionTranslationDeviation GetById(Guid id)
        {
            var entityData = _dbContext.MedicationInstructionTranslationDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationinstructiontranslationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationinstructiontranslationdeviations</returns>/// <exception cref="Exception"></exception>
        public List<MedicationInstructionTranslationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationInstructionTranslationDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationinstructiontranslationdeviation</summary>
        /// <param name="model">The medicationinstructiontranslationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationInstructionTranslationDeviation model)
        {
            model.Id = CreateMedicationInstructionTranslationDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationInstructionTranslationDeviation updatedEntity)
        {
            UpdateMedicationInstructionTranslationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationInstructionTranslationDeviation> updatedEntity)
        {
            PatchMedicationInstructionTranslationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationinstructiontranslationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslationdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationInstructionTranslationDeviation(id);
            return true;
        }
        #region
        private List<MedicationInstructionTranslationDeviation> GetMedicationInstructionTranslationDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationInstructionTranslationDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationInstructionTranslationDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationInstructionTranslationDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationInstructionTranslationDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationInstructionTranslationDeviation(MedicationInstructionTranslationDeviation model)
        {
            _dbContext.MedicationInstructionTranslationDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationInstructionTranslationDeviation(Guid id, MedicationInstructionTranslationDeviation updatedEntity)
        {
            _dbContext.MedicationInstructionTranslationDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationInstructionTranslationDeviation(Guid id)
        {
            var entityData = _dbContext.MedicationInstructionTranslationDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationInstructionTranslationDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationInstructionTranslationDeviation(Guid id, JsonPatchDocument<MedicationInstructionTranslationDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationInstructionTranslationDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationInstructionTranslationDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}