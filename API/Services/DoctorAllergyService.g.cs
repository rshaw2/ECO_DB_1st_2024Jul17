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
    /// The doctorallergyService responsible for managing doctorallergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorallergy information.
    /// </remarks>
    public interface IDoctorAllergyService
    {
        /// <summary>Retrieves a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <returns>The doctorallergy data</returns>
        DoctorAllergy GetById(Guid id);

        /// <summary>Retrieves a list of doctorallergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorallergys</returns>
        List<DoctorAllergy> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctorallergy</summary>
        /// <param name="model">The doctorallergy data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorAllergy model);

        /// <summary>Updates a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <param name="updatedEntity">The doctorallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorAllergy updatedEntity);

        /// <summary>Updates a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <param name="updatedEntity">The doctorallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorAllergy> updatedEntity);

        /// <summary>Deletes a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctorallergyService responsible for managing doctorallergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorallergy information.
    /// </remarks>
    public class DoctorAllergyService : IDoctorAllergyService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorAllergy class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorAllergyService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <returns>The doctorallergy data</returns>
        public DoctorAllergy GetById(Guid id)
        {
            var entityData = _dbContext.DoctorAllergy.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctorallergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorallergys</returns>/// <exception cref="Exception"></exception>
        public List<DoctorAllergy> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorAllergy(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctorallergy</summary>
        /// <param name="model">The doctorallergy data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorAllergy model)
        {
            model.Id = CreateDoctorAllergy(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <param name="updatedEntity">The doctorallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorAllergy updatedEntity)
        {
            UpdateDoctorAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <param name="updatedEntity">The doctorallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorAllergy> updatedEntity)
        {
            PatchDoctorAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctorallergy by its primary key</summary>
        /// <param name="id">The primary key of the doctorallergy</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorAllergy(id);
            return true;
        }
        #region
        private List<DoctorAllergy> GetDoctorAllergy(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorAllergy.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorAllergy>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorAllergy), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorAllergy, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorAllergy(DoctorAllergy model)
        {
            _dbContext.DoctorAllergy.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorAllergy(Guid id, DoctorAllergy updatedEntity)
        {
            _dbContext.DoctorAllergy.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorAllergy(Guid id)
        {
            var entityData = _dbContext.DoctorAllergy.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorAllergy.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorAllergy(Guid id, JsonPatchDocument<DoctorAllergy> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorAllergy.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorAllergy.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}