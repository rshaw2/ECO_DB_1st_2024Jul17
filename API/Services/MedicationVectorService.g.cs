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
    /// The medicationvectorService responsible for managing medicationvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationvector information.
    /// </remarks>
    public interface IMedicationVectorService
    {
        /// <summary>Retrieves a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <returns>The medicationvector data</returns>
        MedicationVector GetById(Guid id);

        /// <summary>Retrieves a list of medicationvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationvectors</returns>
        List<MedicationVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationvector</summary>
        /// <param name="model">The medicationvector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationVector model);

        /// <summary>Updates a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <param name="updatedEntity">The medicationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationVector updatedEntity);

        /// <summary>Updates a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <param name="updatedEntity">The medicationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationVector> updatedEntity);

        /// <summary>Deletes a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationvectorService responsible for managing medicationvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationvector information.
    /// </remarks>
    public class MedicationVectorService : IMedicationVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <returns>The medicationvector data</returns>
        public MedicationVector GetById(Guid id)
        {
            var entityData = _dbContext.MedicationVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationvectors</returns>/// <exception cref="Exception"></exception>
        public List<MedicationVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationvector</summary>
        /// <param name="model">The medicationvector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationVector model)
        {
            model.Id = CreateMedicationVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <param name="updatedEntity">The medicationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationVector updatedEntity)
        {
            UpdateMedicationVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <param name="updatedEntity">The medicationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationVector> updatedEntity)
        {
            PatchMedicationVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationvector by its primary key</summary>
        /// <param name="id">The primary key of the medicationvector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationVector(id);
            return true;
        }
        #region
        private List<MedicationVector> GetMedicationVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationVector(MedicationVector model)
        {
            _dbContext.MedicationVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationVector(Guid id, MedicationVector updatedEntity)
        {
            _dbContext.MedicationVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationVector(Guid id)
        {
            var entityData = _dbContext.MedicationVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationVector(Guid id, JsonPatchDocument<MedicationVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}