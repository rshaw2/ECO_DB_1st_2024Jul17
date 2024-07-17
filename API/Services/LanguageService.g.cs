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
    /// The languageService responsible for managing language related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting language information.
    /// </remarks>
    public interface ILanguageService
    {
        /// <summary>Retrieves a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <returns>The language data</returns>
        Language GetById(Guid id);

        /// <summary>Retrieves a list of languages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of languages</returns>
        List<Language> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new language</summary>
        /// <param name="model">The language data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Language model);

        /// <summary>Updates a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <param name="updatedEntity">The language data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Language updatedEntity);

        /// <summary>Updates a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <param name="updatedEntity">The language data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Language> updatedEntity);

        /// <summary>Deletes a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The languageService responsible for managing language related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting language information.
    /// </remarks>
    public class LanguageService : ILanguageService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Language class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LanguageService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <returns>The language data</returns>
        public Language GetById(Guid id)
        {
            var entityData = _dbContext.Language.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of languages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of languages</returns>/// <exception cref="Exception"></exception>
        public List<Language> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLanguage(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new language</summary>
        /// <param name="model">The language data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Language model)
        {
            model.Id = CreateLanguage(model);
            return model.Id;
        }

        /// <summary>Updates a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <param name="updatedEntity">The language data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Language updatedEntity)
        {
            UpdateLanguage(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <param name="updatedEntity">The language data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Language> updatedEntity)
        {
            PatchLanguage(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific language by its primary key</summary>
        /// <param name="id">The primary key of the language</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLanguage(id);
            return true;
        }
        #region
        private List<Language> GetLanguage(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Language.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Language>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Language), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Language, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLanguage(Language model)
        {
            _dbContext.Language.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLanguage(Guid id, Language updatedEntity)
        {
            _dbContext.Language.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLanguage(Guid id)
        {
            var entityData = _dbContext.Language.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Language.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLanguage(Guid id, JsonPatchDocument<Language> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Language.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Language.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}