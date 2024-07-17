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
    /// The specialitypersonalisationcountryService responsible for managing specialitypersonalisationcountry related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationcountry information.
    /// </remarks>
    public interface ISpecialityPersonalisationCountryService
    {
        /// <summary>Retrieves a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <returns>The specialitypersonalisationcountry data</returns>
        SpecialityPersonalisationCountry GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationcountrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationcountrys</returns>
        List<SpecialityPersonalisationCountry> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationcountry</summary>
        /// <param name="model">The specialitypersonalisationcountry data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationCountry model);

        /// <summary>Updates a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <param name="updatedEntity">The specialitypersonalisationcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationCountry updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <param name="updatedEntity">The specialitypersonalisationcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationCountry> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationcountryService responsible for managing specialitypersonalisationcountry related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationcountry information.
    /// </remarks>
    public class SpecialityPersonalisationCountryService : ISpecialityPersonalisationCountryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationCountry class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationCountryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <returns>The specialitypersonalisationcountry data</returns>
        public SpecialityPersonalisationCountry GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationCountry.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationcountrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationcountrys</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationCountry> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationCountry(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationcountry</summary>
        /// <param name="model">The specialitypersonalisationcountry data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationCountry model)
        {
            model.Id = CreateSpecialityPersonalisationCountry(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <param name="updatedEntity">The specialitypersonalisationcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationCountry updatedEntity)
        {
            UpdateSpecialityPersonalisationCountry(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <param name="updatedEntity">The specialitypersonalisationcountry data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationCountry> updatedEntity)
        {
            PatchSpecialityPersonalisationCountry(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationcountry by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcountry</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationCountry(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationCountry> GetSpecialityPersonalisationCountry(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationCountry.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationCountry>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationCountry), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationCountry, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationCountry(SpecialityPersonalisationCountry model)
        {
            _dbContext.SpecialityPersonalisationCountry.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationCountry(Guid id, SpecialityPersonalisationCountry updatedEntity)
        {
            _dbContext.SpecialityPersonalisationCountry.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationCountry(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationCountry.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationCountry.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationCountry(Guid id, JsonPatchDocument<SpecialityPersonalisationCountry> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationCountry.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationCountry.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}