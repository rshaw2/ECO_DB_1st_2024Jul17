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
    /// The proceduredeviationService responsible for managing proceduredeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting proceduredeviation information.
    /// </remarks>
    public interface IProcedureDeviationService
    {
        /// <summary>Retrieves a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <returns>The proceduredeviation data</returns>
        ProcedureDeviation GetById(Guid id);

        /// <summary>Retrieves a list of proceduredeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of proceduredeviations</returns>
        List<ProcedureDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new proceduredeviation</summary>
        /// <param name="model">The proceduredeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureDeviation model);

        /// <summary>Updates a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <param name="updatedEntity">The proceduredeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureDeviation updatedEntity);

        /// <summary>Updates a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <param name="updatedEntity">The proceduredeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureDeviation> updatedEntity);

        /// <summary>Deletes a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The proceduredeviationService responsible for managing proceduredeviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting proceduredeviation information.
    /// </remarks>
    public class ProcedureDeviationService : IProcedureDeviationService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureDeviation class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureDeviationService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <returns>The proceduredeviation data</returns>
        public ProcedureDeviation GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureDeviation.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of proceduredeviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of proceduredeviations</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureDeviation> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureDeviation(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new proceduredeviation</summary>
        /// <param name="model">The proceduredeviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureDeviation model)
        {
            model.Id = CreateProcedureDeviation(model);
            return model.Id;
        }

        /// <summary>Updates a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <param name="updatedEntity">The proceduredeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureDeviation updatedEntity)
        {
            UpdateProcedureDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <param name="updatedEntity">The proceduredeviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureDeviation> updatedEntity)
        {
            PatchProcedureDeviation(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific proceduredeviation by its primary key</summary>
        /// <param name="id">The primary key of the proceduredeviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureDeviation(id);
            return true;
        }
        #region
        private List<ProcedureDeviation> GetProcedureDeviation(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureDeviation.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureDeviation>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureDeviation), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureDeviation, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureDeviation(ProcedureDeviation model)
        {
            _dbContext.ProcedureDeviation.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureDeviation(Guid id, ProcedureDeviation updatedEntity)
        {
            _dbContext.ProcedureDeviation.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureDeviation(Guid id)
        {
            var entityData = _dbContext.ProcedureDeviation.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureDeviation.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureDeviation(Guid id, JsonPatchDocument<ProcedureDeviation> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureDeviation.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureDeviation.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}