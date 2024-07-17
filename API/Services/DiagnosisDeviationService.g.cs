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
    /// The diagnosisdeviationService responsible for managing diagnosisdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosisdeviation information.
    /// </remarks>
    public interface IDiagnosisDeviationService
    {
        /// <summary>Retrieves a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <returns>The diagnosisdeviation data</returns>
        DiagnosisDeviation GetById(Guid id);

        /// <summary>Retrieves a list of diagnosisdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosisdeviations</returns>
        List<DiagnosisDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new diagnosisdeviation</summary>
        /// <param name="model">The diagnosisdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DiagnosisDeviation model);

        /// <summary>Updates a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <param name="updatedEntity">The diagnosisdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DiagnosisDeviation updatedEntity);

        /// <summary>Updates a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <param name="updatedEntity">The diagnosisdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DiagnosisDeviation> updatedEntity);

        /// <summary>Deletes a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The diagnosisdeviationService responsible for managing diagnosisdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosisdeviation information.
    /// </remarks>
    public class DiagnosisDeviationService : IDiagnosisDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DiagnosisDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DiagnosisDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <returns>The diagnosisdeviation data</returns>
        public DiagnosisDeviation GetById(Guid id)
        {
            var entityData = _dbContext.DiagnosisDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of diagnosisdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosisdeviations</returns>/// <exception cref="Exception"></exception>
        public List<DiagnosisDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDiagnosisDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new diagnosisdeviation</summary>
        /// <param name="model">The diagnosisdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DiagnosisDeviation model)
        {
            model.Id = CreateDiagnosisDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <param name="updatedEntity">The diagnosisdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DiagnosisDeviation updatedEntity)
        {
            UpdateDiagnosisDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <param name="updatedEntity">The diagnosisdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DiagnosisDeviation> updatedEntity)
        {
            PatchDiagnosisDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific diagnosisdeviation by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDiagnosisDeviation(id);
            return true;
        }
        #region
        private List<DiagnosisDeviation> GetDiagnosisDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DiagnosisDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DiagnosisDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DiagnosisDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DiagnosisDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDiagnosisDeviation(DiagnosisDeviation model)
        {
            _dbContext.DiagnosisDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDiagnosisDeviation(Guid id, DiagnosisDeviation updatedEntity)
        {
            _dbContext.DiagnosisDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDiagnosisDeviation(Guid id)
        {
            var entityData = _dbContext.DiagnosisDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DiagnosisDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDiagnosisDeviation(Guid id, JsonPatchDocument<DiagnosisDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DiagnosisDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DiagnosisDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}