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
    /// The emailstatusService responsible for managing emailstatus related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emailstatus information.
    /// </remarks>
    public interface IEmailStatusService
    {
        /// <summary>Retrieves a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <returns>The emailstatus data</returns>
        EmailStatus GetById(Guid id);

        /// <summary>Retrieves a list of emailstatuss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emailstatuss</returns>
        List<EmailStatus> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new emailstatus</summary>
        /// <param name="model">The emailstatus data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EmailStatus model);

        /// <summary>Updates a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <param name="updatedEntity">The emailstatus data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EmailStatus updatedEntity);

        /// <summary>Updates a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <param name="updatedEntity">The emailstatus data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EmailStatus> updatedEntity);

        /// <summary>Deletes a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The emailstatusService responsible for managing emailstatus related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting emailstatus information.
    /// </remarks>
    public class EmailStatusService : IEmailStatusService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EmailStatus class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EmailStatusService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <returns>The emailstatus data</returns>
        public EmailStatus GetById(Guid id)
        {
            var entityData = _dbContext.EmailStatus.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of emailstatuss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of emailstatuss</returns>/// <exception cref="Exception"></exception>
        public List<EmailStatus> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEmailStatus(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new emailstatus</summary>
        /// <param name="model">The emailstatus data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EmailStatus model)
        {
            model.Id = CreateEmailStatus(model);
            return model.Id;
        }

        /// <summary>Updates a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <param name="updatedEntity">The emailstatus data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EmailStatus updatedEntity)
        {
            UpdateEmailStatus(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <param name="updatedEntity">The emailstatus data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EmailStatus> updatedEntity)
        {
            PatchEmailStatus(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific emailstatus by its primary key</summary>
        /// <param name="id">The primary key of the emailstatus</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEmailStatus(id);
            return true;
        }
        #region
        private List<EmailStatus> GetEmailStatus(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EmailStatus.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EmailStatus>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EmailStatus), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EmailStatus, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEmailStatus(EmailStatus model)
        {
            _dbContext.EmailStatus.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEmailStatus(Guid id, EmailStatus updatedEntity)
        {
            _dbContext.EmailStatus.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEmailStatus(Guid id)
        {
            var entityData = _dbContext.EmailStatus.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EmailStatus.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEmailStatus(Guid id, JsonPatchDocument<EmailStatus> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EmailStatus.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EmailStatus.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}