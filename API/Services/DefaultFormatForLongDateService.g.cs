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
    /// The defaultformatforlongdateService responsible for managing defaultformatforlongdate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting defaultformatforlongdate information.
    /// </remarks>
    public interface IDefaultFormatForLongDateService
    {
        /// <summary>Retrieves a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <returns>The defaultformatforlongdate data</returns>
        DefaultFormatForLongDate GetById(Guid id);

        /// <summary>Retrieves a list of defaultformatforlongdates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforlongdates</returns>
        List<DefaultFormatForLongDate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new defaultformatforlongdate</summary>
        /// <param name="model">The defaultformatforlongdate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DefaultFormatForLongDate model);

        /// <summary>Updates a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <param name="updatedEntity">The defaultformatforlongdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DefaultFormatForLongDate updatedEntity);

        /// <summary>Updates a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <param name="updatedEntity">The defaultformatforlongdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DefaultFormatForLongDate> updatedEntity);

        /// <summary>Deletes a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The defaultformatforlongdateService responsible for managing defaultformatforlongdate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting defaultformatforlongdate information.
    /// </remarks>
    public class DefaultFormatForLongDateService : IDefaultFormatForLongDateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DefaultFormatForLongDate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DefaultFormatForLongDateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <returns>The defaultformatforlongdate data</returns>
        public DefaultFormatForLongDate GetById(Guid id)
        {
            var entityData = _dbContext.DefaultFormatForLongDate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of defaultformatforlongdates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforlongdates</returns>/// <exception cref="Exception"></exception>
        public List<DefaultFormatForLongDate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDefaultFormatForLongDate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new defaultformatforlongdate</summary>
        /// <param name="model">The defaultformatforlongdate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DefaultFormatForLongDate model)
        {
            model.Id = CreateDefaultFormatForLongDate(model);
            return model.Id;
        }

        /// <summary>Updates a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <param name="updatedEntity">The defaultformatforlongdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DefaultFormatForLongDate updatedEntity)
        {
            UpdateDefaultFormatForLongDate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <param name="updatedEntity">The defaultformatforlongdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DefaultFormatForLongDate> updatedEntity)
        {
            PatchDefaultFormatForLongDate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific defaultformatforlongdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforlongdate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDefaultFormatForLongDate(id);
            return true;
        }
        #region
        private List<DefaultFormatForLongDate> GetDefaultFormatForLongDate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DefaultFormatForLongDate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DefaultFormatForLongDate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DefaultFormatForLongDate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DefaultFormatForLongDate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDefaultFormatForLongDate(DefaultFormatForLongDate model)
        {
            _dbContext.DefaultFormatForLongDate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDefaultFormatForLongDate(Guid id, DefaultFormatForLongDate updatedEntity)
        {
            _dbContext.DefaultFormatForLongDate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDefaultFormatForLongDate(Guid id)
        {
            var entityData = _dbContext.DefaultFormatForLongDate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DefaultFormatForLongDate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDefaultFormatForLongDate(Guid id, JsonPatchDocument<DefaultFormatForLongDate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DefaultFormatForLongDate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DefaultFormatForLongDate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}