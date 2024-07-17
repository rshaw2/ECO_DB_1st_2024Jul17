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
    /// The informationobjectsrulefieldsService responsible for managing informationobjectsrulefields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectsrulefields information.
    /// </remarks>
    public interface IInformationObjectsRuleFieldsService
    {
        /// <summary>Retrieves a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <returns>The informationobjectsrulefields data</returns>
        InformationObjectsRuleFields GetById(Guid id);

        /// <summary>Retrieves a list of informationobjectsrulefieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectsrulefieldss</returns>
        List<InformationObjectsRuleFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new informationobjectsrulefields</summary>
        /// <param name="model">The informationobjectsrulefields data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(InformationObjectsRuleFields model);

        /// <summary>Updates a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <param name="updatedEntity">The informationobjectsrulefields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, InformationObjectsRuleFields updatedEntity);

        /// <summary>Updates a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <param name="updatedEntity">The informationobjectsrulefields data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<InformationObjectsRuleFields> updatedEntity);

        /// <summary>Deletes a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The informationobjectsrulefieldsService responsible for managing informationobjectsrulefields related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting informationobjectsrulefields information.
    /// </remarks>
    public class InformationObjectsRuleFieldsService : IInformationObjectsRuleFieldsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the InformationObjectsRuleFields class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public InformationObjectsRuleFieldsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <returns>The informationobjectsrulefields data</returns>
        public InformationObjectsRuleFields GetById(Guid id)
        {
            var entityData = _dbContext.InformationObjectsRuleFields.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of informationobjectsrulefieldss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of informationobjectsrulefieldss</returns>/// <exception cref="Exception"></exception>
        public List<InformationObjectsRuleFields> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetInformationObjectsRuleFields(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new informationobjectsrulefields</summary>
        /// <param name="model">The informationobjectsrulefields data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(InformationObjectsRuleFields model)
        {
            model.Id = CreateInformationObjectsRuleFields(model);
            return model.Id;
        }

        /// <summary>Updates a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <param name="updatedEntity">The informationobjectsrulefields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, InformationObjectsRuleFields updatedEntity)
        {
            UpdateInformationObjectsRuleFields(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <param name="updatedEntity">The informationobjectsrulefields data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<InformationObjectsRuleFields> updatedEntity)
        {
            PatchInformationObjectsRuleFields(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific informationobjectsrulefields by its primary key</summary>
        /// <param name="id">The primary key of the informationobjectsrulefields</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteInformationObjectsRuleFields(id);
            return true;
        }
        #region
        private List<InformationObjectsRuleFields> GetInformationObjectsRuleFields(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.InformationObjectsRuleFields.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<InformationObjectsRuleFields>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(InformationObjectsRuleFields), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<InformationObjectsRuleFields, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateInformationObjectsRuleFields(InformationObjectsRuleFields model)
        {
            _dbContext.InformationObjectsRuleFields.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateInformationObjectsRuleFields(Guid id, InformationObjectsRuleFields updatedEntity)
        {
            _dbContext.InformationObjectsRuleFields.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteInformationObjectsRuleFields(Guid id)
        {
            var entityData = _dbContext.InformationObjectsRuleFields.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.InformationObjectsRuleFields.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchInformationObjectsRuleFields(Guid id, JsonPatchDocument<InformationObjectsRuleFields> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.InformationObjectsRuleFields.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.InformationObjectsRuleFields.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}