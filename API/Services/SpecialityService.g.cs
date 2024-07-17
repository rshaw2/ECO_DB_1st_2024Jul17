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
    /// The specialityService responsible for managing speciality related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting speciality information.
    /// </remarks>
    public interface ISpecialityService
    {
        /// <summary>Retrieves a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <returns>The speciality data</returns>
        Speciality GetById(Guid id);

        /// <summary>Retrieves a list of specialitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitys</returns>
        List<Speciality> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new speciality</summary>
        /// <param name="model">The speciality data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Speciality model);

        /// <summary>Updates a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <param name="updatedEntity">The speciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Speciality updatedEntity);

        /// <summary>Updates a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <param name="updatedEntity">The speciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Speciality> updatedEntity);

        /// <summary>Deletes a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialityService responsible for managing speciality related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting speciality information.
    /// </remarks>
    public class SpecialityService : ISpecialityService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Speciality class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <returns>The speciality data</returns>
        public Speciality GetById(Guid id)
        {
            var entityData = _dbContext.Speciality.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitys</returns>/// <exception cref="Exception"></exception>
        public List<Speciality> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpeciality(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new speciality</summary>
        /// <param name="model">The speciality data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Speciality model)
        {
            model.Id = CreateSpeciality(model);
            return model.Id;
        }

        /// <summary>Updates a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <param name="updatedEntity">The speciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Speciality updatedEntity)
        {
            UpdateSpeciality(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <param name="updatedEntity">The speciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Speciality> updatedEntity)
        {
            PatchSpeciality(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific speciality by its primary key</summary>
        /// <param name="id">The primary key of the speciality</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpeciality(id);
            return true;
        }
        #region
        private List<Speciality> GetSpeciality(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Speciality.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Speciality>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Speciality), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Speciality, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpeciality(Speciality model)
        {
            _dbContext.Speciality.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpeciality(Guid id, Speciality updatedEntity)
        {
            _dbContext.Speciality.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpeciality(Guid id)
        {
            var entityData = _dbContext.Speciality.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Speciality.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpeciality(Guid id, JsonPatchDocument<Speciality> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Speciality.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Speciality.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}