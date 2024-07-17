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
    /// The patientmedicalhistorynotesService responsible for managing patientmedicalhistorynotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientmedicalhistorynotes information.
    /// </remarks>
    public interface IPatientMedicalHistoryNotesService
    {
        /// <summary>Retrieves a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <returns>The patientmedicalhistorynotes data</returns>
        PatientMedicalHistoryNotes GetById(Guid id);

        /// <summary>Retrieves a list of patientmedicalhistorynotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientmedicalhistorynotess</returns>
        List<PatientMedicalHistoryNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientmedicalhistorynotes</summary>
        /// <param name="model">The patientmedicalhistorynotes data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientMedicalHistoryNotes model);

        /// <summary>Updates a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <param name="updatedEntity">The patientmedicalhistorynotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientMedicalHistoryNotes updatedEntity);

        /// <summary>Updates a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <param name="updatedEntity">The patientmedicalhistorynotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientMedicalHistoryNotes> updatedEntity);

        /// <summary>Deletes a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientmedicalhistorynotesService responsible for managing patientmedicalhistorynotes related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientmedicalhistorynotes information.
    /// </remarks>
    public class PatientMedicalHistoryNotesService : IPatientMedicalHistoryNotesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientMedicalHistoryNotes class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientMedicalHistoryNotesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <returns>The patientmedicalhistorynotes data</returns>
        public PatientMedicalHistoryNotes GetById(Guid id)
        {
            var entityData = _dbContext.PatientMedicalHistoryNotes.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientmedicalhistorynotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientmedicalhistorynotess</returns>/// <exception cref="Exception"></exception>
        public List<PatientMedicalHistoryNotes> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientMedicalHistoryNotes(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientmedicalhistorynotes</summary>
        /// <param name="model">The patientmedicalhistorynotes data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientMedicalHistoryNotes model)
        {
            model.Id = CreatePatientMedicalHistoryNotes(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <param name="updatedEntity">The patientmedicalhistorynotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientMedicalHistoryNotes updatedEntity)
        {
            UpdatePatientMedicalHistoryNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <param name="updatedEntity">The patientmedicalhistorynotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientMedicalHistoryNotes> updatedEntity)
        {
            PatchPatientMedicalHistoryNotes(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientmedicalhistorynotes by its primary key</summary>
        /// <param name="id">The primary key of the patientmedicalhistorynotes</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientMedicalHistoryNotes(id);
            return true;
        }
        #region
        private List<PatientMedicalHistoryNotes> GetPatientMedicalHistoryNotes(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientMedicalHistoryNotes.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientMedicalHistoryNotes>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientMedicalHistoryNotes), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientMedicalHistoryNotes, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientMedicalHistoryNotes(PatientMedicalHistoryNotes model)
        {
            _dbContext.PatientMedicalHistoryNotes.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientMedicalHistoryNotes(Guid id, PatientMedicalHistoryNotes updatedEntity)
        {
            _dbContext.PatientMedicalHistoryNotes.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientMedicalHistoryNotes(Guid id)
        {
            var entityData = _dbContext.PatientMedicalHistoryNotes.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientMedicalHistoryNotes.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientMedicalHistoryNotes(Guid id, JsonPatchDocument<PatientMedicalHistoryNotes> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientMedicalHistoryNotes.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientMedicalHistoryNotes.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}