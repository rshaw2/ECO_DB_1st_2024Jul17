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
    /// The communicationtemplatevariableService responsible for managing communicationtemplatevariable related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationtemplatevariable information.
    /// </remarks>
    public interface ICommunicationTemplateVariableService
    {
        /// <summary>Retrieves a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <returns>The communicationtemplatevariable data</returns>
        CommunicationTemplateVariable GetById(Guid id);

        /// <summary>Retrieves a list of communicationtemplatevariables based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationtemplatevariables</returns>
        List<CommunicationTemplateVariable> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationtemplatevariable</summary>
        /// <param name="model">The communicationtemplatevariable data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationTemplateVariable model);

        /// <summary>Updates a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <param name="updatedEntity">The communicationtemplatevariable data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationTemplateVariable updatedEntity);

        /// <summary>Updates a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <param name="updatedEntity">The communicationtemplatevariable data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationTemplateVariable> updatedEntity);

        /// <summary>Deletes a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationtemplatevariableService responsible for managing communicationtemplatevariable related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationtemplatevariable information.
    /// </remarks>
    public class CommunicationTemplateVariableService : ICommunicationTemplateVariableService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationTemplateVariable class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationTemplateVariableService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <returns>The communicationtemplatevariable data</returns>
        public CommunicationTemplateVariable GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationTemplateVariable.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationtemplatevariables based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationtemplatevariables</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationTemplateVariable> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationTemplateVariable(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationtemplatevariable</summary>
        /// <param name="model">The communicationtemplatevariable data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationTemplateVariable model)
        {
            model.Id = CreateCommunicationTemplateVariable(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <param name="updatedEntity">The communicationtemplatevariable data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationTemplateVariable updatedEntity)
        {
            UpdateCommunicationTemplateVariable(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <param name="updatedEntity">The communicationtemplatevariable data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationTemplateVariable> updatedEntity)
        {
            PatchCommunicationTemplateVariable(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationtemplatevariable by its primary key</summary>
        /// <param name="id">The primary key of the communicationtemplatevariable</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationTemplateVariable(id);
            return true;
        }
        #region
        private List<CommunicationTemplateVariable> GetCommunicationTemplateVariable(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationTemplateVariable.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationTemplateVariable>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationTemplateVariable), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationTemplateVariable, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationTemplateVariable(CommunicationTemplateVariable model)
        {
            _dbContext.CommunicationTemplateVariable.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationTemplateVariable(Guid id, CommunicationTemplateVariable updatedEntity)
        {
            _dbContext.CommunicationTemplateVariable.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationTemplateVariable(Guid id)
        {
            var entityData = _dbContext.CommunicationTemplateVariable.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationTemplateVariable.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationTemplateVariable(Guid id, JsonPatchDocument<CommunicationTemplateVariable> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationTemplateVariable.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationTemplateVariable.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}