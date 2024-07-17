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
    /// The producedtypeService responsible for managing producedtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting producedtype information.
    /// </remarks>
    public interface IProducedTypeService
    {
        /// <summary>Retrieves a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <returns>The producedtype data</returns>
        ProducedType GetById(Guid id);

        /// <summary>Retrieves a list of producedtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of producedtypes</returns>
        List<ProducedType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new producedtype</summary>
        /// <param name="model">The producedtype data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProducedType model);

        /// <summary>Updates a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <param name="updatedEntity">The producedtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProducedType updatedEntity);

        /// <summary>Updates a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <param name="updatedEntity">The producedtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProducedType> updatedEntity);

        /// <summary>Deletes a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The producedtypeService responsible for managing producedtype related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting producedtype information.
    /// </remarks>
    public class ProducedTypeService : IProducedTypeService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProducedType class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProducedTypeService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <returns>The producedtype data</returns>
        public ProducedType GetById(Guid id)
        {
            var entityData = _dbContext.ProducedType.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of producedtypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of producedtypes</returns>/// <exception cref="Exception"></exception>
        public List<ProducedType> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProducedType(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new producedtype</summary>
        /// <param name="model">The producedtype data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProducedType model)
        {
            model.Id = CreateProducedType(model);
            return model.Id;
        }

        /// <summary>Updates a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <param name="updatedEntity">The producedtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProducedType updatedEntity)
        {
            UpdateProducedType(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <param name="updatedEntity">The producedtype data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProducedType> updatedEntity)
        {
            PatchProducedType(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific producedtype by its primary key</summary>
        /// <param name="id">The primary key of the producedtype</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProducedType(id);
            return true;
        }
        #region
        private List<ProducedType> GetProducedType(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProducedType.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProducedType>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProducedType), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProducedType, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProducedType(ProducedType model)
        {
            _dbContext.ProducedType.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProducedType(Guid id, ProducedType updatedEntity)
        {
            _dbContext.ProducedType.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProducedType(Guid id)
        {
            var entityData = _dbContext.ProducedType.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProducedType.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProducedType(Guid id, JsonPatchDocument<ProducedType> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProducedType.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProducedType.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}