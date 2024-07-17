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
    /// The globaluserService responsible for managing globaluser related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting globaluser information.
    /// </remarks>
    public interface IGlobalUserService
    {
        /// <summary>Retrieves a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <returns>The globaluser data</returns>
        GlobalUser GetById(Guid id);

        /// <summary>Retrieves a list of globalusers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of globalusers</returns>
        List<GlobalUser> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new globaluser</summary>
        /// <param name="model">The globaluser data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GlobalUser model);

        /// <summary>Updates a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <param name="updatedEntity">The globaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GlobalUser updatedEntity);

        /// <summary>Updates a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <param name="updatedEntity">The globaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GlobalUser> updatedEntity);

        /// <summary>Deletes a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The globaluserService responsible for managing globaluser related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting globaluser information.
    /// </remarks>
    public class GlobalUserService : IGlobalUserService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GlobalUser class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GlobalUserService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <returns>The globaluser data</returns>
        public GlobalUser GetById(Guid id)
        {
            var entityData = _dbContext.GlobalUser.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of globalusers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of globalusers</returns>/// <exception cref="Exception"></exception>
        public List<GlobalUser> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGlobalUser(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new globaluser</summary>
        /// <param name="model">The globaluser data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GlobalUser model)
        {
            model.Id = CreateGlobalUser(model);
            return model.Id;
        }

        /// <summary>Updates a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <param name="updatedEntity">The globaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GlobalUser updatedEntity)
        {
            UpdateGlobalUser(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <param name="updatedEntity">The globaluser data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GlobalUser> updatedEntity)
        {
            PatchGlobalUser(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific globaluser by its primary key</summary>
        /// <param name="id">The primary key of the globaluser</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGlobalUser(id);
            return true;
        }
        #region
        private List<GlobalUser> GetGlobalUser(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GlobalUser.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GlobalUser>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GlobalUser), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GlobalUser, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGlobalUser(GlobalUser model)
        {
            _dbContext.GlobalUser.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGlobalUser(Guid id, GlobalUser updatedEntity)
        {
            _dbContext.GlobalUser.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGlobalUser(Guid id)
        {
            var entityData = _dbContext.GlobalUser.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GlobalUser.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGlobalUser(Guid id, JsonPatchDocument<GlobalUser> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GlobalUser.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GlobalUser.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}