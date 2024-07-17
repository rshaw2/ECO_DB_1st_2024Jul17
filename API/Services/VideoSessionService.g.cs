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
    /// The videosessionService responsible for managing videosession related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting videosession information.
    /// </remarks>
    public interface IVideoSessionService
    {
        /// <summary>Retrieves a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <returns>The videosession data</returns>
        VideoSession GetById(Guid id);

        /// <summary>Retrieves a list of videosessions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of videosessions</returns>
        List<VideoSession> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new videosession</summary>
        /// <param name="model">The videosession data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VideoSession model);

        /// <summary>Updates a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <param name="updatedEntity">The videosession data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VideoSession updatedEntity);

        /// <summary>Updates a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <param name="updatedEntity">The videosession data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VideoSession> updatedEntity);

        /// <summary>Deletes a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The videosessionService responsible for managing videosession related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting videosession information.
    /// </remarks>
    public class VideoSessionService : IVideoSessionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VideoSession class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VideoSessionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <returns>The videosession data</returns>
        public VideoSession GetById(Guid id)
        {
            var entityData = _dbContext.VideoSession.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of videosessions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of videosessions</returns>/// <exception cref="Exception"></exception>
        public List<VideoSession> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVideoSession(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new videosession</summary>
        /// <param name="model">The videosession data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VideoSession model)
        {
            model.Id = CreateVideoSession(model);
            return model.Id;
        }

        /// <summary>Updates a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <param name="updatedEntity">The videosession data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VideoSession updatedEntity)
        {
            UpdateVideoSession(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <param name="updatedEntity">The videosession data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VideoSession> updatedEntity)
        {
            PatchVideoSession(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific videosession by its primary key</summary>
        /// <param name="id">The primary key of the videosession</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVideoSession(id);
            return true;
        }
        #region
        private List<VideoSession> GetVideoSession(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VideoSession.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VideoSession>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VideoSession), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VideoSession, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVideoSession(VideoSession model)
        {
            _dbContext.VideoSession.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVideoSession(Guid id, VideoSession updatedEntity)
        {
            _dbContext.VideoSession.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVideoSession(Guid id)
        {
            var entityData = _dbContext.VideoSession.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VideoSession.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVideoSession(Guid id, JsonPatchDocument<VideoSession> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VideoSession.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VideoSession.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}