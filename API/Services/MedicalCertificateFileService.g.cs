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
    /// The medicalcertificatefileService responsible for managing medicalcertificatefile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalcertificatefile information.
    /// </remarks>
    public interface IMedicalCertificateFileService
    {
        /// <summary>Retrieves a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <returns>The medicalcertificatefile data</returns>
        MedicalCertificateFile GetById(Guid id);

        /// <summary>Retrieves a list of medicalcertificatefiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalcertificatefiles</returns>
        List<MedicalCertificateFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicalcertificatefile</summary>
        /// <param name="model">The medicalcertificatefile data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(MedicalCertificateFile model);

        /// <summary>Updates a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <param name="updatedEntity">The medicalcertificatefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, MedicalCertificateFile updatedEntity);

        /// <summary>Updates a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <param name="updatedEntity">The medicalcertificatefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<MedicalCertificateFile> updatedEntity);

        /// <summary>Deletes a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The medicalcertificatefileService responsible for managing medicalcertificatefile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalcertificatefile information.
    /// </remarks>
    public class MedicalCertificateFileService : IMedicalCertificateFileService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the MedicalCertificateFile class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public MedicalCertificateFileService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <returns>The medicalcertificatefile data</returns>
        public MedicalCertificateFile GetById(Guid id)
        {
            var entityData = _dbContext.MedicalCertificateFile.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of medicalcertificatefiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalcertificatefiles</returns>/// <exception cref="Exception"></exception>
        public List<MedicalCertificateFile> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetMedicalCertificateFile(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicalcertificatefile</summary>
        /// <param name="model">The medicalcertificatefile data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(MedicalCertificateFile model)
        {
            model.Id = CreateMedicalCertificateFile(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <param name="updatedEntity">The medicalcertificatefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, MedicalCertificateFile updatedEntity)
        {
            UpdateMedicalCertificateFile(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <param name="updatedEntity">The medicalcertificatefile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<MedicalCertificateFile> updatedEntity)
        {
            PatchMedicalCertificateFile(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicalcertificatefile by its primary key</summary>
        /// <param name="id">The primary key of the medicalcertificatefile</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteMedicalCertificateFile(id);
            return true;
        }
        #region
        private List<MedicalCertificateFile> GetMedicalCertificateFile(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicalCertificateFile.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicalCertificateFile>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicalCertificateFile), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicalCertificateFile, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateMedicalCertificateFile(MedicalCertificateFile model)
        {
            _dbContext.MedicalCertificateFile.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateMedicalCertificateFile(Guid id, MedicalCertificateFile updatedEntity)
        {
            _dbContext.MedicalCertificateFile.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteMedicalCertificateFile(Guid id)
        {
            var entityData = _dbContext.MedicalCertificateFile.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicalCertificateFile.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchMedicalCertificateFile(Guid id, JsonPatchDocument<MedicalCertificateFile> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicalCertificateFile.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicalCertificateFile.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}