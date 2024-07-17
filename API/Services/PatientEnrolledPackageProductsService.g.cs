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
    /// The patientenrolledpackageproductsService responsible for managing patientenrolledpackageproducts related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackageproducts information.
    /// </remarks>
    public interface IPatientEnrolledPackageProductsService
    {
        /// <summary>Retrieves a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <returns>The patientenrolledpackageproducts data</returns>
        PatientEnrolledPackageProducts GetById(Guid id);

        /// <summary>Retrieves a list of patientenrolledpackageproductss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackageproductss</returns>
        List<PatientEnrolledPackageProducts> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new patientenrolledpackageproducts</summary>
        /// <param name="model">The patientenrolledpackageproducts data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(PatientEnrolledPackageProducts model);

        /// <summary>Updates a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <param name="updatedEntity">The patientenrolledpackageproducts data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, PatientEnrolledPackageProducts updatedEntity);

        /// <summary>Updates a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <param name="updatedEntity">The patientenrolledpackageproducts data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackageProducts> updatedEntity);

        /// <summary>Deletes a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The patientenrolledpackageproductsService responsible for managing patientenrolledpackageproducts related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting patientenrolledpackageproducts information.
    /// </remarks>
    public class PatientEnrolledPackageProductsService : IPatientEnrolledPackageProductsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackageProducts class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public PatientEnrolledPackageProductsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <returns>The patientenrolledpackageproducts data</returns>
        public PatientEnrolledPackageProducts GetById(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackageProducts.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of patientenrolledpackageproductss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of patientenrolledpackageproductss</returns>/// <exception cref="Exception"></exception>
        public List<PatientEnrolledPackageProducts> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetPatientEnrolledPackageProducts(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new patientenrolledpackageproducts</summary>
        /// <param name="model">The patientenrolledpackageproducts data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(PatientEnrolledPackageProducts model)
        {
            model.Id = CreatePatientEnrolledPackageProducts(model);
            return model.Id;
        }

        /// <summary>Updates a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <param name="updatedEntity">The patientenrolledpackageproducts data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, PatientEnrolledPackageProducts updatedEntity)
        {
            UpdatePatientEnrolledPackageProducts(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <param name="updatedEntity">The patientenrolledpackageproducts data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<PatientEnrolledPackageProducts> updatedEntity)
        {
            PatchPatientEnrolledPackageProducts(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific patientenrolledpackageproducts by its primary key</summary>
        /// <param name="id">The primary key of the patientenrolledpackageproducts</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeletePatientEnrolledPackageProducts(id);
            return true;
        }
        #region
        private List<PatientEnrolledPackageProducts> GetPatientEnrolledPackageProducts(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PatientEnrolledPackageProducts.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientEnrolledPackageProducts>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PatientEnrolledPackageProducts), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PatientEnrolledPackageProducts, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreatePatientEnrolledPackageProducts(PatientEnrolledPackageProducts model)
        {
            _dbContext.PatientEnrolledPackageProducts.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdatePatientEnrolledPackageProducts(Guid id, PatientEnrolledPackageProducts updatedEntity)
        {
            _dbContext.PatientEnrolledPackageProducts.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeletePatientEnrolledPackageProducts(Guid id)
        {
            var entityData = _dbContext.PatientEnrolledPackageProducts.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PatientEnrolledPackageProducts.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchPatientEnrolledPackageProducts(Guid id, JsonPatchDocument<PatientEnrolledPackageProducts> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PatientEnrolledPackageProducts.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PatientEnrolledPackageProducts.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}