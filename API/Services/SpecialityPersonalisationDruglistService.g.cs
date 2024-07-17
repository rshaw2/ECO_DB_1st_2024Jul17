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
    /// The specialitypersonalisationdruglistService responsible for managing specialitypersonalisationdruglist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationdruglist information.
    /// </remarks>
    public interface ISpecialityPersonalisationDruglistService
    {
        /// <summary>Retrieves a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <returns>The specialitypersonalisationdruglist data</returns>
        SpecialityPersonalisationDruglist GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationdruglists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationdruglists</returns>
        List<SpecialityPersonalisationDruglist> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationdruglist</summary>
        /// <param name="model">The specialitypersonalisationdruglist data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationDruglist model);

        /// <summary>Updates a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <param name="updatedEntity">The specialitypersonalisationdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationDruglist updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <param name="updatedEntity">The specialitypersonalisationdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationDruglist> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationdruglistService responsible for managing specialitypersonalisationdruglist related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationdruglist information.
    /// </remarks>
    public class SpecialityPersonalisationDruglistService : ISpecialityPersonalisationDruglistService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationDruglist class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationDruglistService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <returns>The specialitypersonalisationdruglist data</returns>
        public SpecialityPersonalisationDruglist GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationDruglist.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationdruglists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationdruglists</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationDruglist> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationDruglist(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationdruglist</summary>
        /// <param name="model">The specialitypersonalisationdruglist data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationDruglist model)
        {
            model.Id = CreateSpecialityPersonalisationDruglist(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <param name="updatedEntity">The specialitypersonalisationdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationDruglist updatedEntity)
        {
            UpdateSpecialityPersonalisationDruglist(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <param name="updatedEntity">The specialitypersonalisationdruglist data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationDruglist> updatedEntity)
        {
            PatchSpecialityPersonalisationDruglist(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationdruglist by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationdruglist</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationDruglist(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationDruglist> GetSpecialityPersonalisationDruglist(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationDruglist.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationDruglist>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationDruglist), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationDruglist, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationDruglist(SpecialityPersonalisationDruglist model)
        {
            _dbContext.SpecialityPersonalisationDruglist.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationDruglist(Guid id, SpecialityPersonalisationDruglist updatedEntity)
        {
            _dbContext.SpecialityPersonalisationDruglist.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationDruglist(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationDruglist.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationDruglist.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationDruglist(Guid id, JsonPatchDocument<SpecialityPersonalisationDruglist> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationDruglist.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationDruglist.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}