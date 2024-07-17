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
    /// The clinicalparametervaluedeviationService responsible for managing clinicalparametervaluedeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinicalparametervaluedeviation information.
    /// </remarks>
    public interface IClinicalParameterValueDeviationService
    {
        /// <summary>Retrieves a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <returns>The clinicalparametervaluedeviation data</returns>
        ClinicalParameterValueDeviation GetById(Guid id);

        /// <summary>Retrieves a list of clinicalparametervaluedeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinicalparametervaluedeviations</returns>
        List<ClinicalParameterValueDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new clinicalparametervaluedeviation</summary>
        /// <param name="model">The clinicalparametervaluedeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ClinicalParameterValueDeviation model);

        /// <summary>Updates a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <param name="updatedEntity">The clinicalparametervaluedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ClinicalParameterValueDeviation updatedEntity);

        /// <summary>Updates a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <param name="updatedEntity">The clinicalparametervaluedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ClinicalParameterValueDeviation> updatedEntity);

        /// <summary>Deletes a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The clinicalparametervaluedeviationService responsible for managing clinicalparametervaluedeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinicalparametervaluedeviation information.
    /// </remarks>
    public class ClinicalParameterValueDeviationService : IClinicalParameterValueDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ClinicalParameterValueDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ClinicalParameterValueDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <returns>The clinicalparametervaluedeviation data</returns>
        public ClinicalParameterValueDeviation GetById(Guid id)
        {
            var entityData = _dbContext.ClinicalParameterValueDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of clinicalparametervaluedeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinicalparametervaluedeviations</returns>/// <exception cref="Exception"></exception>
        public List<ClinicalParameterValueDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetClinicalParameterValueDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new clinicalparametervaluedeviation</summary>
        /// <param name="model">The clinicalparametervaluedeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ClinicalParameterValueDeviation model)
        {
            model.Id = CreateClinicalParameterValueDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <param name="updatedEntity">The clinicalparametervaluedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ClinicalParameterValueDeviation updatedEntity)
        {
            UpdateClinicalParameterValueDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <param name="updatedEntity">The clinicalparametervaluedeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ClinicalParameterValueDeviation> updatedEntity)
        {
            PatchClinicalParameterValueDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific clinicalparametervaluedeviation by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparametervaluedeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteClinicalParameterValueDeviation(id);
            return true;
        }
        #region
        private List<ClinicalParameterValueDeviation> GetClinicalParameterValueDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ClinicalParameterValueDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ClinicalParameterValueDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ClinicalParameterValueDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ClinicalParameterValueDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateClinicalParameterValueDeviation(ClinicalParameterValueDeviation model)
        {
            _dbContext.ClinicalParameterValueDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateClinicalParameterValueDeviation(Guid id, ClinicalParameterValueDeviation updatedEntity)
        {
            _dbContext.ClinicalParameterValueDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteClinicalParameterValueDeviation(Guid id)
        {
            var entityData = _dbContext.ClinicalParameterValueDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ClinicalParameterValueDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchClinicalParameterValueDeviation(Guid id, JsonPatchDocument<ClinicalParameterValueDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ClinicalParameterValueDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ClinicalParameterValueDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}