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
    /// The diagnosistemplateparameterService responsible for managing diagnosistemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosistemplateparameter information.
    /// </remarks>
    public interface IDiagnosisTemplateParameterService
    {
        /// <summary>Retrieves a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <returns>The diagnosistemplateparameter data</returns>
        DiagnosisTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of diagnosistemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosistemplateparameters</returns>
        List<DiagnosisTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new diagnosistemplateparameter</summary>
        /// <param name="model">The diagnosistemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DiagnosisTemplateParameter model);

        /// <summary>Updates a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <param name="updatedEntity">The diagnosistemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DiagnosisTemplateParameter updatedEntity);

        /// <summary>Updates a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <param name="updatedEntity">The diagnosistemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DiagnosisTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The diagnosistemplateparameterService responsible for managing diagnosistemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosistemplateparameter information.
    /// </remarks>
    public class DiagnosisTemplateParameterService : IDiagnosisTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DiagnosisTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DiagnosisTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <returns>The diagnosistemplateparameter data</returns>
        public DiagnosisTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.DiagnosisTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of diagnosistemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosistemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<DiagnosisTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDiagnosisTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new diagnosistemplateparameter</summary>
        /// <param name="model">The diagnosistemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DiagnosisTemplateParameter model)
        {
            model.Id = CreateDiagnosisTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <param name="updatedEntity">The diagnosistemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DiagnosisTemplateParameter updatedEntity)
        {
            UpdateDiagnosisTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <param name="updatedEntity">The diagnosistemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DiagnosisTemplateParameter> updatedEntity)
        {
            PatchDiagnosisTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific diagnosistemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the diagnosistemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDiagnosisTemplateParameter(id);
            return true;
        }
        #region
        private List<DiagnosisTemplateParameter> GetDiagnosisTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DiagnosisTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DiagnosisTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DiagnosisTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DiagnosisTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDiagnosisTemplateParameter(DiagnosisTemplateParameter model)
        {
            _dbContext.DiagnosisTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDiagnosisTemplateParameter(Guid id, DiagnosisTemplateParameter updatedEntity)
        {
            _dbContext.DiagnosisTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDiagnosisTemplateParameter(Guid id)
        {
            var entityData = _dbContext.DiagnosisTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DiagnosisTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDiagnosisTemplateParameter(Guid id, JsonPatchDocument<DiagnosisTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DiagnosisTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DiagnosisTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}