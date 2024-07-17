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
    /// The imageService responsible for managing image related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting image information.
    /// </remarks>
    public interface IImageService
    {
        /// <summary>Retrieves a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <returns>The image data</returns>
        Image GetById(Guid id);

        /// <summary>Retrieves a list of images based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of images</returns>
        List<Image> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new image</summary>
        /// <param name="model">The image data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Image model);

        /// <summary>Updates a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <param name="updatedEntity">The image data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Image updatedEntity);

        /// <summary>Updates a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <param name="updatedEntity">The image data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Image> updatedEntity);

        /// <summary>Deletes a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The imageService responsible for managing image related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting image information.
    /// </remarks>
    public class ImageService : IImageService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ImageService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <returns>The image data</returns>
        public Image GetById(Guid id)
        {
            var entityData = _dbContext.Image.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of images based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of images</returns>/// <exception cref="Exception"></exception>
        public List<Image> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetImage(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new image</summary>
        /// <param name="model">The image data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Image model)
        {
            model.Id = CreateImage(model);
            return model.Id;
        }

        /// <summary>Updates a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <param name="updatedEntity">The image data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Image updatedEntity)
        {
            UpdateImage(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <param name="updatedEntity">The image data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Image> updatedEntity)
        {
            PatchImage(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific image by its primary key</summary>
        /// <param name="id">The primary key of the image</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteImage(id);
            return true;
        }
        #region
        private List<Image> GetImage(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Image.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Image>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Image), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Image, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateImage(Image model)
        {
            _dbContext.Image.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateImage(Guid id, Image updatedEntity)
        {
            _dbContext.Image.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteImage(Guid id)
        {
            var entityData = _dbContext.Image.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Image.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchImage(Guid id, JsonPatchDocument<Image> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Image.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Image.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}