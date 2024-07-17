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
    /// The visitinvestigationresultparameterService responsible for managing visitinvestigationresultparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationresultparameter information.
    /// </remarks>
    public interface IVisitInvestigationResultParameterService
    {
        /// <summary>Retrieves a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <returns>The visitinvestigationresultparameter data</returns>
        VisitInvestigationResultParameter GetById(Guid id);

        /// <summary>Retrieves a list of visitinvestigationresultparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationresultparameters</returns>
        List<VisitInvestigationResultParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitinvestigationresultparameter</summary>
        /// <param name="model">The visitinvestigationresultparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitInvestigationResultParameter model);

        /// <summary>Updates a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <param name="updatedEntity">The visitinvestigationresultparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitInvestigationResultParameter updatedEntity);

        /// <summary>Updates a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <param name="updatedEntity">The visitinvestigationresultparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitInvestigationResultParameter> updatedEntity);

        /// <summary>Deletes a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitinvestigationresultparameterService responsible for managing visitinvestigationresultparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationresultparameter information.
    /// </remarks>
    public class VisitInvestigationResultParameterService : IVisitInvestigationResultParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitInvestigationResultParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitInvestigationResultParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <returns>The visitinvestigationresultparameter data</returns>
        public VisitInvestigationResultParameter GetById(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationResultParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitinvestigationresultparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationresultparameters</returns>/// <exception cref="Exception"></exception>
        public List<VisitInvestigationResultParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitInvestigationResultParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitinvestigationresultparameter</summary>
        /// <param name="model">The visitinvestigationresultparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitInvestigationResultParameter model)
        {
            model.Id = CreateVisitInvestigationResultParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <param name="updatedEntity">The visitinvestigationresultparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitInvestigationResultParameter updatedEntity)
        {
            UpdateVisitInvestigationResultParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <param name="updatedEntity">The visitinvestigationresultparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitInvestigationResultParameter> updatedEntity)
        {
            PatchVisitInvestigationResultParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitinvestigationresultparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationresultparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitInvestigationResultParameter(id);
            return true;
        }
        #region
        private List<VisitInvestigationResultParameter> GetVisitInvestigationResultParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitInvestigationResultParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitInvestigationResultParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitInvestigationResultParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitInvestigationResultParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitInvestigationResultParameter(VisitInvestigationResultParameter model)
        {
            _dbContext.VisitInvestigationResultParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitInvestigationResultParameter(Guid id, VisitInvestigationResultParameter updatedEntity)
        {
            _dbContext.VisitInvestigationResultParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitInvestigationResultParameter(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationResultParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitInvestigationResultParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitInvestigationResultParameter(Guid id, JsonPatchDocument<VisitInvestigationResultParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitInvestigationResultParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitInvestigationResultParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}