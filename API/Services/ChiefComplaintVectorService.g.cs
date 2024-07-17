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
    /// The chiefcomplaintvectorService responsible for managing chiefcomplaintvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplaintvector information.
    /// </remarks>
    public interface IChiefComplaintVectorService
    {
        /// <summary>Retrieves a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <returns>The chiefcomplaintvector data</returns>
        ChiefComplaintVector GetById(Guid id);

        /// <summary>Retrieves a list of chiefcomplaintvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintvectors</returns>
        List<ChiefComplaintVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new chiefcomplaintvector</summary>
        /// <param name="model">The chiefcomplaintvector data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ChiefComplaintVector model);

        /// <summary>Updates a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <param name="updatedEntity">The chiefcomplaintvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ChiefComplaintVector updatedEntity);

        /// <summary>Updates a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <param name="updatedEntity">The chiefcomplaintvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ChiefComplaintVector> updatedEntity);

        /// <summary>Deletes a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The chiefcomplaintvectorService responsible for managing chiefcomplaintvector related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplaintvector information.
    /// </remarks>
    public class ChiefComplaintVectorService : IChiefComplaintVectorService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintVector class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ChiefComplaintVectorService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <returns>The chiefcomplaintvector data</returns>
        public ChiefComplaintVector GetById(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintVector.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of chiefcomplaintvectors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintvectors</returns>/// <exception cref="Exception"></exception>
        public List<ChiefComplaintVector> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetChiefComplaintVector(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new chiefcomplaintvector</summary>
        /// <param name="model">The chiefcomplaintvector data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ChiefComplaintVector model)
        {
            model.Id = CreateChiefComplaintVector(model);
            return model.Id;
        }

        /// <summary>Updates a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <param name="updatedEntity">The chiefcomplaintvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ChiefComplaintVector updatedEntity)
        {
            UpdateChiefComplaintVector(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <param name="updatedEntity">The chiefcomplaintvector data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ChiefComplaintVector> updatedEntity)
        {
            PatchChiefComplaintVector(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific chiefcomplaintvector by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteChiefComplaintVector(id);
            return true;
        }
        #region
        private List<ChiefComplaintVector> GetChiefComplaintVector(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ChiefComplaintVector.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ChiefComplaintVector>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ChiefComplaintVector), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ChiefComplaintVector, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateChiefComplaintVector(ChiefComplaintVector model)
        {
            _dbContext.ChiefComplaintVector.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateChiefComplaintVector(Guid id, ChiefComplaintVector updatedEntity)
        {
            _dbContext.ChiefComplaintVector.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteChiefComplaintVector(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintVector.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ChiefComplaintVector.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchChiefComplaintVector(Guid id, JsonPatchDocument<ChiefComplaintVector> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ChiefComplaintVector.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ChiefComplaintVector.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}