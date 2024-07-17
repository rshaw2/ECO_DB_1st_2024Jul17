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
    /// The procedureorderService responsible for managing procedureorder related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureorder information.
    /// </remarks>
    public interface IProcedureOrderService
    {
        /// <summary>Retrieves a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <returns>The procedureorder data</returns>
        ProcedureOrder GetById(Guid id);

        /// <summary>Retrieves a list of procedureorders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureorders</returns>
        List<ProcedureOrder> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new procedureorder</summary>
        /// <param name="model">The procedureorder data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureOrder model);

        /// <summary>Updates a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <param name="updatedEntity">The procedureorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureOrder updatedEntity);

        /// <summary>Updates a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <param name="updatedEntity">The procedureorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureOrder> updatedEntity);

        /// <summary>Deletes a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The procedureorderService responsible for managing procedureorder related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedureorder information.
    /// </remarks>
    public class ProcedureOrderService : IProcedureOrderService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureOrder class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureOrderService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <returns>The procedureorder data</returns>
        public ProcedureOrder GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureOrder.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of procedureorders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedureorders</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureOrder> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureOrder(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new procedureorder</summary>
        /// <param name="model">The procedureorder data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureOrder model)
        {
            model.Id = CreateProcedureOrder(model);
            return model.Id;
        }

        /// <summary>Updates a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <param name="updatedEntity">The procedureorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureOrder updatedEntity)
        {
            UpdateProcedureOrder(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <param name="updatedEntity">The procedureorder data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureOrder> updatedEntity)
        {
            PatchProcedureOrder(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific procedureorder by its primary key</summary>
        /// <param name="id">The primary key of the procedureorder</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureOrder(id);
            return true;
        }
        #region
        private List<ProcedureOrder> GetProcedureOrder(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureOrder.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureOrder>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureOrder), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureOrder, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureOrder(ProcedureOrder model)
        {
            _dbContext.ProcedureOrder.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureOrder(Guid id, ProcedureOrder updatedEntity)
        {
            _dbContext.ProcedureOrder.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureOrder(Guid id)
        {
            var entityData = _dbContext.ProcedureOrder.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureOrder.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureOrder(Guid id, JsonPatchDocument<ProcedureOrder> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureOrder.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureOrder.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}