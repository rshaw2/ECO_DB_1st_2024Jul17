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
    /// The patientenrolledpackagescheduleService responsible for managing patientenrolledpackageschedule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackageschedule information.
    /// </remarks>
    public interface IPatientEnrolledPackageScheduleService
    {
        /// <summary>Retrieves a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <returns>The patientenrolledpackageschedule data</returns>
        PatientEnrolledPackageSchedule GetById(Guid id);

        /// <summary>Retrieves a list of patientenrolledpackageschedules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackageschedules</returns>
        List<PatientEnrolledPackageSchedule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientenrolledpackageschedule</summary>
        /// <param name="model">The patientenrolledpackageschedule data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientEnrolledPackageSchedule model);

        /// <summary>Updates a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientEnrolledPackageSchedule updatedEntity);

        /// <summary>Updates a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackageSchedule> updatedEntity);

        /// <summary>Deletes a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientenrolledpackagescheduleService responsible for managing patientenrolledpackageschedule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackageschedule information.
    /// </remarks>
    public class PatientEnrolledPackageScheduleService : IPatientEnrolledPackageScheduleService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackageSchedule class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientEnrolledPackageScheduleService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <returns>The patientenrolledpackageschedule data</returns>
        public PatientEnrolledPackageSchedule GetById(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackageSchedule.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientenrolledpackageschedules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackageschedules</returns>/// <exception cref="Exception"></exception>
        public List<PatientEnrolledPackageSchedule> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientEnrolledPackageSchedule(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientenrolledpackageschedule</summary>
        /// <param name="model">The patientenrolledpackageschedule data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientEnrolledPackageSchedule model)
        {
            model.Id = CreatePatientEnrolledPackageSchedule(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientEnrolledPackageSchedule updatedEntity)
        {
            UpdatePatientEnrolledPackageSchedule(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <param name="updatedEntity">The patientenrolledpackageschedule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackageSchedule> updatedEntity)
        {
            PatchPatientEnrolledPackageSchedule(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientenrolledpackageschedule by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageschedule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientEnrolledPackageSchedule(id);
            return true;
        }
        #region
        private List<PatientEnrolledPackageSchedule> GetPatientEnrolledPackageSchedule(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientEnrolledPackageSchedule.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientEnrolledPackageSchedule>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientEnrolledPackageSchedule), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientEnrolledPackageSchedule, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientEnrolledPackageSchedule(PatientEnrolledPackageSchedule model)
        {
            _dbContext.PatientEnrolledPackageSchedule.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientEnrolledPackageSchedule(Guid id, PatientEnrolledPackageSchedule updatedEntity)
        {
            _dbContext.PatientEnrolledPackageSchedule.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientEnrolledPackageSchedule(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackageSchedule.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientEnrolledPackageSchedule.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientEnrolledPackageSchedule(Guid id, JsonPatchDocument<PatientEnrolledPackageSchedule> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientEnrolledPackageSchedule.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientEnrolledPackageSchedule.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}