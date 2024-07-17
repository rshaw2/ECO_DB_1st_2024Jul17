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
    /// The visittypeService responsible for managing visittype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittype information.
    /// </remarks>
    public interface IVisitTypeService
    {
        /// <summary>Retrieves a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <returns>The visittype data</returns>
        VisitType GetById(Guid id);

        /// <summary>Retrieves a list of visittypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittypes</returns>
        List<VisitType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visittype</summary>
        /// <param name="model">The visittype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitType model);

        /// <summary>Updates a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <param name="updatedEntity">The visittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitType updatedEntity);

        /// <summary>Updates a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <param name="updatedEntity">The visittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitType> updatedEntity);

        /// <summary>Deletes a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visittypeService responsible for managing visittype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittype information.
    /// </remarks>
    public class VisitTypeService : IVisitTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <returns>The visittype data</returns>
        public VisitType GetById(Guid id)
        {
            var entityData = _dbContext.VisitType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visittypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittypes</returns>/// <exception cref="Exception"></exception>
        public List<VisitType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visittype</summary>
        /// <param name="model">The visittype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitType model)
        {
            model.Id = CreateVisitType(model);
            return model.Id;
        }

        /// <summary>Updates a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <param name="updatedEntity">The visittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitType updatedEntity)
        {
            UpdateVisitType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <param name="updatedEntity">The visittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitType> updatedEntity)
        {
            PatchVisitType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visittype by its primary key</summary>
        /// <param name="id">The primary key of the visittype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitType(id);
            return true;
        }
        #region
        private List<VisitType> GetVisitType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitType(VisitType model)
        {
            _dbContext.VisitType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitType(Guid id, VisitType updatedEntity)
        {
            _dbContext.VisitType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitType(Guid id)
        {
            var entityData = _dbContext.VisitType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitType(Guid id, JsonPatchDocument<VisitType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}