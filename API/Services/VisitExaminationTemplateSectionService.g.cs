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
    /// The visitexaminationtemplatesectionService responsible for managing visitexaminationtemplatesection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesection information.
    /// </remarks>
    public interface IVisitExaminationTemplateSectionService
    {
        /// <summary>Retrieves a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <returns>The visitexaminationtemplatesection data</returns>
        VisitExaminationTemplateSection GetById(Guid id);

        /// <summary>Retrieves a list of visitexaminationtemplatesections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesections</returns>
        List<VisitExaminationTemplateSection> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitexaminationtemplatesection</summary>
        /// <param name="model">The visitexaminationtemplatesection data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitExaminationTemplateSection model);

        /// <summary>Updates a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitExaminationTemplateSection updatedEntity);

        /// <summary>Updates a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSection> updatedEntity);

        /// <summary>Deletes a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitexaminationtemplatesectionService responsible for managing visitexaminationtemplatesection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitexaminationtemplatesection information.
    /// </remarks>
    public class VisitExaminationTemplateSectionService : IVisitExaminationTemplateSectionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitExaminationTemplateSection class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitExaminationTemplateSectionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <returns>The visitexaminationtemplatesection data</returns>
        public VisitExaminationTemplateSection GetById(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSection.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitexaminationtemplatesections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitexaminationtemplatesections</returns>/// <exception cref="Exception"></exception>
        public List<VisitExaminationTemplateSection> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitExaminationTemplateSection(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitexaminationtemplatesection</summary>
        /// <param name="model">The visitexaminationtemplatesection data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitExaminationTemplateSection model)
        {
            model.Id = CreateVisitExaminationTemplateSection(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitExaminationTemplateSection updatedEntity)
        {
            UpdateVisitExaminationTemplateSection(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <param name="updatedEntity">The visitexaminationtemplatesection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitExaminationTemplateSection> updatedEntity)
        {
            PatchVisitExaminationTemplateSection(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitexaminationtemplatesection by its primary key</summary>
        /// <param name="id">The primary key of the visitexaminationtemplatesection</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitExaminationTemplateSection(id);
            return true;
        }
        #region
        private List<VisitExaminationTemplateSection> GetVisitExaminationTemplateSection(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitExaminationTemplateSection.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitExaminationTemplateSection>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitExaminationTemplateSection), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitExaminationTemplateSection, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitExaminationTemplateSection(VisitExaminationTemplateSection model)
        {
            _dbContext.VisitExaminationTemplateSection.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitExaminationTemplateSection(Guid id, VisitExaminationTemplateSection updatedEntity)
        {
            _dbContext.VisitExaminationTemplateSection.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitExaminationTemplateSection(Guid id)
        {
            var entityData = _dbContext.VisitExaminationTemplateSection.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitExaminationTemplateSection.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitExaminationTemplateSection(Guid id, JsonPatchDocument<VisitExaminationTemplateSection> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitExaminationTemplateSection.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitExaminationTemplateSection.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}