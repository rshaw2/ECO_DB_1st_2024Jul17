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
    /// The weekService responsible for managing week related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting week information.
    /// </remarks>
    public interface IWeekService
    {
        /// <summary>Retrieves a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <returns>The week data</returns>
        Week GetById(Guid id);

        /// <summary>Retrieves a list of weeks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of weeks</returns>
        List<Week> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new week</summary>
        /// <param name="model">The week data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Week model);

        /// <summary>Updates a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <param name="updatedEntity">The week data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Week updatedEntity);

        /// <summary>Updates a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <param name="updatedEntity">The week data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Week> updatedEntity);

        /// <summary>Deletes a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The weekService responsible for managing week related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting week information.
    /// </remarks>
    public class WeekService : IWeekService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Week class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public WeekService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <returns>The week data</returns>
        public Week GetById(Guid id)
        {
            var entityData = _dbContext.Week.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of weeks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of weeks</returns>/// <exception cref="Exception"></exception>
        public List<Week> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetWeek(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new week</summary>
        /// <param name="model">The week data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Week model)
        {
            model.Id = CreateWeek(model);
            return model.Id;
        }

        /// <summary>Updates a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <param name="updatedEntity">The week data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Week updatedEntity)
        {
            UpdateWeek(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <param name="updatedEntity">The week data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Week> updatedEntity)
        {
            PatchWeek(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific week by its primary key</summary>
        /// <param name="id">The primary key of the week</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteWeek(id);
            return true;
        }
        #region
        private List<Week> GetWeek(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Week.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Week>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Week), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Week, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateWeek(Week model)
        {
            _dbContext.Week.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateWeek(Guid id, Week updatedEntity)
        {
            _dbContext.Week.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteWeek(Guid id)
        {
            var entityData = _dbContext.Week.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Week.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchWeek(Guid id, JsonPatchDocument<Week> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Week.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Week.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}