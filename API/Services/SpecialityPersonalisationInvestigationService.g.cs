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
    /// The specialitypersonalisationinvestigationService responsible for managing specialitypersonalisationinvestigation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationinvestigation information.
    /// </remarks>
    public interface ISpecialityPersonalisationInvestigationService
    {
        /// <summary>Retrieves a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <returns>The specialitypersonalisationinvestigation data</returns>
        SpecialityPersonalisationInvestigation GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationinvestigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationinvestigations</returns>
        List<SpecialityPersonalisationInvestigation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationinvestigation</summary>
        /// <param name="model">The specialitypersonalisationinvestigation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationInvestigation model);

        /// <summary>Updates a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <param name="updatedEntity">The specialitypersonalisationinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationInvestigation updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <param name="updatedEntity">The specialitypersonalisationinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationInvestigation> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationinvestigationService responsible for managing specialitypersonalisationinvestigation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationinvestigation information.
    /// </remarks>
    public class SpecialityPersonalisationInvestigationService : ISpecialityPersonalisationInvestigationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationInvestigation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationInvestigationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <returns>The specialitypersonalisationinvestigation data</returns>
        public SpecialityPersonalisationInvestigation GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationInvestigation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationinvestigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationinvestigations</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationInvestigation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationInvestigation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationinvestigation</summary>
        /// <param name="model">The specialitypersonalisationinvestigation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationInvestigation model)
        {
            model.Id = CreateSpecialityPersonalisationInvestigation(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <param name="updatedEntity">The specialitypersonalisationinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationInvestigation updatedEntity)
        {
            UpdateSpecialityPersonalisationInvestigation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <param name="updatedEntity">The specialitypersonalisationinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationInvestigation> updatedEntity)
        {
            PatchSpecialityPersonalisationInvestigation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationinvestigation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationinvestigation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationInvestigation(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationInvestigation> GetSpecialityPersonalisationInvestigation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationInvestigation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationInvestigation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationInvestigation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationInvestigation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationInvestigation(SpecialityPersonalisationInvestigation model)
        {
            _dbContext.SpecialityPersonalisationInvestigation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationInvestigation(Guid id, SpecialityPersonalisationInvestigation updatedEntity)
        {
            _dbContext.SpecialityPersonalisationInvestigation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationInvestigation(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationInvestigation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationInvestigation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationInvestigation(Guid id, JsonPatchDocument<SpecialityPersonalisationInvestigation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationInvestigation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationInvestigation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}