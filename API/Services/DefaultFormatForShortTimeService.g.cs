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
    /// The defaultformatforshorttimeService responsible for managing defaultformatforshorttime related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting defaultformatforshorttime information.
    /// </remarks>
    public interface IDefaultFormatForShortTimeService
    {
        /// <summary>Retrieves a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <returns>The defaultformatforshorttime data</returns>
        DefaultFormatForShortTime GetById(Guid id);

        /// <summary>Retrieves a list of defaultformatforshorttimes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforshorttimes</returns>
        List<DefaultFormatForShortTime> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new defaultformatforshorttime</summary>
        /// <param name="model">The defaultformatforshorttime data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DefaultFormatForShortTime model);

        /// <summary>Updates a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <param name="updatedEntity">The defaultformatforshorttime data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DefaultFormatForShortTime updatedEntity);

        /// <summary>Updates a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <param name="updatedEntity">The defaultformatforshorttime data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DefaultFormatForShortTime> updatedEntity);

        /// <summary>Deletes a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The defaultformatforshorttimeService responsible for managing defaultformatforshorttime related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting defaultformatforshorttime information.
    /// </remarks>
    public class DefaultFormatForShortTimeService : IDefaultFormatForShortTimeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DefaultFormatForShortTime class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DefaultFormatForShortTimeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <returns>The defaultformatforshorttime data</returns>
        public DefaultFormatForShortTime GetById(Guid id)
        {
            var entityData = _dbContext.DefaultFormatForShortTime.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of defaultformatforshorttimes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforshorttimes</returns>/// <exception cref="Exception"></exception>
        public List<DefaultFormatForShortTime> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDefaultFormatForShortTime(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new defaultformatforshorttime</summary>
        /// <param name="model">The defaultformatforshorttime data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DefaultFormatForShortTime model)
        {
            model.Id = CreateDefaultFormatForShortTime(model);
            return model.Id;
        }

        /// <summary>Updates a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <param name="updatedEntity">The defaultformatforshorttime data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DefaultFormatForShortTime updatedEntity)
        {
            UpdateDefaultFormatForShortTime(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <param name="updatedEntity">The defaultformatforshorttime data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DefaultFormatForShortTime> updatedEntity)
        {
            PatchDefaultFormatForShortTime(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific defaultformatforshorttime by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshorttime</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDefaultFormatForShortTime(id);
            return true;
        }
        #region
        private List<DefaultFormatForShortTime> GetDefaultFormatForShortTime(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DefaultFormatForShortTime.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DefaultFormatForShortTime>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DefaultFormatForShortTime), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DefaultFormatForShortTime, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDefaultFormatForShortTime(DefaultFormatForShortTime model)
        {
            _dbContext.DefaultFormatForShortTime.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDefaultFormatForShortTime(Guid id, DefaultFormatForShortTime updatedEntity)
        {
            _dbContext.DefaultFormatForShortTime.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDefaultFormatForShortTime(Guid id)
        {
            var entityData = _dbContext.DefaultFormatForShortTime.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DefaultFormatForShortTime.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDefaultFormatForShortTime(Guid id, JsonPatchDocument<DefaultFormatForShortTime> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DefaultFormatForShortTime.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DefaultFormatForShortTime.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}