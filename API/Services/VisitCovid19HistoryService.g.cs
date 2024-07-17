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
    /// The visitcovid19historyService responsible for managing visitcovid19history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitcovid19history information.
    /// </remarks>
    public interface IVisitCovid19HistoryService
    {
        /// <summary>Retrieves a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <returns>The visitcovid19history data</returns>
        VisitCovid19History GetById(Guid id);

        /// <summary>Retrieves a list of visitcovid19historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitcovid19historys</returns>
        List<VisitCovid19History> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitcovid19history</summary>
        /// <param name="model">The visitcovid19history data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitCovid19History model);

        /// <summary>Updates a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <param name="updatedEntity">The visitcovid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitCovid19History updatedEntity);

        /// <summary>Updates a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <param name="updatedEntity">The visitcovid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitCovid19History> updatedEntity);

        /// <summary>Deletes a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitcovid19historyService responsible for managing visitcovid19history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitcovid19history information.
    /// </remarks>
    public class VisitCovid19HistoryService : IVisitCovid19HistoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitCovid19History class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitCovid19HistoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <returns>The visitcovid19history data</returns>
        public VisitCovid19History GetById(Guid id)
        {
            var entityData = _dbContext.VisitCovid19History.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitcovid19historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitcovid19historys</returns>/// <exception cref="Exception"></exception>
        public List<VisitCovid19History> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitCovid19History(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitcovid19history</summary>
        /// <param name="model">The visitcovid19history data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitCovid19History model)
        {
            model.Id = CreateVisitCovid19History(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <param name="updatedEntity">The visitcovid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitCovid19History updatedEntity)
        {
            UpdateVisitCovid19History(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <param name="updatedEntity">The visitcovid19history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitCovid19History> updatedEntity)
        {
            PatchVisitCovid19History(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitcovid19history by its primary key</summary>
        /// <param name="id">The primary key of the visitcovid19history</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitCovid19History(id);
            return true;
        }
        #region
        private List<VisitCovid19History> GetVisitCovid19History(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitCovid19History.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitCovid19History>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitCovid19History), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitCovid19History, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitCovid19History(VisitCovid19History model)
        {
            _dbContext.VisitCovid19History.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitCovid19History(Guid id, VisitCovid19History updatedEntity)
        {
            _dbContext.VisitCovid19History.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitCovid19History(Guid id)
        {
            var entityData = _dbContext.VisitCovid19History.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitCovid19History.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitCovid19History(Guid id, JsonPatchDocument<VisitCovid19History> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitCovid19History.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitCovid19History.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}