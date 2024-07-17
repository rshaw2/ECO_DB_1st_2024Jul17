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
    /// The currencyconversiontypeService responsible for managing currencyconversiontype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting currencyconversiontype information.
    /// </remarks>
    public interface ICurrencyConversionTypeService
    {
        /// <summary>Retrieves a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <returns>The currencyconversiontype data</returns>
        CurrencyConversionType GetById(Guid id);

        /// <summary>Retrieves a list of currencyconversiontypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of currencyconversiontypes</returns>
        List<CurrencyConversionType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new currencyconversiontype</summary>
        /// <param name="model">The currencyconversiontype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CurrencyConversionType model);

        /// <summary>Updates a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <param name="updatedEntity">The currencyconversiontype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CurrencyConversionType updatedEntity);

        /// <summary>Updates a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <param name="updatedEntity">The currencyconversiontype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CurrencyConversionType> updatedEntity);

        /// <summary>Deletes a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The currencyconversiontypeService responsible for managing currencyconversiontype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting currencyconversiontype information.
    /// </remarks>
    public class CurrencyConversionTypeService : ICurrencyConversionTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CurrencyConversionType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CurrencyConversionTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <returns>The currencyconversiontype data</returns>
        public CurrencyConversionType GetById(Guid id)
        {
            var entityData = _dbContext.CurrencyConversionType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of currencyconversiontypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of currencyconversiontypes</returns>/// <exception cref="Exception"></exception>
        public List<CurrencyConversionType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCurrencyConversionType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new currencyconversiontype</summary>
        /// <param name="model">The currencyconversiontype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CurrencyConversionType model)
        {
            model.Id = CreateCurrencyConversionType(model);
            return model.Id;
        }

        /// <summary>Updates a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <param name="updatedEntity">The currencyconversiontype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CurrencyConversionType updatedEntity)
        {
            UpdateCurrencyConversionType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <param name="updatedEntity">The currencyconversiontype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CurrencyConversionType> updatedEntity)
        {
            PatchCurrencyConversionType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific currencyconversiontype by its primary key</summary>
        /// <param name="id">The primary key of the currencyconversiontype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCurrencyConversionType(id);
            return true;
        }
        #region
        private List<CurrencyConversionType> GetCurrencyConversionType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CurrencyConversionType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CurrencyConversionType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CurrencyConversionType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CurrencyConversionType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCurrencyConversionType(CurrencyConversionType model)
        {
            _dbContext.CurrencyConversionType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCurrencyConversionType(Guid id, CurrencyConversionType updatedEntity)
        {
            _dbContext.CurrencyConversionType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCurrencyConversionType(Guid id)
        {
            var entityData = _dbContext.CurrencyConversionType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CurrencyConversionType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCurrencyConversionType(Guid id, JsonPatchDocument<CurrencyConversionType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CurrencyConversionType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CurrencyConversionType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}