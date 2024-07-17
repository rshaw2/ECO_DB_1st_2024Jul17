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
    /// The investigationrecordresultService responsible for managing investigationrecordresult related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationrecordresult information.
    /// </remarks>
    public interface IInvestigationRecordResultService
    {
        /// <summary>Retrieves a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <returns>The investigationrecordresult data</returns>
        InvestigationRecordResult GetById(Guid id);

        /// <summary>Retrieves a list of investigationrecordresults based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationrecordresults</returns>
        List<InvestigationRecordResult> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationrecordresult</summary>
        /// <param name="model">The investigationrecordresult data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationRecordResult model);

        /// <summary>Updates a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <param name="updatedEntity">The investigationrecordresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationRecordResult updatedEntity);

        /// <summary>Updates a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <param name="updatedEntity">The investigationrecordresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationRecordResult> updatedEntity);

        /// <summary>Deletes a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationrecordresultService responsible for managing investigationrecordresult related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationrecordresult information.
    /// </remarks>
    public class InvestigationRecordResultService : IInvestigationRecordResultService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationRecordResult class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationRecordResultService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <returns>The investigationrecordresult data</returns>
        public InvestigationRecordResult GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationRecordResult.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationrecordresults based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationrecordresults</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationRecordResult> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationRecordResult(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationrecordresult</summary>
        /// <param name="model">The investigationrecordresult data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationRecordResult model)
        {
            model.Id = CreateInvestigationRecordResult(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <param name="updatedEntity">The investigationrecordresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationRecordResult updatedEntity)
        {
            UpdateInvestigationRecordResult(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <param name="updatedEntity">The investigationrecordresult data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationRecordResult> updatedEntity)
        {
            PatchInvestigationRecordResult(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationrecordresult by its primary key</summary>
        /// <param name="id">The primary key of the investigationrecordresult</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationRecordResult(id);
            return true;
        }
        #region
        private List<InvestigationRecordResult> GetInvestigationRecordResult(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationRecordResult.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationRecordResult>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationRecordResult), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationRecordResult, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationRecordResult(InvestigationRecordResult model)
        {
            _dbContext.InvestigationRecordResult.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationRecordResult(Guid id, InvestigationRecordResult updatedEntity)
        {
            _dbContext.InvestigationRecordResult.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationRecordResult(Guid id)
        {
            var entityData = _dbContext.InvestigationRecordResult.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationRecordResult.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationRecordResult(Guid id, JsonPatchDocument<InvestigationRecordResult> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationRecordResult.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationRecordResult.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}