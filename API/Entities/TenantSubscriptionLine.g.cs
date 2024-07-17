using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsubscriptionline entity with essential details
    /// </summary>
    public class TenantSubscriptionLine
    {
        /// <summary>
        /// Primary key for the TenantSubscriptionLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantSubscriptionLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantSubscription to which the TenantSubscriptionLine belongs 
        /// </summary>
        [Required]
        public Guid TenantSubscriptionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantSubscription
        /// </summary>
        [ForeignKey("TenantSubscriptionId")]
        public TenantSubscription? TenantSubscriptionId_TenantSubscription { get; set; }

        /// <summary>
        /// Required field PackageLineType of the TenantSubscriptionLine 
        /// </summary>
        [Required]
        public byte PackageLineType { get; set; }
        /// <summary>
        /// PackageLineSubType of the TenantSubscriptionLine 
        /// </summary>
        public byte? PackageLineSubType { get; set; }
        /// <summary>
        /// Limit of the TenantSubscriptionLine 
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Uom of the TenantSubscriptionLine 
        /// </summary>
        public byte? Uom { get; set; }
        /// <summary>
        /// Foreign key referencing the PackageLine to which the TenantSubscriptionLine belongs 
        /// </summary>
        public Guid? PackageLine { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLine
        /// </summary>
        [ForeignKey("PackageLine")]
        public PackageLine? PackageLine_PackageLine { get; set; }
    }
}