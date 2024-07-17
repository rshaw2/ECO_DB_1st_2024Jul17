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
    /// The medicalcertificateordercounterService responsible for managing medicalcertificateordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalcertificateordercounter information.
    /// </remarks>
    public interface IMedicalCertificateOrderCounterService
    {
        /// <summary>Retrieves a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <returns>The medicalcertificateordercounter data</returns>
        MedicalCertificateOrderCounter GetById(Guid id);

        /// <summary>Retrieves a list of medicalcertificateordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalcertificateordercounters</returns>
        List<MedicalCertificateOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicalcertificateordercounter</summary>
        /// <param name="model">The medicalcertificateordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(MedicalCertificateOrderCounter model);

        /// <summary>Updates a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <param name="updatedEntity">The medicalcertificateordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicalCertificateOrderCounter updatedEntity);

        /// <summary>Updates a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <param name="updatedEntity">The medicalcertificateordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicalCertificateOrderCounter> updatedEntity);

        /// <summary>Deletes a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicalcertificateordercounterService responsible for managing medicalcertificateordercounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalcertificateordercounter information.
    /// </remarks>
    public class MedicalCertificateOrderCounterService : IMedicalCertificateOrderCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicalCertificateOrderCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicalCertificateOrderCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <returns>The medicalcertificateordercounter data</returns>
        public MedicalCertificateOrderCounter GetById(Guid id)
        {
            var entityData = _dbContext.MedicalCertificateOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicalcertificateordercounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalcertificateordercounters</returns>/// <exception cref="Exception"></exception>
        public List<MedicalCertificateOrderCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicalCertificateOrderCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicalcertificateordercounter</summary>
        /// <param name="model">The medicalcertificateordercounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(MedicalCertificateOrderCounter model)
        {
            model.TenantId = CreateMedicalCertificateOrderCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <param name="updatedEntity">The medicalcertificateordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicalCertificateOrderCounter updatedEntity)
        {
            UpdateMedicalCertificateOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <param name="updatedEntity">The medicalcertificateordercounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicalCertificateOrderCounter> updatedEntity)
        {
            PatchMedicalCertificateOrderCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicalcertificateordercounter by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificateordercounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicalCertificateOrderCounter(id);
            return true;
        }
        #region
        private List<MedicalCertificateOrderCounter> GetMedicalCertificateOrderCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicalCertificateOrderCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicalCertificateOrderCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicalCertificateOrderCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicalCertificateOrderCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateMedicalCertificateOrderCounter(MedicalCertificateOrderCounter model)
        {
            _dbContext.MedicalCertificateOrderCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateMedicalCertificateOrderCounter(Guid id, MedicalCertificateOrderCounter updatedEntity)
        {
            _dbContext.MedicalCertificateOrderCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicalCertificateOrderCounter(Guid id)
        {
            var entityData = _dbContext.MedicalCertificateOrderCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicalCertificateOrderCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicalCertificateOrderCounter(Guid id, JsonPatchDocument<MedicalCertificateOrderCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicalCertificateOrderCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicalCertificateOrderCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}