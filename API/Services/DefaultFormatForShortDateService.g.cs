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
    /// The defaultformatforshortdateService responsible for managing defaultformatforshortdate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting defaultformatforshortdate information.
    /// </remarks>
    public interface IDefaultFormatForShortDateService
    {
        /// <summary>Retrieves a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <returns>The defaultformatforshortdate data</returns>
        DefaultFormatForShortDate GetById(Guid id);

        /// <summary>Retrieves a list of defaultformatforshortdates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforshortdates</returns>
        List<DefaultFormatForShortDate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new defaultformatforshortdate</summary>
        /// <param name="model">The defaultformatforshortdate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DefaultFormatForShortDate model);

        /// <summary>Updates a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <param name="updatedEntity">The defaultformatforshortdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DefaultFormatForShortDate updatedEntity);

        /// <summary>Updates a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <param name="updatedEntity">The defaultformatforshortdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DefaultFormatForShortDate> updatedEntity);

        /// <summary>Deletes a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The defaultformatforshortdateService responsible for managing defaultformatforshortdate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting defaultformatforshortdate information.
    /// </remarks>
    public class DefaultFormatForShortDateService : IDefaultFormatForShortDateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DefaultFormatForShortDate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DefaultFormatForShortDateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <returns>The defaultformatforshortdate data</returns>
        public DefaultFormatForShortDate GetById(Guid id)
        {
            var entityData = _dbContext.DefaultFormatForShortDate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of defaultformatforshortdates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of defaultformatforshortdates</returns>/// <exception cref="Exception"></exception>
        public List<DefaultFormatForShortDate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDefaultFormatForShortDate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new defaultformatforshortdate</summary>
        /// <param name="model">The defaultformatforshortdate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DefaultFormatForShortDate model)
        {
            model.Id = CreateDefaultFormatForShortDate(model);
            return model.Id;
        }

        /// <summary>Updates a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <param name="updatedEntity">The defaultformatforshortdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DefaultFormatForShortDate updatedEntity)
        {
            UpdateDefaultFormatForShortDate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <param name="updatedEntity">The defaultformatforshortdate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DefaultFormatForShortDate> updatedEntity)
        {
            PatchDefaultFormatForShortDate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific defaultformatforshortdate by its primary key</summary>
        /// <param name="id">The primary key of the defaultformatforshortdate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDefaultFormatForShortDate(id);
            return true;
        }
        #region
        private List<DefaultFormatForShortDate> GetDefaultFormatForShortDate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DefaultFormatForShortDate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DefaultFormatForShortDate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DefaultFormatForShortDate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DefaultFormatForShortDate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDefaultFormatForShortDate(DefaultFormatForShortDate model)
        {
            _dbContext.DefaultFormatForShortDate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDefaultFormatForShortDate(Guid id, DefaultFormatForShortDate updatedEntity)
        {
            _dbContext.DefaultFormatForShortDate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDefaultFormatForShortDate(Guid id)
        {
            var entityData = _dbContext.DefaultFormatForShortDate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DefaultFormatForShortDate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDefaultFormatForShortDate(Guid id, JsonPatchDocument<DefaultFormatForShortDate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DefaultFormatForShortDate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DefaultFormatForShortDate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}