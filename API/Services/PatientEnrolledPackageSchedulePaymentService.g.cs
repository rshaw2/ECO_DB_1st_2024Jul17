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
    /// The patientenrolledpackageschedulepaymentService responsible for managing patientenrolledpackageschedulepayment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackageschedulepayment information.
    /// </remarks>
    public interface IPatientEnrolledPackageSchedulePaymentService
    {
        /// <summary>Retrieves a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <returns>The patientenrolledpackageschedulepayment data</returns>
        PatientEnrolledPackageSchedulePayment GetById(Guid id);

        /// <summary>Retrieves a list of patientenrolledpackageschedulepayments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackageschedulepayments</returns>
        List<PatientEnrolledPackageSchedulePayment> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientenrolledpackageschedulepayment</summary>
        /// <param name="model">The patientenrolledpackageschedulepayment data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientEnrolledPackageSchedulePayment model);

        /// <summary>Updates a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedulepayment data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientEnrolledPackageSchedulePayment updatedEntity);

        /// <summary>Updates a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedulepayment data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackageSchedulePayment> updatedEntity);

        /// <summary>Deletes a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientenrolledpackageschedulepaymentService responsible for managing patientenrolledpackageschedulepayment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackageschedulepayment information.
    /// </remarks>
    public class PatientEnrolledPackageSchedulePaymentService : IPatientEnrolledPackageSchedulePaymentService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackageSchedulePayment class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientEnrolledPackageSchedulePaymentService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <returns>The patientenrolledpackageschedulepayment data</returns>
        public PatientEnrolledPackageSchedulePayment GetById(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackageSchedulePayment.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientenrolledpackageschedulepayments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackageschedulepayments</returns>/// <exception cref="Exception"></exception>
        public List<PatientEnrolledPackageSchedulePayment> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientEnrolledPackageSchedulePayment(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientenrolledpackageschedulepayment</summary>
        /// <param name="model">The patientenrolledpackageschedulepayment data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientEnrolledPackageSchedulePayment model)
        {
            model.Id = CreatePatientEnrolledPackageSchedulePayment(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedulepayment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientEnrolledPackageSchedulePayment updatedEntity)
        {
            UpdatePatientEnrolledPackageSchedulePayment(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedulepayment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackageSchedulePayment> updatedEntity)
        {
            PatchPatientEnrolledPackageSchedulePayment(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientenrolledpackageschedulepayment by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedulepayment</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientEnrolledPackageSchedulePayment(id);
            return true;
        }
        #region
        private List<PatientEnrolledPackageSchedulePayment> GetPatientEnrolledPackageSchedulePayment(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientEnrolledPackageSchedulePayment.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientEnrolledPackageSchedulePayment>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientEnrolledPackageSchedulePayment), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientEnrolledPackageSchedulePayment, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientEnrolledPackageSchedulePayment(PatientEnrolledPackageSchedulePayment model)
        {
            _dbContext.PatientEnrolledPackageSchedulePayment.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientEnrolledPackageSchedulePayment(Guid id, PatientEnrolledPackageSchedulePayment updatedEntity)
        {
            _dbContext.PatientEnrolledPackageSchedulePayment.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientEnrolledPackageSchedulePayment(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackageSchedulePayment.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientEnrolledPackageSchedulePayment.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientEnrolledPackageSchedulePayment(Guid id, JsonPatchDocument<PatientEnrolledPackageSchedulePayment> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientEnrolledPackageSchedulePayment.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientEnrolledPackageSchedulePayment.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}