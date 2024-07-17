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
    /// The visitvoicetranscriptService responsible for managing visitvoicetranscript related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitvoicetranscript information.
    /// </remarks>
    public interface IVisitVoiceTranscriptService
    {
        /// <summary>Retrieves a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <returns>The visitvoicetranscript data</returns>
        VisitVoiceTranscript GetById(Guid id);

        /// <summary>Retrieves a list of visitvoicetranscripts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitvoicetranscripts</returns>
        List<VisitVoiceTranscript> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitvoicetranscript</summary>
        /// <param name="model">The visitvoicetranscript data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitVoiceTranscript model);

        /// <summary>Updates a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <param name="updatedEntity">The visitvoicetranscript data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitVoiceTranscript updatedEntity);

        /// <summary>Updates a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <param name="updatedEntity">The visitvoicetranscript data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitVoiceTranscript> updatedEntity);

        /// <summary>Deletes a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitvoicetranscriptService responsible for managing visitvoicetranscript related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitvoicetranscript information.
    /// </remarks>
    public class VisitVoiceTranscriptService : IVisitVoiceTranscriptService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitVoiceTranscript class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitVoiceTranscriptService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <returns>The visitvoicetranscript data</returns>
        public VisitVoiceTranscript GetById(Guid id)
        {
            var entityData = _dbContext.VisitVoiceTranscript.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitvoicetranscripts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitvoicetranscripts</returns>/// <exception cref="Exception"></exception>
        public List<VisitVoiceTranscript> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitVoiceTranscript(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitvoicetranscript</summary>
        /// <param name="model">The visitvoicetranscript data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitVoiceTranscript model)
        {
            model.Id = CreateVisitVoiceTranscript(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <param name="updatedEntity">The visitvoicetranscript data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitVoiceTranscript updatedEntity)
        {
            UpdateVisitVoiceTranscript(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <param name="updatedEntity">The visitvoicetranscript data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitVoiceTranscript> updatedEntity)
        {
            PatchVisitVoiceTranscript(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitvoicetranscript by its primary key</summary>
        /// <param name="id">The primary key of the visitvoicetranscript</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitVoiceTranscript(id);
            return true;
        }
        #region
        private List<VisitVoiceTranscript> GetVisitVoiceTranscript(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitVoiceTranscript.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitVoiceTranscript>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitVoiceTranscript), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitVoiceTranscript, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitVoiceTranscript(VisitVoiceTranscript model)
        {
            _dbContext.VisitVoiceTranscript.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitVoiceTranscript(Guid id, VisitVoiceTranscript updatedEntity)
        {
            _dbContext.VisitVoiceTranscript.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitVoiceTranscript(Guid id)
        {
            var entityData = _dbContext.VisitVoiceTranscript.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitVoiceTranscript.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitVoiceTranscript(Guid id, JsonPatchDocument<VisitVoiceTranscript> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitVoiceTranscript.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitVoiceTranscript.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}