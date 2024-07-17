using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsubscriptionadditionaluser entity with essential details
    /// </summary>
    public class TenantSubscriptionAdditionalUser
    {
        /// <summary>
        /// Primary key for the TenantSubscriptionAdditionalUser 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantSubscription to which the TenantSubscriptionAdditionalUser belongs 
        /// </summary>
        [Required]
        public Guid TenantSubscriptionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantSubscription
        /// </summary>
        [ForeignKey("TenantSubscriptionId")]
        public TenantSubscription? TenantSubscriptionId_TenantSubscription { get; set; }

        /// <summary>
        /// Required field AdditionalUser of the TenantSubscriptionAdditionalUser 
        /// </summary>
        [Required]
        public short AdditionalUser { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantSubscriptionAdditionalUser 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Amount of the TenantSubscriptionAdditionalUser 
        /// </summary>
        public decimal? Amount { get; set; }
        /// <summary>
        /// Discount of the TenantSubscriptionAdditionalUser 
        /// </summary>
        public decimal? Discount { get; set; }
        /// <summary>
        /// UnitPrice of the TenantSubscriptionAdditionalUser 
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}