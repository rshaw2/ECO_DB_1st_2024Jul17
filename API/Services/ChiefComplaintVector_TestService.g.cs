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
    /// The chiefcomplaintvector_testService responsible for managing chiefcomplaintvector_test related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplaintvector_test information.
    /// </remarks>
    public interface IChiefComplaintVector_TestService
    {
        /// <summary>Retrieves a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <returns>The chiefcomplaintvector_test data</returns>
        ChiefComplaintVector_Test GetById(Guid id);

        /// <summary>Retrieves a list of chiefcomplaintvector_tests based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintvector_tests</returns>
        List<ChiefComplaintVector_Test> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new chiefcomplaintvector_test</summary>
        /// <param name="model">The chiefcomplaintvector_test data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ChiefComplaintVector_Test model);

        /// <summary>Updates a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <param name="updatedEntity">The chiefcomplaintvector_test data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ChiefComplaintVector_Test updatedEntity);

        /// <summary>Updates a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <param name="updatedEntity">The chiefcomplaintvector_test data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ChiefComplaintVector_Test> updatedEntity);

        /// <summary>Deletes a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The chiefcomplaintvector_testService responsible for managing chiefcomplaintvector_test related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplaintvector_test information.
    /// </remarks>
    public class ChiefComplaintVector_TestService : IChiefComplaintVector_TestService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintVector_Test class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ChiefComplaintVector_TestService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <returns>The chiefcomplaintvector_test data</returns>
        public ChiefComplaintVector_Test GetById(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintVector_Test.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of chiefcomplaintvector_tests based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplaintvector_tests</returns>/// <exception cref="Exception"></exception>
        public List<ChiefComplaintVector_Test> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetChiefComplaintVector_Test(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new chiefcomplaintvector_test</summary>
        /// <param name="model">The chiefcomplaintvector_test data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ChiefComplaintVector_Test model)
        {
            model.Id = CreateChiefComplaintVector_Test(model);
            return model.Id;
        }

        /// <summary>Updates a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <param name="updatedEntity">The chiefcomplaintvector_test data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ChiefComplaintVector_Test updatedEntity)
        {
            UpdateChiefComplaintVector_Test(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <param name="updatedEntity">The chiefcomplaintvector_test data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ChiefComplaintVector_Test> updatedEntity)
        {
            PatchChiefComplaintVector_Test(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific chiefcomplaintvector_test by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplaintvector_test</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteChiefComplaintVector_Test(id);
            return true;
        }
        #region
        private List<ChiefComplaintVector_Test> GetChiefComplaintVector_Test(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ChiefComplaintVector_Test.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ChiefComplaintVector_Test>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ChiefComplaintVector_Test), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ChiefComplaintVector_Test, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateChiefComplaintVector_Test(ChiefComplaintVector_Test model)
        {
            _dbContext.ChiefComplaintVector_Test.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateChiefComplaintVector_Test(Guid id, ChiefComplaintVector_Test updatedEntity)
        {
            _dbContext.ChiefComplaintVector_Test.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteChiefComplaintVector_Test(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintVector_Test.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ChiefComplaintVector_Test.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchChiefComplaintVector_Test(Guid id, JsonPatchDocument<ChiefComplaintVector_Test> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ChiefComplaintVector_Test.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ChiefComplaintVector_Test.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}