using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a informationobjectfieldsettings entity with essential details
    /// </summary>
    public class InformationObjectFieldSettings
    {
        /// <summary>
        /// Primary key for the InformationObjectFieldSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InformationObjectFieldSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjectFields to which the InformationObjectFieldSettings belongs 
        /// </summary>
        [Required]
        public Guid InformationObjectFieldId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjectFields
        /// </summary>
        [ForeignKey("InformationObjectFieldId")]
        public InformationObjectFields? InformationObjectFieldId_InformationObjectFields { get; set; }
        /// <summary>
        /// Mandatory of the InformationObjectFieldSettings 
        /// </summary>
        public bool? Mandatory { get; set; }
        /// <summary>
        /// Unique of the InformationObjectFieldSettings 
        /// </summary>
        public bool? Unique { get; set; }
        /// <summary>
        /// AutoGenerateCode of the InformationObjectFieldSettings 
        /// </summary>
        public bool? AutoGenerateCode { get; set; }
        /// <summary>
        /// Prefix of the InformationObjectFieldSettings 
        /// </summary>
        public string? Prefix { get; set; }
        /// <summary>
        /// NextSequenceNumber of the InformationObjectFieldSettings 
        /// </summary>
        public int? NextSequenceNumber { get; set; }
        /// <summary>
        /// Postfix of the InformationObjectFieldSettings 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// RegularExpression of the InformationObjectFieldSettings 
        /// </summary>
        public string? RegularExpression { get; set; }
        /// <summary>
        /// StartRange of the InformationObjectFieldSettings 
        /// </summary>
        public int? StartRange { get; set; }
        /// <summary>
        /// EndRange of the InformationObjectFieldSettings 
        /// </summary>
        public int? EndRange { get; set; }
        /// <summary>
        /// Description of the InformationObjectFieldSettings 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// DefaultValue of the InformationObjectFieldSettings 
        /// </summary>
        public string? DefaultValue { get; set; }
    }
}