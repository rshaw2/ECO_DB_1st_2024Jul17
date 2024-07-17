using Microsoft.AspNetCore.Mvc;
using ECODB1st2024Jul17.Models;
using ECODB1st2024Jul17.Helpers;
using Microsoft.AspNetCore.Authorization;
using YamlDotNet.Serialization;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace ECODB1st2024Jul17.Controllers
{
    /**The MetaDataController class provides API endpoints for retrieving metadata.
                                                                    * It includes authorization and two actions:
                                                                    * - GetMenu: Retrieves menu data from a YAML file and returns it as JSON.
                                                                    * - GetLayout: Retrieves layout data based on the entity and layout type, specified in the route and query parameters respectively.
                                                                    *   The layout data is read from a YAML file and returned as JSON.
                                                                    */
    [Route("api/dynamic/meta-data")]
    [Authorize]
    public class MetaDataController : BaseApiController
    {
        /// <summary>
        /// Retrieves and returns menu data
        /// </summary>
        /// <returns>Returns json.</returns>
        [HttpGet]
        [Route("menu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetMenu()
        {
            string menuFilePath =  $"./Menu/Menu.yaml";
            var dynamicYaml = System.IO.File.ReadAllText(menuFilePath);
            var deserializer =  new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize<dynamic>(dynamicYaml);
            return Ok(yamlObject);
        }

        /// <summary>
        /// Retrieves and returns layout data based on entity and layout type.
        /// </summary>
        /// <param name="entity">Entity name</param>
        /// <param name="layoutType">Layout type as List= 1, Add= 2 and Edit= 3</param>
        /// <returns>Returns json.</returns>
        [HttpGet]
        [Route("{entity}/layout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetLayout([FromRoute] string entity, [FromQuery] LayoutType layoutType)
        {
            if (string.IsNullOrEmpty(entity))
            {
                return BadRequest("Entity should not be empty");
            }

            if (layoutType == 0)
            {
                return BadRequest("Entity's layout type should not be blank");
            }

            string type = "";
            switch (layoutType)
            {
                case LayoutType.List:
                    type = "List";
                    break;
                case LayoutType.Edit:
                    type = "Edit";
                    break;
                case LayoutType.Add:
                    type = "Add";
                    break;
            }

            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Invalid layout type");
            }

            string layoutFilePath = $"./Layout/{entity}/{type}.yaml";
            var dynamicYaml = System.IO.File.ReadAllText(layoutFilePath);
            var deserializer =  new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize<dynamic>(dynamicYaml);
            return Ok(yamlObject);
        }

        /// <summary>
        /// Retrieves the fields of an entity of user project asynchronously.
        /// </summary>
        /// <remarks>
        /// Endpoint for getting the fields of an entity of user project. Requires a GET request with the specified in the route and 'entityName' specified in the query parameter.
        /// </remarks>
        /// <param name="entityName">The entityName identifying the entity.</param>
        /// <returns>Returns json.</returns>
        [HttpGet("{entityName}/fields")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetEntityFields([FromRoute] string entityName)
        {
            var entity = GetEntitiesDetailByNamespace("ECODB1st2024Jul17.Entities", entityName);
            return Ok(entity);
        }

        /// <summary>
        /// Update layout asynchronously.
        /// </summary>
        /// <remarks>
        /// Endpoint for save the layout of an entity of user project. Requires a PUT request with the specified in the route and 'entityName' specified in the query parameter.
        /// </remarks>
        /// <param name="entityName">The entityName identifying the entity.</param>
        /// <param name="fileDetail">The file content of the entity layout.</param>
        /// <returns>Returns json.</returns>
        [HttpPut("{entityName}/layout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLayoutFile([FromRoute] string entityName, [FromBody] LayoutFileDetail fileDetail)
        {
            var projectRootPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(string.Format("{0}/Layout/{1}/", projectRootPath, entityName), fileDetail.FileName);
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Layout folder does not exist!");
            }

            await System.IO.File.WriteAllTextAsync(filePath, fileDetail.FileContent);
            return Ok(true);
        }

        private static List<MetaDataEntity> GetEntitiesDetailByNamespace(string @namespace, string entityName)
        {
            List<MetaDataEntity> entities = new List<MetaDataEntity>();
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.Namespace == @namespace && t.IsClass && t.Name.ToLower() == entityName.ToLower());
            types = types.ToList();
            foreach (var type in types)
            {
                var entity = new MetaDataEntity { Name = type.Name };
                var properties = type.GetProperties();
                foreach (var prop in properties)
                {
                    if (IsNavigationProperty(prop))
                    {
                        var fields = prop.Name.Split("_");
                        if (fields.Length > 0)
                        {
                            entity.Entities.Add(fields[1]);
                            entity.Fields.Where(w => w.Name.ToLower() == fields[0].ToLower()).ToList().ForEach(s => s.DataSource = fields[1]);
                            continue;
                        }
                    }

                    var propertyInfo = new PropertyInformation { Name = prop.Name, DataType = GetPropertyTypeName(prop.PropertyType), Required = IsPropertyRequired(prop) };
                    entity.Fields.Add(propertyInfo);
                }

                entity.PrimaryField = GetPrimaryKey(properties);
                entities.Add(entity);
            }

            return entities;
        }

        private static string GetPropertyTypeName(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(type).Name;
            }

            return type.Name;
        }

        private static bool IsPropertyRequired(PropertyInfo property)
        {
            var requiredAttribute = property.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();
            return requiredAttribute != null;
        }

        private static bool IsNavigationProperty(PropertyInfo property)
        {
            return property.PropertyType.IsClass && property.PropertyType.Name != "String";
        }

        private static PropertyInformation? GetPrimaryKey(PropertyInfo[] properties)
        {
            foreach (var prop in properties)
            {
                if (prop.GetCustomAttributes(typeof(KeyAttribute), false).Any())
                {
                    var data = new PropertyInformation { Name = prop.Name, DataType = GetPropertyTypeName(prop.PropertyType), Required = IsPropertyRequired(prop) };
                    return data;
                }
            }

            return null;
        }
    }
}