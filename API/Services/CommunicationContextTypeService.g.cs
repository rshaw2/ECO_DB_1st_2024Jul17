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
    /// The communicationcontexttypeService responsible for managing communicationcontexttype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationcontexttype information.
    /// </remarks>
    public interface ICommunicationContextTypeService
    {
        /// <summary>Retrieves a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <returns>The communicationcontexttype data</returns>
        CommunicationContextType GetById(Guid id);

        /// <summary>Retrieves a list of communicationcontexttypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationcontexttypes</returns>
        List<CommunicationContextType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationcontexttype</summary>
        /// <param name="model">The communicationcontexttype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationContextType model);

        /// <summary>Updates a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <param name="updatedEntity">The communicationcontexttype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationContextType updatedEntity);

        /// <summary>Updates a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <param name="updatedEntity">The communicationcontexttype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationContextType> updatedEntity);

        /// <summary>Deletes a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationcontexttypeService responsible for managing communicationcontexttype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationcontexttype information.
    /// </remarks>
    public class CommunicationContextTypeService : ICommunicationContextTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationContextType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationContextTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <returns>The communicationcontexttype data</returns>
        public CommunicationContextType GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationContextType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationcontexttypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationcontexttypes</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationContextType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationContextType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationcontexttype</summary>
        /// <param name="model">The communicationcontexttype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationContextType model)
        {
            model.Id = CreateCommunicationContextType(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <param name="updatedEntity">The communicationcontexttype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationContextType updatedEntity)
        {
            UpdateCommunicationContextType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <param name="updatedEntity">The communicationcontexttype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationContextType> updatedEntity)
        {
            PatchCommunicationContextType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationcontexttype by its primary key</summary>
        /// <param name="id">The primary key of the communicationcontexttype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationContextType(id);
            return true;
        }
        #region
        private List<CommunicationContextType> GetCommunicationContextType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationContextType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationContextType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationContextType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationContextType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationContextType(CommunicationContextType model)
        {
            _dbContext.CommunicationContextType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationContextType(Guid id, CommunicationContextType updatedEntity)
        {
            _dbContext.CommunicationContextType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationContextType(Guid id)
        {
            var entityData = _dbContext.CommunicationContextType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationContextType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationContextType(Guid id, JsonPatchDocument<CommunicationContextType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationContextType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationContextType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}