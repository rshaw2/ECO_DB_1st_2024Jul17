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
    /// The investigationvectorService responsible for managing investigationvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationvector information.
    /// </remarks>
    public interface IInvestigationVectorService
    {
        /// <summary>Retrieves a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <returns>The investigationvector data</returns>
        InvestigationVector GetById(Guid id);

        /// <summary>Retrieves a list of investigationvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationvectors</returns>
        List<InvestigationVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new investigationvector</summary>
        /// <param name="model">The investigationvector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InvestigationVector model);

        /// <summary>Updates a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <param name="updatedEntity">The investigationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InvestigationVector updatedEntity);

        /// <summary>Updates a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <param name="updatedEntity">The investigationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InvestigationVector> updatedEntity);

        /// <summary>Deletes a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The investigationvectorService responsible for managing investigationvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting investigationvector information.
    /// </remarks>
    public class InvestigationVectorService : IInvestigationVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InvestigationVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InvestigationVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <returns>The investigationvector data</returns>
        public InvestigationVector GetById(Guid id)
        {
            var entityData = _dbContext.InvestigationVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of investigationvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of investigationvectors</returns>/// <exception cref="Exception"></exception>
        public List<InvestigationVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInvestigationVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new investigationvector</summary>
        /// <param name="model">The investigationvector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InvestigationVector model)
        {
            model.Id = CreateInvestigationVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <param name="updatedEntity">The investigationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InvestigationVector updatedEntity)
        {
            UpdateInvestigationVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <param name="updatedEntity">The investigationvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InvestigationVector> updatedEntity)
        {
            PatchInvestigationVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific investigationvector by its primary key</summary>
        /// <param name="id">The primary key of the investigationvector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInvestigationVector(id);
            return true;
        }
        #region
        private List<InvestigationVector> GetInvestigationVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InvestigationVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InvestigationVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InvestigationVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InvestigationVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInvestigationVector(InvestigationVector model)
        {
            _dbContext.InvestigationVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInvestigationVector(Guid id, InvestigationVector updatedEntity)
        {
            _dbContext.InvestigationVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInvestigationVector(Guid id)
        {
            var entityData = _dbContext.InvestigationVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InvestigationVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInvestigationVector(Guid id, JsonPatchDocument<InvestigationVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InvestigationVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InvestigationVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}