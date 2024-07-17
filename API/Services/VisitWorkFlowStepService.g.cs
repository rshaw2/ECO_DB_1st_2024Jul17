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
    /// The visitworkflowstepService responsible for managing visitworkflowstep related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitworkflowstep information.
    /// </remarks>
    public interface IVisitWorkFlowStepService
    {
        /// <summary>Retrieves a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <returns>The visitworkflowstep data</returns>
        VisitWorkFlowStep GetById(Guid id);

        /// <summary>Retrieves a list of visitworkflowsteps based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitworkflowsteps</returns>
        List<VisitWorkFlowStep> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitworkflowstep</summary>
        /// <param name="model">The visitworkflowstep data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitWorkFlowStep model);

        /// <summary>Updates a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <param name="updatedEntity">The visitworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitWorkFlowStep updatedEntity);

        /// <summary>Updates a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <param name="updatedEntity">The visitworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitWorkFlowStep> updatedEntity);

        /// <summary>Deletes a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitworkflowstepService responsible for managing visitworkflowstep related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitworkflowstep information.
    /// </remarks>
    public class VisitWorkFlowStepService : IVisitWorkFlowStepService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitWorkFlowStep class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitWorkFlowStepService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <returns>The visitworkflowstep data</returns>
        public VisitWorkFlowStep GetById(Guid id)
        {
            var entityData = _dbContext.VisitWorkFlowStep.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitworkflowsteps based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitworkflowsteps</returns>/// <exception cref="Exception"></exception>
        public List<VisitWorkFlowStep> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitWorkFlowStep(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitworkflowstep</summary>
        /// <param name="model">The visitworkflowstep data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitWorkFlowStep model)
        {
            model.Id = CreateVisitWorkFlowStep(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <param name="updatedEntity">The visitworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitWorkFlowStep updatedEntity)
        {
            UpdateVisitWorkFlowStep(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <param name="updatedEntity">The visitworkflowstep data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitWorkFlowStep> updatedEntity)
        {
            PatchVisitWorkFlowStep(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitworkflowstep by its primary key</summary>
        /// <param name="id">The primary key of the visitworkflowstep</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitWorkFlowStep(id);
            return true;
        }
        #region
        private List<VisitWorkFlowStep> GetVisitWorkFlowStep(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitWorkFlowStep.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitWorkFlowStep>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitWorkFlowStep), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitWorkFlowStep, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitWorkFlowStep(VisitWorkFlowStep model)
        {
            _dbContext.VisitWorkFlowStep.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitWorkFlowStep(Guid id, VisitWorkFlowStep updatedEntity)
        {
            _dbContext.VisitWorkFlowStep.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitWorkFlowStep(Guid id)
        {
            var entityData = _dbContext.VisitWorkFlowStep.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitWorkFlowStep.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitWorkFlowStep(Guid id, JsonPatchDocument<VisitWorkFlowStep> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitWorkFlowStep.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitWorkFlowStep.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}