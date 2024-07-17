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
    /// The comorbiditydeviationService responsible for managing comorbiditydeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting comorbiditydeviation information.
    /// </remarks>
    public interface IComorbidityDeviationService
    {
        /// <summary>Retrieves a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <returns>The comorbiditydeviation data</returns>
        ComorbidityDeviation GetById(Guid id);

        /// <summary>Retrieves a list of comorbiditydeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of comorbiditydeviations</returns>
        List<ComorbidityDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new comorbiditydeviation</summary>
        /// <param name="model">The comorbiditydeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ComorbidityDeviation model);

        /// <summary>Updates a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <param name="updatedEntity">The comorbiditydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ComorbidityDeviation updatedEntity);

        /// <summary>Updates a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <param name="updatedEntity">The comorbiditydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ComorbidityDeviation> updatedEntity);

        /// <summary>Deletes a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The comorbiditydeviationService responsible for managing comorbiditydeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting comorbiditydeviation information.
    /// </remarks>
    public class ComorbidityDeviationService : IComorbidityDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ComorbidityDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ComorbidityDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <returns>The comorbiditydeviation data</returns>
        public ComorbidityDeviation GetById(Guid id)
        {
            var entityData = _dbContext.ComorbidityDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of comorbiditydeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of comorbiditydeviations</returns>/// <exception cref="Exception"></exception>
        public List<ComorbidityDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetComorbidityDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new comorbiditydeviation</summary>
        /// <param name="model">The comorbiditydeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ComorbidityDeviation model)
        {
            model.Id = CreateComorbidityDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <param name="updatedEntity">The comorbiditydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ComorbidityDeviation updatedEntity)
        {
            UpdateComorbidityDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <param name="updatedEntity">The comorbiditydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ComorbidityDeviation> updatedEntity)
        {
            PatchComorbidityDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific comorbiditydeviation by its primary key</summary>
        /// <param name="id">The primary key of the comorbiditydeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteComorbidityDeviation(id);
            return true;
        }
        #region
        private List<ComorbidityDeviation> GetComorbidityDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ComorbidityDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ComorbidityDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ComorbidityDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ComorbidityDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateComorbidityDeviation(ComorbidityDeviation model)
        {
            _dbContext.ComorbidityDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateComorbidityDeviation(Guid id, ComorbidityDeviation updatedEntity)
        {
            _dbContext.ComorbidityDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteComorbidityDeviation(Guid id)
        {
            var entityData = _dbContext.ComorbidityDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ComorbidityDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchComorbidityDeviation(Guid id, JsonPatchDocument<ComorbidityDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ComorbidityDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ComorbidityDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}