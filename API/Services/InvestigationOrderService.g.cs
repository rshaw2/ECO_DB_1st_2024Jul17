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
    /// The investigationorderService responsible for managing investigationorder related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationorder information.
    /// </remarks>
    public interface IInvestigationOrderService
    {
        /// <summary>Retrieves a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <returns>The investigationorder data</returns>
        InvestigationOrder GetById(Guid id);

        /// <summary>Retrieves a list of investigationorders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationorders</returns>
        List<InvestigationOrder> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationorder</summary>
        /// <param name="model">The investigationorder data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationOrder model);

        /// <summary>Updates a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <param name="updatedEntity">The investigationorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationOrder updatedEntity);

        /// <summary>Updates a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <param name="updatedEntity">The investigationorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationOrder> updatedEntity);

        /// <summary>Deletes a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationorderService responsible for managing investigationorder related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationorder information.
    /// </remarks>
    public class InvestigationOrderService : IInvestigationOrderService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationOrder class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationOrderService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <returns>The investigationorder data</returns>
        public InvestigationOrder GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationOrder.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationorders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationorders</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationOrder> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationOrder(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationorder</summary>
        /// <param name="model">The investigationorder data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationOrder model)
        {
            model.Id = CreateInvestigationOrder(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <param name="updatedEntity">The investigationorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationOrder updatedEntity)
        {
            UpdateInvestigationOrder(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <param name="updatedEntity">The investigationorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationOrder> updatedEntity)
        {
            PatchInvestigationOrder(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationorder by its primary key</summary>
        /// <param name="id">The primary key of the investigationorder</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationOrder(id);
            return true;
        }
        #region
        private List<InvestigationOrder> GetInvestigationOrder(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationOrder.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationOrder>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationOrder), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationOrder, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationOrder(InvestigationOrder model)
        {
            _dbContext.InvestigationOrder.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationOrder(Guid id, InvestigationOrder updatedEntity)
        {
            _dbContext.InvestigationOrder.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationOrder(Guid id)
        {
            var entityData = _dbContext.InvestigationOrder.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationOrder.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationOrder(Guid id, JsonPatchDocument<InvestigationOrder> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationOrder.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationOrder.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}