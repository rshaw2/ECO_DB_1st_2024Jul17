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
    /// The visitchecklistService responsible for managing visitchecklist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitchecklist information.
    /// </remarks>
    public interface IVisitCheckListService
    {
        /// <summary>Retrieves a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <returns>The visitchecklist data</returns>
        VisitCheckList GetById(Guid id);

        /// <summary>Retrieves a list of visitchecklists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitchecklists</returns>
        List<VisitCheckList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitchecklist</summary>
        /// <param name="model">The visitchecklist data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitCheckList model);

        /// <summary>Updates a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <param name="updatedEntity">The visitchecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitCheckList updatedEntity);

        /// <summary>Updates a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <param name="updatedEntity">The visitchecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitCheckList> updatedEntity);

        /// <summary>Deletes a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitchecklistService responsible for managing visitchecklist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitchecklist information.
    /// </remarks>
    public class VisitCheckListService : IVisitCheckListService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitCheckList class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitCheckListService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <returns>The visitchecklist data</returns>
        public VisitCheckList GetById(Guid id)
        {
            var entityData = _dbContext.VisitCheckList.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitchecklists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitchecklists</returns>/// <exception cref="Exception"></exception>
        public List<VisitCheckList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitCheckList(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitchecklist</summary>
        /// <param name="model">The visitchecklist data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitCheckList model)
        {
            model.Id = CreateVisitCheckList(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <param name="updatedEntity">The visitchecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitCheckList updatedEntity)
        {
            UpdateVisitCheckList(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <param name="updatedEntity">The visitchecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitCheckList> updatedEntity)
        {
            PatchVisitCheckList(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitchecklist by its primary key</summary>
        /// <param name="id">The primary key of the visitchecklist</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitCheckList(id);
            return true;
        }
        #region
        private List<VisitCheckList> GetVisitCheckList(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitCheckList.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitCheckList>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitCheckList), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitCheckList, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitCheckList(VisitCheckList model)
        {
            _dbContext.VisitCheckList.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitCheckList(Guid id, VisitCheckList updatedEntity)
        {
            _dbContext.VisitCheckList.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitCheckList(Guid id)
        {
            var entityData = _dbContext.VisitCheckList.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitCheckList.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitCheckList(Guid id, JsonPatchDocument<VisitCheckList> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitCheckList.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitCheckList.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}