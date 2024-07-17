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
    /// The allergydeviationService responsible for managing allergydeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergydeviation information.
    /// </remarks>
    public interface IAllergyDeviationService
    {
        /// <summary>Retrieves a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <returns>The allergydeviation data</returns>
        AllergyDeviation GetById(Guid id);

        /// <summary>Retrieves a list of allergydeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergydeviations</returns>
        List<AllergyDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new allergydeviation</summary>
        /// <param name="model">The allergydeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(AllergyDeviation model);

        /// <summary>Updates a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <param name="updatedEntity">The allergydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AllergyDeviation updatedEntity);

        /// <summary>Updates a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <param name="updatedEntity">The allergydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AllergyDeviation> updatedEntity);

        /// <summary>Deletes a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The allergydeviationService responsible for managing allergydeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergydeviation information.
    /// </remarks>
    public class AllergyDeviationService : IAllergyDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AllergyDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AllergyDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <returns>The allergydeviation data</returns>
        public AllergyDeviation GetById(Guid id)
        {
            var entityData = _dbContext.AllergyDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of allergydeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergydeviations</returns>/// <exception cref="Exception"></exception>
        public List<AllergyDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAllergyDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new allergydeviation</summary>
        /// <param name="model">The allergydeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(AllergyDeviation model)
        {
            model.Id = CreateAllergyDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <param name="updatedEntity">The allergydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AllergyDeviation updatedEntity)
        {
            UpdateAllergyDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <param name="updatedEntity">The allergydeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AllergyDeviation> updatedEntity)
        {
            PatchAllergyDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific allergydeviation by its primary key</summary>
        /// <param name="id">The primary key of the allergydeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAllergyDeviation(id);
            return true;
        }
        #region
        private List<AllergyDeviation> GetAllergyDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AllergyDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AllergyDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AllergyDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AllergyDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAllergyDeviation(AllergyDeviation model)
        {
            _dbContext.AllergyDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAllergyDeviation(Guid id, AllergyDeviation updatedEntity)
        {
            _dbContext.AllergyDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAllergyDeviation(Guid id)
        {
            var entityData = _dbContext.AllergyDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AllergyDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAllergyDeviation(Guid id, JsonPatchDocument<AllergyDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AllergyDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AllergyDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}