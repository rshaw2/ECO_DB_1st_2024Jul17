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
    /// The examinationsectiongroupService responsible for managing examinationsectiongroup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationsectiongroup information.
    /// </remarks>
    public interface IExaminationSectionGroupService
    {
        /// <summary>Retrieves a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <returns>The examinationsectiongroup data</returns>
        ExaminationSectionGroup GetById(Guid id);

        /// <summary>Retrieves a list of examinationsectiongroups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationsectiongroups</returns>
        List<ExaminationSectionGroup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new examinationsectiongroup</summary>
        /// <param name="model">The examinationsectiongroup data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ExaminationSectionGroup model);

        /// <summary>Updates a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <param name="updatedEntity">The examinationsectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ExaminationSectionGroup updatedEntity);

        /// <summary>Updates a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <param name="updatedEntity">The examinationsectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ExaminationSectionGroup> updatedEntity);

        /// <summary>Deletes a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The examinationsectiongroupService responsible for managing examinationsectiongroup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationsectiongroup information.
    /// </remarks>
    public class ExaminationSectionGroupService : IExaminationSectionGroupService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ExaminationSectionGroup class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ExaminationSectionGroupService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <returns>The examinationsectiongroup data</returns>
        public ExaminationSectionGroup GetById(Guid id)
        {
            var entityData = _dbContext.ExaminationSectionGroup.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of examinationsectiongroups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationsectiongroups</returns>/// <exception cref="Exception"></exception>
        public List<ExaminationSectionGroup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetExaminationSectionGroup(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new examinationsectiongroup</summary>
        /// <param name="model">The examinationsectiongroup data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ExaminationSectionGroup model)
        {
            model.Id = CreateExaminationSectionGroup(model);
            return model.Id;
        }

        /// <summary>Updates a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <param name="updatedEntity">The examinationsectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ExaminationSectionGroup updatedEntity)
        {
            UpdateExaminationSectionGroup(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <param name="updatedEntity">The examinationsectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ExaminationSectionGroup> updatedEntity)
        {
            PatchExaminationSectionGroup(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific examinationsectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroup</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteExaminationSectionGroup(id);
            return true;
        }
        #region
        private List<ExaminationSectionGroup> GetExaminationSectionGroup(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ExaminationSectionGroup.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ExaminationSectionGroup>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ExaminationSectionGroup), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ExaminationSectionGroup, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateExaminationSectionGroup(ExaminationSectionGroup model)
        {
            _dbContext.ExaminationSectionGroup.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateExaminationSectionGroup(Guid id, ExaminationSectionGroup updatedEntity)
        {
            _dbContext.ExaminationSectionGroup.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteExaminationSectionGroup(Guid id)
        {
            var entityData = _dbContext.ExaminationSectionGroup.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ExaminationSectionGroup.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchExaminationSectionGroup(Guid id, JsonPatchDocument<ExaminationSectionGroup> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ExaminationSectionGroup.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ExaminationSectionGroup.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}