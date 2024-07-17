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
    /// The dependentinformationobjectsService responsible for managing dependentinformationobjects related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dependentinformationobjects information.
    /// </remarks>
    public interface IDependentInformationObjectsService
    {
        /// <summary>Retrieves a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <returns>The dependentinformationobjects data</returns>
        DependentInformationObjects GetById(Guid id);

        /// <summary>Retrieves a list of dependentinformationobjectss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dependentinformationobjectss</returns>
        List<DependentInformationObjects> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new dependentinformationobjects</summary>
        /// <param name="model">The dependentinformationobjects data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DependentInformationObjects model);

        /// <summary>Updates a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <param name="updatedEntity">The dependentinformationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DependentInformationObjects updatedEntity);

        /// <summary>Updates a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <param name="updatedEntity">The dependentinformationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DependentInformationObjects> updatedEntity);

        /// <summary>Deletes a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The dependentinformationobjectsService responsible for managing dependentinformationobjects related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dependentinformationobjects information.
    /// </remarks>
    public class DependentInformationObjectsService : IDependentInformationObjectsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DependentInformationObjects class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DependentInformationObjectsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <returns>The dependentinformationobjects data</returns>
        public DependentInformationObjects GetById(Guid id)
        {
            var entityData = _dbContext.DependentInformationObjects.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of dependentinformationobjectss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dependentinformationobjectss</returns>/// <exception cref="Exception"></exception>
        public List<DependentInformationObjects> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDependentInformationObjects(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new dependentinformationobjects</summary>
        /// <param name="model">The dependentinformationobjects data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DependentInformationObjects model)
        {
            model.Id = CreateDependentInformationObjects(model);
            return model.Id;
        }

        /// <summary>Updates a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <param name="updatedEntity">The dependentinformationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DependentInformationObjects updatedEntity)
        {
            UpdateDependentInformationObjects(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <param name="updatedEntity">The dependentinformationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DependentInformationObjects> updatedEntity)
        {
            PatchDependentInformationObjects(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific dependentinformationobjects by its primary key</summary>
        /// <param name="id">The primary key of the dependentinformationobjects</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDependentInformationObjects(id);
            return true;
        }
        #region
        private List<DependentInformationObjects> GetDependentInformationObjects(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DependentInformationObjects.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DependentInformationObjects>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DependentInformationObjects), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DependentInformationObjects, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDependentInformationObjects(DependentInformationObjects model)
        {
            _dbContext.DependentInformationObjects.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDependentInformationObjects(Guid id, DependentInformationObjects updatedEntity)
        {
            _dbContext.DependentInformationObjects.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDependentInformationObjects(Guid id)
        {
            var entityData = _dbContext.DependentInformationObjects.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DependentInformationObjects.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDependentInformationObjects(Guid id, JsonPatchDocument<DependentInformationObjects> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DependentInformationObjects.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DependentInformationObjects.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}