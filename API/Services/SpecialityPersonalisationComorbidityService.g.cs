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
    /// The specialitypersonalisationcomorbidityService responsible for managing specialitypersonalisationcomorbidity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationcomorbidity information.
    /// </remarks>
    public interface ISpecialityPersonalisationComorbidityService
    {
        /// <summary>Retrieves a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <returns>The specialitypersonalisationcomorbidity data</returns>
        SpecialityPersonalisationComorbidity GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationcomorbiditys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationcomorbiditys</returns>
        List<SpecialityPersonalisationComorbidity> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationcomorbidity</summary>
        /// <param name="model">The specialitypersonalisationcomorbidity data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationComorbidity model);

        /// <summary>Updates a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationComorbidity updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationComorbidity> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationcomorbidityService responsible for managing specialitypersonalisationcomorbidity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationcomorbidity information.
    /// </remarks>
    public class SpecialityPersonalisationComorbidityService : ISpecialityPersonalisationComorbidityService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationComorbidity class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationComorbidityService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <returns>The specialitypersonalisationcomorbidity data</returns>
        public SpecialityPersonalisationComorbidity GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationComorbidity.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationcomorbiditys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationcomorbiditys</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationComorbidity> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationComorbidity(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationcomorbidity</summary>
        /// <param name="model">The specialitypersonalisationcomorbidity data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationComorbidity model)
        {
            model.Id = CreateSpecialityPersonalisationComorbidity(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationComorbidity updatedEntity)
        {
            UpdateSpecialityPersonalisationComorbidity(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <param name="updatedEntity">The specialitypersonalisationcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationComorbidity> updatedEntity)
        {
            PatchSpecialityPersonalisationComorbidity(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationcomorbidity</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationComorbidity(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationComorbidity> GetSpecialityPersonalisationComorbidity(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationComorbidity.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationComorbidity>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationComorbidity), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationComorbidity, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationComorbidity(SpecialityPersonalisationComorbidity model)
        {
            _dbContext.SpecialityPersonalisationComorbidity.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationComorbidity(Guid id, SpecialityPersonalisationComorbidity updatedEntity)
        {
            _dbContext.SpecialityPersonalisationComorbidity.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationComorbidity(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationComorbidity.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationComorbidity.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationComorbidity(Guid id, JsonPatchDocument<SpecialityPersonalisationComorbidity> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationComorbidity.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationComorbidity.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}