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
    /// The patientautoappointmentlinkService responsible for managing patientautoappointmentlink related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientautoappointmentlink information.
    /// </remarks>
    public interface IPatientAutoAppointmentLinkService
    {
        /// <summary>Retrieves a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <returns>The patientautoappointmentlink data</returns>
        PatientAutoAppointmentLink GetById(Guid id);

        /// <summary>Retrieves a list of patientautoappointmentlinks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientautoappointmentlinks</returns>
        List<PatientAutoAppointmentLink> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientautoappointmentlink</summary>
        /// <param name="model">The patientautoappointmentlink data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientAutoAppointmentLink model);

        /// <summary>Updates a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <param name="updatedEntity">The patientautoappointmentlink data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientAutoAppointmentLink updatedEntity);

        /// <summary>Updates a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <param name="updatedEntity">The patientautoappointmentlink data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientAutoAppointmentLink> updatedEntity);

        /// <summary>Deletes a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientautoappointmentlinkService responsible for managing patientautoappointmentlink related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientautoappointmentlink information.
    /// </remarks>
    public class PatientAutoAppointmentLinkService : IPatientAutoAppointmentLinkService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientAutoAppointmentLink class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientAutoAppointmentLinkService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <returns>The patientautoappointmentlink data</returns>
        public PatientAutoAppointmentLink GetById(Guid id)
        {
            var entityData = _dbContext.PatientAutoAppointmentLink.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientautoappointmentlinks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientautoappointmentlinks</returns>/// <exception cref="Exception"></exception>
        public List<PatientAutoAppointmentLink> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientAutoAppointmentLink(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientautoappointmentlink</summary>
        /// <param name="model">The patientautoappointmentlink data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientAutoAppointmentLink model)
        {
            model.Id = CreatePatientAutoAppointmentLink(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <param name="updatedEntity">The patientautoappointmentlink data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientAutoAppointmentLink updatedEntity)
        {
            UpdatePatientAutoAppointmentLink(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <param name="updatedEntity">The patientautoappointmentlink data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientAutoAppointmentLink> updatedEntity)
        {
            PatchPatientAutoAppointmentLink(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientautoappointmentlink by its primary key</summary>
        /// <param name="id">The primary key of the patientautoappointmentlink</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientAutoAppointmentLink(id);
            return true;
        }
        #region
        private List<PatientAutoAppointmentLink> GetPatientAutoAppointmentLink(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientAutoAppointmentLink.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientAutoAppointmentLink>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientAutoAppointmentLink), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientAutoAppointmentLink, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientAutoAppointmentLink(PatientAutoAppointmentLink model)
        {
            _dbContext.PatientAutoAppointmentLink.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientAutoAppointmentLink(Guid id, PatientAutoAppointmentLink updatedEntity)
        {
            _dbContext.PatientAutoAppointmentLink.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientAutoAppointmentLink(Guid id)
        {
            var entityData = _dbContext.PatientAutoAppointmentLink.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientAutoAppointmentLink.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientAutoAppointmentLink(Guid id, JsonPatchDocument<PatientAutoAppointmentLink> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientAutoAppointmentLink.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientAutoAppointmentLink.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}