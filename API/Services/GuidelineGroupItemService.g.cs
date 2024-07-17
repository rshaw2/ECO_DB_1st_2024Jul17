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
    /// The guidelinegroupitemService responsible for managing guidelinegroupitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinegroupitem information.
    /// </remarks>
    public interface IGuidelineGroupItemService
    {
        /// <summary>Retrieves a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <returns>The guidelinegroupitem data</returns>
        GuidelineGroupItem GetById(Guid id);

        /// <summary>Retrieves a list of guidelinegroupitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinegroupitems</returns>
        List<GuidelineGroupItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new guidelinegroupitem</summary>
        /// <param name="model">The guidelinegroupitem data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(GuidelineGroupItem model);

        /// <summary>Updates a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <param name="updatedEntity">The guidelinegroupitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, GuidelineGroupItem updatedEntity);

        /// <summary>Updates a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <param name="updatedEntity">The guidelinegroupitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<GuidelineGroupItem> updatedEntity);

        /// <summary>Deletes a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The guidelinegroupitemService responsible for managing guidelinegroupitem related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting guidelinegroupitem information.
    /// </remarks>
    public class GuidelineGroupItemService : IGuidelineGroupItemService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the GuidelineGroupItem class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public GuidelineGroupItemService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <returns>The guidelinegroupitem data</returns>
        public GuidelineGroupItem GetById(Guid id)
        {
            var entityData = _dbContext.GuidelineGroupItem.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of guidelinegroupitems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of guidelinegroupitems</returns>/// <exception cref="Exception"></exception>
        public List<GuidelineGroupItem> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetGuidelineGroupItem(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new guidelinegroupitem</summary>
        /// <param name="model">The guidelinegroupitem data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(GuidelineGroupItem model)
        {
            model.Id = CreateGuidelineGroupItem(model);
            return model.Id;
        }

        /// <summary>Updates a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <param name="updatedEntity">The guidelinegroupitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, GuidelineGroupItem updatedEntity)
        {
            UpdateGuidelineGroupItem(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <param name="updatedEntity">The guidelinegroupitem data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<GuidelineGroupItem> updatedEntity)
        {
            PatchGuidelineGroupItem(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific guidelinegroupitem by its primary key</summary>
        /// <param name="id">The primary key of the guidelinegroupitem</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteGuidelineGroupItem(id);
            return true;
        }
        #region
        private List<GuidelineGroupItem> GetGuidelineGroupItem(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GuidelineGroupItem.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GuidelineGroupItem>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GuidelineGroupItem), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GuidelineGroupItem, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateGuidelineGroupItem(GuidelineGroupItem model)
        {
            _dbContext.GuidelineGroupItem.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateGuidelineGroupItem(Guid id, GuidelineGroupItem updatedEntity)
        {
            _dbContext.GuidelineGroupItem.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteGuidelineGroupItem(Guid id)
        {
            var entityData = _dbContext.GuidelineGroupItem.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GuidelineGroupItem.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchGuidelineGroupItem(Guid id, JsonPatchDocument<GuidelineGroupItem> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GuidelineGroupItem.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GuidelineGroupItem.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}