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
    /// The vitaltemplateparameterService responsible for managing vitaltemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting vitaltemplateparameter information.
    /// </remarks>
    public interface IVitalTemplateParameterService
    {
        /// <summary>Retrieves a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <returns>The vitaltemplateparameter data</returns>
        VitalTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of vitaltemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of vitaltemplateparameters</returns>
        List<VitalTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new vitaltemplateparameter</summary>
        /// <param name="model">The vitaltemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(VitalTemplateParameter model);

        /// <summary>Updates a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <param name="updatedEntity">The vitaltemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, VitalTemplateParameter updatedEntity);

        /// <summary>Updates a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <param name="updatedEntity">The vitaltemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<VitalTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The vitaltemplateparameterService responsible for managing vitaltemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting vitaltemplateparameter information.
    /// </remarks>
    public class VitalTemplateParameterService : IVitalTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the VitalTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public VitalTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <returns>The vitaltemplateparameter data</returns>
        public VitalTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.VitalTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of vitaltemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of vitaltemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<VitalTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetVitalTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new vitaltemplateparameter</summary>
        /// <param name="model">The vitaltemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(VitalTemplateParameter model)
        {
            model.Id = CreateVitalTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <param name="updatedEntity">The vitaltemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, VitalTemplateParameter updatedEntity)
        {
            UpdateVitalTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <param name="updatedEntity">The vitaltemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<VitalTemplateParameter> updatedEntity)
        {
            PatchVitalTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific vitaltemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the vitaltemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteVitalTemplateParameter(id);
            return true;
        }
        #region
        private List<VitalTemplateParameter> GetVitalTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VitalTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VitalTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VitalTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VitalTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateVitalTemplateParameter(VitalTemplateParameter model)
        {
            _dbContext.VitalTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateVitalTemplateParameter(Guid id, VitalTemplateParameter updatedEntity)
        {
            _dbContext.VitalTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteVitalTemplateParameter(Guid id)
        {
            var entityData = _dbContext.VitalTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VitalTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchVitalTemplateParameter(Guid id, JsonPatchDocument<VitalTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VitalTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VitalTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}