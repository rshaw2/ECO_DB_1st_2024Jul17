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
    /// The communicationfieldsService responsible for managing communicationfields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationfields information.
    /// </remarks>
    public interface ICommunicationFieldsService
    {
        /// <summary>Retrieves a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <returns>The communicationfields data</returns>
        CommunicationFields GetById(Guid id);

        /// <summary>Retrieves a list of communicationfieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationfieldss</returns>
        List<CommunicationFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationfields</summary>
        /// <param name="model">The communicationfields data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationFields model);

        /// <summary>Updates a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <param name="updatedEntity">The communicationfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationFields updatedEntity);

        /// <summary>Updates a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <param name="updatedEntity">The communicationfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationFields> updatedEntity);

        /// <summary>Deletes a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationfieldsService responsible for managing communicationfields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationfields information.
    /// </remarks>
    public class CommunicationFieldsService : ICommunicationFieldsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationFields class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationFieldsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <returns>The communicationfields data</returns>
        public CommunicationFields GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationFields.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationfieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationfieldss</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationFields(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationfields</summary>
        /// <param name="model">The communicationfields data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationFields model)
        {
            model.Id = CreateCommunicationFields(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <param name="updatedEntity">The communicationfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationFields updatedEntity)
        {
            UpdateCommunicationFields(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <param name="updatedEntity">The communicationfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationFields> updatedEntity)
        {
            PatchCommunicationFields(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationfields by its primary key</summary>
        /// <param name="id">The primary key of the communicationfields</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationFields(id);
            return true;
        }
        #region
        private List<CommunicationFields> GetCommunicationFields(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationFields.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationFields>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationFields), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationFields, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationFields(CommunicationFields model)
        {
            _dbContext.CommunicationFields.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationFields(Guid id, CommunicationFields updatedEntity)
        {
            _dbContext.CommunicationFields.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationFields(Guid id)
        {
            var entityData = _dbContext.CommunicationFields.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationFields.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationFields(Guid id, JsonPatchDocument<CommunicationFields> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationFields.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationFields.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}