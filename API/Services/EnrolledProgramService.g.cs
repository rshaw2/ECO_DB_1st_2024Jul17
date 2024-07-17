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
    /// The enrolledprogramService responsible for managing enrolledprogram related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting enrolledprogram information.
    /// </remarks>
    public interface IEnrolledProgramService
    {
        /// <summary>Retrieves a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <returns>The enrolledprogram data</returns>
        EnrolledProgram GetById(Guid id);

        /// <summary>Retrieves a list of enrolledprograms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of enrolledprograms</returns>
        List<EnrolledProgram> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new enrolledprogram</summary>
        /// <param name="model">The enrolledprogram data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EnrolledProgram model);

        /// <summary>Updates a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <param name="updatedEntity">The enrolledprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EnrolledProgram updatedEntity);

        /// <summary>Updates a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <param name="updatedEntity">The enrolledprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EnrolledProgram> updatedEntity);

        /// <summary>Deletes a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The enrolledprogramService responsible for managing enrolledprogram related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting enrolledprogram information.
    /// </remarks>
    public class EnrolledProgramService : IEnrolledProgramService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EnrolledProgram class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EnrolledProgramService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <returns>The enrolledprogram data</returns>
        public EnrolledProgram GetById(Guid id)
        {
            var entityData = _dbContext.EnrolledProgram.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of enrolledprograms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of enrolledprograms</returns>/// <exception cref="Exception"></exception>
        public List<EnrolledProgram> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEnrolledProgram(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new enrolledprogram</summary>
        /// <param name="model">The enrolledprogram data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EnrolledProgram model)
        {
            model.Id = CreateEnrolledProgram(model);
            return model.Id;
        }

        /// <summary>Updates a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <param name="updatedEntity">The enrolledprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EnrolledProgram updatedEntity)
        {
            UpdateEnrolledProgram(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <param name="updatedEntity">The enrolledprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EnrolledProgram> updatedEntity)
        {
            PatchEnrolledProgram(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific enrolledprogram by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogram</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEnrolledProgram(id);
            return true;
        }
        #region
        private List<EnrolledProgram> GetEnrolledProgram(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EnrolledProgram.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EnrolledProgram>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EnrolledProgram), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EnrolledProgram, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEnrolledProgram(EnrolledProgram model)
        {
            _dbContext.EnrolledProgram.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEnrolledProgram(Guid id, EnrolledProgram updatedEntity)
        {
            _dbContext.EnrolledProgram.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEnrolledProgram(Guid id)
        {
            var entityData = _dbContext.EnrolledProgram.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EnrolledProgram.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEnrolledProgram(Guid id, JsonPatchDocument<EnrolledProgram> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EnrolledProgram.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EnrolledProgram.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}