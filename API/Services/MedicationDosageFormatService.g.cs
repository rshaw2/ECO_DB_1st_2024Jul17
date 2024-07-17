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
    /// The medicationdosageformatService responsible for managing medicationdosageformat related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationdosageformat information.
    /// </remarks>
    public interface IMedicationDosageFormatService
    {
        /// <summary>Retrieves a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <returns>The medicationdosageformat data</returns>
        MedicationDosageFormat GetById(Guid id);

        /// <summary>Retrieves a list of medicationdosageformats based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationdosageformats</returns>
        List<MedicationDosageFormat> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicationdosageformat</summary>
        /// <param name="model">The medicationdosageformat data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicationDosageFormat model);

        /// <summary>Updates a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <param name="updatedEntity">The medicationdosageformat data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicationDosageFormat updatedEntity);

        /// <summary>Updates a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <param name="updatedEntity">The medicationdosageformat data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicationDosageFormat> updatedEntity);

        /// <summary>Deletes a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicationdosageformatService responsible for managing medicationdosageformat related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicationdosageformat information.
    /// </remarks>
    public class MedicationDosageFormatService : IMedicationDosageFormatService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicationDosageFormat class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicationDosageFormatService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <returns>The medicationdosageformat data</returns>
        public MedicationDosageFormat GetById(Guid id)
        {
            var entityData = _dbContext.MedicationDosageFormat.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicationdosageformats based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicationdosageformats</returns>/// <exception cref="Exception"></exception>
        public List<MedicationDosageFormat> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicationDosageFormat(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicationdosageformat</summary>
        /// <param name="model">The medicationdosageformat data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicationDosageFormat model)
        {
            model.Id = CreateMedicationDosageFormat(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <param name="updatedEntity">The medicationdosageformat data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicationDosageFormat updatedEntity)
        {
            UpdateMedicationDosageFormat(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <param name="updatedEntity">The medicationdosageformat data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicationDosageFormat> updatedEntity)
        {
            PatchMedicationDosageFormat(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicationdosageformat by its primary key</summary>
        /// <param name="id">The primary key of the medicationdosageformat</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicationDosageFormat(id);
            return true;
        }
        #region
        private List<MedicationDosageFormat> GetMedicationDosageFormat(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicationDosageFormat.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicationDosageFormat>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicationDosageFormat), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicationDosageFormat, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicationDosageFormat(MedicationDosageFormat model)
        {
            _dbContext.MedicationDosageFormat.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicationDosageFormat(Guid id, MedicationDosageFormat updatedEntity)
        {
            _dbContext.MedicationDosageFormat.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicationDosageFormat(Guid id)
        {
            var entityData = _dbContext.MedicationDosageFormat.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicationDosageFormat.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicationDosageFormat(Guid id, JsonPatchDocument<MedicationDosageFormat> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicationDosageFormat.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicationDosageFormat.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}