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
    /// The patientlifestyleparameterService responsible for managing patientlifestyleparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientlifestyleparameter information.
    /// </remarks>
    public interface IPatientLifeStyleParameterService
    {
        /// <summary>Retrieves a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <returns>The patientlifestyleparameter data</returns>
        PatientLifeStyleParameter GetById(Guid id);

        /// <summary>Retrieves a list of patientlifestyleparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientlifestyleparameters</returns>
        List<PatientLifeStyleParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientlifestyleparameter</summary>
        /// <param name="model">The patientlifestyleparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientLifeStyleParameter model);

        /// <summary>Updates a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <param name="updatedEntity">The patientlifestyleparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientLifeStyleParameter updatedEntity);

        /// <summary>Updates a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <param name="updatedEntity">The patientlifestyleparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientLifeStyleParameter> updatedEntity);

        /// <summary>Deletes a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientlifestyleparameterService responsible for managing patientlifestyleparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientlifestyleparameter information.
    /// </remarks>
    public class PatientLifeStyleParameterService : IPatientLifeStyleParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientLifeStyleParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientLifeStyleParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <returns>The patientlifestyleparameter data</returns>
        public PatientLifeStyleParameter GetById(Guid id)
        {
            var entityData = _dbContext.PatientLifeStyleParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientlifestyleparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientlifestyleparameters</returns>/// <exception cref="Exception"></exception>
        public List<PatientLifeStyleParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientLifeStyleParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientlifestyleparameter</summary>
        /// <param name="model">The patientlifestyleparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientLifeStyleParameter model)
        {
            model.Id = CreatePatientLifeStyleParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <param name="updatedEntity">The patientlifestyleparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientLifeStyleParameter updatedEntity)
        {
            UpdatePatientLifeStyleParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <param name="updatedEntity">The patientlifestyleparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientLifeStyleParameter> updatedEntity)
        {
            PatchPatientLifeStyleParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientlifestyleparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientlifestyleparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientLifeStyleParameter(id);
            return true;
        }
        #region
        private List<PatientLifeStyleParameter> GetPatientLifeStyleParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientLifeStyleParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientLifeStyleParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientLifeStyleParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientLifeStyleParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientLifeStyleParameter(PatientLifeStyleParameter model)
        {
            _dbContext.PatientLifeStyleParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientLifeStyleParameter(Guid id, PatientLifeStyleParameter updatedEntity)
        {
            _dbContext.PatientLifeStyleParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientLifeStyleParameter(Guid id)
        {
            var entityData = _dbContext.PatientLifeStyleParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientLifeStyleParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientLifeStyleParameter(Guid id, JsonPatchDocument<PatientLifeStyleParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientLifeStyleParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientLifeStyleParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}