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
    /// The chiefcomplainttemplateService responsible for managing chiefcomplainttemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplainttemplate information.
    /// </remarks>
    public interface IChiefComplaintTemplateService
    {
        /// <summary>Retrieves a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <returns>The chiefcomplainttemplate data</returns>
        ChiefComplaintTemplate GetById(Guid id);

        /// <summary>Retrieves a list of chiefcomplainttemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplainttemplates</returns>
        List<ChiefComplaintTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new chiefcomplainttemplate</summary>
        /// <param name="model">The chiefcomplainttemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ChiefComplaintTemplate model);

        /// <summary>Updates a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <param name="updatedEntity">The chiefcomplainttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ChiefComplaintTemplate updatedEntity);

        /// <summary>Updates a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <param name="updatedEntity">The chiefcomplainttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ChiefComplaintTemplate> updatedEntity);

        /// <summary>Deletes a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The chiefcomplainttemplateService responsible for managing chiefcomplainttemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplainttemplate information.
    /// </remarks>
    public class ChiefComplaintTemplateService : IChiefComplaintTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ChiefComplaintTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <returns>The chiefcomplainttemplate data</returns>
        public ChiefComplaintTemplate GetById(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of chiefcomplainttemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplainttemplates</returns>/// <exception cref="Exception"></exception>
        public List<ChiefComplaintTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetChiefComplaintTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new chiefcomplainttemplate</summary>
        /// <param name="model">The chiefcomplainttemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ChiefComplaintTemplate model)
        {
            model.Id = CreateChiefComplaintTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <param name="updatedEntity">The chiefcomplainttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ChiefComplaintTemplate updatedEntity)
        {
            UpdateChiefComplaintTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <param name="updatedEntity">The chiefcomplainttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ChiefComplaintTemplate> updatedEntity)
        {
            PatchChiefComplaintTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific chiefcomplainttemplate by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteChiefComplaintTemplate(id);
            return true;
        }
        #region
        private List<ChiefComplaintTemplate> GetChiefComplaintTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ChiefComplaintTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ChiefComplaintTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ChiefComplaintTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ChiefComplaintTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateChiefComplaintTemplate(ChiefComplaintTemplate model)
        {
            _dbContext.ChiefComplaintTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateChiefComplaintTemplate(Guid id, ChiefComplaintTemplate updatedEntity)
        {
            _dbContext.ChiefComplaintTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteChiefComplaintTemplate(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ChiefComplaintTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchChiefComplaintTemplate(Guid id, JsonPatchDocument<ChiefComplaintTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ChiefComplaintTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ChiefComplaintTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}