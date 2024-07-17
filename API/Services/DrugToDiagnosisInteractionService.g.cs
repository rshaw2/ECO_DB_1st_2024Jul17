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
    /// The drugtodiagnosisinteractionService responsible for managing drugtodiagnosisinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtodiagnosisinteraction information.
    /// </remarks>
    public interface IDrugToDiagnosisInteractionService
    {
        /// <summary>Retrieves a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <returns>The drugtodiagnosisinteraction data</returns>
        DrugToDiagnosisInteraction GetById(Guid id);

        /// <summary>Retrieves a list of drugtodiagnosisinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtodiagnosisinteractions</returns>
        List<DrugToDiagnosisInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new drugtodiagnosisinteraction</summary>
        /// <param name="model">The drugtodiagnosisinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugToDiagnosisInteraction model);

        /// <summary>Updates a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <param name="updatedEntity">The drugtodiagnosisinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugToDiagnosisInteraction updatedEntity);

        /// <summary>Updates a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <param name="updatedEntity">The drugtodiagnosisinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugToDiagnosisInteraction> updatedEntity);

        /// <summary>Deletes a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The drugtodiagnosisinteractionService responsible for managing drugtodiagnosisinteraction related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drugtodiagnosisinteraction information.
    /// </remarks>
    public class DrugToDiagnosisInteractionService : IDrugToDiagnosisInteractionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugToDiagnosisInteraction class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugToDiagnosisInteractionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <returns>The drugtodiagnosisinteraction data</returns>
        public DrugToDiagnosisInteraction GetById(Guid id)
        {
            var entityData = _dbContext.DrugToDiagnosisInteraction.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of drugtodiagnosisinteractions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drugtodiagnosisinteractions</returns>/// <exception cref="Exception"></exception>
        public List<DrugToDiagnosisInteraction> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugToDiagnosisInteraction(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new drugtodiagnosisinteraction</summary>
        /// <param name="model">The drugtodiagnosisinteraction data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugToDiagnosisInteraction model)
        {
            model.Id = CreateDrugToDiagnosisInteraction(model);
            return model.Id;
        }

        /// <summary>Updates a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <param name="updatedEntity">The drugtodiagnosisinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugToDiagnosisInteraction updatedEntity)
        {
            UpdateDrugToDiagnosisInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <param name="updatedEntity">The drugtodiagnosisinteraction data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugToDiagnosisInteraction> updatedEntity)
        {
            PatchDrugToDiagnosisInteraction(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific drugtodiagnosisinteraction by its primary key</summary>
        /// <param name="id">The primary key of the drugtodiagnosisinteraction</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugToDiagnosisInteraction(id);
            return true;
        }
        #region
        private List<DrugToDiagnosisInteraction> GetDrugToDiagnosisInteraction(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugToDiagnosisInteraction.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugToDiagnosisInteraction>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugToDiagnosisInteraction), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugToDiagnosisInteraction, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugToDiagnosisInteraction(DrugToDiagnosisInteraction model)
        {
            _dbContext.DrugToDiagnosisInteraction.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugToDiagnosisInteraction(Guid id, DrugToDiagnosisInteraction updatedEntity)
        {
            _dbContext.DrugToDiagnosisInteraction.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugToDiagnosisInteraction(Guid id)
        {
            var entityData = _dbContext.DrugToDiagnosisInteraction.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugToDiagnosisInteraction.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugToDiagnosisInteraction(Guid id, JsonPatchDocument<DrugToDiagnosisInteraction> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugToDiagnosisInteraction.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugToDiagnosisInteraction.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}