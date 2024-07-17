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
    /// The prescriptionprinttemplatecomponentService responsible for managing prescriptionprinttemplatecomponent related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionprinttemplatecomponent information.
    /// </remarks>
    public interface IPrescriptionPrintTemplateComponentService
    {
        /// <summary>Retrieves a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <returns>The prescriptionprinttemplatecomponent data</returns>
        PrescriptionPrintTemplateComponent GetById(Guid id);

        /// <summary>Retrieves a list of prescriptionprinttemplatecomponents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionprinttemplatecomponents</returns>
        List<PrescriptionPrintTemplateComponent> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new prescriptionprinttemplatecomponent</summary>
        /// <param name="model">The prescriptionprinttemplatecomponent data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PrescriptionPrintTemplateComponent model);

        /// <summary>Updates a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <param name="updatedEntity">The prescriptionprinttemplatecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PrescriptionPrintTemplateComponent updatedEntity);

        /// <summary>Updates a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <param name="updatedEntity">The prescriptionprinttemplatecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PrescriptionPrintTemplateComponent> updatedEntity);

        /// <summary>Deletes a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The prescriptionprinttemplatecomponentService responsible for managing prescriptionprinttemplatecomponent related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting prescriptionprinttemplatecomponent information.
    /// </remarks>
    public class PrescriptionPrintTemplateComponentService : IPrescriptionPrintTemplateComponentService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PrescriptionPrintTemplateComponent class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PrescriptionPrintTemplateComponentService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <returns>The prescriptionprinttemplatecomponent data</returns>
        public PrescriptionPrintTemplateComponent GetById(Guid id)
        {
            var entityData = _dbContext.PrescriptionPrintTemplateComponent.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of prescriptionprinttemplatecomponents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prescriptionprinttemplatecomponents</returns>/// <exception cref="Exception"></exception>
        public List<PrescriptionPrintTemplateComponent> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPrescriptionPrintTemplateComponent(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new prescriptionprinttemplatecomponent</summary>
        /// <param name="model">The prescriptionprinttemplatecomponent data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PrescriptionPrintTemplateComponent model)
        {
            model.Id = CreatePrescriptionPrintTemplateComponent(model);
            return model.Id;
        }

        /// <summary>Updates a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <param name="updatedEntity">The prescriptionprinttemplatecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PrescriptionPrintTemplateComponent updatedEntity)
        {
            UpdatePrescriptionPrintTemplateComponent(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <param name="updatedEntity">The prescriptionprinttemplatecomponent data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PrescriptionPrintTemplateComponent> updatedEntity)
        {
            PatchPrescriptionPrintTemplateComponent(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific prescriptionprinttemplatecomponent by its primary key</summary>
        /// <param name="id">The primary key of the prescriptionprinttemplatecomponent</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePrescriptionPrintTemplateComponent(id);
            return true;
        }
        #region
        private List<PrescriptionPrintTemplateComponent> GetPrescriptionPrintTemplateComponent(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PrescriptionPrintTemplateComponent.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PrescriptionPrintTemplateComponent>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PrescriptionPrintTemplateComponent), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PrescriptionPrintTemplateComponent, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePrescriptionPrintTemplateComponent(PrescriptionPrintTemplateComponent model)
        {
            _dbContext.PrescriptionPrintTemplateComponent.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePrescriptionPrintTemplateComponent(Guid id, PrescriptionPrintTemplateComponent updatedEntity)
        {
            _dbContext.PrescriptionPrintTemplateComponent.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePrescriptionPrintTemplateComponent(Guid id)
        {
            var entityData = _dbContext.PrescriptionPrintTemplateComponent.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PrescriptionPrintTemplateComponent.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPrescriptionPrintTemplateComponent(Guid id, JsonPatchDocument<PrescriptionPrintTemplateComponent> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PrescriptionPrintTemplateComponent.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PrescriptionPrintTemplateComponent.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}