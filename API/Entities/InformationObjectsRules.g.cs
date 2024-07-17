using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a informationobjectsrules entity with essential details
    /// </summary>
    public class InformationObjectsRules
    {
        /// <summary>
        /// Primary key for the InformationObjectsRules 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InformationObjectsRules belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjects to which the InformationObjectsRules belongs 
        /// </summary>
        [Required]
        public Guid InformationObjectId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjects
        /// </summary>
        [ForeignKey("InformationObjectId")]
        public InformationObjects? InformationObjectId_InformationObjects { get; set; }

        /// <summary>
        /// Required field RuleName of the InformationObjectsRules 
        /// </summary>
        [Required]
        public string RuleName { get; set; }

        /// <summary>
        /// Required field RuleType of the InformationObjectsRules 
        /// </summary>
        [Required]
        public byte RuleType { get; set; }

        /// <summary>
        /// Required field Strictness of the InformationObjectsRules 
        /// </summary>
        [Required]
        public byte Strictness { get; set; }
        /// <summary>
        /// ResponseCode of the InformationObjectsRules 
        /// </summary>
        public string? ResponseCode { get; set; }
    }
}