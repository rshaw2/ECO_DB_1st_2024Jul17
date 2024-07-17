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
    /// The chatassistantsettingsService responsible for managing chatassistantsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chatassistantsettings information.
    /// </remarks>
    public interface IChatAssistantSettingsService
    {
        /// <summary>Retrieves a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <returns>The chatassistantsettings data</returns>
        ChatAssistantSettings GetById(Guid id);

        /// <summary>Retrieves a list of chatassistantsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chatassistantsettingss</returns>
        List<ChatAssistantSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new chatassistantsettings</summary>
        /// <param name="model">The chatassistantsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        Guid Create(ChatAssistantSettings model);

        /// <summary>Updates a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <param name="updatedEntity">The chatassistantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Update(Guid id, ChatAssistantSettings updatedEntity);

        /// <summary>Updates a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <param name="updatedEntity">The chatassistantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        bool Patch(Guid id, JsonPatchDocument<ChatAssistantSettings> updatedEntity);

        /// <summary>Deletes a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <returns>The result of the operation</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// The chatassistantsettingsService responsible for managing chatassistantsettings related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting chatassistantsettings information.
    /// </remarks>
    public class ChatAssistantSettingsService : IChatAssistantSettingsService
    {
        private ECODB1st2024Jul17Context _dbContext;

        /// <summary>
        /// Initializes a new instance of the ChatAssistantSettings class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        public ChatAssistantSettingsService(ECODB1st2024Jul17Context dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Retrieves a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <returns>The chatassistantsettings data</returns>
        public ChatAssistantSettings GetById(Guid id)
        {
            var entityData = _dbContext.ChatAssistantSettings.FirstOrDefault(entity => entity.Id == id);
            return entityData;
        }

        /// <summary>Retrieves a list of chatassistantsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of chatassistantsettingss</returns>/// <exception cref="Exception"></exception>
        public List<ChatAssistantSettings> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = GetChatAssistantSettings(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new chatassistantsettings</summary>
        /// <param name="model">The chatassistantsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        public Guid Create(ChatAssistantSettings model)
        {
            model.Id = CreateChatAssistantSettings(model);
            return model.Id;
        }

        /// <summary>Updates a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <param name="updatedEntity">The chatassistantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Update(Guid id, ChatAssistantSettings updatedEntity)
        {
            UpdateChatAssistantSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <param name="updatedEntity">The chatassistantsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Patch(Guid id, JsonPatchDocument<ChatAssistantSettings> updatedEntity)
        {
            PatchChatAssistantSettings(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific chatassistantsettings by its primary key</summary>
        /// <param name="id">The primary key of the chatassistantsettings</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(Guid id)
        {
            DeleteChatAssistantSettings(id);
            return true;
        }
        #region
        private List<ChatAssistantSettings> GetChatAssistantSettings(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ChatAssistantSettings.AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ChatAssistantSettings>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ChatAssistantSettings), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ChatAssistantSettings, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private Guid CreateChatAssistantSettings(ChatAssistantSettings model)
        {
            _dbContext.ChatAssistantSettings.Add(model);
            _dbContext.SaveChanges();
            return model.Id;
        }

        private void UpdateChatAssistantSettings(Guid id, ChatAssistantSettings updatedEntity)
        {
            _dbContext.ChatAssistantSettings.Update(updatedEntity);
            _dbContext.SaveChanges();
        }

        private bool DeleteChatAssistantSettings(Guid id)
        {
            var entityData = _dbContext.ChatAssistantSettings.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ChatAssistantSettings.Remove(entityData);
            _dbContext.SaveChanges();
            return true;
        }

        private void PatchChatAssistantSettings(Guid id, JsonPatchDocument<ChatAssistantSettings> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ChatAssistantSettings.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ChatAssistantSettings.Update(existingEntity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}