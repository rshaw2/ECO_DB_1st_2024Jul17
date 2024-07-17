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
    /// The generalexamtemplateparameterService responsible for managing generalexamtemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting generalexamtemplateparameter information.
    /// </remarks>
    public interface IGeneralExamTemplateParameterService
    {
        /// <summary>Retrieves a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <returns>The generalexamtemplateparameter data</returns>
        GeneralExamTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of generalexamtemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of generalexamtemplateparameters</returns>
        List<GeneralExamTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new generalexamtemplateparameter</summary>
        /// <param name="model">The generalexamtemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GeneralExamTemplateParameter model);

        /// <summary>Updates a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <param name="updatedEntity">The generalexamtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GeneralExamTemplateParameter updatedEntity);

        /// <summary>Updates a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <param name="updatedEntity">The generalexamtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GeneralExamTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The generalexamtemplateparameterService responsible for managing generalexamtemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting generalexamtemplateparameter information.
    /// </remarks>
    public class GeneralExamTemplateParameterService : IGeneralExamTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GeneralExamTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GeneralExamTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <returns>The generalexamtemplateparameter data</returns>
        public GeneralExamTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.GeneralExamTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of generalexamtemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of generalexamtemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<GeneralExamTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGeneralExamTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new generalexamtemplateparameter</summary>
        /// <param name="model">The generalexamtemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GeneralExamTemplateParameter model)
        {
            model.Id = CreateGeneralExamTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <param name="updatedEntity">The generalexamtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GeneralExamTemplateParameter updatedEntity)
        {
            UpdateGeneralExamTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <param name="updatedEntity">The generalexamtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GeneralExamTemplateParameter> updatedEntity)
        {
            PatchGeneralExamTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific generalexamtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the generalexamtemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGeneralExamTemplateParameter(id);
            return true;
        }
        #region
        private List<GeneralExamTemplateParameter> GetGeneralExamTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GeneralExamTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GeneralExamTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GeneralExamTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GeneralExamTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGeneralExamTemplateParameter(GeneralExamTemplateParameter model)
        {
            _dbContext.GeneralExamTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGeneralExamTemplateParameter(Guid id, GeneralExamTemplateParameter updatedEntity)
        {
            _dbContext.GeneralExamTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGeneralExamTemplateParameter(Guid id)
        {
            var entityData = _dbContext.GeneralExamTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GeneralExamTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGeneralExamTemplateParameter(Guid id, JsonPatchDocument<GeneralExamTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GeneralExamTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GeneralExamTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}