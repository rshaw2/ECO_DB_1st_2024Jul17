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
    /// The notesshortcutService responsible for managing notesshortcut related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting notesshortcut information.
    /// </remarks>
    public interface INotesShortcutService
    {
        /// <summary>Retrieves a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <returns>The notesshortcut data</returns>
        NotesShortcut GetById(Guid id);

        /// <summary>Retrieves a list of notesshortcuts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of notesshortcuts</returns>
        List<NotesShortcut> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new notesshortcut</summary>
        /// <param name="model">The notesshortcut data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(NotesShortcut model);

        /// <summary>Updates a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <param name="updatedEntity">The notesshortcut data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, NotesShortcut updatedEntity);

        /// <summary>Updates a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <param name="updatedEntity">The notesshortcut data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<NotesShortcut> updatedEntity);

        /// <summary>Deletes a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The notesshortcutService responsible for managing notesshortcut related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting notesshortcut information.
    /// </remarks>
    public class NotesShortcutService : INotesShortcutService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the NotesShortcut class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public NotesShortcutService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <returns>The notesshortcut data</returns>
        public NotesShortcut GetById(Guid id)
        {
            var entityData = _dbContext.NotesShortcut.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of notesshortcuts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of notesshortcuts</returns>/// <exception cref="Exception"></exception>
        public List<NotesShortcut> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetNotesShortcut(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new notesshortcut</summary>
        /// <param name="model">The notesshortcut data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(NotesShortcut model)
        {
            model.Id = CreateNotesShortcut(model);
            return model.Id;
        }

        /// <summary>Updates a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <param name="updatedEntity">The notesshortcut data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, NotesShortcut updatedEntity)
        {
            UpdateNotesShortcut(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <param name="updatedEntity">The notesshortcut data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<NotesShortcut> updatedEntity)
        {
            PatchNotesShortcut(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific notesshortcut by its primary key</summary>
        /// <param name="id">The primary key of the notesshortcut</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteNotesShortcut(id);
            return true;
        }
        #region
        private List<NotesShortcut> GetNotesShortcut(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.NotesShortcut.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<NotesShortcut>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(NotesShortcut), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<NotesShortcut, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateNotesShortcut(NotesShortcut model)
        {
            _dbContext.NotesShortcut.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateNotesShortcut(Guid id, NotesShortcut updatedEntity)
        {
            _dbContext.NotesShortcut.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteNotesShortcut(Guid id)
        {
            var entityData = _dbContext.NotesShortcut.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.NotesShortcut.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchNotesShortcut(Guid id, JsonPatchDocument<NotesShortcut> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.NotesShortcut.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.NotesShortcut.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}