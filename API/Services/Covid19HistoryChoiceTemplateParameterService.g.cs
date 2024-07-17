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
    /// The covid19historychoicetemplateparameterService responsible for managing covid19historychoicetemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covid19historychoicetemplateparameter information.
    /// </remarks>
    public interface ICovid19HistoryChoiceTemplateParameterService
    {
        /// <summary>Retrieves a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <returns>The covid19historychoicetemplateparameter data</returns>
        Covid19HistoryChoiceTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of covid19historychoicetemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covid19historychoicetemplateparameters</returns>
        List<Covid19HistoryChoiceTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covid19historychoicetemplateparameter</summary>
        /// <param name="model">The covid19historychoicetemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Covid19HistoryChoiceTemplateParameter model);

        /// <summary>Updates a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <param name="updatedEntity">The covid19historychoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Covid19HistoryChoiceTemplateParameter updatedEntity);

        /// <summary>Updates a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <param name="updatedEntity">The covid19historychoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Covid19HistoryChoiceTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covid19historychoicetemplateparameterService responsible for managing covid19historychoicetemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covid19historychoicetemplateparameter information.
    /// </remarks>
    public class Covid19HistoryChoiceTemplateParameterService : ICovid19HistoryChoiceTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Covid19HistoryChoiceTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public Covid19HistoryChoiceTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <returns>The covid19historychoicetemplateparameter data</returns>
        public Covid19HistoryChoiceTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.Covid19HistoryChoiceTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covid19historychoicetemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covid19historychoicetemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<Covid19HistoryChoiceTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCovid19HistoryChoiceTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covid19historychoicetemplateparameter</summary>
        /// <param name="model">The covid19historychoicetemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Covid19HistoryChoiceTemplateParameter model)
        {
            model.Id = CreateCovid19HistoryChoiceTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <param name="updatedEntity">The covid19historychoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Covid19HistoryChoiceTemplateParameter updatedEntity)
        {
            UpdateCovid19HistoryChoiceTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <param name="updatedEntity">The covid19historychoicetemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Covid19HistoryChoiceTemplateParameter> updatedEntity)
        {
            PatchCovid19HistoryChoiceTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covid19historychoicetemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoicetemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCovid19HistoryChoiceTemplateParameter(id);
            return true;
        }
        #region
        private List<Covid19HistoryChoiceTemplateParameter> GetCovid19HistoryChoiceTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Covid19HistoryChoiceTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Covid19HistoryChoiceTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Covid19HistoryChoiceTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Covid19HistoryChoiceTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCovid19HistoryChoiceTemplateParameter(Covid19HistoryChoiceTemplateParameter model)
        {
            _dbContext.Covid19HistoryChoiceTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCovid19HistoryChoiceTemplateParameter(Guid id, Covid19HistoryChoiceTemplateParameter updatedEntity)
        {
            _dbContext.Covid19HistoryChoiceTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCovid19HistoryChoiceTemplateParameter(Guid id)
        {
            var entityData = _dbContext.Covid19HistoryChoiceTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Covid19HistoryChoiceTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCovid19HistoryChoiceTemplateParameter(Guid id, JsonPatchDocument<Covid19HistoryChoiceTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Covid19HistoryChoiceTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Covid19HistoryChoiceTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}