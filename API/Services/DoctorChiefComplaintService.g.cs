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
    /// The doctorchiefcomplaintService responsible for managing doctorchiefcomplaint related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorchiefcomplaint information.
    /// </remarks>
    public interface IDoctorChiefComplaintService
    {
        /// <summary>Retrieves a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <returns>The doctorchiefcomplaint data</returns>
        DoctorChiefComplaint GetById(Guid id);

        /// <summary>Retrieves a list of doctorchiefcomplaints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorchiefcomplaints</returns>
        List<DoctorChiefComplaint> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new doctorchiefcomplaint</summary>
        /// <param name="model">The doctorchiefcomplaint data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(DoctorChiefComplaint model);

        /// <summary>Updates a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <param name="updatedEntity">The doctorchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, DoctorChiefComplaint updatedEntity);

        /// <summary>Updates a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <param name="updatedEntity">The doctorchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<DoctorChiefComplaint> updatedEntity);

        /// <summary>Deletes a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The doctorchiefcomplaintService responsible for managing doctorchiefcomplaint related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting doctorchiefcomplaint information.
    /// </remarks>
    public class DoctorChiefComplaintService : IDoctorChiefComplaintService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the DoctorChiefComplaint class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public DoctorChiefComplaintService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <returns>The doctorchiefcomplaint data</returns>
        public DoctorChiefComplaint GetById(Guid id)
        {
            var entityData = _dbContext.DoctorChiefComplaint.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of doctorchiefcomplaints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of doctorchiefcomplaints</returns>/// <exception cref="Exception"></exception>
        public List<DoctorChiefComplaint> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetDoctorChiefComplaint(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new doctorchiefcomplaint</summary>
        /// <param name="model">The doctorchiefcomplaint data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(DoctorChiefComplaint model)
        {
            model.Id = CreateDoctorChiefComplaint(model);
            return model.Id;
        }

        /// <summary>Updates a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <param name="updatedEntity">The doctorchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, DoctorChiefComplaint updatedEntity)
        {
            UpdateDoctorChiefComplaint(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <param name="updatedEntity">The doctorchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<DoctorChiefComplaint> updatedEntity)
        {
            PatchDoctorChiefComplaint(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific doctorchiefcomplaint by its primary key</summary>
        /// <param name="id">The primary key of the doctorchiefcomplaint</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteDoctorChiefComplaint(id);
            return true;
        }
        #region
        private List<DoctorChiefComplaint> GetDoctorChiefComplaint(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DoctorChiefComplaint.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DoctorChiefComplaint>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DoctorChiefComplaint), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DoctorChiefComplaint, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateDoctorChiefComplaint(DoctorChiefComplaint model)
        {
            _dbContext.DoctorChiefComplaint.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateDoctorChiefComplaint(Guid id, DoctorChiefComplaint updatedEntity)
        {
            _dbContext.DoctorChiefComplaint.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteDoctorChiefComplaint(Guid id)
        {
            var entityData = _dbContext.DoctorChiefComplaint.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DoctorChiefComplaint.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchDoctorChiefComplaint(Guid id, JsonPatchDocument<DoctorChiefComplaint> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DoctorChiefComplaint.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DoctorChiefComplaint.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}