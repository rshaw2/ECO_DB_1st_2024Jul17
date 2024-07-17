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
    /// The datatypeService responsible for managing datatype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting datatype information.
    /// </remarks>
    public interface IDataTypeService
    {
        /// <summary>Retrieves a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <returns>The datatype data</returns>
        DataType GetById(Guid id);

        /// <summary>Retrieves a list of datatypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of datatypes</returns>
        List<DataType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new datatype</summary>
        /// <param name="model">The datatype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DataType model);

        /// <summary>Updates a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <param name="updatedEntity">The datatype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DataType updatedEntity);

        /// <summary>Updates a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <param name="updatedEntity">The datatype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DataType> updatedEntity);

        /// <summary>Deletes a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The datatypeService responsible for managing datatype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting datatype information.
    /// </remarks>
    public class DataTypeService : IDataTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DataType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DataTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <returns>The datatype data</returns>
        public DataType GetById(Guid id)
        {
            var entityData = _dbContext.DataType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of datatypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of datatypes</returns>/// <exception cref="Exception"></exception>
        public List<DataType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDataType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new datatype</summary>
        /// <param name="model">The datatype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DataType model)
        {
            model.Id = CreateDataType(model);
            return model.Id;
        }

        /// <summary>Updates a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <param name="updatedEntity">The datatype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DataType updatedEntity)
        {
            UpdateDataType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <param name="updatedEntity">The datatype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DataType> updatedEntity)
        {
            PatchDataType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific datatype by its primary key</summary>
        /// <param name="id">The primary key of the datatype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDataType(id);
            return true;
        }
        #region
        private List<DataType> GetDataType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DataType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DataType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DataType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DataType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDataType(DataType model)
        {
            _dbContext.DataType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDataType(Guid id, DataType updatedEntity)
        {
            _dbContext.DataType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDataType(Guid id)
        {
            var entityData = _dbContext.DataType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DataType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDataType(Guid id, JsonPatchDocument<DataType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DataType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DataType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}