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
    /// The specialitypersonalisationcomponentService responsible for managing specialitypersonalisationcomponent related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationcomponent information.
    /// </remarks>
    public interface ISpecialityPersonalisationComponentService
    {
        /// <summary>Retrieves a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <returns>The specialitypersonalisationcomponent data</returns>
        SpecialityPersonalisationComponent GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationcomponents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationcomponents</returns>
        List<SpecialityPersonalisationComponent> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationcomponent</summary>
        /// <param name="model">The specialitypersonalisationcomponent data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationComponent model);

        /// <summary>Updates a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationComponent updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationComponent> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationcomponentService responsible for managing specialitypersonalisationcomponent related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationcomponent information.
    /// </remarks>
    public class SpecialityPersonalisationComponentService : ISpecialityPersonalisationComponentService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationComponent class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationComponentService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <returns>The specialitypersonalisationcomponent data</returns>
        public SpecialityPersonalisationComponent GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationComponent.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationcomponents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationcomponents</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationComponent> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationComponent(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationcomponent</summary>
        /// <param name="model">The specialitypersonalisationcomponent data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationComponent model)
        {
            model.Id = CreateSpecialityPersonalisationComponent(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationComponent updatedEntity)
        {
            UpdateSpecialityPersonalisationComponent(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationComponent> updatedEntity)
        {
            PatchSpecialityPersonalisationComponent(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationcomponent by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomponent</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationComponent(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationComponent> GetSpecialityPersonalisationComponent(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationComponent.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationComponent>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationComponent), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationComponent, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationComponent(SpecialityPersonalisationComponent model)
        {
            _dbContext.SpecialityPersonalisationComponent.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationComponent(Guid id, SpecialityPersonalisationComponent updatedEntity)
        {
            _dbContext.SpecialityPersonalisationComponent.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationComponent(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationComponent.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationComponent.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationComponent(Guid id, JsonPatchDocument<SpecialityPersonalisationComponent> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationComponent.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationComponent.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}