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
    /// The examinationsectiongroupparameterService responsible for managing examinationsectiongroupparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationsectiongroupparameter information.
    /// </remarks>
    public interface IExaminationSectionGroupParameterService
    {
        /// <summary>Retrieves a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <returns>The examinationsectiongroupparameter data</returns>
        ExaminationSectionGroupParameter GetById(Guid id);

        /// <summary>Retrieves a list of examinationsectiongroupparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationsectiongroupparameters</returns>
        List<ExaminationSectionGroupParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new examinationsectiongroupparameter</summary>
        /// <param name="model">The examinationsectiongroupparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ExaminationSectionGroupParameter model);

        /// <summary>Updates a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <param name="updatedEntity">The examinationsectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ExaminationSectionGroupParameter updatedEntity);

        /// <summary>Updates a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <param name="updatedEntity">The examinationsectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ExaminationSectionGroupParameter> updatedEntity);

        /// <summary>Deletes a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The examinationsectiongroupparameterService responsible for managing examinationsectiongroupparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationsectiongroupparameter information.
    /// </remarks>
    public class ExaminationSectionGroupParameterService : IExaminationSectionGroupParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ExaminationSectionGroupParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ExaminationSectionGroupParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <returns>The examinationsectiongroupparameter data</returns>
        public ExaminationSectionGroupParameter GetById(Guid id)
        {
            var entityData = _dbContext.ExaminationSectionGroupParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of examinationsectiongroupparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationsectiongroupparameters</returns>/// <exception cref="Exception"></exception>
        public List<ExaminationSectionGroupParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetExaminationSectionGroupParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new examinationsectiongroupparameter</summary>
        /// <param name="model">The examinationsectiongroupparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ExaminationSectionGroupParameter model)
        {
            model.Id = CreateExaminationSectionGroupParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <param name="updatedEntity">The examinationsectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ExaminationSectionGroupParameter updatedEntity)
        {
            UpdateExaminationSectionGroupParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <param name="updatedEntity">The examinationsectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ExaminationSectionGroupParameter> updatedEntity)
        {
            PatchExaminationSectionGroupParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific examinationsectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the examinationsectiongroupparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteExaminationSectionGroupParameter(id);
            return true;
        }
        #region
        private List<ExaminationSectionGroupParameter> GetExaminationSectionGroupParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ExaminationSectionGroupParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ExaminationSectionGroupParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ExaminationSectionGroupParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ExaminationSectionGroupParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateExaminationSectionGroupParameter(ExaminationSectionGroupParameter model)
        {
            _dbContext.ExaminationSectionGroupParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateExaminationSectionGroupParameter(Guid id, ExaminationSectionGroupParameter updatedEntity)
        {
            _dbContext.ExaminationSectionGroupParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteExaminationSectionGroupParameter(Guid id)
        {
            var entityData = _dbContext.ExaminationSectionGroupParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ExaminationSectionGroupParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchExaminationSectionGroupParameter(Guid id, JsonPatchDocument<ExaminationSectionGroupParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ExaminationSectionGroupParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ExaminationSectionGroupParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}