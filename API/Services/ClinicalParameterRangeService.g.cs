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
    /// The clinicalparameterrangeService responsible for managing clinicalparameterrange related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinicalparameterrange information.
    /// </remarks>
    public interface IClinicalParameterRangeService
    {
        /// <summary>Retrieves a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <returns>The clinicalparameterrange data</returns>
        ClinicalParameterRange GetById(Guid id);

        /// <summary>Retrieves a list of clinicalparameterranges based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinicalparameterranges</returns>
        List<ClinicalParameterRange> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new clinicalparameterrange</summary>
        /// <param name="model">The clinicalparameterrange data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ClinicalParameterRange model);

        /// <summary>Updates a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <param name="updatedEntity">The clinicalparameterrange data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ClinicalParameterRange updatedEntity);

        /// <summary>Updates a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <param name="updatedEntity">The clinicalparameterrange data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ClinicalParameterRange> updatedEntity);

        /// <summary>Deletes a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The clinicalparameterrangeService responsible for managing clinicalparameterrange related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinicalparameterrange information.
    /// </remarks>
    public class ClinicalParameterRangeService : IClinicalParameterRangeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ClinicalParameterRange class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ClinicalParameterRangeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <returns>The clinicalparameterrange data</returns>
        public ClinicalParameterRange GetById(Guid id)
        {
            var entityData = _dbContext.ClinicalParameterRange.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of clinicalparameterranges based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinicalparameterranges</returns>/// <exception cref="Exception"></exception>
        public List<ClinicalParameterRange> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetClinicalParameterRange(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new clinicalparameterrange</summary>
        /// <param name="model">The clinicalparameterrange data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ClinicalParameterRange model)
        {
            model.Id = CreateClinicalParameterRange(model);
            return model.Id;
        }

        /// <summary>Updates a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <param name="updatedEntity">The clinicalparameterrange data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ClinicalParameterRange updatedEntity)
        {
            UpdateClinicalParameterRange(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <param name="updatedEntity">The clinicalparameterrange data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ClinicalParameterRange> updatedEntity)
        {
            PatchClinicalParameterRange(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific clinicalparameterrange by its primary key</summary>
        /// <param name="id">The primary key of the clinicalparameterrange</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteClinicalParameterRange(id);
            return true;
        }
        #region
        private List<ClinicalParameterRange> GetClinicalParameterRange(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ClinicalParameterRange.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ClinicalParameterRange>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ClinicalParameterRange), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ClinicalParameterRange, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateClinicalParameterRange(ClinicalParameterRange model)
        {
            _dbContext.ClinicalParameterRange.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateClinicalParameterRange(Guid id, ClinicalParameterRange updatedEntity)
        {
            _dbContext.ClinicalParameterRange.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteClinicalParameterRange(Guid id)
        {
            var entityData = _dbContext.ClinicalParameterRange.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ClinicalParameterRange.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchClinicalParameterRange(Guid id, JsonPatchDocument<ClinicalParameterRange> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ClinicalParameterRange.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ClinicalParameterRange.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}