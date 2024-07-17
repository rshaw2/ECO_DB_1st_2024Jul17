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
    /// The reportService responsible for managing report related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting report information.
    /// </remarks>
    public interface IReportService
    {
        /// <summary>Retrieves a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <returns>The report data</returns>
        Report GetById(Guid id);

        /// <summary>Retrieves a list of reports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reports</returns>
        List<Report> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new report</summary>
        /// <param name="model">The report data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Report model);

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Report updatedEntity);

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Report> updatedEntity);

        /// <summary>Deletes a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The reportService responsible for managing report related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting report information.
    /// </remarks>
    public class ReportService : IReportService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Report class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReportService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <returns>The report data</returns>
        public Report GetById(Guid id)
        {
            var entityData = _dbContext.Report.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of reports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reports</returns>/// <exception cref="Exception"></exception>
        public List<Report> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReport(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new report</summary>
        /// <param name="model">The report data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Report model)
        {
            model.Id = CreateReport(model);
            return model.Id;
        }

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Report updatedEntity)
        {
            UpdateReport(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Report> updatedEntity)
        {
            PatchReport(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReport(id);
            return true;
        }
        #region
        private List<Report> GetReport(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Report.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Report>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Report), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Report, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateReport(Report model)
        {
            _dbContext.Report.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateReport(Guid id, Report updatedEntity)
        {
            _dbContext.Report.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReport(Guid id)
        {
            var entityData = _dbContext.Report.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Report.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReport(Guid id, JsonPatchDocument<Report> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Report.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Report.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}