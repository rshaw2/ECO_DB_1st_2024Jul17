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
    /// The visitcovid19historyparameterService responsible for managing visitcovid19historyparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitcovid19historyparameter information.
    /// </remarks>
    public interface IVisitCovid19HistoryParameterService
    {
        /// <summary>Retrieves a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <returns>The visitcovid19historyparameter data</returns>
        VisitCovid19HistoryParameter GetById(Guid id);

        /// <summary>Retrieves a list of visitcovid19historyparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitcovid19historyparameters</returns>
        List<VisitCovid19HistoryParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitcovid19historyparameter</summary>
        /// <param name="model">The visitcovid19historyparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitCovid19HistoryParameter model);

        /// <summary>Updates a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <param name="updatedEntity">The visitcovid19historyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitCovid19HistoryParameter updatedEntity);

        /// <summary>Updates a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <param name="updatedEntity">The visitcovid19historyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitCovid19HistoryParameter> updatedEntity);

        /// <summary>Deletes a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitcovid19historyparameterService responsible for managing visitcovid19historyparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitcovid19historyparameter information.
    /// </remarks>
    public class VisitCovid19HistoryParameterService : IVisitCovid19HistoryParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitCovid19HistoryParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitCovid19HistoryParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <returns>The visitcovid19historyparameter data</returns>
        public VisitCovid19HistoryParameter GetById(Guid id)
        {
            var entityData = _dbContext.VisitCovid19HistoryParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitcovid19historyparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitcovid19historyparameters</returns>/// <exception cref="Exception"></exception>
        public List<VisitCovid19HistoryParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitCovid19HistoryParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitcovid19historyparameter</summary>
        /// <param name="model">The visitcovid19historyparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitCovid19HistoryParameter model)
        {
            model.Id = CreateVisitCovid19HistoryParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <param name="updatedEntity">The visitcovid19historyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitCovid19HistoryParameter updatedEntity)
        {
            UpdateVisitCovid19HistoryParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <param name="updatedEntity">The visitcovid19historyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitCovid19HistoryParameter> updatedEntity)
        {
            PatchVisitCovid19HistoryParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitcovid19historyparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19historyparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitCovid19HistoryParameter(id);
            return true;
        }
        #region
        private List<VisitCovid19HistoryParameter> GetVisitCovid19HistoryParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitCovid19HistoryParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitCovid19HistoryParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitCovid19HistoryParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitCovid19HistoryParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitCovid19HistoryParameter(VisitCovid19HistoryParameter model)
        {
            _dbContext.VisitCovid19HistoryParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitCovid19HistoryParameter(Guid id, VisitCovid19HistoryParameter updatedEntity)
        {
            _dbContext.VisitCovid19HistoryParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitCovid19HistoryParameter(Guid id)
        {
            var entityData = _dbContext.VisitCovid19HistoryParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitCovid19HistoryParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitCovid19HistoryParameter(Guid id, JsonPatchDocument<VisitCovid19HistoryParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitCovid19HistoryParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitCovid19HistoryParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}