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
    /// The labService responsible for managing lab related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lab information.
    /// </remarks>
    public interface ILabService
    {
        /// <summary>Retrieves a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <returns>The lab data</returns>
        Lab GetById(Guid id);

        /// <summary>Retrieves a list of labs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of labs</returns>
        List<Lab> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new lab</summary>
        /// <param name="model">The lab data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Lab model);

        /// <summary>Updates a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <param name="updatedEntity">The lab data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Lab updatedEntity);

        /// <summary>Updates a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <param name="updatedEntity">The lab data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Lab> updatedEntity);

        /// <summary>Deletes a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The labService responsible for managing lab related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lab information.
    /// </remarks>
    public class LabService : ILabService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Lab class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public LabService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <returns>The lab data</returns>
        public Lab GetById(Guid id)
        {
            var entityData = _dbContext.Lab.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of labs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of labs</returns>/// <exception cref="Exception"></exception>
        public List<Lab> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetLab(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new lab</summary>
        /// <param name="model">The lab data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Lab model)
        {
            model.Id = CreateLab(model);
            return model.Id;
        }

        /// <summary>Updates a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <param name="updatedEntity">The lab data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Lab updatedEntity)
        {
            UpdateLab(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <param name="updatedEntity">The lab data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Lab> updatedEntity)
        {
            PatchLab(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific lab by its primary key</summary>
        /// <param name="id">The primary key of the lab</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteLab(id);
            return true;
        }
        #region
        private List<Lab> GetLab(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Lab.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Lab>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Lab), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Lab, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateLab(Lab model)
        {
            _dbContext.Lab.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateLab(Guid id, Lab updatedEntity)
        {
            _dbContext.Lab.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteLab(Guid id)
        {
            var entityData = _dbContext.Lab.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Lab.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchLab(Guid id, JsonPatchDocument<Lab> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Lab.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Lab.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}