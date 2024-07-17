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
    /// The patientcommunicationService responsible for managing patientcommunication related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientcommunication information.
    /// </remarks>
    public interface IPatientCommunicationService
    {
        /// <summary>Retrieves a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <returns>The patientcommunication data</returns>
        PatientCommunication GetById(Guid id);

        /// <summary>Retrieves a list of patientcommunications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientcommunications</returns>
        List<PatientCommunication> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientcommunication</summary>
        /// <param name="model">The patientcommunication data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientCommunication model);

        /// <summary>Updates a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <param name="updatedEntity">The patientcommunication data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientCommunication updatedEntity);

        /// <summary>Updates a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <param name="updatedEntity">The patientcommunication data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientCommunication> updatedEntity);

        /// <summary>Deletes a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientcommunicationService responsible for managing patientcommunication related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientcommunication information.
    /// </remarks>
    public class PatientCommunicationService : IPatientCommunicationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientCommunication class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientCommunicationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <returns>The patientcommunication data</returns>
        public PatientCommunication GetById(Guid id)
        {
            var entityData = _dbContext.PatientCommunication.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientcommunications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientcommunications</returns>/// <exception cref="Exception"></exception>
        public List<PatientCommunication> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientCommunication(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientcommunication</summary>
        /// <param name="model">The patientcommunication data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientCommunication model)
        {
            model.Id = CreatePatientCommunication(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <param name="updatedEntity">The patientcommunication data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientCommunication updatedEntity)
        {
            UpdatePatientCommunication(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <param name="updatedEntity">The patientcommunication data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientCommunication> updatedEntity)
        {
            PatchPatientCommunication(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientcommunication by its primary key</summary>
        /// <param name="id">The primary key of the patientcommunication</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientCommunication(id);
            return true;
        }
        #region
        private List<PatientCommunication> GetPatientCommunication(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientCommunication.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientCommunication>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientCommunication), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientCommunication, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientCommunication(PatientCommunication model)
        {
            _dbContext.PatientCommunication.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientCommunication(Guid id, PatientCommunication updatedEntity)
        {
            _dbContext.PatientCommunication.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientCommunication(Guid id)
        {
            var entityData = _dbContext.PatientCommunication.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientCommunication.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientCommunication(Guid id, JsonPatchDocument<PatientCommunication> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientCommunication.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientCommunication.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}