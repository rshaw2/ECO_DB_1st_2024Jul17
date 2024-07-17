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
    /// The chiefcomplaintdeviationService responsible for managing chiefcomplaintdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplaintdeviation information.
    /// </remarks>
    public interface IChiefComplaintDeviationService
    {
        /// <summary>Retrieves a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <returns>The chiefcomplaintdeviation data</returns>
        ChiefComplaintDeviation GetById(Guid id);

        /// <summary>Retrieves a list of chiefcomplaintdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintdeviations</returns>
        List<ChiefComplaintDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new chiefcomplaintdeviation</summary>
        /// <param name="model">The chiefcomplaintdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ChiefComplaintDeviation model);

        /// <summary>Updates a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <param name="updatedEntity">The chiefcomplaintdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ChiefComplaintDeviation updatedEntity);

        /// <summary>Updates a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <param name="updatedEntity">The chiefcomplaintdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ChiefComplaintDeviation> updatedEntity);

        /// <summary>Deletes a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The chiefcomplaintdeviationService responsible for managing chiefcomplaintdeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplaintdeviation information.
    /// </remarks>
    public class ChiefComplaintDeviationService : IChiefComplaintDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ChiefComplaintDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <returns>The chiefcomplaintdeviation data</returns>
        public ChiefComplaintDeviation GetById(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of chiefcomplaintdeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintdeviations</returns>/// <exception cref="Exception"></exception>
        public List<ChiefComplaintDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetChiefComplaintDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new chiefcomplaintdeviation</summary>
        /// <param name="model">The chiefcomplaintdeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ChiefComplaintDeviation model)
        {
            model.Id = CreateChiefComplaintDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <param name="updatedEntity">The chiefcomplaintdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ChiefComplaintDeviation updatedEntity)
        {
            UpdateChiefComplaintDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <param name="updatedEntity">The chiefcomplaintdeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ChiefComplaintDeviation> updatedEntity)
        {
            PatchChiefComplaintDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific chiefcomplaintdeviation by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintdeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteChiefComplaintDeviation(id);
            return true;
        }
        #region
        private List<ChiefComplaintDeviation> GetChiefComplaintDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ChiefComplaintDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ChiefComplaintDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ChiefComplaintDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ChiefComplaintDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateChiefComplaintDeviation(ChiefComplaintDeviation model)
        {
            _dbContext.ChiefComplaintDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateChiefComplaintDeviation(Guid id, ChiefComplaintDeviation updatedEntity)
        {
            _dbContext.ChiefComplaintDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteChiefComplaintDeviation(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ChiefComplaintDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchChiefComplaintDeviation(Guid id, JsonPatchDocument<ChiefComplaintDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ChiefComplaintDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ChiefComplaintDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}