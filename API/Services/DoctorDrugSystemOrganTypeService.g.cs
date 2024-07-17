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
    /// The doctordrugsystemorgantypeService responsible for managing doctordrugsystemorgantype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctordrugsystemorgantype information.
    /// </remarks>
    public interface IDoctorDrugSystemOrganTypeService
    {
        /// <summary>Retrieves a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <returns>The doctordrugsystemorgantype data</returns>
        DoctorDrugSystemOrganType GetById(Guid id);

        /// <summary>Retrieves a list of doctordrugsystemorgantypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctordrugsystemorgantypes</returns>
        List<DoctorDrugSystemOrganType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctordrugsystemorgantype</summary>
        /// <param name="model">The doctordrugsystemorgantype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorDrugSystemOrganType model);

        /// <summary>Updates a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <param name="updatedEntity">The doctordrugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorDrugSystemOrganType updatedEntity);

        /// <summary>Updates a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <param name="updatedEntity">The doctordrugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorDrugSystemOrganType> updatedEntity);

        /// <summary>Deletes a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctordrugsystemorgantypeService responsible for managing doctordrugsystemorgantype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctordrugsystemorgantype information.
    /// </remarks>
    public class DoctorDrugSystemOrganTypeService : IDoctorDrugSystemOrganTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorDrugSystemOrganType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorDrugSystemOrganTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <returns>The doctordrugsystemorgantype data</returns>
        public DoctorDrugSystemOrganType GetById(Guid id)
        {
            var entityData = _dbContext.DoctorDrugSystemOrganType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctordrugsystemorgantypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctordrugsystemorgantypes</returns>/// <exception cref="Exception"></exception>
        public List<DoctorDrugSystemOrganType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorDrugSystemOrganType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctordrugsystemorgantype</summary>
        /// <param name="model">The doctordrugsystemorgantype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorDrugSystemOrganType model)
        {
            model.Id = CreateDoctorDrugSystemOrganType(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <param name="updatedEntity">The doctordrugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorDrugSystemOrganType updatedEntity)
        {
            UpdateDoctorDrugSystemOrganType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <param name="updatedEntity">The doctordrugsystemorgantype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorDrugSystemOrganType> updatedEntity)
        {
            PatchDoctorDrugSystemOrganType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctordrugsystemorgantype by its primary key</summary>
        /// <param name="id">The primary key of the doctordrugsystemorgantype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorDrugSystemOrganType(id);
            return true;
        }
        #region
        private List<DoctorDrugSystemOrganType> GetDoctorDrugSystemOrganType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorDrugSystemOrganType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorDrugSystemOrganType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorDrugSystemOrganType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorDrugSystemOrganType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorDrugSystemOrganType(DoctorDrugSystemOrganType model)
        {
            _dbContext.DoctorDrugSystemOrganType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorDrugSystemOrganType(Guid id, DoctorDrugSystemOrganType updatedEntity)
        {
            _dbContext.DoctorDrugSystemOrganType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorDrugSystemOrganType(Guid id)
        {
            var entityData = _dbContext.DoctorDrugSystemOrganType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorDrugSystemOrganType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorDrugSystemOrganType(Guid id, JsonPatchDocument<DoctorDrugSystemOrganType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorDrugSystemOrganType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorDrugSystemOrganType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}