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
    /// The doctorcomorbidityService responsible for managing doctorcomorbidity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorcomorbidity information.
    /// </remarks>
    public interface IDoctorComorbidityService
    {
        /// <summary>Retrieves a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <returns>The doctorcomorbidity data</returns>
        DoctorComorbidity GetById(Guid id);

        /// <summary>Retrieves a list of doctorcomorbiditys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorcomorbiditys</returns>
        List<DoctorComorbidity> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctorcomorbidity</summary>
        /// <param name="model">The doctorcomorbidity data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorComorbidity model);

        /// <summary>Updates a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <param name="updatedEntity">The doctorcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorComorbidity updatedEntity);

        /// <summary>Updates a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <param name="updatedEntity">The doctorcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorComorbidity> updatedEntity);

        /// <summary>Deletes a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctorcomorbidityService responsible for managing doctorcomorbidity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorcomorbidity information.
    /// </remarks>
    public class DoctorComorbidityService : IDoctorComorbidityService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorComorbidity class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorComorbidityService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <returns>The doctorcomorbidity data</returns>
        public DoctorComorbidity GetById(Guid id)
        {
            var entityData = _dbContext.DoctorComorbidity.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctorcomorbiditys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorcomorbiditys</returns>/// <exception cref="Exception"></exception>
        public List<DoctorComorbidity> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorComorbidity(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctorcomorbidity</summary>
        /// <param name="model">The doctorcomorbidity data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorComorbidity model)
        {
            model.Id = CreateDoctorComorbidity(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <param name="updatedEntity">The doctorcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorComorbidity updatedEntity)
        {
            UpdateDoctorComorbidity(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <param name="updatedEntity">The doctorcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorComorbidity> updatedEntity)
        {
            PatchDoctorComorbidity(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctorcomorbidity by its primary key</summary>
        /// <param name="id">The primary key of the doctorcomorbidity</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorComorbidity(id);
            return true;
        }
        #region
        private List<DoctorComorbidity> GetDoctorComorbidity(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorComorbidity.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorComorbidity>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorComorbidity), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorComorbidity, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorComorbidity(DoctorComorbidity model)
        {
            _dbContext.DoctorComorbidity.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorComorbidity(Guid id, DoctorComorbidity updatedEntity)
        {
            _dbContext.DoctorComorbidity.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorComorbidity(Guid id)
        {
            var entityData = _dbContext.DoctorComorbidity.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorComorbidity.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorComorbidity(Guid id, JsonPatchDocument<DoctorComorbidity> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorComorbidity.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorComorbidity.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}