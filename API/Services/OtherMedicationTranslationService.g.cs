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
    /// The othermedicationtranslationService responsible for managing othermedicationtranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting othermedicationtranslation information.
    /// </remarks>
    public interface IOtherMedicationTranslationService
    {
        /// <summary>Retrieves a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <returns>The othermedicationtranslation data</returns>
        OtherMedicationTranslation GetById(Guid id);

        /// <summary>Retrieves a list of othermedicationtranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of othermedicationtranslations</returns>
        List<OtherMedicationTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new othermedicationtranslation</summary>
        /// <param name="model">The othermedicationtranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(OtherMedicationTranslation model);

        /// <summary>Updates a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <param name="updatedEntity">The othermedicationtranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, OtherMedicationTranslation updatedEntity);

        /// <summary>Updates a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <param name="updatedEntity">The othermedicationtranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<OtherMedicationTranslation> updatedEntity);

        /// <summary>Deletes a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The othermedicationtranslationService responsible for managing othermedicationtranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting othermedicationtranslation information.
    /// </remarks>
    public class OtherMedicationTranslationService : IOtherMedicationTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the OtherMedicationTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public OtherMedicationTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <returns>The othermedicationtranslation data</returns>
        public OtherMedicationTranslation GetById(Guid id)
        {
            var entityData = _dbContext.OtherMedicationTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of othermedicationtranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of othermedicationtranslations</returns>/// <exception cref="Exception"></exception>
        public List<OtherMedicationTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetOtherMedicationTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new othermedicationtranslation</summary>
        /// <param name="model">The othermedicationtranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(OtherMedicationTranslation model)
        {
            model.Id = CreateOtherMedicationTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <param name="updatedEntity">The othermedicationtranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, OtherMedicationTranslation updatedEntity)
        {
            UpdateOtherMedicationTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <param name="updatedEntity">The othermedicationtranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<OtherMedicationTranslation> updatedEntity)
        {
            PatchOtherMedicationTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific othermedicationtranslation by its primary key</summary>
        /// <param name="id">The primary key of the othermedicationtranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteOtherMedicationTranslation(id);
            return true;
        }
        #region
        private List<OtherMedicationTranslation> GetOtherMedicationTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.OtherMedicationTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<OtherMedicationTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(OtherMedicationTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<OtherMedicationTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateOtherMedicationTranslation(OtherMedicationTranslation model)
        {
            _dbContext.OtherMedicationTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateOtherMedicationTranslation(Guid id, OtherMedicationTranslation updatedEntity)
        {
            _dbContext.OtherMedicationTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteOtherMedicationTranslation(Guid id)
        {
            var entityData = _dbContext.OtherMedicationTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.OtherMedicationTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchOtherMedicationTranslation(Guid id, JsonPatchDocument<OtherMedicationTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.OtherMedicationTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.OtherMedicationTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}