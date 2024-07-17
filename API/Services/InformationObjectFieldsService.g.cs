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
    /// The informationobjectfieldsService responsible for managing informationobjectfields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectfields information.
    /// </remarks>
    public interface IInformationObjectFieldsService
    {
        /// <summary>Retrieves a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <returns>The informationobjectfields data</returns>
        InformationObjectFields GetById(Guid id);

        /// <summary>Retrieves a list of informationobjectfieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectfieldss</returns>
        List<InformationObjectFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new informationobjectfields</summary>
        /// <param name="model">The informationobjectfields data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InformationObjectFields model);

        /// <summary>Updates a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <param name="updatedEntity">The informationobjectfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InformationObjectFields updatedEntity);

        /// <summary>Updates a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <param name="updatedEntity">The informationobjectfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InformationObjectFields> updatedEntity);

        /// <summary>Deletes a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The informationobjectfieldsService responsible for managing informationobjectfields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectfields information.
    /// </remarks>
    public class InformationObjectFieldsService : IInformationObjectFieldsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InformationObjectFields class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InformationObjectFieldsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <returns>The informationobjectfields data</returns>
        public InformationObjectFields GetById(Guid id)
        {
            var entityData = _dbContext.InformationObjectFields.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of informationobjectfieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectfieldss</returns>/// <exception cref="Exception"></exception>
        public List<InformationObjectFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInformationObjectFields(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new informationobjectfields</summary>
        /// <param name="model">The informationobjectfields data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InformationObjectFields model)
        {
            model.Id = CreateInformationObjectFields(model);
            return model.Id;
        }

        /// <summary>Updates a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <param name="updatedEntity">The informationobjectfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InformationObjectFields updatedEntity)
        {
            UpdateInformationObjectFields(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <param name="updatedEntity">The informationobjectfields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InformationObjectFields> updatedEntity)
        {
            PatchInformationObjectFields(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific informationobjectfields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectfields</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInformationObjectFields(id);
            return true;
        }
        #region
        private List<InformationObjectFields> GetInformationObjectFields(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InformationObjectFields.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InformationObjectFields>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InformationObjectFields), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InformationObjectFields, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInformationObjectFields(InformationObjectFields model)
        {
            _dbContext.InformationObjectFields.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInformationObjectFields(Guid id, InformationObjectFields updatedEntity)
        {
            _dbContext.InformationObjectFields.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInformationObjectFields(Guid id)
        {
            var entityData = _dbContext.InformationObjectFields.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InformationObjectFields.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInformationObjectFields(Guid id, JsonPatchDocument<InformationObjectFields> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InformationObjectFields.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InformationObjectFields.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}