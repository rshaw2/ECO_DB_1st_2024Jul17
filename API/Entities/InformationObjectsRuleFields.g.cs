using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a informationobjectsrulefields entity with essential details
    /// </summary>
    public class InformationObjectsRuleFields
    {
        /// <summary>
        /// Primary key for the InformationObjectsRuleFields 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InformationObjectsRuleFields belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjectsRules to which the InformationObjectsRuleFields belongs 
        /// </summary>
        [Required]
        public Guid InformationObjectRuleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjectsRules
        /// </summary>
        [ForeignKey("InformationObjectRuleId")]
        public InformationObjectsRules? InformationObjectRuleId_InformationObjectsRules { get; set; }
        /// <summary>
        /// RuleField of the InformationObjectsRuleFields 
        /// </summary>
        public string? RuleField { get; set; }
        /// <summary>
        /// FilterObjects of the InformationObjectsRuleFields 
        /// </summary>
        public string? FilterObjects { get; set; }
    }
}