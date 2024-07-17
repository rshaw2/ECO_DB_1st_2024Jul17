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
    /// The prescriptionprinttemplateService responsible for managing prescriptionprinttemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionprinttemplate information.
    /// </remarks>
    public interface IPrescriptionPrintTemplateService
    {
        /// <summary>Retrieves a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <returns>The prescriptionprinttemplate data</returns>
        PrescriptionPrintTemplate GetById(Guid id);

        /// <summary>Retrieves a list of prescriptionprinttemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionprinttemplates</returns>
        List<PrescriptionPrintTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new prescriptionprinttemplate</summary>
        /// <param name="model">The prescriptionprinttemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PrescriptionPrintTemplate model);

        /// <summary>Updates a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <param name="updatedEntity">The prescriptionprinttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PrescriptionPrintTemplate updatedEntity);

        /// <summary>Updates a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <param name="updatedEntity">The prescriptionprinttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PrescriptionPrintTemplate> updatedEntity);

        /// <summary>Deletes a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The prescriptionprinttemplateService responsible for managing prescriptionprinttemplate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionprinttemplate information.
    /// </remarks>
    public class PrescriptionPrintTemplateService : IPrescriptionPrintTemplateService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PrescriptionPrintTemplate class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PrescriptionPrintTemplateService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <returns>The prescriptionprinttemplate data</returns>
        public PrescriptionPrintTemplate GetById(Guid id)
        {
            var entityData = _dbContext.PrescriptionPrintTemplate.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of prescriptionprinttemplates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionprinttemplates</returns>/// <exception cref="Exception"></exception>
        public List<PrescriptionPrintTemplate> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPrescriptionPrintTemplate(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new prescriptionprinttemplate</summary>
        /// <param name="model">The prescriptionprinttemplate data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PrescriptionPrintTemplate model)
        {
            model.Id = CreatePrescriptionPrintTemplate(model);
            return model.Id;
        }

        /// <summary>Updates a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <param name="updatedEntity">The prescriptionprinttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PrescriptionPrintTemplate updatedEntity)
        {
            UpdatePrescriptionPrintTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <param name="updatedEntity">The prescriptionprinttemplate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PrescriptionPrintTemplate> updatedEntity)
        {
            PatchPrescriptionPrintTemplate(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific prescriptionprinttemplate by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePrescriptionPrintTemplate(id);
            return true;
        }
        #region
        private List<PrescriptionPrintTemplate> GetPrescriptionPrintTemplate(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PrescriptionPrintTemplate.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PrescriptionPrintTemplate>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PrescriptionPrintTemplate), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PrescriptionPrintTemplate, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePrescriptionPrintTemplate(PrescriptionPrintTemplate model)
        {
            _dbContext.PrescriptionPrintTemplate.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePrescriptionPrintTemplate(Guid id, PrescriptionPrintTemplate updatedEntity)
        {
            _dbContext.PrescriptionPrintTemplate.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePrescriptionPrintTemplate(Guid id)
        {
            var entityData = _dbContext.PrescriptionPrintTemplate.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PrescriptionPrintTemplate.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPrescriptionPrintTemplate(Guid id, JsonPatchDocument<PrescriptionPrintTemplate> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PrescriptionPrintTemplate.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PrescriptionPrintTemplate.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}