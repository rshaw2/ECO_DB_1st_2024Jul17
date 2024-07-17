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
    /// The proceduretemplateService responsible for managing proceduretemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting proceduretemplate information.
    /// </remarks>
    public interface IProcedureTemplateService
    {
        /// <summary>Retrieves a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <returns>The proceduretemplate data</returns>
        ProcedureTemplate GetById(Guid id);

        /// <summary>Retrieves a list of proceduretemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of proceduretemplates</returns>
        List<ProcedureTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new proceduretemplate</summary>
        /// <param name="model">The proceduretemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ProcedureTemplate model);

        /// <summary>Updates a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <param name="updatedEntity">The proceduretemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ProcedureTemplate updatedEntity);

        /// <summary>Updates a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <param name="updatedEntity">The proceduretemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ProcedureTemplate> updatedEntity);

        /// <summary>Deletes a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The proceduretemplateService responsible for managing proceduretemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting proceduretemplate information.
    /// </remarks>
    public class ProcedureTemplateService : IProcedureTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ProcedureTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ProcedureTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <returns>The proceduretemplate data</returns>
        public ProcedureTemplate GetById(Guid id)
        {
            var entityData = _dbContext.ProcedureTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of proceduretemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of proceduretemplates</returns>/// <exception cref="Exception"></exception>
        public List<ProcedureTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetProcedureTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new proceduretemplate</summary>
        /// <param name="model">The proceduretemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ProcedureTemplate model)
        {
            model.Id = CreateProcedureTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <param name="updatedEntity">The proceduretemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ProcedureTemplate updatedEntity)
        {
            UpdateProcedureTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <param name="updatedEntity">The proceduretemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ProcedureTemplate> updatedEntity)
        {
            PatchProcedureTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific proceduretemplate by its primary key</summary>
        /// <param name="id">The primary key of the proceduretemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteProcedureTemplate(id);
            return true;
        }
        #region
        private List<ProcedureTemplate> GetProcedureTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProcedureTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProcedureTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProcedureTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProcedureTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateProcedureTemplate(ProcedureTemplate model)
        {
            _dbContext.ProcedureTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateProcedureTemplate(Guid id, ProcedureTemplate updatedEntity)
        {
            _dbContext.ProcedureTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteProcedureTemplate(Guid id)
        {
            var entityData = _dbContext.ProcedureTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProcedureTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchProcedureTemplate(Guid id, JsonPatchDocument<ProcedureTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProcedureTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProcedureTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}