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
    /// The informationobjectsService responsible for managing informationobjects related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjects information.
    /// </remarks>
    public interface IInformationObjectsService
    {
        /// <summary>Retrieves a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <returns>The informationobjects data</returns>
        InformationObjects GetById(Guid id);

        /// <summary>Retrieves a list of informationobjectss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectss</returns>
        List<InformationObjects> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new informationobjects</summary>
        /// <param name="model">The informationobjects data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InformationObjects model);

        /// <summary>Updates a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <param name="updatedEntity">The informationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InformationObjects updatedEntity);

        /// <summary>Updates a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <param name="updatedEntity">The informationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InformationObjects> updatedEntity);

        /// <summary>Deletes a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The informationobjectsService responsible for managing informationobjects related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjects information.
    /// </remarks>
    public class InformationObjectsService : IInformationObjectsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InformationObjects class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InformationObjectsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <returns>The informationobjects data</returns>
        public InformationObjects GetById(Guid id)
        {
            var entityData = _dbContext.InformationObjects.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of informationobjectss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectss</returns>/// <exception cref="Exception"></exception>
        public List<InformationObjects> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInformationObjects(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new informationobjects</summary>
        /// <param name="model">The informationobjects data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InformationObjects model)
        {
            model.Id = CreateInformationObjects(model);
            return model.Id;
        }

        /// <summary>Updates a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <param name="updatedEntity">The informationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InformationObjects updatedEntity)
        {
            UpdateInformationObjects(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <param name="updatedEntity">The informationobjects data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InformationObjects> updatedEntity)
        {
            PatchInformationObjects(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific informationobjects by its primary key</summary>
        /// <param name="id">The primary key of the informationobjects</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInformationObjects(id);
            return true;
        }
        #region
        private List<InformationObjects> GetInformationObjects(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InformationObjects.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InformationObjects>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InformationObjects), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InformationObjects, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInformationObjects(InformationObjects model)
        {
            _dbContext.InformationObjects.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInformationObjects(Guid id, InformationObjects updatedEntity)
        {
            _dbContext.InformationObjects.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInformationObjects(Guid id)
        {
            var entityData = _dbContext.InformationObjects.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InformationObjects.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInformationObjects(Guid id, JsonPatchDocument<InformationObjects> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InformationObjects.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InformationObjects.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}