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
    /// The smslogService responsible for managing smslog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting smslog information.
    /// </remarks>
    public interface ISmsLogService
    {
        /// <summary>Retrieves a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <returns>The smslog data</returns>
        SmsLog GetById(Guid id);

        /// <summary>Retrieves a list of smslogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of smslogs</returns>
        List<SmsLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new smslog</summary>
        /// <param name="model">The smslog data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SmsLog model);

        /// <summary>Updates a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <param name="updatedEntity">The smslog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SmsLog updatedEntity);

        /// <summary>Updates a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <param name="updatedEntity">The smslog data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SmsLog> updatedEntity);

        /// <summary>Deletes a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The smslogService responsible for managing smslog related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting smslog information.
    /// </remarks>
    public class SmsLogService : ISmsLogService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SmsLog class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SmsLogService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <returns>The smslog data</returns>
        public SmsLog GetById(Guid id)
        {
            var entityData = _dbContext.SmsLog.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of smslogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of smslogs</returns>/// <exception cref="Exception"></exception>
        public List<SmsLog> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSmsLog(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new smslog</summary>
        /// <param name="model">The smslog data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SmsLog model)
        {
            model.Id = CreateSmsLog(model);
            return model.Id;
        }

        /// <summary>Updates a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <param name="updatedEntity">The smslog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SmsLog updatedEntity)
        {
            UpdateSmsLog(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <param name="updatedEntity">The smslog data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SmsLog> updatedEntity)
        {
            PatchSmsLog(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific smslog by its primary key</summary>
        /// <param name="id">The primary key of the smslog</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSmsLog(id);
            return true;
        }
        #region
        private List<SmsLog> GetSmsLog(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SmsLog.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SmsLog>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SmsLog), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SmsLog, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSmsLog(SmsLog model)
        {
            _dbContext.SmsLog.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSmsLog(Guid id, SmsLog updatedEntity)
        {
            _dbContext.SmsLog.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSmsLog(Guid id)
        {
            var entityData = _dbContext.SmsLog.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SmsLog.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSmsLog(Guid id, JsonPatchDocument<SmsLog> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SmsLog.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SmsLog.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}