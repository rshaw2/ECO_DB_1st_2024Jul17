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
    /// The visitexaminationtemplatesectiongroupService responsible for managing visitexaminationtemplatesectiongroup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesectiongroup information.
    /// </remarks>
    public interface IVisitExaminationTemplateSectionGroupService
    {
        /// <summary>Retrieves a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <returns>The visitexaminationtemplatesectiongroup data</returns>
        VisitExaminationTemplateSectionGroup GetById(Guid id);

        /// <summary>Retrieves a list of visitexaminationtemplatesectiongroups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesectiongroups</returns>
        List<VisitExaminationTemplateSectionGroup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitexaminationtemplatesectiongroup</summary>
        /// <param name="model">The visitexaminationtemplatesectiongroup data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitExaminationTemplateSectionGroup model);

        /// <summary>Updates a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitExaminationTemplateSectionGroup updatedEntity);

        /// <summary>Updates a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionGroup> updatedEntity);

        /// <summary>Deletes a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitexaminationtemplatesectiongroupService responsible for managing visitexaminationtemplatesectiongroup related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesectiongroup information.
    /// </remarks>
    public class VisitExaminationTemplateSectionGroupService : IVisitExaminationTemplateSectionGroupService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitExaminationTemplateSectionGroup class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitExaminationTemplateSectionGroupService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <returns>The visitexaminationtemplatesectiongroup data</returns>
        public VisitExaminationTemplateSectionGroup GetById(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSectionGroup.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitexaminationtemplatesectiongroups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesectiongroups</returns>/// <exception cref="Exception"></exception>
        public List<VisitExaminationTemplateSectionGroup> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitExaminationTemplateSectionGroup(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitexaminationtemplatesectiongroup</summary>
        /// <param name="model">The visitexaminationtemplatesectiongroup data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitExaminationTemplateSectionGroup model)
        {
            model.Id = CreateVisitExaminationTemplateSectionGroup(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitExaminationTemplateSectionGroup updatedEntity)
        {
            UpdateVisitExaminationTemplateSectionGroup(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectiongroup data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionGroup> updatedEntity)
        {
            PatchVisitExaminationTemplateSectionGroup(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitexaminationtemplatesectiongroup by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectiongroup</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitExaminationTemplateSectionGroup(id);
            return true;
        }
        #region
        private List<VisitExaminationTemplateSectionGroup> GetVisitExaminationTemplateSectionGroup(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitExaminationTemplateSectionGroup.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitExaminationTemplateSectionGroup>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitExaminationTemplateSectionGroup), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitExaminationTemplateSectionGroup, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitExaminationTemplateSectionGroup(VisitExaminationTemplateSectionGroup model)
        {
            _dbContext.VisitExaminationTemplateSectionGroup.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitExaminationTemplateSectionGroup(Guid id, VisitExaminationTemplateSectionGroup updatedEntity)
        {
            _dbContext.VisitExaminationTemplateSectionGroup.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitExaminationTemplateSectionGroup(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSectionGroup.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitExaminationTemplateSectionGroup.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitExaminationTemplateSectionGroup(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionGroup> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitExaminationTemplateSectionGroup.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitExaminationTemplateSectionGroup.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}