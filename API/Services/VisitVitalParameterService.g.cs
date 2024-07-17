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
    /// The visitvitalparameterService responsible for managing visitvitalparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitvitalparameter information.
    /// </remarks>
    public interface IVisitVitalParameterService
    {
        /// <summary>Retrieves a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <returns>The visitvitalparameter data</returns>
        VisitVitalParameter GetById(Guid id);

        /// <summary>Retrieves a list of visitvitalparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitvitalparameters</returns>
        List<VisitVitalParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitvitalparameter</summary>
        /// <param name="model">The visitvitalparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitVitalParameter model);

        /// <summary>Updates a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <param name="updatedEntity">The visitvitalparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitVitalParameter updatedEntity);

        /// <summary>Updates a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <param name="updatedEntity">The visitvitalparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitVitalParameter> updatedEntity);

        /// <summary>Deletes a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitvitalparameterService responsible for managing visitvitalparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitvitalparameter information.
    /// </remarks>
    public class VisitVitalParameterService : IVisitVitalParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitVitalParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitVitalParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <returns>The visitvitalparameter data</returns>
        public VisitVitalParameter GetById(Guid id)
        {
            var entityData = _dbContext.VisitVitalParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitvitalparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitvitalparameters</returns>/// <exception cref="Exception"></exception>
        public List<VisitVitalParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitVitalParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitvitalparameter</summary>
        /// <param name="model">The visitvitalparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitVitalParameter model)
        {
            model.Id = CreateVisitVitalParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <param name="updatedEntity">The visitvitalparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitVitalParameter updatedEntity)
        {
            UpdateVisitVitalParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <param name="updatedEntity">The visitvitalparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitVitalParameter> updatedEntity)
        {
            PatchVisitVitalParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitvitalparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitvitalparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitVitalParameter(id);
            return true;
        }
        #region
        private List<VisitVitalParameter> GetVisitVitalParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitVitalParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitVitalParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitVitalParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitVitalParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitVitalParameter(VisitVitalParameter model)
        {
            _dbContext.VisitVitalParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitVitalParameter(Guid id, VisitVitalParameter updatedEntity)
        {
            _dbContext.VisitVitalParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitVitalParameter(Guid id)
        {
            var entityData = _dbContext.VisitVitalParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitVitalParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitVitalParameter(Guid id, JsonPatchDocument<VisitVitalParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitVitalParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitVitalParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}