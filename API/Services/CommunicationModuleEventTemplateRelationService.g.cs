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
    /// The communicationmoduleeventtemplaterelationService responsible for managing communicationmoduleeventtemplaterelation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmoduleeventtemplaterelation information.
    /// </remarks>
    public interface ICommunicationModuleEventTemplateRelationService
    {
        /// <summary>Retrieves a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <returns>The communicationmoduleeventtemplaterelation data</returns>
        CommunicationModuleEventTemplateRelation GetById(Guid id);

        /// <summary>Retrieves a list of communicationmoduleeventtemplaterelations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmoduleeventtemplaterelations</returns>
        List<CommunicationModuleEventTemplateRelation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationmoduleeventtemplaterelation</summary>
        /// <param name="model">The communicationmoduleeventtemplaterelation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationModuleEventTemplateRelation model);

        /// <summary>Updates a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventtemplaterelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationModuleEventTemplateRelation updatedEntity);

        /// <summary>Updates a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventtemplaterelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationModuleEventTemplateRelation> updatedEntity);

        /// <summary>Deletes a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationmoduleeventtemplaterelationService responsible for managing communicationmoduleeventtemplaterelation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmoduleeventtemplaterelation information.
    /// </remarks>
    public class CommunicationModuleEventTemplateRelationService : ICommunicationModuleEventTemplateRelationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationModuleEventTemplateRelation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationModuleEventTemplateRelationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <returns>The communicationmoduleeventtemplaterelation data</returns>
        public CommunicationModuleEventTemplateRelation GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationModuleEventTemplateRelation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationmoduleeventtemplaterelations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmoduleeventtemplaterelations</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationModuleEventTemplateRelation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationModuleEventTemplateRelation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationmoduleeventtemplaterelation</summary>
        /// <param name="model">The communicationmoduleeventtemplaterelation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationModuleEventTemplateRelation model)
        {
            model.Id = CreateCommunicationModuleEventTemplateRelation(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventtemplaterelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationModuleEventTemplateRelation updatedEntity)
        {
            UpdateCommunicationModuleEventTemplateRelation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventtemplaterelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationModuleEventTemplateRelation> updatedEntity)
        {
            PatchCommunicationModuleEventTemplateRelation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationmoduleeventtemplaterelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventtemplaterelation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationModuleEventTemplateRelation(id);
            return true;
        }
        #region
        private List<CommunicationModuleEventTemplateRelation> GetCommunicationModuleEventTemplateRelation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationModuleEventTemplateRelation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationModuleEventTemplateRelation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationModuleEventTemplateRelation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationModuleEventTemplateRelation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationModuleEventTemplateRelation(CommunicationModuleEventTemplateRelation model)
        {
            _dbContext.CommunicationModuleEventTemplateRelation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationModuleEventTemplateRelation(Guid id, CommunicationModuleEventTemplateRelation updatedEntity)
        {
            _dbContext.CommunicationModuleEventTemplateRelation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationModuleEventTemplateRelation(Guid id)
        {
            var entityData = _dbContext.CommunicationModuleEventTemplateRelation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationModuleEventTemplateRelation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationModuleEventTemplateRelation(Guid id, JsonPatchDocument<CommunicationModuleEventTemplateRelation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationModuleEventTemplateRelation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationModuleEventTemplateRelation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}