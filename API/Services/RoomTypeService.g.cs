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
    /// The roomtypeService responsible for managing roomtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roomtype information.
    /// </remarks>
    public interface IRoomTypeService
    {
        /// <summary>Retrieves a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <returns>The roomtype data</returns>
        RoomType GetById(Guid id);

        /// <summary>Retrieves a list of roomtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roomtypes</returns>
        List<RoomType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new roomtype</summary>
        /// <param name="model">The roomtype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(RoomType model);

        /// <summary>Updates a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <param name="updatedEntity">The roomtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, RoomType updatedEntity);

        /// <summary>Updates a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <param name="updatedEntity">The roomtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<RoomType> updatedEntity);

        /// <summary>Deletes a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The roomtypeService responsible for managing roomtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting roomtype information.
    /// </remarks>
    public class RoomTypeService : IRoomTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the RoomType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RoomTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <returns>The roomtype data</returns>
        public RoomType GetById(Guid id)
        {
            var entityData = _dbContext.RoomType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of roomtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of roomtypes</returns>/// <exception cref="Exception"></exception>
        public List<RoomType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRoomType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new roomtype</summary>
        /// <param name="model">The roomtype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(RoomType model)
        {
            model.Id = CreateRoomType(model);
            return model.Id;
        }

        /// <summary>Updates a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <param name="updatedEntity">The roomtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, RoomType updatedEntity)
        {
            UpdateRoomType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <param name="updatedEntity">The roomtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<RoomType> updatedEntity)
        {
            PatchRoomType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific roomtype by its primary key</summary>
        /// <param name="id">The primary key of the roomtype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRoomType(id);
            return true;
        }
        #region
        private List<RoomType> GetRoomType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RoomType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RoomType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RoomType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RoomType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateRoomType(RoomType model)
        {
            _dbContext.RoomType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateRoomType(Guid id, RoomType updatedEntity)
        {
            _dbContext.RoomType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRoomType(Guid id)
        {
            var entityData = _dbContext.RoomType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RoomType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRoomType(Guid id, JsonPatchDocument<RoomType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RoomType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RoomType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}