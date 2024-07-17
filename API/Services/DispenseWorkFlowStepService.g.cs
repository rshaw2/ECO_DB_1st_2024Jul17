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
    /// The dispenseworkflowstepService responsible for managing dispenseworkflowstep related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dispenseworkflowstep information.
    /// </remarks>
    public interface IDispenseWorkFlowStepService
    {
        /// <summary>Retrieves a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <returns>The dispenseworkflowstep data</returns>
        DispenseWorkFlowStep GetById(Guid id);

        /// <summary>Retrieves a list of dispenseworkflowsteps based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dispenseworkflowsteps</returns>
        List<DispenseWorkFlowStep> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new dispenseworkflowstep</summary>
        /// <param name="model">The dispenseworkflowstep data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DispenseWorkFlowStep model);

        /// <summary>Updates a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <param name="updatedEntity">The dispenseworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DispenseWorkFlowStep updatedEntity);

        /// <summary>Updates a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <param name="updatedEntity">The dispenseworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DispenseWorkFlowStep> updatedEntity);

        /// <summary>Deletes a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The dispenseworkflowstepService responsible for managing dispenseworkflowstep related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dispenseworkflowstep information.
    /// </remarks>
    public class DispenseWorkFlowStepService : IDispenseWorkFlowStepService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DispenseWorkFlowStep class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DispenseWorkFlowStepService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <returns>The dispenseworkflowstep data</returns>
        public DispenseWorkFlowStep GetById(Guid id)
        {
            var entityData = _dbContext.DispenseWorkFlowStep.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of dispenseworkflowsteps based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dispenseworkflowsteps</returns>/// <exception cref="Exception"></exception>
        public List<DispenseWorkFlowStep> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDispenseWorkFlowStep(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new dispenseworkflowstep</summary>
        /// <param name="model">The dispenseworkflowstep data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DispenseWorkFlowStep model)
        {
            model.Id = CreateDispenseWorkFlowStep(model);
            return model.Id;
        }

        /// <summary>Updates a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <param name="updatedEntity">The dispenseworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DispenseWorkFlowStep updatedEntity)
        {
            UpdateDispenseWorkFlowStep(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <param name="updatedEntity">The dispenseworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DispenseWorkFlowStep> updatedEntity)
        {
            PatchDispenseWorkFlowStep(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific dispenseworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the dispenseworkflowstep</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDispenseWorkFlowStep(id);
            return true;
        }
        #region
        private List<DispenseWorkFlowStep> GetDispenseWorkFlowStep(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DispenseWorkFlowStep.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DispenseWorkFlowStep>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DispenseWorkFlowStep), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DispenseWorkFlowStep, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDispenseWorkFlowStep(DispenseWorkFlowStep model)
        {
            _dbContext.DispenseWorkFlowStep.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDispenseWorkFlowStep(Guid id, DispenseWorkFlowStep updatedEntity)
        {
            _dbContext.DispenseWorkFlowStep.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDispenseWorkFlowStep(Guid id)
        {
            var entityData = _dbContext.DispenseWorkFlowStep.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DispenseWorkFlowStep.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDispenseWorkFlowStep(Guid id, JsonPatchDocument<DispenseWorkFlowStep> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DispenseWorkFlowStep.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DispenseWorkFlowStep.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}