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
    /// The proceduretemplateparameterService responsible for managing proceduretemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting proceduretemplateparameter information.
    /// </remarks>
    public interface IProcedureTemplateParameterService
    {
        /// <summary>Retrieves a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <returns>The proceduretemplateparameter data</returns>
        ProcedureTemplateParameter GetById(Guid id);

        /// <summary>Retrieves a list of proceduretemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of proceduretemplateparameters</returns>
        List<ProcedureTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new proceduretemplateparameter</summary>
        /// <param name="model">The proceduretemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureTemplateParameter model);

        /// <summary>Updates a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <param name="updatedEntity">The proceduretemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureTemplateParameter updatedEntity);

        /// <summary>Updates a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <param name="updatedEntity">The proceduretemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureTemplateParameter> updatedEntity);

        /// <summary>Deletes a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The proceduretemplateparameterService responsible for managing proceduretemplateparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting proceduretemplateparameter information.
    /// </remarks>
    public class ProcedureTemplateParameterService : IProcedureTemplateParameterService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureTemplateParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureTemplateParameterService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <returns>The proceduretemplateparameter data</returns>
        public ProcedureTemplateParameter GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of proceduretemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of proceduretemplateparameters</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureTemplateParameter> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureTemplateParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new proceduretemplateparameter</summary>
        /// <param name="model">The proceduretemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureTemplateParameter model)
        {
            model.Id = CreateProcedureTemplateParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <param name="updatedEntity">The proceduretemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureTemplateParameter updatedEntity)
        {
            UpdateProcedureTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <param name="updatedEntity">The proceduretemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureTemplateParameter> updatedEntity)
        {
            PatchProcedureTemplateParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific proceduretemplateparameter by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplateparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureTemplateParameter(id);
            return true;
        }
        #region
        private List<ProcedureTemplateParameter> GetProcedureTemplateParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureTemplateParameter.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureTemplateParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureTemplateParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureTemplateParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureTemplateParameter(ProcedureTemplateParameter model)
        {
            _dbContext.ProcedureTemplateParameter.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureTemplateParameter(Guid id, ProcedureTemplateParameter updatedEntity)
        {
            _dbContext.ProcedureTemplateParameter.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureTemplateParameter(Guid id)
        {
            var entityData = _dbContext.ProcedureTemplateParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureTemplateParameter.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureTemplateParameter(Guid id, JsonPatchDocument<ProcedureTemplateParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureTemplateParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureTemplateParameter.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}