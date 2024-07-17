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
    /// The allergyService responsible for managing allergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergy information.
    /// </remarks>
    public interface IAllergyService
    {
        /// <summary>Retrieves a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <returns>The allergy data</returns>
        Allergy GetById(Guid id);

        /// <summary>Retrieves a list of allergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergys</returns>
        List<Allergy> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new allergy</summary>
        /// <param name="model">The allergy data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Allergy model);

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Allergy updatedEntity);

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Allergy> updatedEntity);

        /// <summary>Deletes a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The allergyService responsible for managing allergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergy information.
    /// </remarks>
    public class AllergyService : IAllergyService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Allergy class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AllergyService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <returns>The allergy data</returns>
        public Allergy GetById(Guid id)
        {
            var entityData = _dbContext.Allergy.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of allergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergys</returns>/// <exception cref="Exception"></exception>
        public List<Allergy> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAllergy(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new allergy</summary>
        /// <param name="model">The allergy data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Allergy model)
        {
            model.Id = CreateAllergy(model);
            return model.Id;
        }

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Allergy updatedEntity)
        {
            UpdateAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Allergy> updatedEntity)
        {
            PatchAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAllergy(id);
            return true;
        }
        #region
        private List<Allergy> GetAllergy(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Allergy.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Allergy>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Allergy), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Allergy, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAllergy(Allergy model)
        {
            _dbContext.Allergy.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAllergy(Guid id, Allergy updatedEntity)
        {
            _dbContext.Allergy.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAllergy(Guid id)
        {
            var entityData = _dbContext.Allergy.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Allergy.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAllergy(Guid id, JsonPatchDocument<Allergy> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Allergy.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Allergy.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}