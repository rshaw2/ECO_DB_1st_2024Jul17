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
    /// The voidreasonService responsible for managing voidreason related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting voidreason information.
    /// </remarks>
    public interface IVoidReasonService
    {
        /// <summary>Retrieves a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <returns>The voidreason data</returns>
        VoidReason GetById(Guid id);

        /// <summary>Retrieves a list of voidreasons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of voidreasons</returns>
        List<VoidReason> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new voidreason</summary>
        /// <param name="model">The voidreason data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VoidReason model);

        /// <summary>Updates a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <param name="updatedEntity">The voidreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VoidReason updatedEntity);

        /// <summary>Updates a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <param name="updatedEntity">The voidreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VoidReason> updatedEntity);

        /// <summary>Deletes a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The voidreasonService responsible for managing voidreason related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting voidreason information.
    /// </remarks>
    public class VoidReasonService : IVoidReasonService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VoidReason class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VoidReasonService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <returns>The voidreason data</returns>
        public VoidReason GetById(Guid id)
        {
            var entityData = _dbContext.VoidReason.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of voidreasons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of voidreasons</returns>/// <exception cref="Exception"></exception>
        public List<VoidReason> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVoidReason(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new voidreason</summary>
        /// <param name="model">The voidreason data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VoidReason model)
        {
            model.Id = CreateVoidReason(model);
            return model.Id;
        }

        /// <summary>Updates a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <param name="updatedEntity">The voidreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VoidReason updatedEntity)
        {
            UpdateVoidReason(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <param name="updatedEntity">The voidreason data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VoidReason> updatedEntity)
        {
            PatchVoidReason(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific voidreason by its primary key</summary>
        /// <param name="id">The primary key of the voidreason</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVoidReason(id);
            return true;
        }
        #region
        private List<VoidReason> GetVoidReason(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VoidReason.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VoidReason>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VoidReason), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VoidReason, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVoidReason(VoidReason model)
        {
            _dbContext.VoidReason.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVoidReason(Guid id, VoidReason updatedEntity)
        {
            _dbContext.VoidReason.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVoidReason(Guid id)
        {
            var entityData = _dbContext.VoidReason.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VoidReason.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVoidReason(Guid id, JsonPatchDocument<VoidReason> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VoidReason.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VoidReason.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}