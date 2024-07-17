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
    /// The informationobjectfieldsettingsService responsible for managing informationobjectfieldsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectfieldsettings information.
    /// </remarks>
    public interface IInformationObjectFieldSettingsService
    {
        /// <summary>Retrieves a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <returns>The informationobjectfieldsettings data</returns>
        InformationObjectFieldSettings GetById(Guid id);

        /// <summary>Retrieves a list of informationobjectfieldsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectfieldsettingss</returns>
        List<InformationObjectFieldSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new informationobjectfieldsettings</summary>
        /// <param name="model">The informationobjectfieldsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InformationObjectFieldSettings model);

        /// <summary>Updates a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <param name="updatedEntity">The informationobjectfieldsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InformationObjectFieldSettings updatedEntity);

        /// <summary>Updates a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <param name="updatedEntity">The informationobjectfieldsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InformationObjectFieldSettings> updatedEntity);

        /// <summary>Deletes a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The informationobjectfieldsettingsService responsible for managing informationobjectfieldsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectfieldsettings information.
    /// </remarks>
    public class InformationObjectFieldSettingsService : IInformationObjectFieldSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InformationObjectFieldSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InformationObjectFieldSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <returns>The informationobjectfieldsettings data</returns>
        public InformationObjectFieldSettings GetById(Guid id)
        {
            var entityData = _dbContext.InformationObjectFieldSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of informationobjectfieldsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectfieldsettingss</returns>/// <exception cref="Exception"></exception>
        public List<InformationObjectFieldSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInformationObjectFieldSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new informationobjectfieldsettings</summary>
        /// <param name="model">The informationobjectfieldsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InformationObjectFieldSettings model)
        {
            model.Id = CreateInformationObjectFieldSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <param name="updatedEntity">The informationobjectfieldsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InformationObjectFieldSettings updatedEntity)
        {
            UpdateInformationObjectFieldSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <param name="updatedEntity">The informationobjectfieldsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InformationObjectFieldSettings> updatedEntity)
        {
            PatchInformationObjectFieldSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific informationobjectfieldsettings by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfieldsettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInformationObjectFieldSettings(id);
            return true;
        }
        #region
        private List<InformationObjectFieldSettings> GetInformationObjectFieldSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InformationObjectFieldSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InformationObjectFieldSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InformationObjectFieldSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InformationObjectFieldSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInformationObjectFieldSettings(InformationObjectFieldSettings model)
        {
            _dbContext.InformationObjectFieldSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInformationObjectFieldSettings(Guid id, InformationObjectFieldSettings updatedEntity)
        {
            _dbContext.InformationObjectFieldSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInformationObjectFieldSettings(Guid id)
        {
            var entityData = _dbContext.InformationObjectFieldSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InformationObjectFieldSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInformationObjectFieldSettings(Guid id, JsonPatchDocument<InformationObjectFieldSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InformationObjectFieldSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InformationObjectFieldSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}