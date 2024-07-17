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
    /// The icdcodeService responsible for managing icdcode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting icdcode information.
    /// </remarks>
    public interface IIcdCodeService
    {
        /// <summary>Retrieves a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <returns>The icdcode data</returns>
        IcdCode GetById(Guid id);

        /// <summary>Retrieves a list of icdcodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of icdcodes</returns>
        List<IcdCode> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new icdcode</summary>
        /// <param name="model">The icdcode data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(IcdCode model);

        /// <summary>Updates a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <param name="updatedEntity">The icdcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, IcdCode updatedEntity);

        /// <summary>Updates a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <param name="updatedEntity">The icdcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<IcdCode> updatedEntity);

        /// <summary>Deletes a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The icdcodeService responsible for managing icdcode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting icdcode information.
    /// </remarks>
    public class IcdCodeService : IIcdCodeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the IcdCode class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public IcdCodeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <returns>The icdcode data</returns>
        public IcdCode GetById(Guid id)
        {
            var entityData = _dbContext.IcdCode.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of icdcodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of icdcodes</returns>/// <exception cref="Exception"></exception>
        public List<IcdCode> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetIcdCode(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new icdcode</summary>
        /// <param name="model">The icdcode data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(IcdCode model)
        {
            model.Id = CreateIcdCode(model);
            return model.Id;
        }

        /// <summary>Updates a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <param name="updatedEntity">The icdcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, IcdCode updatedEntity)
        {
            UpdateIcdCode(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <param name="updatedEntity">The icdcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<IcdCode> updatedEntity)
        {
            PatchIcdCode(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific icdcode by its primary key</summary>
        /// <param name="id">The primary key of the icdcode</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteIcdCode(id);
            return true;
        }
        #region
        private List<IcdCode> GetIcdCode(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.IcdCode.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<IcdCode>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(IcdCode), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<IcdCode, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateIcdCode(IcdCode model)
        {
            _dbContext.IcdCode.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateIcdCode(Guid id, IcdCode updatedEntity)
        {
            _dbContext.IcdCode.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteIcdCode(Guid id)
        {
            var entityData = _dbContext.IcdCode.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.IcdCode.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchIcdCode(Guid id, JsonPatchDocument<IcdCode> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.IcdCode.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.IcdCode.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}