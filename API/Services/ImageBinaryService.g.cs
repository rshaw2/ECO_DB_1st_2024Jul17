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
    /// The imagebinaryService responsible for managing imagebinary related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting imagebinary information.
    /// </remarks>
    public interface IImageBinaryService
    {
        /// <summary>Retrieves a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <returns>The imagebinary data</returns>
        ImageBinary GetById(Guid id);

        /// <summary>Retrieves a list of imagebinarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of imagebinarys</returns>
        List<ImageBinary> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new imagebinary</summary>
        /// <param name="model">The imagebinary data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ImageBinary model);

        /// <summary>Updates a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <param name="updatedEntity">The imagebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ImageBinary updatedEntity);

        /// <summary>Updates a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <param name="updatedEntity">The imagebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ImageBinary> updatedEntity);

        /// <summary>Deletes a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The imagebinaryService responsible for managing imagebinary related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting imagebinary information.
    /// </remarks>
    public class ImageBinaryService : IImageBinaryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ImageBinary class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ImageBinaryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <returns>The imagebinary data</returns>
        public ImageBinary GetById(Guid id)
        {
            var entityData = _dbContext.ImageBinary.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of imagebinarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of imagebinarys</returns>/// <exception cref="Exception"></exception>
        public List<ImageBinary> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetImageBinary(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new imagebinary</summary>
        /// <param name="model">The imagebinary data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ImageBinary model)
        {
            model.Id = CreateImageBinary(model);
            return model.Id;
        }

        /// <summary>Updates a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <param name="updatedEntity">The imagebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ImageBinary updatedEntity)
        {
            UpdateImageBinary(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <param name="updatedEntity">The imagebinary data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ImageBinary> updatedEntity)
        {
            PatchImageBinary(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific imagebinary by its primary key</summary>
        /// <param name="id">The primary key of the imagebinary</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteImageBinary(id);
            return true;
        }
        #region
        private List<ImageBinary> GetImageBinary(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ImageBinary.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ImageBinary>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ImageBinary), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ImageBinary, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateImageBinary(ImageBinary model)
        {
            _dbContext.ImageBinary.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateImageBinary(Guid id, ImageBinary updatedEntity)
        {
            _dbContext.ImageBinary.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteImageBinary(Guid id)
        {
            var entityData = _dbContext.ImageBinary.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ImageBinary.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchImageBinary(Guid id, JsonPatchDocument<ImageBinary> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ImageBinary.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ImageBinary.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}