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
    /// The visitclinicalprintablenotesService responsible for managing visitclinicalprintablenotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitclinicalprintablenotes information.
    /// </remarks>
    public interface IVisitClinicalPrintableNotesService
    {
        /// <summary>Retrieves a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <returns>The visitclinicalprintablenotes data</returns>
        VisitClinicalPrintableNotes GetById(Guid id);

        /// <summary>Retrieves a list of visitclinicalprintablenotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitclinicalprintablenotess</returns>
        List<VisitClinicalPrintableNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitclinicalprintablenotes</summary>
        /// <param name="model">The visitclinicalprintablenotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitClinicalPrintableNotes model);

        /// <summary>Updates a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <param name="updatedEntity">The visitclinicalprintablenotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitClinicalPrintableNotes updatedEntity);

        /// <summary>Updates a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <param name="updatedEntity">The visitclinicalprintablenotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitClinicalPrintableNotes> updatedEntity);

        /// <summary>Deletes a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitclinicalprintablenotesService responsible for managing visitclinicalprintablenotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitclinicalprintablenotes information.
    /// </remarks>
    public class VisitClinicalPrintableNotesService : IVisitClinicalPrintableNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitClinicalPrintableNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitClinicalPrintableNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <returns>The visitclinicalprintablenotes data</returns>
        public VisitClinicalPrintableNotes GetById(Guid id)
        {
            var entityData = _dbContext.VisitClinicalPrintableNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitclinicalprintablenotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitclinicalprintablenotess</returns>/// <exception cref="Exception"></exception>
        public List<VisitClinicalPrintableNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitClinicalPrintableNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitclinicalprintablenotes</summary>
        /// <param name="model">The visitclinicalprintablenotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitClinicalPrintableNotes model)
        {
            model.Id = CreateVisitClinicalPrintableNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <param name="updatedEntity">The visitclinicalprintablenotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitClinicalPrintableNotes updatedEntity)
        {
            UpdateVisitClinicalPrintableNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <param name="updatedEntity">The visitclinicalprintablenotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitClinicalPrintableNotes> updatedEntity)
        {
            PatchVisitClinicalPrintableNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitclinicalprintablenotes by its primary key</summary>
        /// <param name="id">The primary key of the visitclinicalprintablenotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitClinicalPrintableNotes(id);
            return true;
        }
        #region
        private List<VisitClinicalPrintableNotes> GetVisitClinicalPrintableNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitClinicalPrintableNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitClinicalPrintableNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitClinicalPrintableNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitClinicalPrintableNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitClinicalPrintableNotes(VisitClinicalPrintableNotes model)
        {
            _dbContext.VisitClinicalPrintableNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitClinicalPrintableNotes(Guid id, VisitClinicalPrintableNotes updatedEntity)
        {
            _dbContext.VisitClinicalPrintableNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitClinicalPrintableNotes(Guid id)
        {
            var entityData = _dbContext.VisitClinicalPrintableNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitClinicalPrintableNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitClinicalPrintableNotes(Guid id, JsonPatchDocument<VisitClinicalPrintableNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitClinicalPrintableNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitClinicalPrintableNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}