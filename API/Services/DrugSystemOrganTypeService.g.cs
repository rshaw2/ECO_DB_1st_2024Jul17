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
    /// The drugsystemorgantypeService responsible for managing drugsystemorgantype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugsystemorgantype information.
    /// </remarks>
    public interface IDrugSystemOrganTypeService
    {
        /// <summary>Retrieves a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <returns>The drugsystemorgantype data</returns>
        DrugSystemOrganType GetById(Guid id);

        /// <summary>Retrieves a list of drugsystemorgantypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugsystemorgantypes</returns>
        List<DrugSystemOrganType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new drugsystemorgantype</summary>
        /// <param name="model">The drugsystemorgantype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugSystemOrganType model);

        /// <summary>Updates a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <param name="updatedEntity">The drugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugSystemOrganType updatedEntity);

        /// <summary>Updates a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <param name="updatedEntity">The drugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugSystemOrganType> updatedEntity);

        /// <summary>Deletes a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The drugsystemorgantypeService responsible for managing drugsystemorgantype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugsystemorgantype information.
    /// </remarks>
    public class DrugSystemOrganTypeService : IDrugSystemOrganTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugSystemOrganType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugSystemOrganTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <returns>The drugsystemorgantype data</returns>
        public DrugSystemOrganType GetById(Guid id)
        {
            var entityData = _dbContext.DrugSystemOrganType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of drugsystemorgantypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugsystemorgantypes</returns>/// <exception cref="Exception"></exception>
        public List<DrugSystemOrganType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugSystemOrganType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new drugsystemorgantype</summary>
        /// <param name="model">The drugsystemorgantype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugSystemOrganType model)
        {
            model.Id = CreateDrugSystemOrganType(model);
            return model.Id;
        }

        /// <summary>Updates a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <param name="updatedEntity">The drugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugSystemOrganType updatedEntity)
        {
            UpdateDrugSystemOrganType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <param name="updatedEntity">The drugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugSystemOrganType> updatedEntity)
        {
            PatchDrugSystemOrganType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific drugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the drugsystemorgantype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugSystemOrganType(id);
            return true;
        }
        #region
        private List<DrugSystemOrganType> GetDrugSystemOrganType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugSystemOrganType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugSystemOrganType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugSystemOrganType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugSystemOrganType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugSystemOrganType(DrugSystemOrganType model)
        {
            _dbContext.DrugSystemOrganType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugSystemOrganType(Guid id, DrugSystemOrganType updatedEntity)
        {
            _dbContext.DrugSystemOrganType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugSystemOrganType(Guid id)
        {
            var entityData = _dbContext.DrugSystemOrganType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugSystemOrganType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugSystemOrganType(Guid id, JsonPatchDocument<DrugSystemOrganType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugSystemOrganType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugSystemOrganType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}