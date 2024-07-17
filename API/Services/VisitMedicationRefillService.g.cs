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
    /// The visitmedicationrefillService responsible for managing visitmedicationrefill related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitmedicationrefill information.
    /// </remarks>
    public interface IVisitMedicationRefillService
    {
        /// <summary>Retrieves a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <returns>The visitmedicationrefill data</returns>
        VisitMedicationRefill GetById(Guid id);

        /// <summary>Retrieves a list of visitmedicationrefills based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitmedicationrefills</returns>
        List<VisitMedicationRefill> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitmedicationrefill</summary>
        /// <param name="model">The visitmedicationrefill data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitMedicationRefill model);

        /// <summary>Updates a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <param name="updatedEntity">The visitmedicationrefill data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitMedicationRefill updatedEntity);

        /// <summary>Updates a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <param name="updatedEntity">The visitmedicationrefill data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitMedicationRefill> updatedEntity);

        /// <summary>Deletes a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitmedicationrefillService responsible for managing visitmedicationrefill related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitmedicationrefill information.
    /// </remarks>
    public class VisitMedicationRefillService : IVisitMedicationRefillService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitMedicationRefill class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitMedicationRefillService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <returns>The visitmedicationrefill data</returns>
        public VisitMedicationRefill GetById(Guid id)
        {
            var entityData = _dbContext.VisitMedicationRefill.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitmedicationrefills based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitmedicationrefills</returns>/// <exception cref="Exception"></exception>
        public List<VisitMedicationRefill> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitMedicationRefill(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitmedicationrefill</summary>
        /// <param name="model">The visitmedicationrefill data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitMedicationRefill model)
        {
            model.Id = CreateVisitMedicationRefill(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <param name="updatedEntity">The visitmedicationrefill data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitMedicationRefill updatedEntity)
        {
            UpdateVisitMedicationRefill(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <param name="updatedEntity">The visitmedicationrefill data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitMedicationRefill> updatedEntity)
        {
            PatchVisitMedicationRefill(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitmedicationrefill by its primary key</summary>
        /// <param name="id">The primary key of the visitmedicationrefill</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitMedicationRefill(id);
            return true;
        }
        #region
        private List<VisitMedicationRefill> GetVisitMedicationRefill(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitMedicationRefill.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitMedicationRefill>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitMedicationRefill), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitMedicationRefill, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitMedicationRefill(VisitMedicationRefill model)
        {
            _dbContext.VisitMedicationRefill.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitMedicationRefill(Guid id, VisitMedicationRefill updatedEntity)
        {
            _dbContext.VisitMedicationRefill.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitMedicationRefill(Guid id)
        {
            var entityData = _dbContext.VisitMedicationRefill.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitMedicationRefill.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitMedicationRefill(Guid id, JsonPatchDocument<VisitMedicationRefill> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitMedicationRefill.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitMedicationRefill.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}