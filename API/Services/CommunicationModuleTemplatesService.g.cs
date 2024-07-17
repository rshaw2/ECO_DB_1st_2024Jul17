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
    /// The communicationmoduletemplatesService responsible for managing communicationmoduletemplates related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmoduletemplates information.
    /// </remarks>
    public interface ICommunicationModuleTemplatesService
    {
        /// <summary>Retrieves a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <returns>The communicationmoduletemplates data</returns>
        CommunicationModuleTemplates GetById(Guid id);

        /// <summary>Retrieves a list of communicationmoduletemplatess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmoduletemplatess</returns>
        List<CommunicationModuleTemplates> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationmoduletemplates</summary>
        /// <param name="model">The communicationmoduletemplates data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationModuleTemplates model);

        /// <summary>Updates a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <param name="updatedEntity">The communicationmoduletemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationModuleTemplates updatedEntity);

        /// <summary>Updates a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <param name="updatedEntity">The communicationmoduletemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationModuleTemplates> updatedEntity);

        /// <summary>Deletes a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationmoduletemplatesService responsible for managing communicationmoduletemplates related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmoduletemplates information.
    /// </remarks>
    public class CommunicationModuleTemplatesService : ICommunicationModuleTemplatesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationModuleTemplates class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationModuleTemplatesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <returns>The communicationmoduletemplates data</returns>
        public CommunicationModuleTemplates GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationModuleTemplates.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationmoduletemplatess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmoduletemplatess</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationModuleTemplates> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationModuleTemplates(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationmoduletemplates</summary>
        /// <param name="model">The communicationmoduletemplates data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationModuleTemplates model)
        {
            model.Id = CreateCommunicationModuleTemplates(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <param name="updatedEntity">The communicationmoduletemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationModuleTemplates updatedEntity)
        {
            UpdateCommunicationModuleTemplates(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <param name="updatedEntity">The communicationmoduletemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationModuleTemplates> updatedEntity)
        {
            PatchCommunicationModuleTemplates(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationmoduletemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationmoduletemplates</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationModuleTemplates(id);
            return true;
        }
        #region
        private List<CommunicationModuleTemplates> GetCommunicationModuleTemplates(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationModuleTemplates.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationModuleTemplates>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationModuleTemplates), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationModuleTemplates, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationModuleTemplates(CommunicationModuleTemplates model)
        {
            _dbContext.CommunicationModuleTemplates.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationModuleTemplates(Guid id, CommunicationModuleTemplates updatedEntity)
        {
            _dbContext.CommunicationModuleTemplates.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationModuleTemplates(Guid id)
        {
            var entityData = _dbContext.CommunicationModuleTemplates.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationModuleTemplates.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationModuleTemplates(Guid id, JsonPatchDocument<CommunicationModuleTemplates> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationModuleTemplates.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationModuleTemplates.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}