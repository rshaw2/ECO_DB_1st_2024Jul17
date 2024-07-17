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
    /// The visitchiefcomplaintnotesService responsible for managing visitchiefcomplaintnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitchiefcomplaintnotes information.
    /// </remarks>
    public interface IVisitChiefComplaintNotesService
    {
        /// <summary>Retrieves a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <returns>The visitchiefcomplaintnotes data</returns>
        VisitChiefComplaintNotes GetById(Guid id);

        /// <summary>Retrieves a list of visitchiefcomplaintnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitchiefcomplaintnotess</returns>
        List<VisitChiefComplaintNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitchiefcomplaintnotes</summary>
        /// <param name="model">The visitchiefcomplaintnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitChiefComplaintNotes model);

        /// <summary>Updates a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <param name="updatedEntity">The visitchiefcomplaintnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitChiefComplaintNotes updatedEntity);

        /// <summary>Updates a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <param name="updatedEntity">The visitchiefcomplaintnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitChiefComplaintNotes> updatedEntity);

        /// <summary>Deletes a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitchiefcomplaintnotesService responsible for managing visitchiefcomplaintnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitchiefcomplaintnotes information.
    /// </remarks>
    public class VisitChiefComplaintNotesService : IVisitChiefComplaintNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitChiefComplaintNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitChiefComplaintNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <returns>The visitchiefcomplaintnotes data</returns>
        public VisitChiefComplaintNotes GetById(Guid id)
        {
            var entityData = _dbContext.VisitChiefComplaintNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitchiefcomplaintnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitchiefcomplaintnotess</returns>/// <exception cref="Exception"></exception>
        public List<VisitChiefComplaintNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitChiefComplaintNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitchiefcomplaintnotes</summary>
        /// <param name="model">The visitchiefcomplaintnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitChiefComplaintNotes model)
        {
            model.Id = CreateVisitChiefComplaintNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <param name="updatedEntity">The visitchiefcomplaintnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitChiefComplaintNotes updatedEntity)
        {
            UpdateVisitChiefComplaintNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <param name="updatedEntity">The visitchiefcomplaintnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitChiefComplaintNotes> updatedEntity)
        {
            PatchVisitChiefComplaintNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitchiefcomplaintnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitchiefcomplaintnotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitChiefComplaintNotes(id);
            return true;
        }
        #region
        private List<VisitChiefComplaintNotes> GetVisitChiefComplaintNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitChiefComplaintNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitChiefComplaintNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitChiefComplaintNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitChiefComplaintNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitChiefComplaintNotes(VisitChiefComplaintNotes model)
        {
            _dbContext.VisitChiefComplaintNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitChiefComplaintNotes(Guid id, VisitChiefComplaintNotes updatedEntity)
        {
            _dbContext.VisitChiefComplaintNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitChiefComplaintNotes(Guid id)
        {
            var entityData = _dbContext.VisitChiefComplaintNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitChiefComplaintNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitChiefComplaintNotes(Guid id, JsonPatchDocument<VisitChiefComplaintNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitChiefComplaintNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitChiefComplaintNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}