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
    /// The frequencyvalueService responsible for managing frequencyvalue related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting frequencyvalue information.
    /// </remarks>
    public interface IFrequencyValueService
    {
        /// <summary>Retrieves a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <returns>The frequencyvalue data</returns>
        FrequencyValue GetById(Guid id);

        /// <summary>Retrieves a list of frequencyvalues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of frequencyvalues</returns>
        List<FrequencyValue> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new frequencyvalue</summary>
        /// <param name="model">The frequencyvalue data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(FrequencyValue model);

        /// <summary>Updates a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <param name="updatedEntity">The frequencyvalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, FrequencyValue updatedEntity);

        /// <summary>Updates a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <param name="updatedEntity">The frequencyvalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<FrequencyValue> updatedEntity);

        /// <summary>Deletes a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The frequencyvalueService responsible for managing frequencyvalue related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting frequencyvalue information.
    /// </remarks>
    public class FrequencyValueService : IFrequencyValueService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the FrequencyValue class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public FrequencyValueService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <returns>The frequencyvalue data</returns>
        public FrequencyValue GetById(Guid id)
        {
            var entityData = _dbContext.FrequencyValue.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of frequencyvalues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of frequencyvalues</returns>/// <exception cref="Exception"></exception>
        public List<FrequencyValue> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetFrequencyValue(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new frequencyvalue</summary>
        /// <param name="model">The frequencyvalue data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(FrequencyValue model)
        {
            model.Id = CreateFrequencyValue(model);
            return model.Id;
        }

        /// <summary>Updates a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <param name="updatedEntity">The frequencyvalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, FrequencyValue updatedEntity)
        {
            UpdateFrequencyValue(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <param name="updatedEntity">The frequencyvalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<FrequencyValue> updatedEntity)
        {
            PatchFrequencyValue(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific frequencyvalue by its primary key</summary>
        /// <param name="id">The primary key of the frequencyvalue</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteFrequencyValue(id);
            return true;
        }
        #region
        private List<FrequencyValue> GetFrequencyValue(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FrequencyValue.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FrequencyValue>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FrequencyValue), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FrequencyValue, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateFrequencyValue(FrequencyValue model)
        {
            _dbContext.FrequencyValue.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateFrequencyValue(Guid id, FrequencyValue updatedEntity)
        {
            _dbContext.FrequencyValue.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteFrequencyValue(Guid id)
        {
            var entityData = _dbContext.FrequencyValue.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FrequencyValue.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchFrequencyValue(Guid id, JsonPatchDocument<FrequencyValue> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FrequencyValue.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FrequencyValue.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}