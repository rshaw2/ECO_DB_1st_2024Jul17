using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a loyaltyprogram entity with essential details
    /// </summary>
    public class LoyaltyProgram
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the LoyaltyProgram belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the LoyaltyProgram 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Name of the LoyaltyProgram 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field ProgramStartDate of the LoyaltyProgram 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ProgramStartDate { get; set; }

        /// <summary>
        /// Required field Enable of the LoyaltyProgram 
        /// </summary>
        [Required]
        public bool Enable { get; set; }

        /// <summary>
        /// Required field InputRequired of the LoyaltyProgram 
        /// </summary>
        [Required]
        public bool InputRequired { get; set; }

        /// <summary>
        /// Required field UnitType of the LoyaltyProgram 
        /// </summary>
        [Required]
        public short UnitType { get; set; }

        /// <summary>
        /// ProgramEndDate of the LoyaltyProgram 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ProgramEndDate { get; set; }
        /// <summary>
        /// Description of the LoyaltyProgram 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// TermsAndCondition of the LoyaltyProgram 
        /// </summary>
        public string? TermsAndCondition { get; set; }
    }
}