using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a covercategorysubscription entity with essential details
    /// </summary>
    public class CoverCategorySubscription
    {
        /// <summary>
        /// Primary key for the CoverCategorySubscription 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CoverCategorySubscription belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CoverCategory to which the CoverCategorySubscription belongs 
        /// </summary>
        [Required]
        public Guid CoverCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CoverCategory
        /// </summary>
        [ForeignKey("CoverCategoryId")]
        public CoverCategory? CoverCategoryId_CoverCategory { get; set; }

        /// <summary>
        /// Foreign key referencing the SubscriptionCategory to which the CoverCategorySubscription belongs 
        /// </summary>
        [Required]
        public Guid SubscriptionCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubscriptionCategory
        /// </summary>
        [ForeignKey("SubscriptionCategoryId")]
        public SubscriptionCategory? SubscriptionCategoryId_SubscriptionCategory { get; set; }
    }
}