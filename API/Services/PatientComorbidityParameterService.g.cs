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
    /// The patientcomorbidityparameterService responsible for managing patientcomorbidityparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientcomorbidityparameter information.
    /// </remarks>
    public interface IPatientComorbidityParameterService
    {
        /// <summary>Retrieves a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <returns>The patientcomorbidityparameter data</returns>
        PatientComorbidityParameter GetById(Guid id);

        /// <summary>Retrieves a list of patientcomorbidityparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientcomorbidityparameters</returns>
        List<PatientComorbidityParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientcomorbidityparameter</summary>
        /// <param name="model">The patientcomorbidityparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientComorbidityParameter model);

        /// <summary>Updates a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <param name="updatedEntity">The patientcomorbidityparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientComorbidityParameter updatedEntity);

        /// <summary>Updates a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <param name="updatedEntity">The patientcomorbidityparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientComorbidityParameter> updatedEntity);

        /// <summary>Deletes a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientcomorbidityparameterService responsible for managing patientcomorbidityparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientcomorbidityparameter information.
    /// </remarks>
    public class PatientComorbidityParameterService : IPatientComorbidityParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientComorbidityParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientComorbidityParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <returns>The patientcomorbidityparameter data</returns>
        public PatientComorbidityParameter GetById(Guid id)
        {
            var entityData = _dbContext.PatientComorbidityParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientcomorbidityparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientcomorbidityparameters</returns>/// <exception cref="Exception"></exception>
        public List<PatientComorbidityParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientComorbidityParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientcomorbidityparameter</summary>
        /// <param name="model">The patientcomorbidityparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientComorbidityParameter model)
        {
            model.Id = CreatePatientComorbidityParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <param name="updatedEntity">The patientcomorbidityparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientComorbidityParameter updatedEntity)
        {
            UpdatePatientComorbidityParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <param name="updatedEntity">The patientcomorbidityparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientComorbidityParameter> updatedEntity)
        {
            PatchPatientComorbidityParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientcomorbidityparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientcomorbidityparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientComorbidityParameter(id);
            return true;
        }
        #region
        private List<PatientComorbidityParameter> GetPatientComorbidityParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientComorbidityParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientComorbidityParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientComorbidityParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientComorbidityParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientComorbidityParameter(PatientComorbidityParameter model)
        {
            _dbContext.PatientComorbidityParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientComorbidityParameter(Guid id, PatientComorbidityParameter updatedEntity)
        {
            _dbContext.PatientComorbidityParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientComorbidityParameter(Guid id)
        {
            var entityData = _dbContext.PatientComorbidityParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientComorbidityParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientComorbidityParameter(Guid id, JsonPatchDocument<PatientComorbidityParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientComorbidityParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientComorbidityParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}