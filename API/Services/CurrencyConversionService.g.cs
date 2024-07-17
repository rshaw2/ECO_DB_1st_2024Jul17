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
    /// The currencyconversionService responsible for managing currencyconversion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting currencyconversion information.
    /// </remarks>
    public interface ICurrencyConversionService
    {
        /// <summary>Retrieves a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <returns>The currencyconversion data</returns>
        CurrencyConversion GetById(Guid id);

        /// <summary>Retrieves a list of currencyconversions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of currencyconversions</returns>
        List<CurrencyConversion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new currencyconversion</summary>
        /// <param name="model">The currencyconversion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CurrencyConversion model);

        /// <summary>Updates a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <param name="updatedEntity">The currencyconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CurrencyConversion updatedEntity);

        /// <summary>Updates a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <param name="updatedEntity">The currencyconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CurrencyConversion> updatedEntity);

        /// <summary>Deletes a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The currencyconversionService responsible for managing currencyconversion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting currencyconversion information.
    /// </remarks>
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CurrencyConversion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CurrencyConversionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <returns>The currencyconversion data</returns>
        public CurrencyConversion GetById(Guid id)
        {
            var entityData = _dbContext.CurrencyConversion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of currencyconversions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of currencyconversions</returns>/// <exception cref="Exception"></exception>
        public List<CurrencyConversion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCurrencyConversion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new currencyconversion</summary>
        /// <param name="model">The currencyconversion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CurrencyConversion model)
        {
            model.Id = CreateCurrencyConversion(model);
            return model.Id;
        }

        /// <summary>Updates a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <param name="updatedEntity">The currencyconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CurrencyConversion updatedEntity)
        {
            UpdateCurrencyConversion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <param name="updatedEntity">The currencyconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CurrencyConversion> updatedEntity)
        {
            PatchCurrencyConversion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific currencyconversion by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCurrencyConversion(id);
            return true;
        }
        #region
        private List<CurrencyConversion> GetCurrencyConversion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CurrencyConversion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CurrencyConversion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CurrencyConversion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CurrencyConversion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCurrencyConversion(CurrencyConversion model)
        {
            _dbContext.CurrencyConversion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCurrencyConversion(Guid id, CurrencyConversion updatedEntity)
        {
            _dbContext.CurrencyConversion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCurrencyConversion(Guid id)
        {
            var entityData = _dbContext.CurrencyConversion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CurrencyConversion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCurrencyConversion(Guid id, JsonPatchDocument<CurrencyConversion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CurrencyConversion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CurrencyConversion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}