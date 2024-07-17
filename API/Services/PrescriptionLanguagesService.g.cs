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
    /// The prescriptionlanguagesService responsible for managing prescriptionlanguages related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionlanguages information.
    /// </remarks>
    public interface IPrescriptionLanguagesService
    {
        /// <summary>Retrieves a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <returns>The prescriptionlanguages data</returns>
        PrescriptionLanguages GetById(Guid id);

        /// <summary>Retrieves a list of prescriptionlanguagess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionlanguagess</returns>
        List<PrescriptionLanguages> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new prescriptionlanguages</summary>
        /// <param name="model">The prescriptionlanguages data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PrescriptionLanguages model);

        /// <summary>Updates a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <param name="updatedEntity">The prescriptionlanguages data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PrescriptionLanguages updatedEntity);

        /// <summary>Updates a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <param name="updatedEntity">The prescriptionlanguages data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PrescriptionLanguages> updatedEntity);

        /// <summary>Deletes a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The prescriptionlanguagesService responsible for managing prescriptionlanguages related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionlanguages information.
    /// </remarks>
    public class PrescriptionLanguagesService : IPrescriptionLanguagesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PrescriptionLanguages class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PrescriptionLanguagesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <returns>The prescriptionlanguages data</returns>
        public PrescriptionLanguages GetById(Guid id)
        {
            var entityData = _dbContext.PrescriptionLanguages.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of prescriptionlanguagess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionlanguagess</returns>/// <exception cref="Exception"></exception>
        public List<PrescriptionLanguages> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPrescriptionLanguages(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new prescriptionlanguages</summary>
        /// <param name="model">The prescriptionlanguages data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PrescriptionLanguages model)
        {
            model.Id = CreatePrescriptionLanguages(model);
            return model.Id;
        }

        /// <summary>Updates a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <param name="updatedEntity">The prescriptionlanguages data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PrescriptionLanguages updatedEntity)
        {
            UpdatePrescriptionLanguages(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <param name="updatedEntity">The prescriptionlanguages data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PrescriptionLanguages> updatedEntity)
        {
            PatchPrescriptionLanguages(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific prescriptionlanguages by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionlanguages</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePrescriptionLanguages(id);
            return true;
        }
        #region
        private List<PrescriptionLanguages> GetPrescriptionLanguages(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PrescriptionLanguages.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PrescriptionLanguages>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PrescriptionLanguages), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PrescriptionLanguages, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePrescriptionLanguages(PrescriptionLanguages model)
        {
            _dbContext.PrescriptionLanguages.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePrescriptionLanguages(Guid id, PrescriptionLanguages updatedEntity)
        {
            _dbContext.PrescriptionLanguages.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePrescriptionLanguages(Guid id)
        {
            var entityData = _dbContext.PrescriptionLanguages.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PrescriptionLanguages.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPrescriptionLanguages(Guid id, JsonPatchDocument<PrescriptionLanguages> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PrescriptionLanguages.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PrescriptionLanguages.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}