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
    /// The filesettingService responsible for managing filesetting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting filesetting information.
    /// </remarks>
    public interface IFileSettingService
    {
        /// <summary>Retrieves a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <returns>The filesetting data</returns>
        FileSetting GetById(Guid id);

        /// <summary>Retrieves a list of filesettings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of filesettings</returns>
        List<FileSetting> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new filesetting</summary>
        /// <param name="model">The filesetting data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FileSetting model);

        /// <summary>Updates a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <param name="updatedEntity">The filesetting data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FileSetting updatedEntity);

        /// <summary>Updates a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <param name="updatedEntity">The filesetting data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FileSetting> updatedEntity);

        /// <summary>Deletes a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The filesettingService responsible for managing filesetting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting filesetting information.
    /// </remarks>
    public class FileSettingService : IFileSettingService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FileSetting class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FileSettingService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <returns>The filesetting data</returns>
        public FileSetting GetById(Guid id)
        {
            var entityData = _dbContext.FileSetting.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of filesettings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of filesettings</returns>/// <exception cref="Exception"></exception>
        public List<FileSetting> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFileSetting(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new filesetting</summary>
        /// <param name="model">The filesetting data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FileSetting model)
        {
            model.Id = CreateFileSetting(model);
            return model.Id;
        }

        /// <summary>Updates a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <param name="updatedEntity">The filesetting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FileSetting updatedEntity)
        {
            UpdateFileSetting(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <param name="updatedEntity">The filesetting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FileSetting> updatedEntity)
        {
            PatchFileSetting(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific filesetting by its primary key</summary>
        /// <param name="id">The primary key of the filesetting</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFileSetting(id);
            return true;
        }
        #region
        private List<FileSetting> GetFileSetting(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FileSetting.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FileSetting>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FileSetting), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FileSetting, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFileSetting(FileSetting model)
        {
            _dbContext.FileSetting.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFileSetting(Guid id, FileSetting updatedEntity)
        {
            _dbContext.FileSetting.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFileSetting(Guid id)
        {
            var entityData = _dbContext.FileSetting.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FileSetting.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFileSetting(Guid id, JsonPatchDocument<FileSetting> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FileSetting.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FileSetting.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}