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
    /// The eccoinbenefitService responsible for managing eccoinbenefit related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting eccoinbenefit information.
    /// </remarks>
    public interface IEcCoinBenefitService
    {
        /// <summary>Retrieves a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <returns>The eccoinbenefit data</returns>
        EcCoinBenefit GetById(Guid id);

        /// <summary>Retrieves a list of eccoinbenefits based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of eccoinbenefits</returns>
        List<EcCoinBenefit> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new eccoinbenefit</summary>
        /// <param name="model">The eccoinbenefit data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(EcCoinBenefit model);

        /// <summary>Updates a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <param name="updatedEntity">The eccoinbenefit data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, EcCoinBenefit updatedEntity);

        /// <summary>Updates a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <param name="updatedEntity">The eccoinbenefit data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<EcCoinBenefit> updatedEntity);

        /// <summary>Deletes a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The eccoinbenefitService responsible for managing eccoinbenefit related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting eccoinbenefit information.
    /// </remarks>
    public class EcCoinBenefitService : IEcCoinBenefitService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the EcCoinBenefit class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public EcCoinBenefitService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <returns>The eccoinbenefit data</returns>
        public EcCoinBenefit GetById(Guid id)
        {
            var entityData = _dbContext.EcCoinBenefit.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of eccoinbenefits based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of eccoinbenefits</returns>/// <exception cref="Exception"></exception>
        public List<EcCoinBenefit> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetEcCoinBenefit(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new eccoinbenefit</summary>
        /// <param name="model">The eccoinbenefit data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(EcCoinBenefit model)
        {
            model.Id = CreateEcCoinBenefit(model);
            return model.Id;
        }

        /// <summary>Updates a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <param name="updatedEntity">The eccoinbenefit data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, EcCoinBenefit updatedEntity)
        {
            UpdateEcCoinBenefit(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <param name="updatedEntity">The eccoinbenefit data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<EcCoinBenefit> updatedEntity)
        {
            PatchEcCoinBenefit(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific eccoinbenefit by its primary key</summary>
        /// <param name="id">The primary key of the eccoinbenefit</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteEcCoinBenefit(id);
            return true;
        }
        #region
        private List<EcCoinBenefit> GetEcCoinBenefit(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EcCoinBenefit.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EcCoinBenefit>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EcCoinBenefit), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EcCoinBenefit, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateEcCoinBenefit(EcCoinBenefit model)
        {
            _dbContext.EcCoinBenefit.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateEcCoinBenefit(Guid id, EcCoinBenefit updatedEntity)
        {
            _dbContext.EcCoinBenefit.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteEcCoinBenefit(Guid id)
        {
            var entityData = _dbContext.EcCoinBenefit.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EcCoinBenefit.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchEcCoinBenefit(Guid id, JsonPatchDocument<EcCoinBenefit> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EcCoinBenefit.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EcCoinBenefit.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}