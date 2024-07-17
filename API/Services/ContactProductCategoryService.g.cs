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
    /// The contactproductcategoryService responsible for managing contactproductcategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contactproductcategory information.
    /// </remarks>
    public interface IContactProductCategoryService
    {
        /// <summary>Retrieves a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <returns>The contactproductcategory data</returns>
        ContactProductCategory GetById(Guid id);

        /// <summary>Retrieves a list of contactproductcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contactproductcategorys</returns>
        List<ContactProductCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new contactproductcategory</summary>
        /// <param name="model">The contactproductcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ContactProductCategory model);

        /// <summary>Updates a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <param name="updatedEntity">The contactproductcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ContactProductCategory updatedEntity);

        /// <summary>Updates a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <param name="updatedEntity">The contactproductcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ContactProductCategory> updatedEntity);

        /// <summary>Deletes a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The contactproductcategoryService responsible for managing contactproductcategory related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contactproductcategory information.
    /// </remarks>
    public class ContactProductCategoryService : IContactProductCategoryService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ContactProductCategory class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ContactProductCategoryService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <returns>The contactproductcategory data</returns>
        public ContactProductCategory GetById(Guid id)
        {
            var entityData = _dbContext.ContactProductCategory.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of contactproductcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contactproductcategorys</returns>/// <exception cref="Exception"></exception>
        public List<ContactProductCategory> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetContactProductCategory(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new contactproductcategory</summary>
        /// <param name="model">The contactproductcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ContactProductCategory model)
        {
            model.Id = CreateContactProductCategory(model);
            return model.Id;
        }

        /// <summary>Updates a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <param name="updatedEntity">The contactproductcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ContactProductCategory updatedEntity)
        {
            UpdateContactProductCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <param name="updatedEntity">The contactproductcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ContactProductCategory> updatedEntity)
        {
            PatchContactProductCategory(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific contactproductcategory by its primary key</summary>
        /// <param name="id">The primary key of the contactproductcategory</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteContactProductCategory(id);
            return true;
        }
        #region
        private List<ContactProductCategory> GetContactProductCategory(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ContactProductCategory.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ContactProductCategory>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ContactProductCategory), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ContactProductCategory, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateContactProductCategory(ContactProductCategory model)
        {
            _dbContext.ContactProductCategory.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateContactProductCategory(Guid id, ContactProductCategory updatedEntity)
        {
            _dbContext.ContactProductCategory.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteContactProductCategory(Guid id)
        {
            var entityData = _dbContext.ContactProductCategory.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ContactProductCategory.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchContactProductCategory(Guid id, JsonPatchDocument<ContactProductCategory> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ContactProductCategory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ContactProductCategory.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}