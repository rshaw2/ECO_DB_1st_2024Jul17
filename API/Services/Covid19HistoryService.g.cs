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
    /// The covid19historyService responsible for managing covid19history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covid19history information.
    /// </remarks>
    public interface ICovid19HistoryService
    {
        /// <summary>Retrieves a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <returns>The covid19history data</returns>
        Covid19History GetById(Guid id);

        /// <summary>Retrieves a list of covid19historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covid19historys</returns>
        List<Covid19History> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covid19history</summary>
        /// <param name="model">The covid19history data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Covid19History model);

        /// <summary>Updates a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <param name="updatedEntity">The covid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Covid19History updatedEntity);

        /// <summary>Updates a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <param name="updatedEntity">The covid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Covid19History> updatedEntity);

        /// <summary>Deletes a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covid19historyService responsible for managing covid19history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covid19history information.
    /// </remarks>
    public class Covid19HistoryService : ICovid19HistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Covid19History class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public Covid19HistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <returns>The covid19history data</returns>
        public Covid19History GetById(Guid id)
        {
            var entityData = _dbContext.Covid19History.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covid19historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covid19historys</returns>/// <exception cref="Exception"></exception>
        public List<Covid19History> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCovid19History(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covid19history</summary>
        /// <param name="model">The covid19history data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Covid19History model)
        {
            model.Id = CreateCovid19History(model);
            return model.Id;
        }

        /// <summary>Updates a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <param name="updatedEntity">The covid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Covid19History updatedEntity)
        {
            UpdateCovid19History(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <param name="updatedEntity">The covid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Covid19History> updatedEntity)
        {
            PatchCovid19History(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covid19history by its primary key</summary>
        /// <param name="id">The primary key of the covid19history</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCovid19History(id);
            return true;
        }
        #region
        private List<Covid19History> GetCovid19History(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Covid19History.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Covid19History>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Covid19History), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Covid19History, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCovid19History(Covid19History model)
        {
            _dbContext.Covid19History.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCovid19History(Guid id, Covid19History updatedEntity)
        {
            _dbContext.Covid19History.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCovid19History(Guid id)
        {
            var entityData = _dbContext.Covid19History.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Covid19History.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCovid19History(Guid id, JsonPatchDocument<Covid19History> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Covid19History.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Covid19History.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}