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
    /// The visitactivityhistoryService responsible for managing visitactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitactivityhistory information.
    /// </remarks>
    public interface IVisitActivityHistoryService
    {
        /// <summary>Retrieves a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <returns>The visitactivityhistory data</returns>
        VisitActivityHistory GetById(Guid id);

        /// <summary>Retrieves a list of visitactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitactivityhistorys</returns>
        List<VisitActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitactivityhistory</summary>
        /// <param name="model">The visitactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitActivityHistory model);

        /// <summary>Updates a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <param name="updatedEntity">The visitactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitActivityHistory updatedEntity);

        /// <summary>Updates a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <param name="updatedEntity">The visitactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitActivityHistory> updatedEntity);

        /// <summary>Deletes a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitactivityhistoryService responsible for managing visitactivityhistory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitactivityhistory information.
    /// </remarks>
    public class VisitActivityHistoryService : IVisitActivityHistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitActivityHistory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitActivityHistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <returns>The visitactivityhistory data</returns>
        public VisitActivityHistory GetById(Guid id)
        {
            var entityData = _dbContext.VisitActivityHistory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitactivityhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitactivityhistorys</returns>/// <exception cref="Exception"></exception>
        public List<VisitActivityHistory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitActivityHistory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitactivityhistory</summary>
        /// <param name="model">The visitactivityhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitActivityHistory model)
        {
            model.Id = CreateVisitActivityHistory(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <param name="updatedEntity">The visitactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitActivityHistory updatedEntity)
        {
            UpdateVisitActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <param name="updatedEntity">The visitactivityhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitActivityHistory> updatedEntity)
        {
            PatchVisitActivityHistory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitactivityhistory by its primary key</summary>
        /// <param name="id">The primary key of the visitactivityhistory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitActivityHistory(id);
            return true;
        }
        #region
        private List<VisitActivityHistory> GetVisitActivityHistory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitActivityHistory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitActivityHistory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitActivityHistory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitActivityHistory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitActivityHistory(VisitActivityHistory model)
        {
            _dbContext.VisitActivityHistory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitActivityHistory(Guid id, VisitActivityHistory updatedEntity)
        {
            _dbContext.VisitActivityHistory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitActivityHistory(Guid id)
        {
            var entityData = _dbContext.VisitActivityHistory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitActivityHistory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitActivityHistory(Guid id, JsonPatchDocument<VisitActivityHistory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitActivityHistory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitActivityHistory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}