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
    /// The clinictypeService responsible for managing clinictype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinictype information.
    /// </remarks>
    public interface IClinicTypeService
    {
        /// <summary>Retrieves a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <returns>The clinictype data</returns>
        ClinicType GetById(Guid id);

        /// <summary>Retrieves a list of clinictypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinictypes</returns>
        List<ClinicType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new clinictype</summary>
        /// <param name="model">The clinictype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ClinicType model);

        /// <summary>Updates a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <param name="updatedEntity">The clinictype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ClinicType updatedEntity);

        /// <summary>Updates a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <param name="updatedEntity">The clinictype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ClinicType> updatedEntity);

        /// <summary>Deletes a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The clinictypeService responsible for managing clinictype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting clinictype information.
    /// </remarks>
    public class ClinicTypeService : IClinicTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ClinicType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ClinicTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <returns>The clinictype data</returns>
        public ClinicType GetById(Guid id)
        {
            var entityData = _dbContext.ClinicType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of clinictypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of clinictypes</returns>/// <exception cref="Exception"></exception>
        public List<ClinicType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetClinicType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new clinictype</summary>
        /// <param name="model">The clinictype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ClinicType model)
        {
            model.Id = CreateClinicType(model);
            return model.Id;
        }

        /// <summary>Updates a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <param name="updatedEntity">The clinictype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ClinicType updatedEntity)
        {
            UpdateClinicType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <param name="updatedEntity">The clinictype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ClinicType> updatedEntity)
        {
            PatchClinicType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific clinictype by its primary key</summary>
        /// <param name="id">The primary key of the clinictype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteClinicType(id);
            return true;
        }
        #region
        private List<ClinicType> GetClinicType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ClinicType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ClinicType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ClinicType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ClinicType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateClinicType(ClinicType model)
        {
            _dbContext.ClinicType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateClinicType(Guid id, ClinicType updatedEntity)
        {
            _dbContext.ClinicType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteClinicType(Guid id)
        {
            var entityData = _dbContext.ClinicType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ClinicType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchClinicType(Guid id, JsonPatchDocument<ClinicType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ClinicType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ClinicType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}