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
    /// The fileService responsible for managing file related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting file information.
    /// </remarks>
    public interface IFileService
    {
        /// <summary>Retrieves a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <returns>The file data</returns>
        Entities.File GetById(Guid id);

        /// <summary>Retrieves a list of files based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of files</returns>
        List<Entities.File> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new file</summary>
        /// <param name="model">The file data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Entities.File model);

        /// <summary>Updates a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <param name="updatedEntity">The file data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Entities.File updatedEntity);

        /// <summary>Updates a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <param name="updatedEntity">The file data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Entities.File> updatedEntity);

        /// <summary>Deletes a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The fileService responsible for managing file related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting file information.
    /// </remarks>
    public class FileService : IFileService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the File class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FileService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <returns>The file data</returns>
        public Entities.File GetById(Guid id)
        {
            var entityData = _dbContext.File.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of files based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of files</returns>/// <exception cref="Exception"></exception>
        public List<Entities.File> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFile(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new file</summary>
        /// <param name="model">The file data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Entities.File model)
        {
            model.Id = CreateFile(model);
            return model.Id;
        }

        /// <summary>Updates a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <param name="updatedEntity">The file data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Entities.File updatedEntity)
        {
            UpdateFile(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <param name="updatedEntity">The file data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Entities.File> updatedEntity)
        {
            PatchFile(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific file by its primary key</summary>
        /// <param name="id">The primary key of the file</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFile(id);
            return true;
        }
        #region
        private List<Entities.File> GetFile(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.File.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Entities.File>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Entities.File), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Entities.File, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFile(Entities.File model)
        {
            _dbContext.File.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFile(Guid id, Entities.File updatedEntity)
        {
            _dbContext.File.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFile(Guid id)
        {
            var entityData = _dbContext.File.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.File.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFile(Guid id, JsonPatchDocument<Entities.File> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.File.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.File.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}