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
    /// The visittypechecklistService responsible for managing visittypechecklist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittypechecklist information.
    /// </remarks>
    public interface IVisitTypeCheckListService
    {
        /// <summary>Retrieves a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <returns>The visittypechecklist data</returns>
        VisitTypeCheckList GetById(Guid id);

        /// <summary>Retrieves a list of visittypechecklists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittypechecklists</returns>
        List<VisitTypeCheckList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visittypechecklist</summary>
        /// <param name="model">The visittypechecklist data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitTypeCheckList model);

        /// <summary>Updates a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <param name="updatedEntity">The visittypechecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitTypeCheckList updatedEntity);

        /// <summary>Updates a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <param name="updatedEntity">The visittypechecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitTypeCheckList> updatedEntity);

        /// <summary>Deletes a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visittypechecklistService responsible for managing visittypechecklist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittypechecklist information.
    /// </remarks>
    public class VisitTypeCheckListService : IVisitTypeCheckListService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitTypeCheckList class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitTypeCheckListService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <returns>The visittypechecklist data</returns>
        public VisitTypeCheckList GetById(Guid id)
        {
            var entityData = _dbContext.VisitTypeCheckList.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visittypechecklists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittypechecklists</returns>/// <exception cref="Exception"></exception>
        public List<VisitTypeCheckList> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitTypeCheckList(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visittypechecklist</summary>
        /// <param name="model">The visittypechecklist data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitTypeCheckList model)
        {
            model.Id = CreateVisitTypeCheckList(model);
            return model.Id;
        }

        /// <summary>Updates a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <param name="updatedEntity">The visittypechecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitTypeCheckList updatedEntity)
        {
            UpdateVisitTypeCheckList(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <param name="updatedEntity">The visittypechecklist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitTypeCheckList> updatedEntity)
        {
            PatchVisitTypeCheckList(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visittypechecklist by its primary key</summary>
        /// <param name="id">The primary key of the visittypechecklist</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitTypeCheckList(id);
            return true;
        }
        #region
        private List<VisitTypeCheckList> GetVisitTypeCheckList(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitTypeCheckList.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitTypeCheckList>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitTypeCheckList), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitTypeCheckList, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitTypeCheckList(VisitTypeCheckList model)
        {
            _dbContext.VisitTypeCheckList.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitTypeCheckList(Guid id, VisitTypeCheckList updatedEntity)
        {
            _dbContext.VisitTypeCheckList.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitTypeCheckList(Guid id)
        {
            var entityData = _dbContext.VisitTypeCheckList.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitTypeCheckList.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitTypeCheckList(Guid id, JsonPatchDocument<VisitTypeCheckList> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitTypeCheckList.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitTypeCheckList.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}