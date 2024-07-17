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
    /// The communicationmeterService responsible for managing communicationmeter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmeter information.
    /// </remarks>
    public interface ICommunicationMeterService
    {
        /// <summary>Retrieves a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <returns>The communicationmeter data</returns>
        CommunicationMeter GetById(Guid id);

        /// <summary>Retrieves a list of communicationmeters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmeters</returns>
        List<CommunicationMeter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new communicationmeter</summary>
        /// <param name="model">The communicationmeter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(CommunicationMeter model);

        /// <summary>Updates a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <param name="updatedEntity">The communicationmeter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, CommunicationMeter updatedEntity);

        /// <summary>Updates a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <param name="updatedEntity">The communicationmeter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<CommunicationMeter> updatedEntity);

        /// <summary>Deletes a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The communicationmeterService responsible for managing communicationmeter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting communicationmeter information.
    /// </remarks>
    public class CommunicationMeterService : ICommunicationMeterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the CommunicationMeter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public CommunicationMeterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <returns>The communicationmeter data</returns>
        public CommunicationMeter GetById(Guid id)
        {
            var entityData = _dbContext.CommunicationMeter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of communicationmeters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of communicationmeters</returns>/// <exception cref="Exception"></exception>
        public List<CommunicationMeter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCommunicationMeter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new communicationmeter</summary>
        /// <param name="model">The communicationmeter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(CommunicationMeter model)
        {
            model.Id = CreateCommunicationMeter(model);
            return model.Id;
        }

        /// <summary>Updates a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <param name="updatedEntity">The communicationmeter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, CommunicationMeter updatedEntity)
        {
            UpdateCommunicationMeter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <param name="updatedEntity">The communicationmeter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<CommunicationMeter> updatedEntity)
        {
            PatchCommunicationMeter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific communicationmeter by its primary key</summary>
        /// <param name="id">The primary key of the communicationmeter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCommunicationMeter(id);
            return true;
        }
        #region
        private List<CommunicationMeter> GetCommunicationMeter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CommunicationMeter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CommunicationMeter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CommunicationMeter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CommunicationMeter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCommunicationMeter(CommunicationMeter model)
        {
            _dbContext.CommunicationMeter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCommunicationMeter(Guid id, CommunicationMeter updatedEntity)
        {
            _dbContext.CommunicationMeter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCommunicationMeter(Guid id)
        {
            var entityData = _dbContext.CommunicationMeter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CommunicationMeter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCommunicationMeter(Guid id, JsonPatchDocument<CommunicationMeter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CommunicationMeter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CommunicationMeter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}