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
    /// The smsService responsible for managing sms related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting sms information.
    /// </remarks>
    public interface ISMSService
    {
        /// <summary>Retrieves a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <returns>The sms data</returns>
        SMS GetById(Guid id);

        /// <summary>Retrieves a list of smss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of smss</returns>
        List<SMS> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new sms</summary>
        /// <param name="model">The sms data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SMS model);

        /// <summary>Updates a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <param name="updatedEntity">The sms data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SMS updatedEntity);

        /// <summary>Updates a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <param name="updatedEntity">The sms data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SMS> updatedEntity);

        /// <summary>Deletes a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The smsService responsible for managing sms related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting sms information.
    /// </remarks>
    public class SMSService : ISMSService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SMS class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SMSService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <returns>The sms data</returns>
        public SMS GetById(Guid id)
        {
            var entityData = _dbContext.SMS.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of smss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of smss</returns>/// <exception cref="Exception"></exception>
        public List<SMS> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSMS(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new sms</summary>
        /// <param name="model">The sms data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SMS model)
        {
            model.Id = CreateSMS(model);
            return model.Id;
        }

        /// <summary>Updates a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <param name="updatedEntity">The sms data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SMS updatedEntity)
        {
            UpdateSMS(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <param name="updatedEntity">The sms data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SMS> updatedEntity)
        {
            PatchSMS(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific sms by its primary key</summary>
        /// <param name="id">The primary key of the sms</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSMS(id);
            return true;
        }
        #region
        private List<SMS> GetSMS(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SMS.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SMS>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SMS), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SMS, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSMS(SMS model)
        {
            _dbContext.SMS.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSMS(Guid id, SMS updatedEntity)
        {
            _dbContext.SMS.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSMS(Guid id)
        {
            var entityData = _dbContext.SMS.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SMS.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSMS(Guid id, JsonPatchDocument<SMS> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SMS.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SMS.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}