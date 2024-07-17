namespace ECODB1st2024Jul17.Models
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Metadata for entity details 
    /// </summary>
    public class MetaDataEntity
    {
        /// <summary>
        /// Initializes a new instance of the MetaDataEntity class.
        /// </summary>
        public MetaDataEntity()
        {
            Fields = new List<PropertyInformation>();
            Entities = new List<string>();
        }

        /// <summary>
        /// Name of the MetaDataEntity 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// PrimaryField of the MetaDataEntity 
        /// </summary>
        [AllowNull]
        public PropertyInformation PrimaryField { get; set; }
        /// <summary>
        /// Fields of the MetaDataEntity 
        /// </summary>
        public List<PropertyInformation> Fields { get; set; }
        /// <summary>
        /// Entities of the MetaDataEntity 
        /// </summary>
        public List<string> Entities { get; set; }
    }

    /// <summary>
    /// Entity property class 
    /// </summary>
    public class PropertyInformation
    {
        /// <summary>
        /// Name of the MetaDataEntity 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// DataType of the PropertyInformation 
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// DataSource of the PropertyInformation 
        /// </summary>
        [AllowNull]
        public string DataSource { get; set; }
        /// <summary>
        /// Required of the PropertyInformation 
        /// </summary>
        public bool? Required { get; set; }
    }

    /// <summary>
    /// Layout file model 
    /// </summary>
    public class LayoutFileDetail
    {
        /// <summary>
        /// FileName of the LayoutFileDetail 
        /// </summary>
        public string FileName { get; set; } = "";
        /// <summary>
        /// FileContent of the LayoutFileDetail 
        /// </summary>
        public string FileContent { get; set; } = "";
    }
}