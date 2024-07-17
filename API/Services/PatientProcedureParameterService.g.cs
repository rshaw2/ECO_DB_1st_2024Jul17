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
    /// The patientprocedureparameterService responsible for managing patientprocedureparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientprocedureparameter information.
    /// </remarks>
    public interface IPatientProcedureParameterService
    {
        /// <summary>Retrieves a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <returns>The patientprocedureparameter data</returns>
        PatientProcedureParameter GetById(Guid id);

        /// <summary>Retrieves a list of patientprocedureparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientprocedureparameters</returns>
        List<PatientProcedureParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientprocedureparameter</summary>
        /// <param name="model">The patientprocedureparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientProcedureParameter model);

        /// <summary>Updates a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <param name="updatedEntity">The patientprocedureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientProcedureParameter updatedEntity);

        /// <summary>Updates a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <param name="updatedEntity">The patientprocedureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientProcedureParameter> updatedEntity);

        /// <summary>Deletes a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientprocedureparameterService responsible for managing patientprocedureparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientprocedureparameter information.
    /// </remarks>
    public class PatientProcedureParameterService : IPatientProcedureParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientProcedureParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientProcedureParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <returns>The patientprocedureparameter data</returns>
        public PatientProcedureParameter GetById(Guid id)
        {
            var entityData = _dbContext.PatientProcedureParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientprocedureparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientprocedureparameters</returns>/// <exception cref="Exception"></exception>
        public List<PatientProcedureParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientProcedureParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientprocedureparameter</summary>
        /// <param name="model">The patientprocedureparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientProcedureParameter model)
        {
            model.Id = CreatePatientProcedureParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <param name="updatedEntity">The patientprocedureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientProcedureParameter updatedEntity)
        {
            UpdatePatientProcedureParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <param name="updatedEntity">The patientprocedureparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientProcedureParameter> updatedEntity)
        {
            PatchPatientProcedureParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientprocedureparameter by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedureparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientProcedureParameter(id);
            return true;
        }
        #region
        private List<PatientProcedureParameter> GetPatientProcedureParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientProcedureParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientProcedureParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientProcedureParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientProcedureParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientProcedureParameter(PatientProcedureParameter model)
        {
            _dbContext.PatientProcedureParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientProcedureParameter(Guid id, PatientProcedureParameter updatedEntity)
        {
            _dbContext.PatientProcedureParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientProcedureParameter(Guid id)
        {
            var entityData = _dbContext.PatientProcedureParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientProcedureParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientProcedureParameter(Guid id, JsonPatchDocument<PatientProcedureParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientProcedureParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientProcedureParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}