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
    /// The visitclinicalinternalnotesService responsible for managing visitclinicalinternalnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitclinicalinternalnotes information.
    /// </remarks>
    public interface IVisitClinicalInternalNotesService
    {
        /// <summary>Retrieves a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <returns>The visitclinicalinternalnotes data</returns>
        VisitClinicalInternalNotes GetById(Guid id);

        /// <summary>Retrieves a list of visitclinicalinternalnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitclinicalinternalnotess</returns>
        List<VisitClinicalInternalNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitclinicalinternalnotes</summary>
        /// <param name="model">The visitclinicalinternalnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitClinicalInternalNotes model);

        /// <summary>Updates a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <param name="updatedEntity">The visitclinicalinternalnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitClinicalInternalNotes updatedEntity);

        /// <summary>Updates a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <param name="updatedEntity">The visitclinicalinternalnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitClinicalInternalNotes> updatedEntity);

        /// <summary>Deletes a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitclinicalinternalnotesService responsible for managing visitclinicalinternalnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitclinicalinternalnotes information.
    /// </remarks>
    public class VisitClinicalInternalNotesService : IVisitClinicalInternalNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitClinicalInternalNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitClinicalInternalNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <returns>The visitclinicalinternalnotes data</returns>
        public VisitClinicalInternalNotes GetById(Guid id)
        {
            var entityData = _dbContext.VisitClinicalInternalNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitclinicalinternalnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitclinicalinternalnotess</returns>/// <exception cref="Exception"></exception>
        public List<VisitClinicalInternalNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitClinicalInternalNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitclinicalinternalnotes</summary>
        /// <param name="model">The visitclinicalinternalnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitClinicalInternalNotes model)
        {
            model.Id = CreateVisitClinicalInternalNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <param name="updatedEntity">The visitclinicalinternalnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitClinicalInternalNotes updatedEntity)
        {
            UpdateVisitClinicalInternalNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <param name="updatedEntity">The visitclinicalinternalnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitClinicalInternalNotes> updatedEntity)
        {
            PatchVisitClinicalInternalNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitclinicalinternalnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalinternalnotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitClinicalInternalNotes(id);
            return true;
        }
        #region
        private List<VisitClinicalInternalNotes> GetVisitClinicalInternalNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitClinicalInternalNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitClinicalInternalNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitClinicalInternalNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitClinicalInternalNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitClinicalInternalNotes(VisitClinicalInternalNotes model)
        {
            _dbContext.VisitClinicalInternalNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitClinicalInternalNotes(Guid id, VisitClinicalInternalNotes updatedEntity)
        {
            _dbContext.VisitClinicalInternalNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitClinicalInternalNotes(Guid id)
        {
            var entityData = _dbContext.VisitClinicalInternalNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitClinicalInternalNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitClinicalInternalNotes(Guid id, JsonPatchDocument<VisitClinicalInternalNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitClinicalInternalNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitClinicalInternalNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}