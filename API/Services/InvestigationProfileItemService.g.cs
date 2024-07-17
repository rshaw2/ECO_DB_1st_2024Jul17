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
    /// The investigationprofileitemService responsible for managing investigationprofileitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationprofileitem information.
    /// </remarks>
    public interface IInvestigationProfileItemService
    {
        /// <summary>Retrieves a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <returns>The investigationprofileitem data</returns>
        InvestigationProfileItem GetById(Guid id);

        /// <summary>Retrieves a list of investigationprofileitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationprofileitems</returns>
        List<InvestigationProfileItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationprofileitem</summary>
        /// <param name="model">The investigationprofileitem data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationProfileItem model);

        /// <summary>Updates a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <param name="updatedEntity">The investigationprofileitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationProfileItem updatedEntity);

        /// <summary>Updates a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <param name="updatedEntity">The investigationprofileitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationProfileItem> updatedEntity);

        /// <summary>Deletes a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationprofileitemService responsible for managing investigationprofileitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationprofileitem information.
    /// </remarks>
    public class InvestigationProfileItemService : IInvestigationProfileItemService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationProfileItem class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationProfileItemService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <returns>The investigationprofileitem data</returns>
        public InvestigationProfileItem GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationProfileItem.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationprofileitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationprofileitems</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationProfileItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationProfileItem(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationprofileitem</summary>
        /// <param name="model">The investigationprofileitem data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationProfileItem model)
        {
            model.Id = CreateInvestigationProfileItem(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <param name="updatedEntity">The investigationprofileitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationProfileItem updatedEntity)
        {
            UpdateInvestigationProfileItem(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <param name="updatedEntity">The investigationprofileitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationProfileItem> updatedEntity)
        {
            PatchInvestigationProfileItem(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationprofileitem by its primary key</summary>
        /// <param name="id">The primary key of the investigationprofileitem</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationProfileItem(id);
            return true;
        }
        #region
        private List<InvestigationProfileItem> GetInvestigationProfileItem(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationProfileItem.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationProfileItem>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationProfileItem), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationProfileItem, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationProfileItem(InvestigationProfileItem model)
        {
            _dbContext.InvestigationProfileItem.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationProfileItem(Guid id, InvestigationProfileItem updatedEntity)
        {
            _dbContext.InvestigationProfileItem.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationProfileItem(Guid id)
        {
            var entityData = _dbContext.InvestigationProfileItem.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationProfileItem.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationProfileItem(Guid id, JsonPatchDocument<InvestigationProfileItem> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationProfileItem.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationProfileItem.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}