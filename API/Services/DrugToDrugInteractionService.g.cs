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
    /// The drugtodruginteractionService responsible for managing drugtodruginteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtodruginteraction information.
    /// </remarks>
    public interface IDrugToDrugInteractionService
    {
        /// <summary>Retrieves a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <returns>The drugtodruginteraction data</returns>
        DrugToDrugInteraction GetById(Guid id);

        /// <summary>Retrieves a list of drugtodruginteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtodruginteractions</returns>
        List<DrugToDrugInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new drugtodruginteraction</summary>
        /// <param name="model">The drugtodruginteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugToDrugInteraction model);

        /// <summary>Updates a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <param name="updatedEntity">The drugtodruginteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugToDrugInteraction updatedEntity);

        /// <summary>Updates a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <param name="updatedEntity">The drugtodruginteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugToDrugInteraction> updatedEntity);

        /// <summary>Deletes a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The drugtodruginteractionService responsible for managing drugtodruginteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtodruginteraction information.
    /// </remarks>
    public class DrugToDrugInteractionService : IDrugToDrugInteractionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugToDrugInteraction class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugToDrugInteractionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <returns>The drugtodruginteraction data</returns>
        public DrugToDrugInteraction GetById(Guid id)
        {
            var entityData = _dbContext.DrugToDrugInteraction.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of drugtodruginteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtodruginteractions</returns>/// <exception cref="Exception"></exception>
        public List<DrugToDrugInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugToDrugInteraction(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new drugtodruginteraction</summary>
        /// <param name="model">The drugtodruginteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugToDrugInteraction model)
        {
            model.Id = CreateDrugToDrugInteraction(model);
            return model.Id;
        }

        /// <summary>Updates a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <param name="updatedEntity">The drugtodruginteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugToDrugInteraction updatedEntity)
        {
            UpdateDrugToDrugInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <param name="updatedEntity">The drugtodruginteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugToDrugInteraction> updatedEntity)
        {
            PatchDrugToDrugInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific drugtodruginteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodruginteraction</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugToDrugInteraction(id);
            return true;
        }
        #region
        private List<DrugToDrugInteraction> GetDrugToDrugInteraction(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugToDrugInteraction.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugToDrugInteraction>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugToDrugInteraction), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugToDrugInteraction, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugToDrugInteraction(DrugToDrugInteraction model)
        {
            _dbContext.DrugToDrugInteraction.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugToDrugInteraction(Guid id, DrugToDrugInteraction updatedEntity)
        {
            _dbContext.DrugToDrugInteraction.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugToDrugInteraction(Guid id)
        {
            var entityData = _dbContext.DrugToDrugInteraction.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugToDrugInteraction.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugToDrugInteraction(Guid id, JsonPatchDocument<DrugToDrugInteraction> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugToDrugInteraction.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugToDrugInteraction.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}