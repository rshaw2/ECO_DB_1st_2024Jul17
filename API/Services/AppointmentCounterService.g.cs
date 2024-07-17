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
    /// The appointmentcounterService responsible for managing appointmentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting appointmentcounter information.
    /// </remarks>
    public interface IAppointmentCounterService
    {
        /// <summary>Retrieves a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <returns>The appointmentcounter data</returns>
        AppointmentCounter GetById(Guid id);

        /// <summary>Retrieves a list of appointmentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointmentcounters</returns>
        List<AppointmentCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new appointmentcounter</summary>
        /// <param name="model">The appointmentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid? Create(AppointmentCounter model);

        /// <summary>Updates a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <param name="updatedEntity">The appointmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, AppointmentCounter updatedEntity);

        /// <summary>Updates a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <param name="updatedEntity">The appointmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<AppointmentCounter> updatedEntity);

        /// <summary>Deletes a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The appointmentcounterService responsible for managing appointmentcounter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting appointmentcounter information.
    /// </remarks>
    public class AppointmentCounterService : IAppointmentCounterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AppointmentCounter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AppointmentCounterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <returns>The appointmentcounter data</returns>
        public AppointmentCounter GetById(Guid id)
        {
            var entityData = _dbContext.AppointmentCounter.FirstOrDefault(entity => entity.TenantId == id);
            return entityData;
        }

        /// <summary>Retrieves a list of appointmentcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointmentcounters</returns>/// <exception cref="Exception"></exception>
        public List<AppointmentCounter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAppointmentCounter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new appointmentcounter</summary>
        /// <param name="model">The appointmentcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid? Create(AppointmentCounter model)
        {
            model.TenantId = CreateAppointmentCounter(model);
            return model.TenantId;
        }

        /// <summary>Updates a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <param name="updatedEntity">The appointmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, AppointmentCounter updatedEntity)
        {
            UpdateAppointmentCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <param name="updatedEntity">The appointmentcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<AppointmentCounter> updatedEntity)
        {
            PatchAppointmentCounter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific appointmentcounter by its primary key</summary>
        /// <param name="id">The primary key of the appointmentcounter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAppointmentCounter(id);
            return true;
        }
        #region
        private List<AppointmentCounter> GetAppointmentCounter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AppointmentCounter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AppointmentCounter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AppointmentCounter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AppointmentCounter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid? CreateAppointmentCounter(AppointmentCounter model)
        {
            _dbContext.AppointmentCounter.Add(model);
            _dbContext.SaveChanges();
            return model.TenantId;
        }

        private void UpdateAppointmentCounter(Guid id, AppointmentCounter updatedEntity)
        {
            _dbContext.AppointmentCounter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAppointmentCounter(Guid id)
        {
            var entityData = _dbContext.AppointmentCounter.FirstOrDefault(entity => entity.TenantId == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AppointmentCounter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAppointmentCounter(Guid id, JsonPatchDocument<AppointmentCounter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AppointmentCounter.FirstOrDefault(t => t.TenantId == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AppointmentCounter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}