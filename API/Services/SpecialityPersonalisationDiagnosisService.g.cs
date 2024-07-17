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
    /// The specialitypersonalisationdiagnosisService responsible for managing specialitypersonalisationdiagnosis related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationdiagnosis information.
    /// </remarks>
    public interface ISpecialityPersonalisationDiagnosisService
    {
        /// <summary>Retrieves a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <returns>The specialitypersonalisationdiagnosis data</returns>
        SpecialityPersonalisationDiagnosis GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationdiagnosiss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationdiagnosiss</returns>
        List<SpecialityPersonalisationDiagnosis> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationdiagnosis</summary>
        /// <param name="model">The specialitypersonalisationdiagnosis data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationDiagnosis model);

        /// <summary>Updates a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <param name="updatedEntity">The specialitypersonalisationdiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationDiagnosis updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <param name="updatedEntity">The specialitypersonalisationdiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationDiagnosis> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationdiagnosisService responsible for managing specialitypersonalisationdiagnosis related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationdiagnosis information.
    /// </remarks>
    public class SpecialityPersonalisationDiagnosisService : ISpecialityPersonalisationDiagnosisService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationDiagnosis class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationDiagnosisService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <returns>The specialitypersonalisationdiagnosis data</returns>
        public SpecialityPersonalisationDiagnosis GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationDiagnosis.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationdiagnosiss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationdiagnosiss</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationDiagnosis> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationDiagnosis(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationdiagnosis</summary>
        /// <param name="model">The specialitypersonalisationdiagnosis data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationDiagnosis model)
        {
            model.Id = CreateSpecialityPersonalisationDiagnosis(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <param name="updatedEntity">The specialitypersonalisationdiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationDiagnosis updatedEntity)
        {
            UpdateSpecialityPersonalisationDiagnosis(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <param name="updatedEntity">The specialitypersonalisationdiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationDiagnosis> updatedEntity)
        {
            PatchSpecialityPersonalisationDiagnosis(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationdiagnosis by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdiagnosis</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationDiagnosis(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationDiagnosis> GetSpecialityPersonalisationDiagnosis(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationDiagnosis.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationDiagnosis>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationDiagnosis), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationDiagnosis, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationDiagnosis(SpecialityPersonalisationDiagnosis model)
        {
            _dbContext.SpecialityPersonalisationDiagnosis.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationDiagnosis(Guid id, SpecialityPersonalisationDiagnosis updatedEntity)
        {
            _dbContext.SpecialityPersonalisationDiagnosis.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationDiagnosis(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationDiagnosis.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationDiagnosis.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationDiagnosis(Guid id, JsonPatchDocument<SpecialityPersonalisationDiagnosis> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationDiagnosis.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationDiagnosis.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}