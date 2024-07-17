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
    /// The paymentcounterService responsible for managing paymentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting paymentcounter information.
    /// </remarks>
    public interface IPaymentCounterService
    {
        /// <summary>Retrieves a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <returns>The paymentcounter data</returns>
        PaymentCounter GetById(Guid id);

        /// <summary>Retrieves a list of paymentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of paymentcounters</returns>
        List<PaymentCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new paymentcounter</summary>
        /// <param name="model">The paymentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(PaymentCounter model);

        /// <summary>Updates a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <param name="updatedEntity">The paymentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PaymentCounter updatedEntity);

        /// <summary>Updates a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <param name="updatedEntity">The paymentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PaymentCounter> updatedEntity);

        /// <summary>Deletes a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The paymentcounterService responsible for managing paymentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting paymentcounter information.
    /// </remarks>
    public class PaymentCounterService : IPaymentCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PaymentCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PaymentCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <returns>The paymentcounter data</returns>
        public PaymentCounter GetById(Guid id)
        {
            var entityData = _dbContext.PaymentCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of paymentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of paymentcounters</returns>/// <exception cref="Exception"></exception>
        public List<PaymentCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPaymentCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new paymentcounter</summary>
        /// <param name="model">The paymentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(PaymentCounter model)
        {
            model.TenantId = CreatePaymentCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <param name="updatedEntity">The paymentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PaymentCounter updatedEntity)
        {
            UpdatePaymentCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <param name="updatedEntity">The paymentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PaymentCounter> updatedEntity)
        {
            PatchPaymentCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific paymentcounter by its primary key</summary>
        /// <param name="id">The primary key of the paymentcounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePaymentCounter(id);
            return true;
        }
        #region
        private List<PaymentCounter> GetPaymentCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PaymentCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PaymentCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PaymentCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PaymentCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreatePaymentCounter(PaymentCounter model)
        {
            _dbContext.PaymentCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdatePaymentCounter(Guid id, PaymentCounter updatedEntity)
        {
            _dbContext.PaymentCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePaymentCounter(Guid id)
        {
            var entityData = _dbContext.PaymentCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PaymentCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPaymentCounter(Guid id, JsonPatchDocument<PaymentCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PaymentCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PaymentCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}