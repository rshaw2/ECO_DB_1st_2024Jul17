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
    /// The notesshortcutdeviationService responsible for managing notesshortcutdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting notesshortcutdeviation information.
    /// </remarks>
    public interface INotesShortcutDeviationService
    {
        /// <summary>Retrieves a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <returns>The notesshortcutdeviation data</returns>
        NotesShortcutDeviation GetById(Guid id);

        /// <summary>Retrieves a list of notesshortcutdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of notesshortcutdeviations</returns>
        List<NotesShortcutDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new notesshortcutdeviation</summary>
        /// <param name="model">The notesshortcutdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(NotesShortcutDeviation model);

        /// <summary>Updates a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <param name="updatedEntity">The notesshortcutdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, NotesShortcutDeviation updatedEntity);

        /// <summary>Updates a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <param name="updatedEntity">The notesshortcutdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<NotesShortcutDeviation> updatedEntity);

        /// <summary>Deletes a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The notesshortcutdeviationService responsible for managing notesshortcutdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting notesshortcutdeviation information.
    /// </remarks>
    public class NotesShortcutDeviationService : INotesShortcutDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the NotesShortcutDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public NotesShortcutDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <returns>The notesshortcutdeviation data</returns>
        public NotesShortcutDeviation GetById(Guid id)
        {
            var entityData = _dbContext.NotesShortcutDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of notesshortcutdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of notesshortcutdeviations</returns>/// <exception cref="Exception"></exception>
        public List<NotesShortcutDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetNotesShortcutDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new notesshortcutdeviation</summary>
        /// <param name="model">The notesshortcutdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(NotesShortcutDeviation model)
        {
            model.Id = CreateNotesShortcutDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <param name="updatedEntity">The notesshortcutdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, NotesShortcutDeviation updatedEntity)
        {
            UpdateNotesShortcutDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <param name="updatedEntity">The notesshortcutdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<NotesShortcutDeviation> updatedEntity)
        {
            PatchNotesShortcutDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific notesshortcutdeviation by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcutdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteNotesShortcutDeviation(id);
            return true;
        }
        #region
        private List<NotesShortcutDeviation> GetNotesShortcutDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.NotesShortcutDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<NotesShortcutDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(NotesShortcutDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<NotesShortcutDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateNotesShortcutDeviation(NotesShortcutDeviation model)
        {
            _dbContext.NotesShortcutDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateNotesShortcutDeviation(Guid id, NotesShortcutDeviation updatedEntity)
        {
            _dbContext.NotesShortcutDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteNotesShortcutDeviation(Guid id)
        {
            var entityData = _dbContext.NotesShortcutDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.NotesShortcutDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchNotesShortcutDeviation(Guid id, JsonPatchDocument<NotesShortcutDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.NotesShortcutDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.NotesShortcutDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}