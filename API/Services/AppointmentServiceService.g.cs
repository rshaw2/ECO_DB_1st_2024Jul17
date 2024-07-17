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
    /// The appointmentserviceService responsible for managing appointmentservice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting appointmentservice information.
    /// </remarks>
    public interface IAppointmentServiceService
    {
        /// <summary>Retrieves a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <returns>The appointmentservice data</returns>
        Entities.AppointmentService GetById(Guid id);

        /// <summary>Retrieves a list of appointmentservices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointmentservices</returns>
        List<Entities.AppointmentService> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new appointmentservice</summary>
        /// <param name="model">The appointmentservice data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Entities.AppointmentService model);

        /// <summary>Updates a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <param name="updatedEntity">The appointmentservice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Entities.AppointmentService updatedEntity);

        /// <summary>Updates a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <param name="updatedEntity">The appointmentservice data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Entities.AppointmentService> updatedEntity);

        /// <summary>Deletes a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The appointmentserviceService responsible for managing appointmentservice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting appointmentservice information.
    /// </remarks>
    public class AppointmentServiceService : IAppointmentServiceService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the AppointmentService class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public AppointmentServiceService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <returns>The appointmentservice data</returns>
        public Entities.AppointmentService GetById(Guid id)
        {
            var entityData = _dbContext.AppointmentService.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of appointmentservices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointmentservices</returns>/// <exception cref="Exception"></exception>
        public List<Entities.AppointmentService> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetAppointmentService(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new appointmentservice</summary>
        /// <param name="model">The appointmentservice data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Entities.AppointmentService model)
        {
            model.Id = CreateAppointmentService(model);
            return model.Id;
        }

        /// <summary>Updates a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <param name="updatedEntity">The appointmentservice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Entities.AppointmentService updatedEntity)
        {
            UpdateAppointmentService(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <param name="updatedEntity">The appointmentservice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Entities.AppointmentService> updatedEntity)
        {
            PatchAppointmentService(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific appointmentservice by its primary key</summary>
        /// <param name="id">The primary key of the appointmentservice</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteAppointmentService(id);
            return true;
        }
        #region
        private List<Entities.AppointmentService> GetAppointmentService(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AppointmentService.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Entities.AppointmentService>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Entities.AppointmentService), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Entities.AppointmentService, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateAppointmentService(Entities.AppointmentService model)
        {
            _dbContext.AppointmentService.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateAppointmentService(Guid id, Entities.AppointmentService updatedEntity)
        {
            _dbContext.AppointmentService.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteAppointmentService(Guid id)
        {
            var entityData = _dbContext.AppointmentService.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AppointmentService.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchAppointmentService(Guid id, JsonPatchDocument<Entities.AppointmentService> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AppointmentService.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AppointmentService.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}