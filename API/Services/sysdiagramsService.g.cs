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
    /// The sysdiagramsService responsible for managing sysdiagrams related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting sysdiagrams information.
    /// </remarks>
    public interface IsysdiagramsService
    {
        /// <summary>Retrieves a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <returns>The sysdiagrams data</returns>
        sysdiagrams GetById(int id);

        /// <summary>Retrieves a list of sysdiagramss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of sysdiagramss</returns>
        List<sysdiagrams> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new sysdiagrams</summary>
        /// <param name="model">The sysdiagrams data to be added</param>
        /// <returns>The result of the operation</returns>
        int Create(sysdiagrams model);

        /// <summary>Updates a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <param name="updatedEntity">The sysdiagrams data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(int id, sysdiagrams updatedEntity);

        /// <summary>Updates a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <param name="updatedEntity">The sysdiagrams data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(int id, JsonPatchDocument<sysdiagrams> updatedEntity);

        /// <summary>Deletes a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <returns>The result of the operation</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// The sysdiagramsService responsible for managing sysdiagrams related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting sysdiagrams information.
    /// </remarks>
    public class sysdiagramsService : IsysdiagramsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the sysdiagrams class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public sysdiagramsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <returns>The sysdiagrams data</returns>
        public sysdiagrams GetById(int id)
        {
            var entityData = _dbContext.sysdiagrams.FirstOrDefault(entity => entity.diagram_id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of sysdiagramss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of sysdiagramss</returns>/// <exception cref="Exception"></exception>
        public List<sysdiagrams> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = Getsysdiagrams(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new sysdiagrams</summary>
        /// <param name="model">The sysdiagrams data to be added</param>
        /// <returns>The result of the operation</returns>
        public int Create(sysdiagrams model)
        {
            model.diagram_id = Createsysdiagrams(model);
            return model.diagram_id;
        }

        /// <summary>Updates a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <param name="updatedEntity">The sysdiagrams data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(int id, sysdiagrams updatedEntity)
        {
            Updatesysdiagrams(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <param name="updatedEntity">The sysdiagrams data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(int id, JsonPatchDocument<sysdiagrams> updatedEntity)
        {
            Patchsysdiagrams(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific sysdiagrams by its primary key</summary>
        /// <param name="id">The primary key of the sysdiagrams</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            Deletesysdiagrams(id);
            return true;
        }
        #region
        private List<sysdiagrams> Getsysdiagrams(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.sysdiagrams.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<sysdiagrams>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(sysdiagrams), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<sysdiagrams, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private int Createsysdiagrams(sysdiagrams model)
        {
            _dbContext.sysdiagrams.Add(model);
            _dbContext.SaveChanges();
            return model.diagram_id;
        }

        private void Updatesysdiagrams(int id, sysdiagrams updatedEntity)
        {
            _dbContext.sysdiagrams.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool Deletesysdiagrams(int id)
        {
            var entityData = _dbContext.sysdiagrams.FirstOrDefault(entity => entity.diagram_id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.sysdiagrams.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void Patchsysdiagrams(int id, JsonPatchDocument<sysdiagrams> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.sysdiagrams.FirstOrDefault(t => t.diagram_id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.sysdiagrams.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}