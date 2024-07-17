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
    /// The specialitypersonalisationallergyService responsible for managing specialitypersonalisationallergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationallergy information.
    /// </remarks>
    public interface ISpecialityPersonalisationAllergyService
    {
        /// <summary>Retrieves a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <returns>The specialitypersonalisationallergy data</returns>
        SpecialityPersonalisationAllergy GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationallergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationallergys</returns>
        List<SpecialityPersonalisationAllergy> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationallergy</summary>
        /// <param name="model">The specialitypersonalisationallergy data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationAllergy model);

        /// <summary>Updates a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <param name="updatedEntity">The specialitypersonalisationallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationAllergy updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <param name="updatedEntity">The specialitypersonalisationallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationAllergy> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationallergyService responsible for managing specialitypersonalisationallergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationallergy information.
    /// </remarks>
    public class SpecialityPersonalisationAllergyService : ISpecialityPersonalisationAllergyService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationAllergy class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationAllergyService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <returns>The specialitypersonalisationallergy data</returns>
        public SpecialityPersonalisationAllergy GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationAllergy.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationallergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationallergys</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationAllergy> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationAllergy(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationallergy</summary>
        /// <param name="model">The specialitypersonalisationallergy data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationAllergy model)
        {
            model.Id = CreateSpecialityPersonalisationAllergy(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <param name="updatedEntity">The specialitypersonalisationallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationAllergy updatedEntity)
        {
            UpdateSpecialityPersonalisationAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <param name="updatedEntity">The specialitypersonalisationallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationAllergy> updatedEntity)
        {
            PatchSpecialityPersonalisationAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationallergy by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationallergy</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationAllergy(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationAllergy> GetSpecialityPersonalisationAllergy(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationAllergy.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationAllergy>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationAllergy), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationAllergy, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationAllergy(SpecialityPersonalisationAllergy model)
        {
            _dbContext.SpecialityPersonalisationAllergy.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationAllergy(Guid id, SpecialityPersonalisationAllergy updatedEntity)
        {
            _dbContext.SpecialityPersonalisationAllergy.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationAllergy(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationAllergy.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationAllergy.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationAllergy(Guid id, JsonPatchDocument<SpecialityPersonalisationAllergy> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationAllergy.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationAllergy.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}