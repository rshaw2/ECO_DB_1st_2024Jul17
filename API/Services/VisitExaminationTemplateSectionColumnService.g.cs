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
    /// The visitexaminationtemplatesectioncolumnService responsible for managing visitexaminationtemplatesectioncolumn related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesectioncolumn information.
    /// </remarks>
    public interface IVisitExaminationTemplateSectionColumnService
    {
        /// <summary>Retrieves a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <returns>The visitexaminationtemplatesectioncolumn data</returns>
        VisitExaminationTemplateSectionColumn GetById(Guid id);

        /// <summary>Retrieves a list of visitexaminationtemplatesectioncolumns based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesectioncolumns</returns>
        List<VisitExaminationTemplateSectionColumn> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitexaminationtemplatesectioncolumn</summary>
        /// <param name="model">The visitexaminationtemplatesectioncolumn data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitExaminationTemplateSectionColumn model);

        /// <summary>Updates a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectioncolumn data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitExaminationTemplateSectionColumn updatedEntity);

        /// <summary>Updates a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectioncolumn data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionColumn> updatedEntity);

        /// <summary>Deletes a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitexaminationtemplatesectioncolumnService responsible for managing visitexaminationtemplatesectioncolumn related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesectioncolumn information.
    /// </remarks>
    public class VisitExaminationTemplateSectionColumnService : IVisitExaminationTemplateSectionColumnService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitExaminationTemplateSectionColumn class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitExaminationTemplateSectionColumnService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <returns>The visitexaminationtemplatesectioncolumn data</returns>
        public VisitExaminationTemplateSectionColumn GetById(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSectionColumn.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitexaminationtemplatesectioncolumns based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesectioncolumns</returns>/// <exception cref="Exception"></exception>
        public List<VisitExaminationTemplateSectionColumn> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitExaminationTemplateSectionColumn(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitexaminationtemplatesectioncolumn</summary>
        /// <param name="model">The visitexaminationtemplatesectioncolumn data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitExaminationTemplateSectionColumn model)
        {
            model.Id = CreateVisitExaminationTemplateSectionColumn(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectioncolumn data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitExaminationTemplateSectionColumn updatedEntity)
        {
            UpdateVisitExaminationTemplateSectionColumn(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesectioncolumn data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionColumn> updatedEntity)
        {
            PatchVisitExaminationTemplateSectionColumn(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitexaminationtemplatesectioncolumn by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesectioncolumn</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitExaminationTemplateSectionColumn(id);
            return true;
        }
        #region
        private List<VisitExaminationTemplateSectionColumn> GetVisitExaminationTemplateSectionColumn(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitExaminationTemplateSectionColumn.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitExaminationTemplateSectionColumn>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitExaminationTemplateSectionColumn), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitExaminationTemplateSectionColumn, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitExaminationTemplateSectionColumn(VisitExaminationTemplateSectionColumn model)
        {
            _dbContext.VisitExaminationTemplateSectionColumn.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitExaminationTemplateSectionColumn(Guid id, VisitExaminationTemplateSectionColumn updatedEntity)
        {
            _dbContext.VisitExaminationTemplateSectionColumn.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitExaminationTemplateSectionColumn(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSectionColumn.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitExaminationTemplateSectionColumn.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitExaminationTemplateSectionColumn(Guid id, JsonPatchDocument<VisitExaminationTemplateSectionColumn> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitExaminationTemplateSectionColumn.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitExaminationTemplateSectionColumn.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}