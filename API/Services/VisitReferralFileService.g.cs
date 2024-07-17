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
    /// The visitreferralfileService responsible for managing visitreferralfile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitreferralfile information.
    /// </remarks>
    public interface IVisitReferralFileService
    {
        /// <summary>Retrieves a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <returns>The visitreferralfile data</returns>
        VisitReferralFile GetById(Guid id);

        /// <summary>Retrieves a list of visitreferralfiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitreferralfiles</returns>
        List<VisitReferralFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitreferralfile</summary>
        /// <param name="model">The visitreferralfile data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitReferralFile model);

        /// <summary>Updates a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <param name="updatedEntity">The visitreferralfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitReferralFile updatedEntity);

        /// <summary>Updates a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <param name="updatedEntity">The visitreferralfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitReferralFile> updatedEntity);

        /// <summary>Deletes a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitreferralfileService responsible for managing visitreferralfile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitreferralfile information.
    /// </remarks>
    public class VisitReferralFileService : IVisitReferralFileService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitReferralFile class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitReferralFileService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <returns>The visitreferralfile data</returns>
        public VisitReferralFile GetById(Guid id)
        {
            var entityData = _dbContext.VisitReferralFile.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitreferralfiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitreferralfiles</returns>/// <exception cref="Exception"></exception>
        public List<VisitReferralFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitReferralFile(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitreferralfile</summary>
        /// <param name="model">The visitreferralfile data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitReferralFile model)
        {
            model.Id = CreateVisitReferralFile(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <param name="updatedEntity">The visitreferralfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitReferralFile updatedEntity)
        {
            UpdateVisitReferralFile(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <param name="updatedEntity">The visitreferralfile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitReferralFile> updatedEntity)
        {
            PatchVisitReferralFile(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitreferralfile by its primary key</summary>
        /// <param name="id">The primary key of the visitreferralfile</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitReferralFile(id);
            return true;
        }
        #region
        private List<VisitReferralFile> GetVisitReferralFile(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitReferralFile.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitReferralFile>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitReferralFile), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitReferralFile, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitReferralFile(VisitReferralFile model)
        {
            _dbContext.VisitReferralFile.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitReferralFile(Guid id, VisitReferralFile updatedEntity)
        {
            _dbContext.VisitReferralFile.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitReferralFile(Guid id)
        {
            var entityData = _dbContext.VisitReferralFile.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitReferralFile.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitReferralFile(Guid id, JsonPatchDocument<VisitReferralFile> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitReferralFile.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitReferralFile.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}