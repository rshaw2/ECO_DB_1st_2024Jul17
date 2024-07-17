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
    /// The routeService responsible for managing route related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting route information.
    /// </remarks>
    public interface IRouteService
    {
        /// <summary>Retrieves a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <returns>The route data</returns>
        Entities.Route GetById(Guid id);

        /// <summary>Retrieves a list of routes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of routes</returns>
        List<Entities.Route> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new route</summary>
        /// <param name="model">The route data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(Entities.Route model);

        /// <summary>Updates a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <param name="updatedEntity">The route data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, Entities.Route updatedEntity);

        /// <summary>Updates a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <param name="updatedEntity">The route data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<Entities.Route> updatedEntity);

        /// <summary>Deletes a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The routeService responsible for managing route related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting route information.
    /// </remarks>
    public class RouteService : IRouteService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the Route class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public RouteService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <returns>The route data</returns>
        public Entities.Route GetById(Guid id)
        {
            var entityData = _dbContext.Route.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of routes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of routes</returns>/// <exception cref="Exception"></exception>
        public List<Entities.Route> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetRoute(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new route</summary>
        /// <param name="model">The route data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(Entities.Route model)
        {
            model.Id = CreateRoute(model);
            return model.Id;
        }

        /// <summary>Updates a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <param name="updatedEntity">The route data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, Entities.Route updatedEntity)
        {
            UpdateRoute(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <param name="updatedEntity">The route data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<Entities.Route> updatedEntity)
        {
            PatchRoute(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific route by its primary key</summary>
        /// <param name="id">The primary key of the route</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteRoute(id);
            return true;
        }
        #region
        private List<Entities.Route> GetRoute(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Route.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Entities.Route>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Entities.Route), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Entities.Route, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateRoute(Entities.Route model)
        {
            _dbContext.Route.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateRoute(Guid id, Entities.Route updatedEntity)
        {
            _dbContext.Route.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteRoute(Guid id)
        {
            var entityData = _dbContext.Route.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Route.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchRoute(Guid id, JsonPatchDocument<Entities.Route> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Route.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Route.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}