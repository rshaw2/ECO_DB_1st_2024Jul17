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
    /// The druglistspecialityService responsible for managing druglistspeciality related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druglistspeciality information.
    /// </remarks>
    public interface IDrugListSpecialityService
    {
        /// <summary>Retrieves a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <returns>The druglistspeciality data</returns>
        DrugListSpeciality GetById(Guid id);

        /// <summary>Retrieves a list of druglistspecialitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druglistspecialitys</returns>
        List<DrugListSpeciality> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new druglistspeciality</summary>
        /// <param name="model">The druglistspeciality data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DrugListSpeciality model);

        /// <summary>Updates a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <param name="updatedEntity">The druglistspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DrugListSpeciality updatedEntity);

        /// <summary>Updates a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <param name="updatedEntity">The druglistspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DrugListSpeciality> updatedEntity);

        /// <summary>Deletes a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The druglistspecialityService responsible for managing druglistspeciality related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting druglistspeciality information.
    /// </remarks>
    public class DrugListSpecialityService : IDrugListSpecialityService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DrugListSpeciality class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DrugListSpecialityService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <returns>The druglistspeciality data</returns>
        public DrugListSpeciality GetById(Guid id)
        {
            var entityData = _dbContext.DrugListSpeciality.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of druglistspecialitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of druglistspecialitys</returns>/// <exception cref="Exception"></exception>
        public List<DrugListSpeciality> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDrugListSpeciality(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new druglistspeciality</summary>
        /// <param name="model">The druglistspeciality data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DrugListSpeciality model)
        {
            model.Id = CreateDrugListSpeciality(model);
            return model.Id;
        }

        /// <summary>Updates a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <param name="updatedEntity">The druglistspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DrugListSpeciality updatedEntity)
        {
            UpdateDrugListSpeciality(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <param name="updatedEntity">The druglistspeciality data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DrugListSpeciality> updatedEntity)
        {
            PatchDrugListSpeciality(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific druglistspeciality by its primary key</summary>
        /// <param name="id">The primary key of the druglistspeciality</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDrugListSpeciality(id);
            return true;
        }
        #region
        private List<DrugListSpeciality> GetDrugListSpeciality(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DrugListSpeciality.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DrugListSpeciality>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DrugListSpeciality), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DrugListSpeciality, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDrugListSpeciality(DrugListSpeciality model)
        {
            _dbContext.DrugListSpeciality.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDrugListSpeciality(Guid id, DrugListSpeciality updatedEntity)
        {
            _dbContext.DrugListSpeciality.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDrugListSpeciality(Guid id)
        {
            var entityData = _dbContext.DrugListSpeciality.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DrugListSpeciality.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDrugListSpeciality(Guid id, JsonPatchDocument<DrugListSpeciality> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DrugListSpeciality.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DrugListSpeciality.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}