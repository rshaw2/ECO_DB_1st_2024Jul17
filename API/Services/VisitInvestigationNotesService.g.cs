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
    /// The visitinvestigationnotesService responsible for managing visitinvestigationnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationnotes information.
    /// </remarks>
    public interface IVisitInvestigationNotesService
    {
        /// <summary>Retrieves a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <returns>The visitinvestigationnotes data</returns>
        VisitInvestigationNotes GetById(Guid id);

        /// <summary>Retrieves a list of visitinvestigationnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationnotess</returns>
        List<VisitInvestigationNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitinvestigationnotes</summary>
        /// <param name="model">The visitinvestigationnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitInvestigationNotes model);

        /// <summary>Updates a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <param name="updatedEntity">The visitinvestigationnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitInvestigationNotes updatedEntity);

        /// <summary>Updates a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <param name="updatedEntity">The visitinvestigationnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitInvestigationNotes> updatedEntity);

        /// <summary>Deletes a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitinvestigationnotesService responsible for managing visitinvestigationnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitinvestigationnotes information.
    /// </remarks>
    public class VisitInvestigationNotesService : IVisitInvestigationNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitInvestigationNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitInvestigationNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <returns>The visitinvestigationnotes data</returns>
        public VisitInvestigationNotes GetById(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitinvestigationnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitinvestigationnotess</returns>/// <exception cref="Exception"></exception>
        public List<VisitInvestigationNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitInvestigationNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitinvestigationnotes</summary>
        /// <param name="model">The visitinvestigationnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitInvestigationNotes model)
        {
            model.Id = CreateVisitInvestigationNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <param name="updatedEntity">The visitinvestigationnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitInvestigationNotes updatedEntity)
        {
            UpdateVisitInvestigationNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <param name="updatedEntity">The visitinvestigationnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitInvestigationNotes> updatedEntity)
        {
            PatchVisitInvestigationNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitinvestigationnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitinvestigationnotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitInvestigationNotes(id);
            return true;
        }
        #region
        private List<VisitInvestigationNotes> GetVisitInvestigationNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitInvestigationNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitInvestigationNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitInvestigationNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitInvestigationNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitInvestigationNotes(VisitInvestigationNotes model)
        {
            _dbContext.VisitInvestigationNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitInvestigationNotes(Guid id, VisitInvestigationNotes updatedEntity)
        {
            _dbContext.VisitInvestigationNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitInvestigationNotes(Guid id)
        {
            var entityData = _dbContext.VisitInvestigationNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitInvestigationNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitInvestigationNotes(Guid id, JsonPatchDocument<VisitInvestigationNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitInvestigationNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitInvestigationNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}