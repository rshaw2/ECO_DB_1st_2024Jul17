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
    /// The specialitypersonalisationprocedureService responsible for managing specialitypersonalisationprocedure related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationprocedure information.
    /// </remarks>
    public interface ISpecialityPersonalisationProcedureService
    {
        /// <summary>Retrieves a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <returns>The specialitypersonalisationprocedure data</returns>
        SpecialityPersonalisationProcedure GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationprocedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationprocedures</returns>
        List<SpecialityPersonalisationProcedure> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationprocedure</summary>
        /// <param name="model">The specialitypersonalisationprocedure data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationProcedure model);

        /// <summary>Updates a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <param name="updatedEntity">The specialitypersonalisationprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationProcedure updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <param name="updatedEntity">The specialitypersonalisationprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationProcedure> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationprocedureService responsible for managing specialitypersonalisationprocedure related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationprocedure information.
    /// </remarks>
    public class SpecialityPersonalisationProcedureService : ISpecialityPersonalisationProcedureService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationProcedure class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationProcedureService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <returns>The specialitypersonalisationprocedure data</returns>
        public SpecialityPersonalisationProcedure GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationProcedure.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationprocedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationprocedures</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationProcedure> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationProcedure(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationprocedure</summary>
        /// <param name="model">The specialitypersonalisationprocedure data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationProcedure model)
        {
            model.Id = CreateSpecialityPersonalisationProcedure(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <param name="updatedEntity">The specialitypersonalisationprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationProcedure updatedEntity)
        {
            UpdateSpecialityPersonalisationProcedure(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <param name="updatedEntity">The specialitypersonalisationprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationProcedure> updatedEntity)
        {
            PatchSpecialityPersonalisationProcedure(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationprocedure by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationprocedure</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationProcedure(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationProcedure> GetSpecialityPersonalisationProcedure(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationProcedure.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationProcedure>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationProcedure), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationProcedure, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationProcedure(SpecialityPersonalisationProcedure model)
        {
            _dbContext.SpecialityPersonalisationProcedure.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationProcedure(Guid id, SpecialityPersonalisationProcedure updatedEntity)
        {
            _dbContext.SpecialityPersonalisationProcedure.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationProcedure(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationProcedure.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationProcedure.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationProcedure(Guid id, JsonPatchDocument<SpecialityPersonalisationProcedure> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationProcedure.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationProcedure.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}