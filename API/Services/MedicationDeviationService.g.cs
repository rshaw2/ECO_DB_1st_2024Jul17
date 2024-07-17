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
    /// The medicationdeviationService responsible for managing medicationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationdeviation information.
    /// </remarks>
    public interface IMedicationDeviationService
    {
        /// <summary>Retrieves a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <returns>The medicationdeviation data</returns>
        MedicationDeviation GetById(Guid id);

        /// <summary>Retrieves a list of medicationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationdeviations</returns>
        List<MedicationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationdeviation</summary>
        /// <param name="model">The medicationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationDeviation model);

        /// <summary>Updates a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <param name="updatedEntity">The medicationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationDeviation updatedEntity);

        /// <summary>Updates a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <param name="updatedEntity">The medicationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationDeviation> updatedEntity);

        /// <summary>Deletes a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationdeviationService responsible for managing medicationdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationdeviation information.
    /// </remarks>
    public class MedicationDeviationService : IMedicationDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <returns>The medicationdeviation data</returns>
        public MedicationDeviation GetById(Guid id)
        {
            var entityData = _dbContext.MedicationDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationdeviations</returns>/// <exception cref="Exception"></exception>
        public List<MedicationDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationdeviation</summary>
        /// <param name="model">The medicationdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationDeviation model)
        {
            model.Id = CreateMedicationDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <param name="updatedEntity">The medicationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationDeviation updatedEntity)
        {
            UpdateMedicationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <param name="updatedEntity">The medicationdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationDeviation> updatedEntity)
        {
            PatchMedicationDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationdeviation by its primary key</summary>
        /// <param name="id">The primary key of the medicationdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationDeviation(id);
            return true;
        }
        #region
        private List<MedicationDeviation> GetMedicationDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationDeviation(MedicationDeviation model)
        {
            _dbContext.MedicationDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationDeviation(Guid id, MedicationDeviation updatedEntity)
        {
            _dbContext.MedicationDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationDeviation(Guid id)
        {
            var entityData = _dbContext.MedicationDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationDeviation(Guid id, JsonPatchDocument<MedicationDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}