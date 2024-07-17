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
    /// The drugtoallergyinteractionService responsible for managing drugtoallergyinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtoallergyinteraction information.
    /// </remarks>
    public interface IDrugToAllergyInteractionService
    {
        /// <summary>Retrieves a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <returns>The drugtoallergyinteraction data</returns>
        DrugToAllergyInteraction GetById(Guid id);

        /// <summary>Retrieves a list of drugtoallergyinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtoallergyinteractions</returns>
        List<DrugToAllergyInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new drugtoallergyinteraction</summary>
        /// <param name="model">The drugtoallergyinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugToAllergyInteraction model);

        /// <summary>Updates a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <param name="updatedEntity">The drugtoallergyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugToAllergyInteraction updatedEntity);

        /// <summary>Updates a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <param name="updatedEntity">The drugtoallergyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugToAllergyInteraction> updatedEntity);

        /// <summary>Deletes a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The drugtoallergyinteractionService responsible for managing drugtoallergyinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtoallergyinteraction information.
    /// </remarks>
    public class DrugToAllergyInteractionService : IDrugToAllergyInteractionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugToAllergyInteraction class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugToAllergyInteractionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <returns>The drugtoallergyinteraction data</returns>
        public DrugToAllergyInteraction GetById(Guid id)
        {
            var entityData = _dbContext.DrugToAllergyInteraction.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of drugtoallergyinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtoallergyinteractions</returns>/// <exception cref="Exception"></exception>
        public List<DrugToAllergyInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugToAllergyInteraction(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new drugtoallergyinteraction</summary>
        /// <param name="model">The drugtoallergyinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugToAllergyInteraction model)
        {
            model.Id = CreateDrugToAllergyInteraction(model);
            return model.Id;
        }

        /// <summary>Updates a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <param name="updatedEntity">The drugtoallergyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugToAllergyInteraction updatedEntity)
        {
            UpdateDrugToAllergyInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <param name="updatedEntity">The drugtoallergyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugToAllergyInteraction> updatedEntity)
        {
            PatchDrugToAllergyInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific drugtoallergyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtoallergyinteraction</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugToAllergyInteraction(id);
            return true;
        }
        #region
        private List<DrugToAllergyInteraction> GetDrugToAllergyInteraction(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugToAllergyInteraction.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugToAllergyInteraction>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugToAllergyInteraction), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugToAllergyInteraction, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugToAllergyInteraction(DrugToAllergyInteraction model)
        {
            _dbContext.DrugToAllergyInteraction.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugToAllergyInteraction(Guid id, DrugToAllergyInteraction updatedEntity)
        {
            _dbContext.DrugToAllergyInteraction.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugToAllergyInteraction(Guid id)
        {
            var entityData = _dbContext.DrugToAllergyInteraction.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugToAllergyInteraction.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugToAllergyInteraction(Guid id, JsonPatchDocument<DrugToAllergyInteraction> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugToAllergyInteraction.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugToAllergyInteraction.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}