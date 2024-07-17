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
    /// The doctordiagnosisService responsible for managing doctordiagnosis related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctordiagnosis information.
    /// </remarks>
    public interface IDoctorDiagnosisService
    {
        /// <summary>Retrieves a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <returns>The doctordiagnosis data</returns>
        DoctorDiagnosis GetById(Guid id);

        /// <summary>Retrieves a list of doctordiagnosiss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctordiagnosiss</returns>
        List<DoctorDiagnosis> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctordiagnosis</summary>
        /// <param name="model">The doctordiagnosis data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorDiagnosis model);

        /// <summary>Updates a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <param name="updatedEntity">The doctordiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorDiagnosis updatedEntity);

        /// <summary>Updates a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <param name="updatedEntity">The doctordiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorDiagnosis> updatedEntity);

        /// <summary>Deletes a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctordiagnosisService responsible for managing doctordiagnosis related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctordiagnosis information.
    /// </remarks>
    public class DoctorDiagnosisService : IDoctorDiagnosisService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorDiagnosis class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorDiagnosisService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <returns>The doctordiagnosis data</returns>
        public DoctorDiagnosis GetById(Guid id)
        {
            var entityData = _dbContext.DoctorDiagnosis.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctordiagnosiss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctordiagnosiss</returns>/// <exception cref="Exception"></exception>
        public List<DoctorDiagnosis> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorDiagnosis(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctordiagnosis</summary>
        /// <param name="model">The doctordiagnosis data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorDiagnosis model)
        {
            model.Id = CreateDoctorDiagnosis(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <param name="updatedEntity">The doctordiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorDiagnosis updatedEntity)
        {
            UpdateDoctorDiagnosis(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <param name="updatedEntity">The doctordiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorDiagnosis> updatedEntity)
        {
            PatchDoctorDiagnosis(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctordiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the doctordiagnosis</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorDiagnosis(id);
            return true;
        }
        #region
        private List<DoctorDiagnosis> GetDoctorDiagnosis(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorDiagnosis.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorDiagnosis>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorDiagnosis), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorDiagnosis, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorDiagnosis(DoctorDiagnosis model)
        {
            _dbContext.DoctorDiagnosis.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorDiagnosis(Guid id, DoctorDiagnosis updatedEntity)
        {
            _dbContext.DoctorDiagnosis.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorDiagnosis(Guid id)
        {
            var entityData = _dbContext.DoctorDiagnosis.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorDiagnosis.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorDiagnosis(Guid id, JsonPatchDocument<DoctorDiagnosis> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorDiagnosis.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorDiagnosis.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}