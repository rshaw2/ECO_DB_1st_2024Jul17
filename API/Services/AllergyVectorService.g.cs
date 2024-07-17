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
    /// The allergyvectorService responsible for managing allergyvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergyvector information.
    /// </remarks>
    public interface IAllergyVectorService
    {
        /// <summary>Retrieves a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <returns>The allergyvector data</returns>
        AllergyVector GetById(Guid id);

        /// <summary>Retrieves a list of allergyvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergyvectors</returns>
        List<AllergyVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new allergyvector</summary>
        /// <param name="model">The allergyvector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AllergyVector model);

        /// <summary>Updates a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <param name="updatedEntity">The allergyvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AllergyVector updatedEntity);

        /// <summary>Updates a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <param name="updatedEntity">The allergyvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AllergyVector> updatedEntity);

        /// <summary>Deletes a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The allergyvectorService responsible for managing allergyvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergyvector information.
    /// </remarks>
    public class AllergyVectorService : IAllergyVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AllergyVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AllergyVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <returns>The allergyvector data</returns>
        public AllergyVector GetById(Guid id)
        {
            var entityData = _dbContext.AllergyVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of allergyvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergyvectors</returns>/// <exception cref="Exception"></exception>
        public List<AllergyVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAllergyVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new allergyvector</summary>
        /// <param name="model">The allergyvector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AllergyVector model)
        {
            model.Id = CreateAllergyVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <param name="updatedEntity">The allergyvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AllergyVector updatedEntity)
        {
            UpdateAllergyVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <param name="updatedEntity">The allergyvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AllergyVector> updatedEntity)
        {
            PatchAllergyVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific allergyvector by its primary key</summary>
        /// <param name="id">The primary key of the allergyvector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAllergyVector(id);
            return true;
        }
        #region
        private List<AllergyVector> GetAllergyVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AllergyVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AllergyVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AllergyVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AllergyVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAllergyVector(AllergyVector model)
        {
            _dbContext.AllergyVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAllergyVector(Guid id, AllergyVector updatedEntity)
        {
            _dbContext.AllergyVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAllergyVector(Guid id)
        {
            var entityData = _dbContext.AllergyVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AllergyVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAllergyVector(Guid id, JsonPatchDocument<AllergyVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AllergyVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AllergyVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}