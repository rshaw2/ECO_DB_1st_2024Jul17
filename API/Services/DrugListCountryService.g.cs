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
    /// The druglistcountryService responsible for managing druglistcountry related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druglistcountry information.
    /// </remarks>
    public interface IDrugListCountryService
    {
        /// <summary>Retrieves a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <returns>The druglistcountry data</returns>
        DrugListCountry GetById(Guid id);

        /// <summary>Retrieves a list of druglistcountrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druglistcountrys</returns>
        List<DrugListCountry> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new druglistcountry</summary>
        /// <param name="model">The druglistcountry data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugListCountry model);

        /// <summary>Updates a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <param name="updatedEntity">The druglistcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugListCountry updatedEntity);

        /// <summary>Updates a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <param name="updatedEntity">The druglistcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugListCountry> updatedEntity);

        /// <summary>Deletes a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The druglistcountryService responsible for managing druglistcountry related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druglistcountry information.
    /// </remarks>
    public class DrugListCountryService : IDrugListCountryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugListCountry class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugListCountryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <returns>The druglistcountry data</returns>
        public DrugListCountry GetById(Guid id)
        {
            var entityData = _dbContext.DrugListCountry.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of druglistcountrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druglistcountrys</returns>/// <exception cref="Exception"></exception>
        public List<DrugListCountry> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugListCountry(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new druglistcountry</summary>
        /// <param name="model">The druglistcountry data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugListCountry model)
        {
            model.Id = CreateDrugListCountry(model);
            return model.Id;
        }

        /// <summary>Updates a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <param name="updatedEntity">The druglistcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugListCountry updatedEntity)
        {
            UpdateDrugListCountry(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <param name="updatedEntity">The druglistcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugListCountry> updatedEntity)
        {
            PatchDrugListCountry(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific druglistcountry by its primary key</summary>
        /// <param name="id">The primary key of the druglistcountry</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugListCountry(id);
            return true;
        }
        #region
        private List<DrugListCountry> GetDrugListCountry(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugListCountry.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugListCountry>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugListCountry), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugListCountry, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugListCountry(DrugListCountry model)
        {
            _dbContext.DrugListCountry.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugListCountry(Guid id, DrugListCountry updatedEntity)
        {
            _dbContext.DrugListCountry.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugListCountry(Guid id)
        {
            var entityData = _dbContext.DrugListCountry.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugListCountry.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugListCountry(Guid id, JsonPatchDocument<DrugListCountry> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugListCountry.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugListCountry.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}