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
    /// The dispensefileService responsible for managing dispensefile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dispensefile information.
    /// </remarks>
    public interface IDispenseFileService
    {
        /// <summary>Retrieves a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <returns>The dispensefile data</returns>
        DispenseFile GetById(Guid id);

        /// <summary>Retrieves a list of dispensefiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dispensefiles</returns>
        List<DispenseFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new dispensefile</summary>
        /// <param name="model">The dispensefile data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DispenseFile model);

        /// <summary>Updates a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <param name="updatedEntity">The dispensefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DispenseFile updatedEntity);

        /// <summary>Updates a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <param name="updatedEntity">The dispensefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DispenseFile> updatedEntity);

        /// <summary>Deletes a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The dispensefileService responsible for managing dispensefile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dispensefile information.
    /// </remarks>
    public class DispenseFileService : IDispenseFileService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DispenseFile class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DispenseFileService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <returns>The dispensefile data</returns>
        public DispenseFile GetById(Guid id)
        {
            var entityData = _dbContext.DispenseFile.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of dispensefiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dispensefiles</returns>/// <exception cref="Exception"></exception>
        public List<DispenseFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDispenseFile(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new dispensefile</summary>
        /// <param name="model">The dispensefile data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DispenseFile model)
        {
            model.Id = CreateDispenseFile(model);
            return model.Id;
        }

        /// <summary>Updates a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <param name="updatedEntity">The dispensefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DispenseFile updatedEntity)
        {
            UpdateDispenseFile(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <param name="updatedEntity">The dispensefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DispenseFile> updatedEntity)
        {
            PatchDispenseFile(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific dispensefile by its primary key</summary>
        /// <param name="id">The primary key of the dispensefile</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDispenseFile(id);
            return true;
        }
        #region
        private List<DispenseFile> GetDispenseFile(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DispenseFile.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DispenseFile>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DispenseFile), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DispenseFile, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDispenseFile(DispenseFile model)
        {
            _dbContext.DispenseFile.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDispenseFile(Guid id, DispenseFile updatedEntity)
        {
            _dbContext.DispenseFile.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDispenseFile(Guid id)
        {
            var entityData = _dbContext.DispenseFile.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DispenseFile.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDispenseFile(Guid id, JsonPatchDocument<DispenseFile> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DispenseFile.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DispenseFile.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}