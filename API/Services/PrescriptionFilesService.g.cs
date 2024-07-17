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
    /// The prescriptionfilesService responsible for managing prescriptionfiles related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionfiles information.
    /// </remarks>
    public interface IPrescriptionFilesService
    {
        /// <summary>Retrieves a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <returns>The prescriptionfiles data</returns>
        PrescriptionFiles GetById(Guid id);

        /// <summary>Retrieves a list of prescriptionfiless based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionfiless</returns>
        List<PrescriptionFiles> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new prescriptionfiles</summary>
        /// <param name="model">The prescriptionfiles data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PrescriptionFiles model);

        /// <summary>Updates a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <param name="updatedEntity">The prescriptionfiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PrescriptionFiles updatedEntity);

        /// <summary>Updates a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <param name="updatedEntity">The prescriptionfiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PrescriptionFiles> updatedEntity);

        /// <summary>Deletes a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The prescriptionfilesService responsible for managing prescriptionfiles related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionfiles information.
    /// </remarks>
    public class PrescriptionFilesService : IPrescriptionFilesService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PrescriptionFiles class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PrescriptionFilesService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <returns>The prescriptionfiles data</returns>
        public PrescriptionFiles GetById(Guid id)
        {
            var entityData = _dbContext.PrescriptionFiles.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of prescriptionfiless based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionfiless</returns>/// <exception cref="Exception"></exception>
        public List<PrescriptionFiles> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPrescriptionFiles(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new prescriptionfiles</summary>
        /// <param name="model">The prescriptionfiles data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PrescriptionFiles model)
        {
            model.Id = CreatePrescriptionFiles(model);
            return model.Id;
        }

        /// <summary>Updates a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <param name="updatedEntity">The prescriptionfiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PrescriptionFiles updatedEntity)
        {
            UpdatePrescriptionFiles(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <param name="updatedEntity">The prescriptionfiles data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PrescriptionFiles> updatedEntity)
        {
            PatchPrescriptionFiles(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific prescriptionfiles by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfiles</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePrescriptionFiles(id);
            return true;
        }
        #region
        private List<PrescriptionFiles> GetPrescriptionFiles(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PrescriptionFiles.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PrescriptionFiles>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PrescriptionFiles), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PrescriptionFiles, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePrescriptionFiles(PrescriptionFiles model)
        {
            _dbContext.PrescriptionFiles.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePrescriptionFiles(Guid id, PrescriptionFiles updatedEntity)
        {
            _dbContext.PrescriptionFiles.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePrescriptionFiles(Guid id)
        {
            var entityData = _dbContext.PrescriptionFiles.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PrescriptionFiles.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPrescriptionFiles(Guid id, JsonPatchDocument<PrescriptionFiles> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PrescriptionFiles.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PrescriptionFiles.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}