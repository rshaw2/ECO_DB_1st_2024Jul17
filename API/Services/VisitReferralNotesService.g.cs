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
    /// The visitreferralnotesService responsible for managing visitreferralnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitreferralnotes information.
    /// </remarks>
    public interface IVisitReferralNotesService
    {
        /// <summary>Retrieves a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <returns>The visitreferralnotes data</returns>
        VisitReferralNotes GetById(Guid id);

        /// <summary>Retrieves a list of visitreferralnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitreferralnotess</returns>
        List<VisitReferralNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitreferralnotes</summary>
        /// <param name="model">The visitreferralnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitReferralNotes model);

        /// <summary>Updates a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <param name="updatedEntity">The visitreferralnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitReferralNotes updatedEntity);

        /// <summary>Updates a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <param name="updatedEntity">The visitreferralnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitReferralNotes> updatedEntity);

        /// <summary>Deletes a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitreferralnotesService responsible for managing visitreferralnotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitreferralnotes information.
    /// </remarks>
    public class VisitReferralNotesService : IVisitReferralNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitReferralNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitReferralNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <returns>The visitreferralnotes data</returns>
        public VisitReferralNotes GetById(Guid id)
        {
            var entityData = _dbContext.VisitReferralNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitreferralnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitreferralnotess</returns>/// <exception cref="Exception"></exception>
        public List<VisitReferralNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitReferralNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitreferralnotes</summary>
        /// <param name="model">The visitreferralnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitReferralNotes model)
        {
            model.Id = CreateVisitReferralNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <param name="updatedEntity">The visitreferralnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitReferralNotes updatedEntity)
        {
            UpdateVisitReferralNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <param name="updatedEntity">The visitreferralnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitReferralNotes> updatedEntity)
        {
            PatchVisitReferralNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitreferralnotes by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralnotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitReferralNotes(id);
            return true;
        }
        #region
        private List<VisitReferralNotes> GetVisitReferralNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitReferralNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitReferralNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitReferralNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitReferralNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitReferralNotes(VisitReferralNotes model)
        {
            _dbContext.VisitReferralNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitReferralNotes(Guid id, VisitReferralNotes updatedEntity)
        {
            _dbContext.VisitReferralNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitReferralNotes(Guid id)
        {
            var entityData = _dbContext.VisitReferralNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitReferralNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitReferralNotes(Guid id, JsonPatchDocument<VisitReferralNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitReferralNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitReferralNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}