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
    /// The enrolledprogramrewardService responsible for managing enrolledprogramreward related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting enrolledprogramreward information.
    /// </remarks>
    public interface IEnrolledProgramRewardService
    {
        /// <summary>Retrieves a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <returns>The enrolledprogramreward data</returns>
        EnrolledProgramReward GetById(Guid id);

        /// <summary>Retrieves a list of enrolledprogramrewards based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of enrolledprogramrewards</returns>
        List<EnrolledProgramReward> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new enrolledprogramreward</summary>
        /// <param name="model">The enrolledprogramreward data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EnrolledProgramReward model);

        /// <summary>Updates a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <param name="updatedEntity">The enrolledprogramreward data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EnrolledProgramReward updatedEntity);

        /// <summary>Updates a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <param name="updatedEntity">The enrolledprogramreward data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EnrolledProgramReward> updatedEntity);

        /// <summary>Deletes a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The enrolledprogramrewardService responsible for managing enrolledprogramreward related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting enrolledprogramreward information.
    /// </remarks>
    public class EnrolledProgramRewardService : IEnrolledProgramRewardService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EnrolledProgramReward class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EnrolledProgramRewardService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <returns>The enrolledprogramreward data</returns>
        public EnrolledProgramReward GetById(Guid id)
        {
            var entityData = _dbContext.EnrolledProgramReward.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of enrolledprogramrewards based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of enrolledprogramrewards</returns>/// <exception cref="Exception"></exception>
        public List<EnrolledProgramReward> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEnrolledProgramReward(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new enrolledprogramreward</summary>
        /// <param name="model">The enrolledprogramreward data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EnrolledProgramReward model)
        {
            model.Id = CreateEnrolledProgramReward(model);
            return model.Id;
        }

        /// <summary>Updates a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <param name="updatedEntity">The enrolledprogramreward data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EnrolledProgramReward updatedEntity)
        {
            UpdateEnrolledProgramReward(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <param name="updatedEntity">The enrolledprogramreward data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EnrolledProgramReward> updatedEntity)
        {
            PatchEnrolledProgramReward(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific enrolledprogramreward by its primary key</summary>
        /// <param name="id">The primary key of the enrolledprogramreward</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEnrolledProgramReward(id);
            return true;
        }
        #region
        private List<EnrolledProgramReward> GetEnrolledProgramReward(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EnrolledProgramReward.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EnrolledProgramReward>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EnrolledProgramReward), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EnrolledProgramReward, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEnrolledProgramReward(EnrolledProgramReward model)
        {
            _dbContext.EnrolledProgramReward.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEnrolledProgramReward(Guid id, EnrolledProgramReward updatedEntity)
        {
            _dbContext.EnrolledProgramReward.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEnrolledProgramReward(Guid id)
        {
            var entityData = _dbContext.EnrolledProgramReward.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EnrolledProgramReward.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEnrolledProgramReward(Guid id, JsonPatchDocument<EnrolledProgramReward> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EnrolledProgramReward.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EnrolledProgramReward.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}