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
    /// The organizationbankdetailService responsible for managing organizationbankdetail related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organizationbankdetail information.
    /// </remarks>
    public interface IOrganizationBankDetailService
    {
        /// <summary>Retrieves a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <returns>The organizationbankdetail data</returns>
        OrganizationBankDetail GetById(Guid id);

        /// <summary>Retrieves a list of organizationbankdetails based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organizationbankdetails</returns>
        List<OrganizationBankDetail> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new organizationbankdetail</summary>
        /// <param name="model">The organizationbankdetail data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(OrganizationBankDetail model);

        /// <summary>Updates a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <param name="updatedEntity">The organizationbankdetail data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, OrganizationBankDetail updatedEntity);

        /// <summary>Updates a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <param name="updatedEntity">The organizationbankdetail data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<OrganizationBankDetail> updatedEntity);

        /// <summary>Deletes a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The organizationbankdetailService responsible for managing organizationbankdetail related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organizationbankdetail information.
    /// </remarks>
    public class OrganizationBankDetailService : IOrganizationBankDetailService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the OrganizationBankDetail class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public OrganizationBankDetailService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <returns>The organizationbankdetail data</returns>
        public OrganizationBankDetail GetById(Guid id)
        {
            var entityData = _dbContext.OrganizationBankDetail.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of organizationbankdetails based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organizationbankdetails</returns>/// <exception cref="Exception"></exception>
        public List<OrganizationBankDetail> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetOrganizationBankDetail(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new organizationbankdetail</summary>
        /// <param name="model">The organizationbankdetail data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(OrganizationBankDetail model)
        {
            model.Id = CreateOrganizationBankDetail(model);
            return model.Id;
        }

        /// <summary>Updates a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <param name="updatedEntity">The organizationbankdetail data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, OrganizationBankDetail updatedEntity)
        {
            UpdateOrganizationBankDetail(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <param name="updatedEntity">The organizationbankdetail data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<OrganizationBankDetail> updatedEntity)
        {
            PatchOrganizationBankDetail(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific organizationbankdetail by its primary key</summary>
        /// <param name="id">The primary key of the organizationbankdetail</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteOrganizationBankDetail(id);
            return true;
        }
        #region
        private List<OrganizationBankDetail> GetOrganizationBankDetail(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.OrganizationBankDetail.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<OrganizationBankDetail>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(OrganizationBankDetail), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<OrganizationBankDetail, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateOrganizationBankDetail(OrganizationBankDetail model)
        {
            _dbContext.OrganizationBankDetail.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateOrganizationBankDetail(Guid id, OrganizationBankDetail updatedEntity)
        {
            _dbContext.OrganizationBankDetail.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteOrganizationBankDetail(Guid id)
        {
            var entityData = _dbContext.OrganizationBankDetail.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.OrganizationBankDetail.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchOrganizationBankDetail(Guid id, JsonPatchDocument<OrganizationBankDetail> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.OrganizationBankDetail.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.OrganizationBankDetail.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}