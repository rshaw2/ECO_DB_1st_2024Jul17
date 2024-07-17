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
    /// The patientpayorService responsible for managing patientpayor related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientpayor information.
    /// </remarks>
    public interface IPatientPayorService
    {
        /// <summary>Retrieves a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <returns>The patientpayor data</returns>
        PatientPayor GetById(Guid id);

        /// <summary>Retrieves a list of patientpayors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientpayors</returns>
        List<PatientPayor> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientpayor</summary>
        /// <param name="model">The patientpayor data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientPayor model);

        /// <summary>Updates a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <param name="updatedEntity">The patientpayor data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientPayor updatedEntity);

        /// <summary>Updates a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <param name="updatedEntity">The patientpayor data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientPayor> updatedEntity);

        /// <summary>Deletes a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientpayorService responsible for managing patientpayor related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientpayor information.
    /// </remarks>
    public class PatientPayorService : IPatientPayorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientPayor class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientPayorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <returns>The patientpayor data</returns>
        public PatientPayor GetById(Guid id)
        {
            var entityData = _dbContext.PatientPayor.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientpayors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientpayors</returns>/// <exception cref="Exception"></exception>
        public List<PatientPayor> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientPayor(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientpayor</summary>
        /// <param name="model">The patientpayor data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientPayor model)
        {
            model.Id = CreatePatientPayor(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <param name="updatedEntity">The patientpayor data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientPayor updatedEntity)
        {
            UpdatePatientPayor(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <param name="updatedEntity">The patientpayor data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientPayor> updatedEntity)
        {
            PatchPatientPayor(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientpayor by its primary key</summary>
        /// <param name="id">The primary key of the patientpayor</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientPayor(id);
            return true;
        }
        #region
        private List<PatientPayor> GetPatientPayor(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientPayor.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientPayor>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientPayor), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientPayor, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientPayor(PatientPayor model)
        {
            _dbContext.PatientPayor.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientPayor(Guid id, PatientPayor updatedEntity)
        {
            _dbContext.PatientPayor.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientPayor(Guid id)
        {
            var entityData = _dbContext.PatientPayor.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientPayor.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientPayor(Guid id, JsonPatchDocument<PatientPayor> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientPayor.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientPayor.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}