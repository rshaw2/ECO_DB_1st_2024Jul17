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
    /// The patientprocedureService responsible for managing patientprocedure related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientprocedure information.
    /// </remarks>
    public interface IPatientProcedureService
    {
        /// <summary>Retrieves a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <returns>The patientprocedure data</returns>
        PatientProcedure GetById(Guid id);

        /// <summary>Retrieves a list of patientprocedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientprocedures</returns>
        List<PatientProcedure> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientprocedure</summary>
        /// <param name="model">The patientprocedure data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientProcedure model);

        /// <summary>Updates a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <param name="updatedEntity">The patientprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientProcedure updatedEntity);

        /// <summary>Updates a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <param name="updatedEntity">The patientprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientProcedure> updatedEntity);

        /// <summary>Deletes a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientprocedureService responsible for managing patientprocedure related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientprocedure information.
    /// </remarks>
    public class PatientProcedureService : IPatientProcedureService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientProcedure class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientProcedureService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <returns>The patientprocedure data</returns>
        public PatientProcedure GetById(Guid id)
        {
            var entityData = _dbContext.PatientProcedure.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientprocedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientprocedures</returns>/// <exception cref="Exception"></exception>
        public List<PatientProcedure> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientProcedure(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientprocedure</summary>
        /// <param name="model">The patientprocedure data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientProcedure model)
        {
            model.Id = CreatePatientProcedure(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <param name="updatedEntity">The patientprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientProcedure updatedEntity)
        {
            UpdatePatientProcedure(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <param name="updatedEntity">The patientprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientProcedure> updatedEntity)
        {
            PatchPatientProcedure(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientprocedure by its primary key</summary>
        /// <param name="id">The primary key of the patientprocedure</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientProcedure(id);
            return true;
        }
        #region
        private List<PatientProcedure> GetPatientProcedure(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientProcedure.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientProcedure>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientProcedure), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientProcedure, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientProcedure(PatientProcedure model)
        {
            _dbContext.PatientProcedure.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientProcedure(Guid id, PatientProcedure updatedEntity)
        {
            _dbContext.PatientProcedure.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientProcedure(Guid id)
        {
            var entityData = _dbContext.PatientProcedure.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientProcedure.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientProcedure(Guid id, JsonPatchDocument<PatientProcedure> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientProcedure.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientProcedure.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}