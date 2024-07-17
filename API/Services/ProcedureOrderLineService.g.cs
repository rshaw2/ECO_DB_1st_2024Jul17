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
    /// The procedureorderlineService responsible for managing procedureorderline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureorderline information.
    /// </remarks>
    public interface IProcedureOrderLineService
    {
        /// <summary>Retrieves a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <returns>The procedureorderline data</returns>
        ProcedureOrderLine GetById(Guid id);

        /// <summary>Retrieves a list of procedureorderlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureorderlines</returns>
        List<ProcedureOrderLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new procedureorderline</summary>
        /// <param name="model">The procedureorderline data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureOrderLine model);

        /// <summary>Updates a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <param name="updatedEntity">The procedureorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureOrderLine updatedEntity);

        /// <summary>Updates a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <param name="updatedEntity">The procedureorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureOrderLine> updatedEntity);

        /// <summary>Deletes a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The procedureorderlineService responsible for managing procedureorderline related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureorderline information.
    /// </remarks>
    public class ProcedureOrderLineService : IProcedureOrderLineService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureOrderLine class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureOrderLineService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <returns>The procedureorderline data</returns>
        public ProcedureOrderLine GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureOrderLine.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of procedureorderlines based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureorderlines</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureOrderLine> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureOrderLine(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new procedureorderline</summary>
        /// <param name="model">The procedureorderline data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureOrderLine model)
        {
            model.Id = CreateProcedureOrderLine(model);
            return model.Id;
        }

        /// <summary>Updates a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <param name="updatedEntity">The procedureorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureOrderLine updatedEntity)
        {
            UpdateProcedureOrderLine(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <param name="updatedEntity">The procedureorderline data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureOrderLine> updatedEntity)
        {
            PatchProcedureOrderLine(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific procedureorderline by its primary key</summary>
        /// <param name="id">The primary key of the procedureorderline</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureOrderLine(id);
            return true;
        }
        #region
        private List<ProcedureOrderLine> GetProcedureOrderLine(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureOrderLine.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureOrderLine>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureOrderLine), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureOrderLine, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureOrderLine(ProcedureOrderLine model)
        {
            _dbContext.ProcedureOrderLine.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureOrderLine(Guid id, ProcedureOrderLine updatedEntity)
        {
            _dbContext.ProcedureOrderLine.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureOrderLine(Guid id)
        {
            var entityData = _dbContext.ProcedureOrderLine.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureOrderLine.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureOrderLine(Guid id, JsonPatchDocument<ProcedureOrderLine> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureOrderLine.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureOrderLine.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}