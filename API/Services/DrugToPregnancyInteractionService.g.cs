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
    /// The drugtopregnancyinteractionService responsible for managing drugtopregnancyinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtopregnancyinteraction information.
    /// </remarks>
    public interface IDrugToPregnancyInteractionService
    {
        /// <summary>Retrieves a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <returns>The drugtopregnancyinteraction data</returns>
        DrugToPregnancyInteraction GetById(Guid id);

        /// <summary>Retrieves a list of drugtopregnancyinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtopregnancyinteractions</returns>
        List<DrugToPregnancyInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new drugtopregnancyinteraction</summary>
        /// <param name="model">The drugtopregnancyinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugToPregnancyInteraction model);

        /// <summary>Updates a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <param name="updatedEntity">The drugtopregnancyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugToPregnancyInteraction updatedEntity);

        /// <summary>Updates a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <param name="updatedEntity">The drugtopregnancyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugToPregnancyInteraction> updatedEntity);

        /// <summary>Deletes a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The drugtopregnancyinteractionService responsible for managing drugtopregnancyinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtopregnancyinteraction information.
    /// </remarks>
    public class DrugToPregnancyInteractionService : IDrugToPregnancyInteractionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugToPregnancyInteraction class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugToPregnancyInteractionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <returns>The drugtopregnancyinteraction data</returns>
        public DrugToPregnancyInteraction GetById(Guid id)
        {
            var entityData = _dbContext.DrugToPregnancyInteraction.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of drugtopregnancyinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtopregnancyinteractions</returns>/// <exception cref="Exception"></exception>
        public List<DrugToPregnancyInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugToPregnancyInteraction(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new drugtopregnancyinteraction</summary>
        /// <param name="model">The drugtopregnancyinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugToPregnancyInteraction model)
        {
            model.Id = CreateDrugToPregnancyInteraction(model);
            return model.Id;
        }

        /// <summary>Updates a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <param name="updatedEntity">The drugtopregnancyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugToPregnancyInteraction updatedEntity)
        {
            UpdateDrugToPregnancyInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <param name="updatedEntity">The drugtopregnancyinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugToPregnancyInteraction> updatedEntity)
        {
            PatchDrugToPregnancyInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific drugtopregnancyinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtopregnancyinteraction</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugToPregnancyInteraction(id);
            return true;
        }
        #region
        private List<DrugToPregnancyInteraction> GetDrugToPregnancyInteraction(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugToPregnancyInteraction.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugToPregnancyInteraction>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugToPregnancyInteraction), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugToPregnancyInteraction, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugToPregnancyInteraction(DrugToPregnancyInteraction model)
        {
            _dbContext.DrugToPregnancyInteraction.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugToPregnancyInteraction(Guid id, DrugToPregnancyInteraction updatedEntity)
        {
            _dbContext.DrugToPregnancyInteraction.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugToPregnancyInteraction(Guid id)
        {
            var entityData = _dbContext.DrugToPregnancyInteraction.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugToPregnancyInteraction.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugToPregnancyInteraction(Guid id, JsonPatchDocument<DrugToPregnancyInteraction> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugToPregnancyInteraction.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugToPregnancyInteraction.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}