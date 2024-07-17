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
    /// The informationobjectversionsService responsible for managing informationobjectversions related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectversions information.
    /// </remarks>
    public interface IInformationObjectVersionsService
    {
        /// <summary>Retrieves a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <returns>The informationobjectversions data</returns>
        InformationObjectVersions GetById(Guid id);

        /// <summary>Retrieves a list of informationobjectversionss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectversionss</returns>
        List<InformationObjectVersions> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new informationobjectversions</summary>
        /// <param name="model">The informationobjectversions data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InformationObjectVersions model);

        /// <summary>Updates a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <param name="updatedEntity">The informationobjectversions data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InformationObjectVersions updatedEntity);

        /// <summary>Updates a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <param name="updatedEntity">The informationobjectversions data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InformationObjectVersions> updatedEntity);

        /// <summary>Deletes a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The informationobjectversionsService responsible for managing informationobjectversions related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectversions information.
    /// </remarks>
    public class InformationObjectVersionsService : IInformationObjectVersionsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InformationObjectVersions class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InformationObjectVersionsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <returns>The informationobjectversions data</returns>
        public InformationObjectVersions GetById(Guid id)
        {
            var entityData = _dbContext.InformationObjectVersions.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of informationobjectversionss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectversionss</returns>/// <exception cref="Exception"></exception>
        public List<InformationObjectVersions> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInformationObjectVersions(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new informationobjectversions</summary>
        /// <param name="model">The informationobjectversions data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InformationObjectVersions model)
        {
            model.Id = CreateInformationObjectVersions(model);
            return model.Id;
        }

        /// <summary>Updates a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <param name="updatedEntity">The informationobjectversions data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InformationObjectVersions updatedEntity)
        {
            UpdateInformationObjectVersions(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <param name="updatedEntity">The informationobjectversions data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InformationObjectVersions> updatedEntity)
        {
            PatchInformationObjectVersions(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific informationobjectversions by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectversions</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInformationObjectVersions(id);
            return true;
        }
        #region
        private List<InformationObjectVersions> GetInformationObjectVersions(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InformationObjectVersions.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InformationObjectVersions>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InformationObjectVersions), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InformationObjectVersions, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInformationObjectVersions(InformationObjectVersions model)
        {
            _dbContext.InformationObjectVersions.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInformationObjectVersions(Guid id, InformationObjectVersions updatedEntity)
        {
            _dbContext.InformationObjectVersions.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInformationObjectVersions(Guid id)
        {
            var entityData = _dbContext.InformationObjectVersions.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InformationObjectVersions.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInformationObjectVersions(Guid id, JsonPatchDocument<InformationObjectVersions> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InformationObjectVersions.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InformationObjectVersions.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}