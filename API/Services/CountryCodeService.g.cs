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
    /// The countrycodeService responsible for managing countrycode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting countrycode information.
    /// </remarks>
    public interface ICountryCodeService
    {
        /// <summary>Retrieves a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <returns>The countrycode data</returns>
        CountryCode GetById(Guid id);

        /// <summary>Retrieves a list of countrycodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of countrycodes</returns>
        List<CountryCode> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new countrycode</summary>
        /// <param name="model">The countrycode data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CountryCode model);

        /// <summary>Updates a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <param name="updatedEntity">The countrycode data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CountryCode updatedEntity);

        /// <summary>Updates a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <param name="updatedEntity">The countrycode data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CountryCode> updatedEntity);

        /// <summary>Deletes a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The countrycodeService responsible for managing countrycode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting countrycode information.
    /// </remarks>
    public class CountryCodeService : ICountryCodeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CountryCode class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CountryCodeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <returns>The countrycode data</returns>
        public CountryCode GetById(Guid id)
        {
            var entityData = _dbContext.CountryCode.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of countrycodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of countrycodes</returns>/// <exception cref="Exception"></exception>
        public List<CountryCode> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCountryCode(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new countrycode</summary>
        /// <param name="model">The countrycode data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CountryCode model)
        {
            model.Id = CreateCountryCode(model);
            return model.Id;
        }

        /// <summary>Updates a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <param name="updatedEntity">The countrycode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CountryCode updatedEntity)
        {
            UpdateCountryCode(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <param name="updatedEntity">The countrycode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CountryCode> updatedEntity)
        {
            PatchCountryCode(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific countrycode by its primary key</summary>
        /// <param name="id">The primary key of the countrycode</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCountryCode(id);
            return true;
        }
        #region
        private List<CountryCode> GetCountryCode(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CountryCode.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CountryCode>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CountryCode), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CountryCode, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCountryCode(CountryCode model)
        {
            _dbContext.CountryCode.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCountryCode(Guid id, CountryCode updatedEntity)
        {
            _dbContext.CountryCode.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCountryCode(Guid id)
        {
            var entityData = _dbContext.CountryCode.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CountryCode.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCountryCode(Guid id, JsonPatchDocument<CountryCode> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CountryCode.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CountryCode.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}