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
    /// The unittypeService responsible for managing unittype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting unittype information.
    /// </remarks>
    public interface IUnitTypeService
    {
        /// <summary>Retrieves a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <returns>The unittype data</returns>
        UnitType GetById(Guid id);

        /// <summary>Retrieves a list of unittypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of unittypes</returns>
        List<UnitType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new unittype</summary>
        /// <param name="model">The unittype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(UnitType model);

        /// <summary>Updates a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <param name="updatedEntity">The unittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, UnitType updatedEntity);

        /// <summary>Updates a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <param name="updatedEntity">The unittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<UnitType> updatedEntity);

        /// <summary>Deletes a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The unittypeService responsible for managing unittype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting unittype information.
    /// </remarks>
    public class UnitTypeService : IUnitTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the UnitType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public UnitTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <returns>The unittype data</returns>
        public UnitType GetById(Guid id)
        {
            var entityData = _dbContext.UnitType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of unittypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of unittypes</returns>/// <exception cref="Exception"></exception>
        public List<UnitType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetUnitType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new unittype</summary>
        /// <param name="model">The unittype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(UnitType model)
        {
            model.Id = CreateUnitType(model);
            return model.Id;
        }

        /// <summary>Updates a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <param name="updatedEntity">The unittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, UnitType updatedEntity)
        {
            UpdateUnitType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <param name="updatedEntity">The unittype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<UnitType> updatedEntity)
        {
            PatchUnitType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific unittype by its primary key</summary>
        /// <param name="id">The primary key of the unittype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteUnitType(id);
            return true;
        }
        #region
        private List<UnitType> GetUnitType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.UnitType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<UnitType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(UnitType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<UnitType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateUnitType(UnitType model)
        {
            _dbContext.UnitType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateUnitType(Guid id, UnitType updatedEntity)
        {
            _dbContext.UnitType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteUnitType(Guid id)
        {
            var entityData = _dbContext.UnitType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.UnitType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchUnitType(Guid id, JsonPatchDocument<UnitType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.UnitType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.UnitType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}