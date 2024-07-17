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
    /// The patienttagService responsible for managing patienttag related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patienttag information.
    /// </remarks>
    public interface IPatientTagService
    {
        /// <summary>Retrieves a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <returns>The patienttag data</returns>
        PatientTag GetById(Guid id);

        /// <summary>Retrieves a list of patienttags based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patienttags</returns>
        List<PatientTag> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patienttag</summary>
        /// <param name="model">The patienttag data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientTag model);

        /// <summary>Updates a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <param name="updatedEntity">The patienttag data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientTag updatedEntity);

        /// <summary>Updates a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <param name="updatedEntity">The patienttag data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientTag> updatedEntity);

        /// <summary>Deletes a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patienttagService responsible for managing patienttag related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patienttag information.
    /// </remarks>
    public class PatientTagService : IPatientTagService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientTag class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientTagService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <returns>The patienttag data</returns>
        public PatientTag GetById(Guid id)
        {
            var entityData = _dbContext.PatientTag.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patienttags based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patienttags</returns>/// <exception cref="Exception"></exception>
        public List<PatientTag> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientTag(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patienttag</summary>
        /// <param name="model">The patienttag data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientTag model)
        {
            model.Id = CreatePatientTag(model);
            return model.Id;
        }

        /// <summary>Updates a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <param name="updatedEntity">The patienttag data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientTag updatedEntity)
        {
            UpdatePatientTag(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <param name="updatedEntity">The patienttag data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientTag> updatedEntity)
        {
            PatchPatientTag(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patienttag by its primary key</summary>
        /// <param name="id">The primary key of the patienttag</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientTag(id);
            return true;
        }
        #region
        private List<PatientTag> GetPatientTag(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientTag.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientTag>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientTag), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientTag, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientTag(PatientTag model)
        {
            _dbContext.PatientTag.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientTag(Guid id, PatientTag updatedEntity)
        {
            _dbContext.PatientTag.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientTag(Guid id)
        {
            var entityData = _dbContext.PatientTag.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientTag.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientTag(Guid id, JsonPatchDocument<PatientTag> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientTag.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientTag.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}