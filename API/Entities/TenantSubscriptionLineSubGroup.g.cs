using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsubscriptionlinesubgroup entity with essential details
    /// </summary>
    public class TenantSubscriptionLineSubGroup
    {
        /// <summary>
        /// Primary key for the TenantSubscriptionLineSubGroup 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantSubscriptionLineSubGroup belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantSubscriptionLine to which the TenantSubscriptionLineSubGroup belongs 
        /// </summary>
        [Required]
        public Guid TenantSubscriptionLine { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantSubscriptionLine
        /// </summary>
        [ForeignKey("TenantSubscriptionLine")]
        public TenantSubscriptionLine? TenantSubscriptionLine_TenantSubscriptionLine { get; set; }

        /// <summary>
        /// Foreign key referencing the PackageLineSubGroup to which the TenantSubscriptionLineSubGroup belongs 
        /// </summary>
        [Required]
        public Guid PackageLineSubGroup { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLineSubGroup
        /// </summary>
        [ForeignKey("PackageLineSubGroup")]
        public PackageLineSubGroup? PackageLineSubGroup_PackageLineSubGroup { get; set; }
    }
}