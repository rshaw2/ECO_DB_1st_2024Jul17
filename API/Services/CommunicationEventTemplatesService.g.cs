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
    /// The communicationeventtemplatesService responsible for managing communicationeventtemplates related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationeventtemplates information.
    /// </remarks>
    public interface ICommunicationEventTemplatesService
    {
        /// <summary>Retrieves a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <returns>The communicationeventtemplates data</returns>
        CommunicationEventTemplates GetById(Guid id);

        /// <summary>Retrieves a list of communicationeventtemplatess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationeventtemplatess</returns>
        List<CommunicationEventTemplates> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationeventtemplates</summary>
        /// <param name="model">The communicationeventtemplates data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationEventTemplates model);

        /// <summary>Updates a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <param name="updatedEntity">The communicationeventtemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationEventTemplates updatedEntity);

        /// <summary>Updates a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <param name="updatedEntity">The communicationeventtemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationEventTemplates> updatedEntity);

        /// <summary>Deletes a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationeventtemplatesService responsible for managing communicationeventtemplates related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationeventtemplates information.
    /// </remarks>
    public class CommunicationEventTemplatesService : ICommunicationEventTemplatesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationEventTemplates class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationEventTemplatesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <returns>The communicationeventtemplates data</returns>
        public CommunicationEventTemplates GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationEventTemplates.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationeventtemplatess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationeventtemplatess</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationEventTemplates> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationEventTemplates(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationeventtemplates</summary>
        /// <param name="model">The communicationeventtemplates data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationEventTemplates model)
        {
            model.Id = CreateCommunicationEventTemplates(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <param name="updatedEntity">The communicationeventtemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationEventTemplates updatedEntity)
        {
            UpdateCommunicationEventTemplates(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <param name="updatedEntity">The communicationeventtemplates data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationEventTemplates> updatedEntity)
        {
            PatchCommunicationEventTemplates(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationeventtemplates by its primary key</summary>
        /// <param name="id">The primary key of the communicationeventtemplates</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationEventTemplates(id);
            return true;
        }
        #region
        private List<CommunicationEventTemplates> GetCommunicationEventTemplates(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationEventTemplates.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationEventTemplates>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationEventTemplates), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationEventTemplates, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationEventTemplates(CommunicationEventTemplates model)
        {
            _dbContext.CommunicationEventTemplates.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationEventTemplates(Guid id, CommunicationEventTemplates updatedEntity)
        {
            _dbContext.CommunicationEventTemplates.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationEventTemplates(Guid id)
        {
            var entityData = _dbContext.CommunicationEventTemplates.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationEventTemplates.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationEventTemplates(Guid id, JsonPatchDocument<CommunicationEventTemplates> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationEventTemplates.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationEventTemplates.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}