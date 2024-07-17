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
    /// The uomconversionService responsible for managing uomconversion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting uomconversion information.
    /// </remarks>
    public interface IUOMConversionService
    {
        /// <summary>Retrieves a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <returns>The uomconversion data</returns>
        UOMConversion GetById(Guid id);

        /// <summary>Retrieves a list of uomconversions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of uomconversions</returns>
        List<UOMConversion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new uomconversion</summary>
        /// <param name="model">The uomconversion data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UOMConversion model);

        /// <summary>Updates a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <param name="updatedEntity">The uomconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UOMConversion updatedEntity);

        /// <summary>Updates a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <param name="updatedEntity">The uomconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UOMConversion> updatedEntity);

        /// <summary>Deletes a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The uomconversionService responsible for managing uomconversion related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting uomconversion information.
    /// </remarks>
    public class UOMConversionService : IUOMConversionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UOMConversion class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UOMConversionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <returns>The uomconversion data</returns>
        public UOMConversion GetById(Guid id)
        {
            var entityData = _dbContext.UOMConversion.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of uomconversions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of uomconversions</returns>/// <exception cref="Exception"></exception>
        public List<UOMConversion> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUOMConversion(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new uomconversion</summary>
        /// <param name="model">The uomconversion data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UOMConversion model)
        {
            model.Id = CreateUOMConversion(model);
            return model.Id;
        }

        /// <summary>Updates a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <param name="updatedEntity">The uomconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UOMConversion updatedEntity)
        {
            UpdateUOMConversion(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <param name="updatedEntity">The uomconversion data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UOMConversion> updatedEntity)
        {
            PatchUOMConversion(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific uomconversion by its primary key</summary>
        /// <param name="id">The primary key of the uomconversion</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUOMConversion(id);
            return true;
        }
        #region
        private List<UOMConversion> GetUOMConversion(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UOMConversion.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UOMConversion>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UOMConversion), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UOMConversion, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUOMConversion(UOMConversion model)
        {
            _dbContext.UOMConversion.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUOMConversion(Guid id, UOMConversion updatedEntity)
        {
            _dbContext.UOMConversion.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUOMConversion(Guid id)
        {
            var entityData = _dbContext.UOMConversion.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UOMConversion.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUOMConversion(Guid id, JsonPatchDocument<UOMConversion> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UOMConversion.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UOMConversion.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}