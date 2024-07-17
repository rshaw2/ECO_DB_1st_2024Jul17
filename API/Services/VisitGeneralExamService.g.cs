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
    /// The visitgeneralexamService responsible for managing visitgeneralexam related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitgeneralexam information.
    /// </remarks>
    public interface IVisitGeneralExamService
    {
        /// <summary>Retrieves a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <returns>The visitgeneralexam data</returns>
        VisitGeneralExam GetById(Guid id);

        /// <summary>Retrieves a list of visitgeneralexams based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitgeneralexams</returns>
        List<VisitGeneralExam> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new visitgeneralexam</summary>
        /// <param name="model">The visitgeneralexam data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VisitGeneralExam model);

        /// <summary>Updates a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <param name="updatedEntity">The visitgeneralexam data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VisitGeneralExam updatedEntity);

        /// <summary>Updates a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <param name="updatedEntity">The visitgeneralexam data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VisitGeneralExam> updatedEntity);

        /// <summary>Deletes a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The visitgeneralexamService responsible for managing visitgeneralexam related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting visitgeneralexam information.
    /// </remarks>
    public class VisitGeneralExamService : IVisitGeneralExamService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VisitGeneralExam class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VisitGeneralExamService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <returns>The visitgeneralexam data</returns>
        public VisitGeneralExam GetById(Guid id)
        {
            var entityData = _dbContext.VisitGeneralExam.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of visitgeneralexams based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of visitgeneralexams</returns>/// <exception cref="Exception"></exception>
        public List<VisitGeneralExam> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVisitGeneralExam(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new visitgeneralexam</summary>
        /// <param name="model">The visitgeneralexam data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VisitGeneralExam model)
        {
            model.Id = CreateVisitGeneralExam(model);
            return model.Id;
        }

        /// <summary>Updates a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <param name="updatedEntity">The visitgeneralexam data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VisitGeneralExam updatedEntity)
        {
            UpdateVisitGeneralExam(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <param name="updatedEntity">The visitgeneralexam data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VisitGeneralExam> updatedEntity)
        {
            PatchVisitGeneralExam(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific visitgeneralexam by its primary key</summary>
        /// <param name="id">The primary key of the visitgeneralexam</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVisitGeneralExam(id);
            return true;
        }
        #region
        private List<VisitGeneralExam> GetVisitGeneralExam(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VisitGeneralExam.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VisitGeneralExam>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VisitGeneralExam), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VisitGeneralExam, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVisitGeneralExam(VisitGeneralExam model)
        {
            _dbContext.VisitGeneralExam.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVisitGeneralExam(Guid id, VisitGeneralExam updatedEntity)
        {
            _dbContext.VisitGeneralExam.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVisitGeneralExam(Guid id)
        {
            var entityData = _dbContext.VisitGeneralExam.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VisitGeneralExam.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVisitGeneralExam(Guid id, JsonPatchDocument<VisitGeneralExam> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VisitGeneralExam.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VisitGeneralExam.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}