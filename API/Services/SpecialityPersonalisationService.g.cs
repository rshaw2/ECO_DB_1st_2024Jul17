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
    /// The specialitypersonalisationService responsible for managing specialitypersonalisation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisation information.
    /// </remarks>
    public interface ISpecialityPersonalisationService
    {
        /// <summary>Retrieves a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <returns>The specialitypersonalisation data</returns>
        SpecialityPersonalisation GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisations</returns>
        List<SpecialityPersonalisation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisation</summary>
        /// <param name="model">The specialitypersonalisation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisation model);

        /// <summary>Updates a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <param name="updatedEntity">The specialitypersonalisation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisation updatedEntity);

        /// <summary>Updates a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <param name="updatedEntity">The specialitypersonalisation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisation> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationService responsible for managing specialitypersonalisation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisation information.
    /// </remarks>
    public class SpecialityPersonalisationService : ISpecialityPersonalisationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <returns>The specialitypersonalisation data</returns>
        public SpecialityPersonalisation GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisations</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisation</summary>
        /// <param name="model">The specialitypersonalisation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisation model)
        {
            model.Id = CreateSpecialityPersonalisation(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <param name="updatedEntity">The specialitypersonalisation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisation updatedEntity)
        {
            UpdateSpecialityPersonalisation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <param name="updatedEntity">The specialitypersonalisation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisation> updatedEntity)
        {
            PatchSpecialityPersonalisation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisation by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisation(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisation> GetSpecialityPersonalisation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisation(SpecialityPersonalisation model)
        {
            _dbContext.SpecialityPersonalisation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisation(Guid id, SpecialityPersonalisation updatedEntity)
        {
            _dbContext.SpecialityPersonalisation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisation(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisation(Guid id, JsonPatchDocument<SpecialityPersonalisation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}