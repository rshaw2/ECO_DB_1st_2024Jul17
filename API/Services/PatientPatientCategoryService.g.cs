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
    /// The patientpatientcategoryService responsible for managing patientpatientcategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientpatientcategory information.
    /// </remarks>
    public interface IPatientPatientCategoryService
    {
        /// <summary>Retrieves a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <returns>The patientpatientcategory data</returns>
        PatientPatientCategory GetById(Guid id);

        /// <summary>Retrieves a list of patientpatientcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientpatientcategorys</returns>
        List<PatientPatientCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientpatientcategory</summary>
        /// <param name="model">The patientpatientcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientPatientCategory model);

        /// <summary>Updates a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <param name="updatedEntity">The patientpatientcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientPatientCategory updatedEntity);

        /// <summary>Updates a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <param name="updatedEntity">The patientpatientcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientPatientCategory> updatedEntity);

        /// <summary>Deletes a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientpatientcategoryService responsible for managing patientpatientcategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientpatientcategory information.
    /// </remarks>
    public class PatientPatientCategoryService : IPatientPatientCategoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientPatientCategory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientPatientCategoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <returns>The patientpatientcategory data</returns>
        public PatientPatientCategory GetById(Guid id)
        {
            var entityData = _dbContext.PatientPatientCategory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientpatientcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientpatientcategorys</returns>/// <exception cref="Exception"></exception>
        public List<PatientPatientCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientPatientCategory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientpatientcategory</summary>
        /// <param name="model">The patientpatientcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientPatientCategory model)
        {
            model.Id = CreatePatientPatientCategory(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <param name="updatedEntity">The patientpatientcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientPatientCategory updatedEntity)
        {
            UpdatePatientPatientCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <param name="updatedEntity">The patientpatientcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientPatientCategory> updatedEntity)
        {
            PatchPatientPatientCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientpatientcategory by its primary key</summary>
        /// <param name="id">The primary key of the patientpatientcategory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientPatientCategory(id);
            return true;
        }
        #region
        private List<PatientPatientCategory> GetPatientPatientCategory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientPatientCategory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientPatientCategory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientPatientCategory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientPatientCategory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientPatientCategory(PatientPatientCategory model)
        {
            _dbContext.PatientPatientCategory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientPatientCategory(Guid id, PatientPatientCategory updatedEntity)
        {
            _dbContext.PatientPatientCategory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientPatientCategory(Guid id)
        {
            var entityData = _dbContext.PatientPatientCategory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientPatientCategory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientPatientCategory(Guid id, JsonPatchDocument<PatientPatientCategory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientPatientCategory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientPatientCategory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}