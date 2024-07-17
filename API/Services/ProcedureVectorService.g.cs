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
    /// The procedurevectorService responsible for managing procedurevector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedurevector information.
    /// </remarks>
    public interface IProcedureVectorService
    {
        /// <summary>Retrieves a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <returns>The procedurevector data</returns>
        ProcedureVector GetById(Guid id);

        /// <summary>Retrieves a list of procedurevectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedurevectors</returns>
        List<ProcedureVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new procedurevector</summary>
        /// <param name="model">The procedurevector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureVector model);

        /// <summary>Updates a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <param name="updatedEntity">The procedurevector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureVector updatedEntity);

        /// <summary>Updates a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <param name="updatedEntity">The procedurevector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureVector> updatedEntity);

        /// <summary>Deletes a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The procedurevectorService responsible for managing procedurevector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting procedurevector information.
    /// </remarks>
    public class ProcedureVectorService : IProcedureVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <returns>The procedurevector data</returns>
        public ProcedureVector GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of procedurevectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of procedurevectors</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new procedurevector</summary>
        /// <param name="model">The procedurevector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureVector model)
        {
            model.Id = CreateProcedureVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <param name="updatedEntity">The procedurevector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureVector updatedEntity)
        {
            UpdateProcedureVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <param name="updatedEntity">The procedurevector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureVector> updatedEntity)
        {
            PatchProcedureVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific procedurevector by its primary key</summary>
        /// <param name="id">The primary key of the procedurevector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureVector(id);
            return true;
        }
        #region
        private List<ProcedureVector> GetProcedureVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureVector(ProcedureVector model)
        {
            _dbContext.ProcedureVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureVector(Guid id, ProcedureVector updatedEntity)
        {
            _dbContext.ProcedureVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureVector(Guid id)
        {
            var entityData = _dbContext.ProcedureVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureVector(Guid id, JsonPatchDocument<ProcedureVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}