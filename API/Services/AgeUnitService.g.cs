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
    /// The ageunitService responsible for managing ageunit related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting ageunit information.
    /// </remarks>
    public interface IAgeUnitService
    {
        /// <summary>Retrieves a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <returns>The ageunit data</returns>
        AgeUnit GetById(Guid id);

        /// <summary>Retrieves a list of ageunits based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of ageunits</returns>
        List<AgeUnit> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new ageunit</summary>
        /// <param name="model">The ageunit data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AgeUnit model);

        /// <summary>Updates a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <param name="updatedEntity">The ageunit data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AgeUnit updatedEntity);

        /// <summary>Updates a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <param name="updatedEntity">The ageunit data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AgeUnit> updatedEntity);

        /// <summary>Deletes a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The ageunitService responsible for managing ageunit related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting ageunit information.
    /// </remarks>
    public class AgeUnitService : IAgeUnitService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AgeUnit class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AgeUnitService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <returns>The ageunit data</returns>
        public AgeUnit GetById(Guid id)
        {
            var entityData = _dbContext.AgeUnit.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of ageunits based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of ageunits</returns>/// <exception cref="Exception"></exception>
        public List<AgeUnit> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAgeUnit(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new ageunit</summary>
        /// <param name="model">The ageunit data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AgeUnit model)
        {
            model.Id = CreateAgeUnit(model);
            return model.Id;
        }

        /// <summary>Updates a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <param name="updatedEntity">The ageunit data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AgeUnit updatedEntity)
        {
            UpdateAgeUnit(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <param name="updatedEntity">The ageunit data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AgeUnit> updatedEntity)
        {
            PatchAgeUnit(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific ageunit by its primary key</summary>
        /// <param name="id">The primary key of the ageunit</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAgeUnit(id);
            return true;
        }
        #region
        private List<AgeUnit> GetAgeUnit(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AgeUnit.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AgeUnit>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AgeUnit), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AgeUnit, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAgeUnit(AgeUnit model)
        {
            _dbContext.AgeUnit.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAgeUnit(Guid id, AgeUnit updatedEntity)
        {
            _dbContext.AgeUnit.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAgeUnit(Guid id)
        {
            var entityData = _dbContext.AgeUnit.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AgeUnit.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAgeUnit(Guid id, JsonPatchDocument<AgeUnit> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AgeUnit.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AgeUnit.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}