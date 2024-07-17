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
    /// The doctorprocedureService responsible for managing doctorprocedure related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorprocedure information.
    /// </remarks>
    public interface IDoctorProcedureService
    {
        /// <summary>Retrieves a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <returns>The doctorprocedure data</returns>
        DoctorProcedure GetById(Guid id);

        /// <summary>Retrieves a list of doctorprocedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorprocedures</returns>
        List<DoctorProcedure> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctorprocedure</summary>
        /// <param name="model">The doctorprocedure data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorProcedure model);

        /// <summary>Updates a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <param name="updatedEntity">The doctorprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorProcedure updatedEntity);

        /// <summary>Updates a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <param name="updatedEntity">The doctorprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorProcedure> updatedEntity);

        /// <summary>Deletes a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctorprocedureService responsible for managing doctorprocedure related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorprocedure information.
    /// </remarks>
    public class DoctorProcedureService : IDoctorProcedureService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorProcedure class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorProcedureService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <returns>The doctorprocedure data</returns>
        public DoctorProcedure GetById(Guid id)
        {
            var entityData = _dbContext.DoctorProcedure.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctorprocedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorprocedures</returns>/// <exception cref="Exception"></exception>
        public List<DoctorProcedure> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorProcedure(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctorprocedure</summary>
        /// <param name="model">The doctorprocedure data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorProcedure model)
        {
            model.Id = CreateDoctorProcedure(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <param name="updatedEntity">The doctorprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorProcedure updatedEntity)
        {
            UpdateDoctorProcedure(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <param name="updatedEntity">The doctorprocedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorProcedure> updatedEntity)
        {
            PatchDoctorProcedure(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctorprocedure by its primary key</summary>
        /// <param name="id">The primary key of the doctorprocedure</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorProcedure(id);
            return true;
        }
        #region
        private List<DoctorProcedure> GetDoctorProcedure(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorProcedure.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorProcedure>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorProcedure), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorProcedure, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorProcedure(DoctorProcedure model)
        {
            _dbContext.DoctorProcedure.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorProcedure(Guid id, DoctorProcedure updatedEntity)
        {
            _dbContext.DoctorProcedure.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorProcedure(Guid id)
        {
            var entityData = _dbContext.DoctorProcedure.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorProcedure.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorProcedure(Guid id, JsonPatchDocument<DoctorProcedure> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorProcedure.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorProcedure.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}