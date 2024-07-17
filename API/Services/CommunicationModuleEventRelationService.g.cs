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
    /// The communicationmoduleeventrelationService responsible for managing communicationmoduleeventrelation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmoduleeventrelation information.
    /// </remarks>
    public interface ICommunicationModuleEventRelationService
    {
        /// <summary>Retrieves a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <returns>The communicationmoduleeventrelation data</returns>
        CommunicationModuleEventRelation GetById(Guid id);

        /// <summary>Retrieves a list of communicationmoduleeventrelations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmoduleeventrelations</returns>
        List<CommunicationModuleEventRelation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationmoduleeventrelation</summary>
        /// <param name="model">The communicationmoduleeventrelation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationModuleEventRelation model);

        /// <summary>Updates a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventrelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationModuleEventRelation updatedEntity);

        /// <summary>Updates a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventrelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationModuleEventRelation> updatedEntity);

        /// <summary>Deletes a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationmoduleeventrelationService responsible for managing communicationmoduleeventrelation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmoduleeventrelation information.
    /// </remarks>
    public class CommunicationModuleEventRelationService : ICommunicationModuleEventRelationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationModuleEventRelation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationModuleEventRelationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <returns>The communicationmoduleeventrelation data</returns>
        public CommunicationModuleEventRelation GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationModuleEventRelation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationmoduleeventrelations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmoduleeventrelations</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationModuleEventRelation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationModuleEventRelation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationmoduleeventrelation</summary>
        /// <param name="model">The communicationmoduleeventrelation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationModuleEventRelation model)
        {
            model.Id = CreateCommunicationModuleEventRelation(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventrelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationModuleEventRelation updatedEntity)
        {
            UpdateCommunicationModuleEventRelation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <param name="updatedEntity">The communicationmoduleeventrelation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationModuleEventRelation> updatedEntity)
        {
            PatchCommunicationModuleEventRelation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationmoduleeventrelation by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduleeventrelation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationModuleEventRelation(id);
            return true;
        }
        #region
        private List<CommunicationModuleEventRelation> GetCommunicationModuleEventRelation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationModuleEventRelation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationModuleEventRelation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationModuleEventRelation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationModuleEventRelation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationModuleEventRelation(CommunicationModuleEventRelation model)
        {
            _dbContext.CommunicationModuleEventRelation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationModuleEventRelation(Guid id, CommunicationModuleEventRelation updatedEntity)
        {
            _dbContext.CommunicationModuleEventRelation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationModuleEventRelation(Guid id)
        {
            var entityData = _dbContext.CommunicationModuleEventRelation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationModuleEventRelation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationModuleEventRelation(Guid id, JsonPatchDocument<CommunicationModuleEventRelation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationModuleEventRelation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationModuleEventRelation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}