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
    /// The dataimportService responsible for managing dataimport related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dataimport information.
    /// </remarks>
    public interface IDataImportService
    {
        /// <summary>Retrieves a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <returns>The dataimport data</returns>
        DataImport GetById(Guid id);

        /// <summary>Retrieves a list of dataimports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dataimports</returns>
        List<DataImport> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new dataimport</summary>
        /// <param name="model">The dataimport data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DataImport model);

        /// <summary>Updates a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <param name="updatedEntity">The dataimport data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DataImport updatedEntity);

        /// <summary>Updates a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <param name="updatedEntity">The dataimport data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DataImport> updatedEntity);

        /// <summary>Deletes a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The dataimportService responsible for managing dataimport related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting dataimport information.
    /// </remarks>
    public class DataImportService : IDataImportService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DataImport class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DataImportService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <returns>The dataimport data</returns>
        public DataImport GetById(Guid id)
        {
            var entityData = _dbContext.DataImport.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of dataimports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of dataimports</returns>/// <exception cref="Exception"></exception>
        public List<DataImport> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDataImport(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new dataimport</summary>
        /// <param name="model">The dataimport data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DataImport model)
        {
            model.Id = CreateDataImport(model);
            return model.Id;
        }

        /// <summary>Updates a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <param name="updatedEntity">The dataimport data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DataImport updatedEntity)
        {
            UpdateDataImport(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <param name="updatedEntity">The dataimport data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DataImport> updatedEntity)
        {
            PatchDataImport(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific dataimport by its primary key</summary>
        /// <param name="id">The primary key of the dataimport</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDataImport(id);
            return true;
        }
        #region
        private List<DataImport> GetDataImport(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DataImport.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DataImport>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DataImport), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DataImport, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDataImport(DataImport model)
        {
            _dbContext.DataImport.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDataImport(Guid id, DataImport updatedEntity)
        {
            _dbContext.DataImport.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDataImport(Guid id)
        {
            var entityData = _dbContext.DataImport.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DataImport.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDataImport(Guid id, JsonPatchDocument<DataImport> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DataImport.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DataImport.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}