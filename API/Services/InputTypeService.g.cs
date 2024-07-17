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
    /// The inputtypeService responsible for managing inputtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting inputtype information.
    /// </remarks>
    public interface IInputTypeService
    {
        /// <summary>Retrieves a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <returns>The inputtype data</returns>
        InputType GetById(Guid id);

        /// <summary>Retrieves a list of inputtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of inputtypes</returns>
        List<InputType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new inputtype</summary>
        /// <param name="model">The inputtype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InputType model);

        /// <summary>Updates a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <param name="updatedEntity">The inputtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InputType updatedEntity);

        /// <summary>Updates a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <param name="updatedEntity">The inputtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InputType> updatedEntity);

        /// <summary>Deletes a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The inputtypeService responsible for managing inputtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting inputtype information.
    /// </remarks>
    public class InputTypeService : IInputTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InputType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InputTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <returns>The inputtype data</returns>
        public InputType GetById(Guid id)
        {
            var entityData = _dbContext.InputType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of inputtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of inputtypes</returns>/// <exception cref="Exception"></exception>
        public List<InputType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInputType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new inputtype</summary>
        /// <param name="model">The inputtype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InputType model)
        {
            model.Id = CreateInputType(model);
            return model.Id;
        }

        /// <summary>Updates a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <param name="updatedEntity">The inputtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InputType updatedEntity)
        {
            UpdateInputType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <param name="updatedEntity">The inputtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InputType> updatedEntity)
        {
            PatchInputType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific inputtype by its primary key</summary>
        /// <param name="id">The primary key of the inputtype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInputType(id);
            return true;
        }
        #region
        private List<InputType> GetInputType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InputType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InputType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InputType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InputType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInputType(InputType model)
        {
            _dbContext.InputType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInputType(Guid id, InputType updatedEntity)
        {
            _dbContext.InputType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInputType(Guid id)
        {
            var entityData = _dbContext.InputType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InputType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInputType(Guid id, JsonPatchDocument<InputType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InputType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InputType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}