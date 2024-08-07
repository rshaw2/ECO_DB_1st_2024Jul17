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
    /// The reportaccessService responsible for managing reportaccess related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting reportaccess information.
    /// </remarks>
    public interface IReportAccessService
    {
        /// <summary>Retrieves a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <returns>The reportaccess data</returns>
        ReportAccess GetById(Guid id);

        /// <summary>Retrieves a list of reportaccesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reportaccesss</returns>
        List<ReportAccess> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new reportaccess</summary>
        /// <param name="model">The reportaccess data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ReportAccess model);

        /// <summary>Updates a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <param name="updatedEntity">The reportaccess data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ReportAccess updatedEntity);

        /// <summary>Updates a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <param name="updatedEntity">The reportaccess data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ReportAccess> updatedEntity);

        /// <summary>Deletes a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The reportaccessService responsible for managing reportaccess related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting reportaccess information.
    /// </remarks>
    public class ReportAccessService : IReportAccessService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ReportAccess class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ReportAccessService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <returns>The reportaccess data</returns>
        public ReportAccess GetById(Guid id)
        {
            var entityData = _dbContext.ReportAccess.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of reportaccesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reportaccesss</returns>/// <exception cref="Exception"></exception>
        public List<ReportAccess> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetReportAccess(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new reportaccess</summary>
        /// <param name="model">The reportaccess data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ReportAccess model)
        {
            model.Id = CreateReportAccess(model);
            return model.Id;
        }

        /// <summary>Updates a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <param name="updatedEntity">The reportaccess data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ReportAccess updatedEntity)
        {
            UpdateReportAccess(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <param name="updatedEntity">The reportaccess data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ReportAccess> updatedEntity)
        {
            PatchReportAccess(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific reportaccess by its primary key</summary>
        /// <param name="id">The primary key of the reportaccess</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteReportAccess(id);
            return true;
        }
        #region
        private List<ReportAccess> GetReportAccess(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ReportAccess.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ReportAccess>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ReportAccess), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ReportAccess, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateReportAccess(ReportAccess model)
        {
            _dbContext.ReportAccess.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateReportAccess(Guid id, ReportAccess updatedEntity)
        {
            _dbContext.ReportAccess.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteReportAccess(Guid id)
        {
            var entityData = _dbContext.ReportAccess.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ReportAccess.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchReportAccess(Guid id, JsonPatchDocument<ReportAccess> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ReportAccess.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ReportAccess.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}