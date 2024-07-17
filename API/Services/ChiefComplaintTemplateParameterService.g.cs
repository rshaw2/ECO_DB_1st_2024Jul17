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
    /// The chiefcomplainttemplateparameterService responsible for managing chiefcomplainttemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplainttemplateparameter information.
    /// </remarks>
    public interface IChiefComplaintTemplateParameterService
    {
        /// <summary>Retrieves a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <returns>The chiefcomplainttemplateparameter data</returns>
        ChiefComplaintTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of chiefcomplainttemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplainttemplateparameters</returns>
        List<ChiefComplaintTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new chiefcomplainttemplateparameter</summary>
        /// <param name="model">The chiefcomplainttemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ChiefComplaintTemplateParameter model);

        /// <summary>Updates a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <param name="updatedEntity">The chiefcomplainttemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ChiefComplaintTemplateParameter updatedEntity);

        /// <summary>Updates a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <param name="updatedEntity">The chiefcomplainttemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ChiefComplaintTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The chiefcomplainttemplateparameterService responsible for managing chiefcomplainttemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chiefcomplainttemplateparameter information.
    /// </remarks>
    public class ChiefComplaintTemplateParameterService : IChiefComplaintTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ChiefComplaintTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ChiefComplaintTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <returns>The chiefcomplainttemplateparameter data</returns>
        public ChiefComplaintTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of chiefcomplainttemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chiefcomplainttemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<ChiefComplaintTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetChiefComplaintTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new chiefcomplainttemplateparameter</summary>
        /// <param name="model">The chiefcomplainttemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ChiefComplaintTemplateParameter model)
        {
            model.Id = CreateChiefComplaintTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <param name="updatedEntity">The chiefcomplainttemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ChiefComplaintTemplateParameter updatedEntity)
        {
            UpdateChiefComplaintTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <param name="updatedEntity">The chiefcomplainttemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ChiefComplaintTemplateParameter> updatedEntity)
        {
            PatchChiefComplaintTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific chiefcomplainttemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the chiefcomplainttemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteChiefComplaintTemplateParameter(id);
            return true;
        }
        #region
        private List<ChiefComplaintTemplateParameter> GetChiefComplaintTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ChiefComplaintTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ChiefComplaintTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ChiefComplaintTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ChiefComplaintTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateChiefComplaintTemplateParameter(ChiefComplaintTemplateParameter model)
        {
            _dbContext.ChiefComplaintTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateChiefComplaintTemplateParameter(Guid id, ChiefComplaintTemplateParameter updatedEntity)
        {
            _dbContext.ChiefComplaintTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteChiefComplaintTemplateParameter(Guid id)
        {
            var entityData = _dbContext.ChiefComplaintTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ChiefComplaintTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchChiefComplaintTemplateParameter(Guid id, JsonPatchDocument<ChiefComplaintTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ChiefComplaintTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ChiefComplaintTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}