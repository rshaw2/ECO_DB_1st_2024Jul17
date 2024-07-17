using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a loyaltyprogramrule entity with essential details
    /// </summary>
    public class LoyaltyProgramRule
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the LoyaltyProgramRule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the LoyaltyProgramRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the LoyaltyProgram to which the LoyaltyProgramRule belongs 
        /// </summary>
        [Required]
        public Guid LoyaltyProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated LoyaltyProgram
        /// </summary>
        [ForeignKey("LoyaltyProgramId")]
        public LoyaltyProgram? LoyaltyProgramId_LoyaltyProgram { get; set; }

        /// <summary>
        /// Required field Unit of the LoyaltyProgramRule 
        /// </summary>
        [Required]
        public int Unit { get; set; }

        /// <summary>
        /// Required field EcCoins of the LoyaltyProgramRule 
        /// </summary>
        [Required]
        public decimal EcCoins { get; set; }

        /// <summary>
        /// Required field UnitLimit of the LoyaltyProgramRule 
        /// </summary>
        [Required]
        public int UnitLimit { get; set; }

        /// <summary>
        /// Required field RuleDuration of the LoyaltyProgramRule 
        /// </summary>
        [Required]
        public short RuleDuration { get; set; }
    }
}