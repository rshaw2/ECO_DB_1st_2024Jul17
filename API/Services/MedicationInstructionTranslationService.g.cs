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
    /// The medicationinstructiontranslationService responsible for managing medicationinstructiontranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationinstructiontranslation information.
    /// </remarks>
    public interface IMedicationInstructionTranslationService
    {
        /// <summary>Retrieves a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <returns>The medicationinstructiontranslation data</returns>
        MedicationInstructionTranslation GetById(Guid id);

        /// <summary>Retrieves a list of medicationinstructiontranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationinstructiontranslations</returns>
        List<MedicationInstructionTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationinstructiontranslation</summary>
        /// <param name="model">The medicationinstructiontranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationInstructionTranslation model);

        /// <summary>Updates a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationInstructionTranslation updatedEntity);

        /// <summary>Updates a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationInstructionTranslation> updatedEntity);

        /// <summary>Deletes a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationinstructiontranslationService responsible for managing medicationinstructiontranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationinstructiontranslation information.
    /// </remarks>
    public class MedicationInstructionTranslationService : IMedicationInstructionTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationInstructionTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationInstructionTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <returns>The medicationinstructiontranslation data</returns>
        public MedicationInstructionTranslation GetById(Guid id)
        {
            var entityData = _dbContext.MedicationInstructionTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationinstructiontranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationinstructiontranslations</returns>/// <exception cref="Exception"></exception>
        public List<MedicationInstructionTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationInstructionTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationinstructiontranslation</summary>
        /// <param name="model">The medicationinstructiontranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationInstructionTranslation model)
        {
            model.Id = CreateMedicationInstructionTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationInstructionTranslation updatedEntity)
        {
            UpdateMedicationInstructionTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <param name="updatedEntity">The medicationinstructiontranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationInstructionTranslation> updatedEntity)
        {
            PatchMedicationInstructionTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationinstructiontranslation by its primary key</summary>
        /// <param name="id">The primary key of the medicationinstructiontranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationInstructionTranslation(id);
            return true;
        }
        #region
        private List<MedicationInstructionTranslation> GetMedicationInstructionTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationInstructionTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationInstructionTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationInstructionTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationInstructionTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationInstructionTranslation(MedicationInstructionTranslation model)
        {
            _dbContext.MedicationInstructionTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationInstructionTranslation(Guid id, MedicationInstructionTranslation updatedEntity)
        {
            _dbContext.MedicationInstructionTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationInstructionTranslation(Guid id)
        {
            var entityData = _dbContext.MedicationInstructionTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationInstructionTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationInstructionTranslation(Guid id, JsonPatchDocument<MedicationInstructionTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationInstructionTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationInstructionTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}