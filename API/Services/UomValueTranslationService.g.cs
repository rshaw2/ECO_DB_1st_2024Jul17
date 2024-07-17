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
    /// The uomvaluetranslationService responsible for managing uomvaluetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting uomvaluetranslation information.
    /// </remarks>
    public interface IUomValueTranslationService
    {
        /// <summary>Retrieves a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <returns>The uomvaluetranslation data</returns>
        UomValueTranslation GetById(Guid id);

        /// <summary>Retrieves a list of uomvaluetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of uomvaluetranslations</returns>
        List<UomValueTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new uomvaluetranslation</summary>
        /// <param name="model">The uomvaluetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UomValueTranslation model);

        /// <summary>Updates a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <param name="updatedEntity">The uomvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UomValueTranslation updatedEntity);

        /// <summary>Updates a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <param name="updatedEntity">The uomvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UomValueTranslation> updatedEntity);

        /// <summary>Deletes a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The uomvaluetranslationService responsible for managing uomvaluetranslation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting uomvaluetranslation information.
    /// </remarks>
    public class UomValueTranslationService : IUomValueTranslationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UomValueTranslation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UomValueTranslationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <returns>The uomvaluetranslation data</returns>
        public UomValueTranslation GetById(Guid id)
        {
            var entityData = _dbContext.UomValueTranslation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of uomvaluetranslations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of uomvaluetranslations</returns>/// <exception cref="Exception"></exception>
        public List<UomValueTranslation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUomValueTranslation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new uomvaluetranslation</summary>
        /// <param name="model">The uomvaluetranslation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UomValueTranslation model)
        {
            model.Id = CreateUomValueTranslation(model);
            return model.Id;
        }

        /// <summary>Updates a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <param name="updatedEntity">The uomvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UomValueTranslation updatedEntity)
        {
            UpdateUomValueTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <param name="updatedEntity">The uomvaluetranslation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UomValueTranslation> updatedEntity)
        {
            PatchUomValueTranslation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific uomvaluetranslation by its primary key</summary>
        /// <param name="id">The primary key of the uomvaluetranslation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUomValueTranslation(id);
            return true;
        }
        #region
        private List<UomValueTranslation> GetUomValueTranslation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UomValueTranslation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UomValueTranslation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UomValueTranslation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UomValueTranslation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUomValueTranslation(UomValueTranslation model)
        {
            _dbContext.UomValueTranslation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUomValueTranslation(Guid id, UomValueTranslation updatedEntity)
        {
            _dbContext.UomValueTranslation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUomValueTranslation(Guid id)
        {
            var entityData = _dbContext.UomValueTranslation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UomValueTranslation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUomValueTranslation(Guid id, JsonPatchDocument<UomValueTranslation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UomValueTranslation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UomValueTranslation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}