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
    /// The visitmedicationService responsible for managing visitmedication related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitmedication information.
    /// </remarks>
    public interface IVisitMedicationService
    {
        /// <summary>Retrieves a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <returns>The visitmedication data</returns>
        VisitMedication GetById(Guid id);

        /// <summary>Retrieves a list of visitmedications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitmedications</returns>
        List<VisitMedication> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitmedication</summary>
        /// <param name="model">The visitmedication data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitMedication model);

        /// <summary>Updates a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <param name="updatedEntity">The visitmedication data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitMedication updatedEntity);

        /// <summary>Updates a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <param name="updatedEntity">The visitmedication data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitMedication> updatedEntity);

        /// <summary>Deletes a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitmedicationService responsible for managing visitmedication related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitmedication information.
    /// </remarks>
    public class VisitMedicationService : IVisitMedicationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitMedication class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitMedicationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <returns>The visitmedication data</returns>
        public VisitMedication GetById(Guid id)
        {
            var entityData = _dbContext.VisitMedication.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitmedications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitmedications</returns>/// <exception cref="Exception"></exception>
        public List<VisitMedication> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitMedication(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitmedication</summary>
        /// <param name="model">The visitmedication data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitMedication model)
        {
            model.Id = CreateVisitMedication(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <param name="updatedEntity">The visitmedication data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitMedication updatedEntity)
        {
            UpdateVisitMedication(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <param name="updatedEntity">The visitmedication data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitMedication> updatedEntity)
        {
            PatchVisitMedication(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitmedication by its primary key</summary>
        /// <param name="id">The primary key of the visitmedication</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitMedication(id);
            return true;
        }
        #region
        private List<VisitMedication> GetVisitMedication(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitMedication.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitMedication>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitMedication), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitMedication, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitMedication(VisitMedication model)
        {
            _dbContext.VisitMedication.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitMedication(Guid id, VisitMedication updatedEntity)
        {
            _dbContext.VisitMedication.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitMedication(Guid id)
        {
            var entityData = _dbContext.VisitMedication.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitMedication.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitMedication(Guid id, JsonPatchDocument<VisitMedication> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitMedication.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitMedication.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}