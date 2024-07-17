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
    /// The comorbidityvectorService responsible for managing comorbidityvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting comorbidityvector information.
    /// </remarks>
    public interface IComorbidityVectorService
    {
        /// <summary>Retrieves a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <returns>The comorbidityvector data</returns>
        ComorbidityVector GetById(Guid id);

        /// <summary>Retrieves a list of comorbidityvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of comorbidityvectors</returns>
        List<ComorbidityVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new comorbidityvector</summary>
        /// <param name="model">The comorbidityvector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ComorbidityVector model);

        /// <summary>Updates a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <param name="updatedEntity">The comorbidityvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ComorbidityVector updatedEntity);

        /// <summary>Updates a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <param name="updatedEntity">The comorbidityvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ComorbidityVector> updatedEntity);

        /// <summary>Deletes a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The comorbidityvectorService responsible for managing comorbidityvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting comorbidityvector information.
    /// </remarks>
    public class ComorbidityVectorService : IComorbidityVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ComorbidityVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ComorbidityVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <returns>The comorbidityvector data</returns>
        public ComorbidityVector GetById(Guid id)
        {
            var entityData = _dbContext.ComorbidityVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of comorbidityvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of comorbidityvectors</returns>/// <exception cref="Exception"></exception>
        public List<ComorbidityVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetComorbidityVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new comorbidityvector</summary>
        /// <param name="model">The comorbidityvector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ComorbidityVector model)
        {
            model.Id = CreateComorbidityVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <param name="updatedEntity">The comorbidityvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ComorbidityVector updatedEntity)
        {
            UpdateComorbidityVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <param name="updatedEntity">The comorbidityvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ComorbidityVector> updatedEntity)
        {
            PatchComorbidityVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific comorbidityvector by its primary key</summary>
        /// <param name="id">The primary key of the comorbidityvector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteComorbidityVector(id);
            return true;
        }
        #region
        private List<ComorbidityVector> GetComorbidityVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ComorbidityVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ComorbidityVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ComorbidityVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ComorbidityVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateComorbidityVector(ComorbidityVector model)
        {
            _dbContext.ComorbidityVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateComorbidityVector(Guid id, ComorbidityVector updatedEntity)
        {
            _dbContext.ComorbidityVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteComorbidityVector(Guid id)
        {
            var entityData = _dbContext.ComorbidityVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ComorbidityVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchComorbidityVector(Guid id, JsonPatchDocument<ComorbidityVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ComorbidityVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ComorbidityVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}