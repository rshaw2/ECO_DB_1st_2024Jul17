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
    /// The patientallergyparametervalueService responsible for managing patientallergyparametervalue related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientallergyparametervalue information.
    /// </remarks>
    public interface IPatientAllergyParameterValueService
    {
        /// <summary>Retrieves a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <returns>The patientallergyparametervalue data</returns>
        PatientAllergyParameterValue GetById(Guid id);

        /// <summary>Retrieves a list of patientallergyparametervalues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientallergyparametervalues</returns>
        List<PatientAllergyParameterValue> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientallergyparametervalue</summary>
        /// <param name="model">The patientallergyparametervalue data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientAllergyParameterValue model);

        /// <summary>Updates a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <param name="updatedEntity">The patientallergyparametervalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientAllergyParameterValue updatedEntity);

        /// <summary>Updates a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <param name="updatedEntity">The patientallergyparametervalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientAllergyParameterValue> updatedEntity);

        /// <summary>Deletes a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientallergyparametervalueService responsible for managing patientallergyparametervalue related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientallergyparametervalue information.
    /// </remarks>
    public class PatientAllergyParameterValueService : IPatientAllergyParameterValueService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientAllergyParameterValue class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientAllergyParameterValueService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <returns>The patientallergyparametervalue data</returns>
        public PatientAllergyParameterValue GetById(Guid id)
        {
            var entityData = _dbContext.PatientAllergyParameterValue.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientallergyparametervalues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientallergyparametervalues</returns>/// <exception cref="Exception"></exception>
        public List<PatientAllergyParameterValue> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientAllergyParameterValue(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientallergyparametervalue</summary>
        /// <param name="model">The patientallergyparametervalue data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientAllergyParameterValue model)
        {
            model.Id = CreatePatientAllergyParameterValue(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <param name="updatedEntity">The patientallergyparametervalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientAllergyParameterValue updatedEntity)
        {
            UpdatePatientAllergyParameterValue(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <param name="updatedEntity">The patientallergyparametervalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientAllergyParameterValue> updatedEntity)
        {
            PatchPatientAllergyParameterValue(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientallergyparametervalue by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparametervalue</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientAllergyParameterValue(id);
            return true;
        }
        #region
        private List<PatientAllergyParameterValue> GetPatientAllergyParameterValue(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientAllergyParameterValue.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientAllergyParameterValue>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientAllergyParameterValue), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientAllergyParameterValue, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientAllergyParameterValue(PatientAllergyParameterValue model)
        {
            _dbContext.PatientAllergyParameterValue.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientAllergyParameterValue(Guid id, PatientAllergyParameterValue updatedEntity)
        {
            _dbContext.PatientAllergyParameterValue.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientAllergyParameterValue(Guid id)
        {
            var entityData = _dbContext.PatientAllergyParameterValue.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientAllergyParameterValue.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientAllergyParameterValue(Guid id, JsonPatchDocument<PatientAllergyParameterValue> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientAllergyParameterValue.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientAllergyParameterValue.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}