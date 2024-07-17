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
    /// The investigationorderlineService responsible for managing investigationorderline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationorderline information.
    /// </remarks>
    public interface IInvestigationOrderLineService
    {
        /// <summary>Retrieves a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <returns>The investigationorderline data</returns>
        InvestigationOrderLine GetById(Guid id);

        /// <summary>Retrieves a list of investigationorderlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationorderlines</returns>
        List<InvestigationOrderLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationorderline</summary>
        /// <param name="model">The investigationorderline data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationOrderLine model);

        /// <summary>Updates a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <param name="updatedEntity">The investigationorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationOrderLine updatedEntity);

        /// <summary>Updates a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <param name="updatedEntity">The investigationorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationOrderLine> updatedEntity);

        /// <summary>Deletes a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationorderlineService responsible for managing investigationorderline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationorderline information.
    /// </remarks>
    public class InvestigationOrderLineService : IInvestigationOrderLineService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationOrderLine class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationOrderLineService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <returns>The investigationorderline data</returns>
        public InvestigationOrderLine GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationOrderLine.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationorderlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationorderlines</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationOrderLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationOrderLine(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationorderline</summary>
        /// <param name="model">The investigationorderline data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationOrderLine model)
        {
            model.Id = CreateInvestigationOrderLine(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <param name="updatedEntity">The investigationorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationOrderLine updatedEntity)
        {
            UpdateInvestigationOrderLine(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <param name="updatedEntity">The investigationorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationOrderLine> updatedEntity)
        {
            PatchInvestigationOrderLine(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationorderline by its primary key</summary>
        /// <param name="id">The primary key of the investigationorderline</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationOrderLine(id);
            return true;
        }
        #region
        private List<InvestigationOrderLine> GetInvestigationOrderLine(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationOrderLine.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationOrderLine>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationOrderLine), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationOrderLine, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationOrderLine(InvestigationOrderLine model)
        {
            _dbContext.InvestigationOrderLine.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationOrderLine(Guid id, InvestigationOrderLine updatedEntity)
        {
            _dbContext.InvestigationOrderLine.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationOrderLine(Guid id)
        {
            var entityData = _dbContext.InvestigationOrderLine.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationOrderLine.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationOrderLine(Guid id, JsonPatchDocument<InvestigationOrderLine> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationOrderLine.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationOrderLine.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}