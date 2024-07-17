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
    /// The examinationsectionService responsible for managing examinationsection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationsection information.
    /// </remarks>
    public interface IExaminationSectionService
    {
        /// <summary>Retrieves a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <returns>The examinationsection data</returns>
        ExaminationSection GetById(Guid id);

        /// <summary>Retrieves a list of examinationsections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationsections</returns>
        List<ExaminationSection> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new examinationsection</summary>
        /// <param name="model">The examinationsection data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ExaminationSection model);

        /// <summary>Updates a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <param name="updatedEntity">The examinationsection data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ExaminationSection updatedEntity);

        /// <summary>Updates a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <param name="updatedEntity">The examinationsection data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ExaminationSection> updatedEntity);

        /// <summary>Deletes a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The examinationsectionService responsible for managing examinationsection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting examinationsection information.
    /// </remarks>
    public class ExaminationSectionService : IExaminationSectionService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ExaminationSection class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ExaminationSectionService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <returns>The examinationsection data</returns>
        public ExaminationSection GetById(Guid id)
        {
            var entityData = _dbContext.ExaminationSection.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of examinationsections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of examinationsections</returns>/// <exception cref="Exception"></exception>
        public List<ExaminationSection> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetExaminationSection(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new examinationsection</summary>
        /// <param name="model">The examinationsection data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ExaminationSection model)
        {
            model.Id = CreateExaminationSection(model);
            return model.Id;
        }

        /// <summary>Updates a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <param name="updatedEntity">The examinationsection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ExaminationSection updatedEntity)
        {
            UpdateExaminationSection(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <param name="updatedEntity">The examinationsection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ExaminationSection> updatedEntity)
        {
            PatchExaminationSection(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific examinationsection by its primary key</summary>
        /// <param name="id">The primary key of the examinationsection</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteExaminationSection(id);
            return true;
        }
        #region
        private List<ExaminationSection> GetExaminationSection(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ExaminationSection.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ExaminationSection>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ExaminationSection), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ExaminationSection, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateExaminationSection(ExaminationSection model)
        {
            _dbContext.ExaminationSection.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateExaminationSection(Guid id, ExaminationSection updatedEntity)
        {
            _dbContext.ExaminationSection.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteExaminationSection(Guid id)
        {
            var entityData = _dbContext.ExaminationSection.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ExaminationSection.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchExaminationSection(Guid id, JsonPatchDocument<ExaminationSection> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ExaminationSection.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ExaminationSection.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}