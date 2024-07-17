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
    /// The visitdiagnosisparameterService responsible for managing visitdiagnosisparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitdiagnosisparameter information.
    /// </remarks>
    public interface IVisitDiagnosisParameterService
    {
        /// <summary>Retrieves a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <returns>The visitdiagnosisparameter data</returns>
        VisitDiagnosisParameter GetById(Guid id);

        /// <summary>Retrieves a list of visitdiagnosisparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitdiagnosisparameters</returns>
        List<VisitDiagnosisParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitdiagnosisparameter</summary>
        /// <param name="model">The visitdiagnosisparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitDiagnosisParameter model);

        /// <summary>Updates a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <param name="updatedEntity">The visitdiagnosisparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitDiagnosisParameter updatedEntity);

        /// <summary>Updates a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <param name="updatedEntity">The visitdiagnosisparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitDiagnosisParameter> updatedEntity);

        /// <summary>Deletes a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitdiagnosisparameterService responsible for managing visitdiagnosisparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitdiagnosisparameter information.
    /// </remarks>
    public class VisitDiagnosisParameterService : IVisitDiagnosisParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitDiagnosisParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitDiagnosisParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <returns>The visitdiagnosisparameter data</returns>
        public VisitDiagnosisParameter GetById(Guid id)
        {
            var entityData = _dbContext.VisitDiagnosisParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitdiagnosisparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitdiagnosisparameters</returns>/// <exception cref="Exception"></exception>
        public List<VisitDiagnosisParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitDiagnosisParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitdiagnosisparameter</summary>
        /// <param name="model">The visitdiagnosisparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitDiagnosisParameter model)
        {
            model.Id = CreateVisitDiagnosisParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <param name="updatedEntity">The visitdiagnosisparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitDiagnosisParameter updatedEntity)
        {
            UpdateVisitDiagnosisParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <param name="updatedEntity">The visitdiagnosisparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitDiagnosisParameter> updatedEntity)
        {
            PatchVisitDiagnosisParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitDiagnosisParameter(id);
            return true;
        }
        #region
        private List<VisitDiagnosisParameter> GetVisitDiagnosisParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitDiagnosisParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitDiagnosisParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitDiagnosisParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitDiagnosisParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitDiagnosisParameter(VisitDiagnosisParameter model)
        {
            _dbContext.VisitDiagnosisParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitDiagnosisParameter(Guid id, VisitDiagnosisParameter updatedEntity)
        {
            _dbContext.VisitDiagnosisParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitDiagnosisParameter(Guid id)
        {
            var entityData = _dbContext.VisitDiagnosisParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitDiagnosisParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitDiagnosisParameter(Guid id, JsonPatchDocument<VisitDiagnosisParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitDiagnosisParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitDiagnosisParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}