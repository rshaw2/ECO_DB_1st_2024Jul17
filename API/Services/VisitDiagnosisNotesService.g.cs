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
    /// The visitdiagnosisnotesService responsible for managing visitdiagnosisnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitdiagnosisnotes information.
    /// </remarks>
    public interface IVisitDiagnosisNotesService
    {
        /// <summary>Retrieves a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <returns>The visitdiagnosisnotes data</returns>
        VisitDiagnosisNotes GetById(Guid id);

        /// <summary>Retrieves a list of visitdiagnosisnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitdiagnosisnotess</returns>
        List<VisitDiagnosisNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitdiagnosisnotes</summary>
        /// <param name="model">The visitdiagnosisnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitDiagnosisNotes model);

        /// <summary>Updates a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <param name="updatedEntity">The visitdiagnosisnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitDiagnosisNotes updatedEntity);

        /// <summary>Updates a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <param name="updatedEntity">The visitdiagnosisnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitDiagnosisNotes> updatedEntity);

        /// <summary>Deletes a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitdiagnosisnotesService responsible for managing visitdiagnosisnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitdiagnosisnotes information.
    /// </remarks>
    public class VisitDiagnosisNotesService : IVisitDiagnosisNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitDiagnosisNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitDiagnosisNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <returns>The visitdiagnosisnotes data</returns>
        public VisitDiagnosisNotes GetById(Guid id)
        {
            var entityData = _dbContext.VisitDiagnosisNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitdiagnosisnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitdiagnosisnotess</returns>/// <exception cref="Exception"></exception>
        public List<VisitDiagnosisNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitDiagnosisNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitdiagnosisnotes</summary>
        /// <param name="model">The visitdiagnosisnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitDiagnosisNotes model)
        {
            model.Id = CreateVisitDiagnosisNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <param name="updatedEntity">The visitdiagnosisnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitDiagnosisNotes updatedEntity)
        {
            UpdateVisitDiagnosisNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <param name="updatedEntity">The visitdiagnosisnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitDiagnosisNotes> updatedEntity)
        {
            PatchVisitDiagnosisNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitdiagnosisnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitdiagnosisnotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitDiagnosisNotes(id);
            return true;
        }
        #region
        private List<VisitDiagnosisNotes> GetVisitDiagnosisNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitDiagnosisNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitDiagnosisNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitDiagnosisNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitDiagnosisNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitDiagnosisNotes(VisitDiagnosisNotes model)
        {
            _dbContext.VisitDiagnosisNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitDiagnosisNotes(Guid id, VisitDiagnosisNotes updatedEntity)
        {
            _dbContext.VisitDiagnosisNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitDiagnosisNotes(Guid id)
        {
            var entityData = _dbContext.VisitDiagnosisNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitDiagnosisNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitDiagnosisNotes(Guid id, JsonPatchDocument<VisitDiagnosisNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitDiagnosisNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitDiagnosisNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}