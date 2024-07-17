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
    /// The specialitypersonalisationspecialityService responsible for managing specialitypersonalisationspeciality related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationspeciality information.
    /// </remarks>
    public interface ISpecialityPersonalisationSpecialityService
    {
        /// <summary>Retrieves a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <returns>The specialitypersonalisationspeciality data</returns>
        SpecialityPersonalisationSpeciality GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationspecialitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationspecialitys</returns>
        List<SpecialityPersonalisationSpeciality> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationspeciality</summary>
        /// <param name="model">The specialitypersonalisationspeciality data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationSpeciality model);

        /// <summary>Updates a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <param name="updatedEntity">The specialitypersonalisationspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationSpeciality updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <param name="updatedEntity">The specialitypersonalisationspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationSpeciality> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationspecialityService responsible for managing specialitypersonalisationspeciality related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationspeciality information.
    /// </remarks>
    public class SpecialityPersonalisationSpecialityService : ISpecialityPersonalisationSpecialityService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationSpeciality class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationSpecialityService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <returns>The specialitypersonalisationspeciality data</returns>
        public SpecialityPersonalisationSpeciality GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationSpeciality.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationspecialitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationspecialitys</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationSpeciality> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationSpeciality(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationspeciality</summary>
        /// <param name="model">The specialitypersonalisationspeciality data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationSpeciality model)
        {
            model.Id = CreateSpecialityPersonalisationSpeciality(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <param name="updatedEntity">The specialitypersonalisationspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationSpeciality updatedEntity)
        {
            UpdateSpecialityPersonalisationSpeciality(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <param name="updatedEntity">The specialitypersonalisationspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationSpeciality> updatedEntity)
        {
            PatchSpecialityPersonalisationSpeciality(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationspeciality by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationspeciality</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationSpeciality(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationSpeciality> GetSpecialityPersonalisationSpeciality(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationSpeciality.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationSpeciality>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationSpeciality), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationSpeciality, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationSpeciality(SpecialityPersonalisationSpeciality model)
        {
            _dbContext.SpecialityPersonalisationSpeciality.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationSpeciality(Guid id, SpecialityPersonalisationSpeciality updatedEntity)
        {
            _dbContext.SpecialityPersonalisationSpeciality.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationSpeciality(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationSpeciality.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationSpeciality.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationSpeciality(Guid id, JsonPatchDocument<SpecialityPersonalisationSpeciality> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationSpeciality.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationSpeciality.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}