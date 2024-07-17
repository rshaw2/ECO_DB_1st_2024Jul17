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
    /// The specialitypersonalisationchiefcomplaintService responsible for managing specialitypersonalisationchiefcomplaint related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationchiefcomplaint information.
    /// </remarks>
    public interface ISpecialityPersonalisationChiefComplaintService
    {
        /// <summary>Retrieves a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <returns>The specialitypersonalisationchiefcomplaint data</returns>
        SpecialityPersonalisationChiefComplaint GetById(Guid id);

        /// <summary>Retrieves a list of specialitypersonalisationchiefcomplaints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationchiefcomplaints</returns>
        List<SpecialityPersonalisationChiefComplaint> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new specialitypersonalisationchiefcomplaint</summary>
        /// <param name="model">The specialitypersonalisationchiefcomplaint data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(SpecialityPersonalisationChiefComplaint model);

        /// <summary>Updates a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <param name="updatedEntity">The specialitypersonalisationchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, SpecialityPersonalisationChiefComplaint updatedEntity);

        /// <summary>Updates a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <param name="updatedEntity">The specialitypersonalisationchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationChiefComplaint> updatedEntity);

        /// <summary>Deletes a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The specialitypersonalisationchiefcomplaintService responsible for managing specialitypersonalisationchiefcomplaint related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting specialitypersonalisationchiefcomplaint information.
    /// </remarks>
    public class SpecialityPersonalisationChiefComplaintService : ISpecialityPersonalisationChiefComplaintService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the SpecialityPersonalisationChiefComplaint class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public SpecialityPersonalisationChiefComplaintService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <returns>The specialitypersonalisationchiefcomplaint data</returns>
        public SpecialityPersonalisationChiefComplaint GetById(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationChiefComplaint.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of specialitypersonalisationchiefcomplaints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of specialitypersonalisationchiefcomplaints</returns>/// <exception cref="Exception"></exception>
        public List<SpecialityPersonalisationChiefComplaint> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetSpecialityPersonalisationChiefComplaint(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new specialitypersonalisationchiefcomplaint</summary>
        /// <param name="model">The specialitypersonalisationchiefcomplaint data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(SpecialityPersonalisationChiefComplaint model)
        {
            model.Id = CreateSpecialityPersonalisationChiefComplaint(model);
            return model.Id;
        }

        /// <summary>Updates a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <param name="updatedEntity">The specialitypersonalisationchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, SpecialityPersonalisationChiefComplaint updatedEntity)
        {
            UpdateSpecialityPersonalisationChiefComplaint(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <param name="updatedEntity">The specialitypersonalisationchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<SpecialityPersonalisationChiefComplaint> updatedEntity)
        {
            PatchSpecialityPersonalisationChiefComplaint(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific specialitypersonalisationchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the specialitypersonalisationchiefcomplaint</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteSpecialityPersonalisationChiefComplaint(id);
            return true;
        }
        #region
        private List<SpecialityPersonalisationChiefComplaint> GetSpecialityPersonalisationChiefComplaint(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SpecialityPersonalisationChiefComplaint.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SpecialityPersonalisationChiefComplaint>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SpecialityPersonalisationChiefComplaint), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SpecialityPersonalisationChiefComplaint, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateSpecialityPersonalisationChiefComplaint(SpecialityPersonalisationChiefComplaint model)
        {
            _dbContext.SpecialityPersonalisationChiefComplaint.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateSpecialityPersonalisationChiefComplaint(Guid id, SpecialityPersonalisationChiefComplaint updatedEntity)
        {
            _dbContext.SpecialityPersonalisationChiefComplaint.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteSpecialityPersonalisationChiefComplaint(Guid id)
        {
            var entityData = _dbContext.SpecialityPersonalisationChiefComplaint.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SpecialityPersonalisationChiefComplaint.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchSpecialityPersonalisationChiefComplaint(Guid id, JsonPatchDocument<SpecialityPersonalisationChiefComplaint> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SpecialityPersonalisationChiefComplaint.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SpecialityPersonalisationChiefComplaint.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}