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
    /// The prescriptionfooterService responsible for managing prescriptionfooter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionfooter information.
    /// </remarks>
    public interface IPrescriptionFooterService
    {
        /// <summary>Retrieves a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <returns>The prescriptionfooter data</returns>
        PrescriptionFooter GetById(Guid id);

        /// <summary>Retrieves a list of prescriptionfooters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionfooters</returns>
        List<PrescriptionFooter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new prescriptionfooter</summary>
        /// <param name="model">The prescriptionfooter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PrescriptionFooter model);

        /// <summary>Updates a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <param name="updatedEntity">The prescriptionfooter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PrescriptionFooter updatedEntity);

        /// <summary>Updates a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <param name="updatedEntity">The prescriptionfooter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PrescriptionFooter> updatedEntity);

        /// <summary>Deletes a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The prescriptionfooterService responsible for managing prescriptionfooter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionfooter information.
    /// </remarks>
    public class PrescriptionFooterService : IPrescriptionFooterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PrescriptionFooter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PrescriptionFooterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <returns>The prescriptionfooter data</returns>
        public PrescriptionFooter GetById(Guid id)
        {
            var entityData = _dbContext.PrescriptionFooter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of prescriptionfooters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionfooters</returns>/// <exception cref="Exception"></exception>
        public List<PrescriptionFooter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPrescriptionFooter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new prescriptionfooter</summary>
        /// <param name="model">The prescriptionfooter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PrescriptionFooter model)
        {
            model.Id = CreatePrescriptionFooter(model);
            return model.Id;
        }

        /// <summary>Updates a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <param name="updatedEntity">The prescriptionfooter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PrescriptionFooter updatedEntity)
        {
            UpdatePrescriptionFooter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <param name="updatedEntity">The prescriptionfooter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PrescriptionFooter> updatedEntity)
        {
            PatchPrescriptionFooter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific prescriptionfooter by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionfooter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePrescriptionFooter(id);
            return true;
        }
        #region
        private List<PrescriptionFooter> GetPrescriptionFooter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PrescriptionFooter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PrescriptionFooter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PrescriptionFooter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PrescriptionFooter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePrescriptionFooter(PrescriptionFooter model)
        {
            _dbContext.PrescriptionFooter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePrescriptionFooter(Guid id, PrescriptionFooter updatedEntity)
        {
            _dbContext.PrescriptionFooter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePrescriptionFooter(Guid id)
        {
            var entityData = _dbContext.PrescriptionFooter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PrescriptionFooter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPrescriptionFooter(Guid id, JsonPatchDocument<PrescriptionFooter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PrescriptionFooter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PrescriptionFooter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}