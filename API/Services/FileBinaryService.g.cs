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
    /// The filebinaryService responsible for managing filebinary related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting filebinary information.
    /// </remarks>
    public interface IFileBinaryService
    {
        /// <summary>Retrieves a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <returns>The filebinary data</returns>
        FileBinary GetById(Guid id);

        /// <summary>Retrieves a list of filebinarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of filebinarys</returns>
        List<FileBinary> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new filebinary</summary>
        /// <param name="model">The filebinary data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FileBinary model);

        /// <summary>Updates a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <param name="updatedEntity">The filebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FileBinary updatedEntity);

        /// <summary>Updates a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <param name="updatedEntity">The filebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FileBinary> updatedEntity);

        /// <summary>Deletes a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The filebinaryService responsible for managing filebinary related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting filebinary information.
    /// </remarks>
    public class FileBinaryService : IFileBinaryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FileBinary class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FileBinaryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <returns>The filebinary data</returns>
        public FileBinary GetById(Guid id)
        {
            var entityData = _dbContext.FileBinary.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of filebinarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of filebinarys</returns>/// <exception cref="Exception"></exception>
        public List<FileBinary> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFileBinary(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new filebinary</summary>
        /// <param name="model">The filebinary data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FileBinary model)
        {
            model.Id = CreateFileBinary(model);
            return model.Id;
        }

        /// <summary>Updates a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <param name="updatedEntity">The filebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FileBinary updatedEntity)
        {
            UpdateFileBinary(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <param name="updatedEntity">The filebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FileBinary> updatedEntity)
        {
            PatchFileBinary(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific filebinary by its primary key</summary>
        /// <param name="id">The primary key of the filebinary</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFileBinary(id);
            return true;
        }
        #region
        private List<FileBinary> GetFileBinary(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FileBinary.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FileBinary>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FileBinary), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FileBinary, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFileBinary(FileBinary model)
        {
            _dbContext.FileBinary.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFileBinary(Guid id, FileBinary updatedEntity)
        {
            _dbContext.FileBinary.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFileBinary(Guid id)
        {
            var entityData = _dbContext.FileBinary.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FileBinary.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFileBinary(Guid id, JsonPatchDocument<FileBinary> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FileBinary.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FileBinary.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}