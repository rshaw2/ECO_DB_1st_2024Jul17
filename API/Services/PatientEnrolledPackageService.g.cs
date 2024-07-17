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
    /// The patientenrolledpackageService responsible for managing patientenrolledpackage related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackage information.
    /// </remarks>
    public interface IPatientEnrolledPackageService
    {
        /// <summary>Retrieves a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <returns>The patientenrolledpackage data</returns>
        PatientEnrolledPackage GetById(Guid id);

        /// <summary>Retrieves a list of patientenrolledpackages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackages</returns>
        List<PatientEnrolledPackage> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientenrolledpackage</summary>
        /// <param name="model">The patientenrolledpackage data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientEnrolledPackage model);

        /// <summary>Updates a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <param name="updatedEntity">The patientenrolledpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientEnrolledPackage updatedEntity);

        /// <summary>Updates a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <param name="updatedEntity">The patientenrolledpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackage> updatedEntity);

        /// <summary>Deletes a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientenrolledpackageService responsible for managing patientenrolledpackage related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackage information.
    /// </remarks>
    public class PatientEnrolledPackageService : IPatientEnrolledPackageService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackage class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientEnrolledPackageService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <returns>The patientenrolledpackage data</returns>
        public PatientEnrolledPackage GetById(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackage.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientenrolledpackages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackages</returns>/// <exception cref="Exception"></exception>
        public List<PatientEnrolledPackage> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientEnrolledPackage(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientenrolledpackage</summary>
        /// <param name="model">The patientenrolledpackage data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientEnrolledPackage model)
        {
            model.Id = CreatePatientEnrolledPackage(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <param name="updatedEntity">The patientenrolledpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientEnrolledPackage updatedEntity)
        {
            UpdatePatientEnrolledPackage(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <param name="updatedEntity">The patientenrolledpackage data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackage> updatedEntity)
        {
            PatchPatientEnrolledPackage(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientenrolledpackage by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackage</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientEnrolledPackage(id);
            return true;
        }
        #region
        private List<PatientEnrolledPackage> GetPatientEnrolledPackage(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientEnrolledPackage.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientEnrolledPackage>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientEnrolledPackage), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientEnrolledPackage, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientEnrolledPackage(PatientEnrolledPackage model)
        {
            _dbContext.PatientEnrolledPackage.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientEnrolledPackage(Guid id, PatientEnrolledPackage updatedEntity)
        {
            _dbContext.PatientEnrolledPackage.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientEnrolledPackage(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackage.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientEnrolledPackage.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientEnrolledPackage(Guid id, JsonPatchDocument<PatientEnrolledPackage> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientEnrolledPackage.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientEnrolledPackage.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}