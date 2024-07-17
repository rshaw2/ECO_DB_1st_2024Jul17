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
    /// The druglistService responsible for managing druglist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druglist information.
    /// </remarks>
    public interface IDrugListService
    {
        /// <summary>Retrieves a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <returns>The druglist data</returns>
        DrugList GetById(Guid id);

        /// <summary>Retrieves a list of druglists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druglists</returns>
        List<DrugList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new druglist</summary>
        /// <param name="model">The druglist data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugList model);

        /// <summary>Updates a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <param name="updatedEntity">The druglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugList updatedEntity);

        /// <summary>Updates a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <param name="updatedEntity">The druglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugList> updatedEntity);

        /// <summary>Deletes a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The druglistService responsible for managing druglist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druglist information.
    /// </remarks>
    public class DrugListService : IDrugListService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugList class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugListService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <returns>The druglist data</returns>
        public DrugList GetById(Guid id)
        {
            var entityData = _dbContext.DrugList.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of druglists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druglists</returns>/// <exception cref="Exception"></exception>
        public List<DrugList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugList(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new druglist</summary>
        /// <param name="model">The druglist data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugList model)
        {
            model.Id = CreateDrugList(model);
            return model.Id;
        }

        /// <summary>Updates a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <param name="updatedEntity">The druglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugList updatedEntity)
        {
            UpdateDrugList(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <param name="updatedEntity">The druglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugList> updatedEntity)
        {
            PatchDrugList(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific druglist by its primary key</summary>
        /// <param name="id">The primary key of the druglist</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugList(id);
            return true;
        }
        #region
        private List<DrugList> GetDrugList(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugList.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugList>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugList), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugList, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugList(DrugList model)
        {
            _dbContext.DrugList.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugList(Guid id, DrugList updatedEntity)
        {
            _dbContext.DrugList.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugList(Guid id)
        {
            var entityData = _dbContext.DrugList.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugList.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugList(Guid id, JsonPatchDocument<DrugList> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugList.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugList.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}