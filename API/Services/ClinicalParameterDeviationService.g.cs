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
    /// The clinicalparameterdeviationService responsible for managing clinicalparameterdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinicalparameterdeviation information.
    /// </remarks>
    public interface IClinicalParameterDeviationService
    {
        /// <summary>Retrieves a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <returns>The clinicalparameterdeviation data</returns>
        ClinicalParameterDeviation GetById(Guid id);

        /// <summary>Retrieves a list of clinicalparameterdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinicalparameterdeviations</returns>
        List<ClinicalParameterDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new clinicalparameterdeviation</summary>
        /// <param name="model">The clinicalparameterdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ClinicalParameterDeviation model);

        /// <summary>Updates a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <param name="updatedEntity">The clinicalparameterdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ClinicalParameterDeviation updatedEntity);

        /// <summary>Updates a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <param name="updatedEntity">The clinicalparameterdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ClinicalParameterDeviation> updatedEntity);

        /// <summary>Deletes a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The clinicalparameterdeviationService responsible for managing clinicalparameterdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinicalparameterdeviation information.
    /// </remarks>
    public class ClinicalParameterDeviationService : IClinicalParameterDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ClinicalParameterDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ClinicalParameterDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <returns>The clinicalparameterdeviation data</returns>
        public ClinicalParameterDeviation GetById(Guid id)
        {
            var entityData = _dbContext.ClinicalParameterDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of clinicalparameterdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinicalparameterdeviations</returns>/// <exception cref="Exception"></exception>
        public List<ClinicalParameterDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetClinicalParameterDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new clinicalparameterdeviation</summary>
        /// <param name="model">The clinicalparameterdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ClinicalParameterDeviation model)
        {
            model.Id = CreateClinicalParameterDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <param name="updatedEntity">The clinicalparameterdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ClinicalParameterDeviation updatedEntity)
        {
            UpdateClinicalParameterDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <param name="updatedEntity">The clinicalparameterdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ClinicalParameterDeviation> updatedEntity)
        {
            PatchClinicalParameterDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific clinicalparameterdeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteClinicalParameterDeviation(id);
            return true;
        }
        #region
        private List<ClinicalParameterDeviation> GetClinicalParameterDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ClinicalParameterDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ClinicalParameterDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ClinicalParameterDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ClinicalParameterDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateClinicalParameterDeviation(ClinicalParameterDeviation model)
        {
            _dbContext.ClinicalParameterDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateClinicalParameterDeviation(Guid id, ClinicalParameterDeviation updatedEntity)
        {
            _dbContext.ClinicalParameterDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteClinicalParameterDeviation(Guid id)
        {
            var entityData = _dbContext.ClinicalParameterDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ClinicalParameterDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchClinicalParameterDeviation(Guid id, JsonPatchDocument<ClinicalParameterDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ClinicalParameterDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ClinicalParameterDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}