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
    /// The diagnosisvectorService responsible for managing diagnosisvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosisvector information.
    /// </remarks>
    public interface IDiagnosisVectorService
    {
        /// <summary>Retrieves a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <returns>The diagnosisvector data</returns>
        DiagnosisVector GetById(Guid id);

        /// <summary>Retrieves a list of diagnosisvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosisvectors</returns>
        List<DiagnosisVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new diagnosisvector</summary>
        /// <param name="model">The diagnosisvector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DiagnosisVector model);

        /// <summary>Updates a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <param name="updatedEntity">The diagnosisvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DiagnosisVector updatedEntity);

        /// <summary>Updates a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <param name="updatedEntity">The diagnosisvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DiagnosisVector> updatedEntity);

        /// <summary>Deletes a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The diagnosisvectorService responsible for managing diagnosisvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting diagnosisvector information.
    /// </remarks>
    public class DiagnosisVectorService : IDiagnosisVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DiagnosisVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DiagnosisVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <returns>The diagnosisvector data</returns>
        public DiagnosisVector GetById(Guid id)
        {
            var entityData = _dbContext.DiagnosisVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of diagnosisvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of diagnosisvectors</returns>/// <exception cref="Exception"></exception>
        public List<DiagnosisVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDiagnosisVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new diagnosisvector</summary>
        /// <param name="model">The diagnosisvector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DiagnosisVector model)
        {
            model.Id = CreateDiagnosisVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <param name="updatedEntity">The diagnosisvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DiagnosisVector updatedEntity)
        {
            UpdateDiagnosisVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <param name="updatedEntity">The diagnosisvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DiagnosisVector> updatedEntity)
        {
            PatchDiagnosisVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific diagnosisvector by its primary key</summary>
        /// <param name="id">The primary key of the diagnosisvector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDiagnosisVector(id);
            return true;
        }
        #region
        private List<DiagnosisVector> GetDiagnosisVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DiagnosisVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DiagnosisVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DiagnosisVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DiagnosisVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDiagnosisVector(DiagnosisVector model)
        {
            _dbContext.DiagnosisVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDiagnosisVector(Guid id, DiagnosisVector updatedEntity)
        {
            _dbContext.DiagnosisVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDiagnosisVector(Guid id)
        {
            var entityData = _dbContext.DiagnosisVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DiagnosisVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDiagnosisVector(Guid id, JsonPatchDocument<DiagnosisVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DiagnosisVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DiagnosisVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}