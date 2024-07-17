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
    /// The patientallergyparameterService responsible for managing patientallergyparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientallergyparameter information.
    /// </remarks>
    public interface IPatientAllergyParameterService
    {
        /// <summary>Retrieves a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <returns>The patientallergyparameter data</returns>
        PatientAllergyParameter GetById(Guid id);

        /// <summary>Retrieves a list of patientallergyparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientallergyparameters</returns>
        List<PatientAllergyParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientallergyparameter</summary>
        /// <param name="model">The patientallergyparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientAllergyParameter model);

        /// <summary>Updates a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <param name="updatedEntity">The patientallergyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientAllergyParameter updatedEntity);

        /// <summary>Updates a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <param name="updatedEntity">The patientallergyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientAllergyParameter> updatedEntity);

        /// <summary>Deletes a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientallergyparameterService responsible for managing patientallergyparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientallergyparameter information.
    /// </remarks>
    public class PatientAllergyParameterService : IPatientAllergyParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientAllergyParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientAllergyParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <returns>The patientallergyparameter data</returns>
        public PatientAllergyParameter GetById(Guid id)
        {
            var entityData = _dbContext.PatientAllergyParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientallergyparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientallergyparameters</returns>/// <exception cref="Exception"></exception>
        public List<PatientAllergyParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientAllergyParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientallergyparameter</summary>
        /// <param name="model">The patientallergyparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientAllergyParameter model)
        {
            model.Id = CreatePatientAllergyParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <param name="updatedEntity">The patientallergyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientAllergyParameter updatedEntity)
        {
            UpdatePatientAllergyParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <param name="updatedEntity">The patientallergyparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientAllergyParameter> updatedEntity)
        {
            PatchPatientAllergyParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientallergyparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientallergyparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientAllergyParameter(id);
            return true;
        }
        #region
        private List<PatientAllergyParameter> GetPatientAllergyParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientAllergyParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientAllergyParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientAllergyParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientAllergyParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientAllergyParameter(PatientAllergyParameter model)
        {
            _dbContext.PatientAllergyParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientAllergyParameter(Guid id, PatientAllergyParameter updatedEntity)
        {
            _dbContext.PatientAllergyParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientAllergyParameter(Guid id)
        {
            var entityData = _dbContext.PatientAllergyParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientAllergyParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientAllergyParameter(Guid id, JsonPatchDocument<PatientAllergyParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientAllergyParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientAllergyParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}