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
    /// The visittypelocationService responsible for managing visittypelocation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittypelocation information.
    /// </remarks>
    public interface IVisitTypeLocationService
    {
        /// <summary>Retrieves a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <returns>The visittypelocation data</returns>
        VisitTypeLocation GetById(Guid id);

        /// <summary>Retrieves a list of visittypelocations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittypelocations</returns>
        List<VisitTypeLocation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visittypelocation</summary>
        /// <param name="model">The visittypelocation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitTypeLocation model);

        /// <summary>Updates a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <param name="updatedEntity">The visittypelocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitTypeLocation updatedEntity);

        /// <summary>Updates a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <param name="updatedEntity">The visittypelocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitTypeLocation> updatedEntity);

        /// <summary>Deletes a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visittypelocationService responsible for managing visittypelocation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visittypelocation information.
    /// </remarks>
    public class VisitTypeLocationService : IVisitTypeLocationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitTypeLocation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitTypeLocationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <returns>The visittypelocation data</returns>
        public VisitTypeLocation GetById(Guid id)
        {
            var entityData = _dbContext.VisitTypeLocation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visittypelocations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visittypelocations</returns>/// <exception cref="Exception"></exception>
        public List<VisitTypeLocation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitTypeLocation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visittypelocation</summary>
        /// <param name="model">The visittypelocation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitTypeLocation model)
        {
            model.Id = CreateVisitTypeLocation(model);
            return model.Id;
        }

        /// <summary>Updates a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <param name="updatedEntity">The visittypelocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitTypeLocation updatedEntity)
        {
            UpdateVisitTypeLocation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <param name="updatedEntity">The visittypelocation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitTypeLocation> updatedEntity)
        {
            PatchVisitTypeLocation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visittypelocation by its primary key</summary>
        /// <param name="id">The primary key of the visittypelocation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitTypeLocation(id);
            return true;
        }
        #region
        private List<VisitTypeLocation> GetVisitTypeLocation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitTypeLocation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitTypeLocation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitTypeLocation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitTypeLocation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitTypeLocation(VisitTypeLocation model)
        {
            _dbContext.VisitTypeLocation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitTypeLocation(Guid id, VisitTypeLocation updatedEntity)
        {
            _dbContext.VisitTypeLocation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitTypeLocation(Guid id)
        {
            var entityData = _dbContext.VisitTypeLocation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitTypeLocation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitTypeLocation(Guid id, JsonPatchDocument<VisitTypeLocation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitTypeLocation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitTypeLocation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}