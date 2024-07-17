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
    /// The covid19historychoiceService responsible for managing covid19historychoice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covid19historychoice information.
    /// </remarks>
    public interface ICovid19HistoryChoiceService
    {
        /// <summary>Retrieves a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <returns>The covid19historychoice data</returns>
        Covid19HistoryChoice GetById(Guid id);

        /// <summary>Retrieves a list of covid19historychoices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covid19historychoices</returns>
        List<Covid19HistoryChoice> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new covid19historychoice</summary>
        /// <param name="model">The covid19historychoice data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Covid19HistoryChoice model);

        /// <summary>Updates a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <param name="updatedEntity">The covid19historychoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Covid19HistoryChoice updatedEntity);

        /// <summary>Updates a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <param name="updatedEntity">The covid19historychoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Covid19HistoryChoice> updatedEntity);

        /// <summary>Deletes a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The covid19historychoiceService responsible for managing covid19historychoice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting covid19historychoice information.
    /// </remarks>
    public class Covid19HistoryChoiceService : ICovid19HistoryChoiceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Covid19HistoryChoice class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public Covid19HistoryChoiceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <returns>The covid19historychoice data</returns>
        public Covid19HistoryChoice GetById(Guid id)
        {
            var entityData = _dbContext.Covid19HistoryChoice.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of covid19historychoices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of covid19historychoices</returns>/// <exception cref="Exception"></exception>
        public List<Covid19HistoryChoice> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetCovid19HistoryChoice(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new covid19historychoice</summary>
        /// <param name="model">The covid19historychoice data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Covid19HistoryChoice model)
        {
            model.Id = CreateCovid19HistoryChoice(model);
            return model.Id;
        }

        /// <summary>Updates a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <param name="updatedEntity">The covid19historychoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Covid19HistoryChoice updatedEntity)
        {
            UpdateCovid19HistoryChoice(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <param name="updatedEntity">The covid19historychoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Covid19HistoryChoice> updatedEntity)
        {
            PatchCovid19HistoryChoice(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific covid19historychoice by its primary key</summary>
        /// <param name="id">The primary key of the covid19historychoice</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteCovid19HistoryChoice(id);
            return true;
        }
        #region
        private List<Covid19HistoryChoice> GetCovid19HistoryChoice(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Covid19HistoryChoice.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Covid19HistoryChoice>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Covid19HistoryChoice), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Covid19HistoryChoice, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateCovid19HistoryChoice(Covid19HistoryChoice model)
        {
            _dbContext.Covid19HistoryChoice.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateCovid19HistoryChoice(Guid id, Covid19HistoryChoice updatedEntity)
        {
            _dbContext.Covid19HistoryChoice.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteCovid19HistoryChoice(Guid id)
        {
            var entityData = _dbContext.Covid19HistoryChoice.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Covid19HistoryChoice.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchCovid19HistoryChoice(Guid id, JsonPatchDocument<Covid19HistoryChoice> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Covid19HistoryChoice.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Covid19HistoryChoice.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}