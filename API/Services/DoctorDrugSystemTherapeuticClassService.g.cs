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
    /// The doctordrugsystemtherapeuticclassService responsible for managing doctordrugsystemtherapeuticclass related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctordrugsystemtherapeuticclass information.
    /// </remarks>
    public interface IDoctorDrugSystemTherapeuticClassService
    {
        /// <summary>Retrieves a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <returns>The doctordrugsystemtherapeuticclass data</returns>
        DoctorDrugSystemTherapeuticClass GetById(Guid id);

        /// <summary>Retrieves a list of doctordrugsystemtherapeuticclasss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctordrugsystemtherapeuticclasss</returns>
        List<DoctorDrugSystemTherapeuticClass> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctordrugsystemtherapeuticclass</summary>
        /// <param name="model">The doctordrugsystemtherapeuticclass data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorDrugSystemTherapeuticClass model);

        /// <summary>Updates a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <param name="updatedEntity">The doctordrugsystemtherapeuticclass data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorDrugSystemTherapeuticClass updatedEntity);

        /// <summary>Updates a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <param name="updatedEntity">The doctordrugsystemtherapeuticclass data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorDrugSystemTherapeuticClass> updatedEntity);

        /// <summary>Deletes a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctordrugsystemtherapeuticclassService responsible for managing doctordrugsystemtherapeuticclass related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctordrugsystemtherapeuticclass information.
    /// </remarks>
    public class DoctorDrugSystemTherapeuticClassService : IDoctorDrugSystemTherapeuticClassService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorDrugSystemTherapeuticClass class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorDrugSystemTherapeuticClassService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <returns>The doctordrugsystemtherapeuticclass data</returns>
        public DoctorDrugSystemTherapeuticClass GetById(Guid id)
        {
            var entityData = _dbContext.DoctorDrugSystemTherapeuticClass.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctordrugsystemtherapeuticclasss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctordrugsystemtherapeuticclasss</returns>/// <exception cref="Exception"></exception>
        public List<DoctorDrugSystemTherapeuticClass> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorDrugSystemTherapeuticClass(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctordrugsystemtherapeuticclass</summary>
        /// <param name="model">The doctordrugsystemtherapeuticclass data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorDrugSystemTherapeuticClass model)
        {
            model.Id = CreateDoctorDrugSystemTherapeuticClass(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <param name="updatedEntity">The doctordrugsystemtherapeuticclass data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorDrugSystemTherapeuticClass updatedEntity)
        {
            UpdateDoctorDrugSystemTherapeuticClass(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <param name="updatedEntity">The doctordrugsystemtherapeuticclass data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorDrugSystemTherapeuticClass> updatedEntity)
        {
            PatchDoctorDrugSystemTherapeuticClass(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctordrugsystemtherapeuticclass by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemtherapeuticclass</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorDrugSystemTherapeuticClass(id);
            return true;
        }
        #region
        private List<DoctorDrugSystemTherapeuticClass> GetDoctorDrugSystemTherapeuticClass(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorDrugSystemTherapeuticClass.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorDrugSystemTherapeuticClass>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorDrugSystemTherapeuticClass), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorDrugSystemTherapeuticClass, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorDrugSystemTherapeuticClass(DoctorDrugSystemTherapeuticClass model)
        {
            _dbContext.DoctorDrugSystemTherapeuticClass.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorDrugSystemTherapeuticClass(Guid id, DoctorDrugSystemTherapeuticClass updatedEntity)
        {
            _dbContext.DoctorDrugSystemTherapeuticClass.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorDrugSystemTherapeuticClass(Guid id)
        {
            var entityData = _dbContext.DoctorDrugSystemTherapeuticClass.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorDrugSystemTherapeuticClass.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorDrugSystemTherapeuticClass(Guid id, JsonPatchDocument<DoctorDrugSystemTherapeuticClass> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorDrugSystemTherapeuticClass.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorDrugSystemTherapeuticClass.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}