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
    /// The investigationtemplateparameterService responsible for managing investigationtemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationtemplateparameter information.
    /// </remarks>
    public interface IInvestigationTemplateParameterService
    {
        /// <summary>Retrieves a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <returns>The investigationtemplateparameter data</returns>
        InvestigationTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of investigationtemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationtemplateparameters</returns>
        List<InvestigationTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationtemplateparameter</summary>
        /// <param name="model">The investigationtemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationTemplateParameter model);

        /// <summary>Updates a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <param name="updatedEntity">The investigationtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationTemplateParameter updatedEntity);

        /// <summary>Updates a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <param name="updatedEntity">The investigationtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationtemplateparameterService responsible for managing investigationtemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationtemplateparameter information.
    /// </remarks>
    public class InvestigationTemplateParameterService : IInvestigationTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <returns>The investigationtemplateparameter data</returns>
        public InvestigationTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationtemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationtemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationtemplateparameter</summary>
        /// <param name="model">The investigationtemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationTemplateParameter model)
        {
            model.Id = CreateInvestigationTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <param name="updatedEntity">The investigationtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationTemplateParameter updatedEntity)
        {
            UpdateInvestigationTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <param name="updatedEntity">The investigationtemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationTemplateParameter> updatedEntity)
        {
            PatchInvestigationTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationtemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the investigationtemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationTemplateParameter(id);
            return true;
        }
        #region
        private List<InvestigationTemplateParameter> GetInvestigationTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationTemplateParameter(InvestigationTemplateParameter model)
        {
            _dbContext.InvestigationTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationTemplateParameter(Guid id, InvestigationTemplateParameter updatedEntity)
        {
            _dbContext.InvestigationTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationTemplateParameter(Guid id)
        {
            var entityData = _dbContext.InvestigationTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationTemplateParameter(Guid id, JsonPatchDocument<InvestigationTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}