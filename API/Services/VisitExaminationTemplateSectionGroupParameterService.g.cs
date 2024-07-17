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
    /// The visitexaminationtemplatesectiongroupparameterService responsible for managing visitexaminationtemplatesectiongroupparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesectiongroupparameter information.
    /// </remarks>
    public interface IVisitExaminationTemplateSectionGroupParameterService
    {
        /// <summary>Retrieves a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <returns>The visitexaminationtemplatesectiongroupparameter data</returns>
        VisitExaminationTemplateSectionGroupParameter GetById(Guid id);

        /// <summary>Retrieves a list of visitexaminationtemplatesectiongroupparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesectiongroupparameters</returns>
        List<VisitExaminationTemplateSectionGroupParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitexaminationtemplatesectiongroupparameter</summary>
        /// <param name="model">The visitexaminationtemplatesectiongroupparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitExaminationTemplateSectionGroupParameter model);

        /// <summary>Updates a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitExaminationTemplateSectionGroupParameter updatedEntity);

        /// <summary>Updates a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionGroupParameter> updatedEntity);

        /// <summary>Deletes a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitexaminationtemplatesectiongroupparameterService responsible for managing visitexaminationtemplatesectiongroupparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesectiongroupparameter information.
    /// </remarks>
    public class VisitExaminationTemplateSectionGroupParameterService : IVisitExaminationTemplateSectionGroupParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitExaminationTemplateSectionGroupParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitExaminationTemplateSectionGroupParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <returns>The visitexaminationtemplatesectiongroupparameter data</returns>
        public VisitExaminationTemplateSectionGroupParameter GetById(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSectionGroupParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitexaminationtemplatesectiongroupparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesectiongroupparameters</returns>/// <exception cref="Exception"></exception>
        public List<VisitExaminationTemplateSectionGroupParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitExaminationTemplateSectionGroupParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitexaminationtemplatesectiongroupparameter</summary>
        /// <param name="model">The visitexaminationtemplatesectiongroupparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitExaminationTemplateSectionGroupParameter model)
        {
            model.Id = CreateVisitExaminationTemplateSectionGroupParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitExaminationTemplateSectionGroupParameter updatedEntity)
        {
            UpdateVisitExaminationTemplateSectionGroupParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroupparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionGroupParameter> updatedEntity)
        {
            PatchVisitExaminationTemplateSectionGroupParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitexaminationtemplatesectiongroupparameter by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroupparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitExaminationTemplateSectionGroupParameter(id);
            return true;
        }
        #region
        private List<VisitExaminationTemplateSectionGroupParameter> GetVisitExaminationTemplateSectionGroupParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitExaminationTemplateSectionGroupParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitExaminationTemplateSectionGroupParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitExaminationTemplateSectionGroupParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitExaminationTemplateSectionGroupParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitExaminationTemplateSectionGroupParameter(VisitExaminationTemplateSectionGroupParameter model)
        {
            _dbContext.VisitExaminationTemplateSectionGroupParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitExaminationTemplateSectionGroupParameter(Guid id, VisitExaminationTemplateSectionGroupParameter updatedEntity)
        {
            _dbContext.VisitExaminationTemplateSectionGroupParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitExaminationTemplateSectionGroupParameter(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSectionGroupParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitExaminationTemplateSectionGroupParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitExaminationTemplateSectionGroupParameter(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionGroupParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitExaminationTemplateSectionGroupParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitExaminationTemplateSectionGroupParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}