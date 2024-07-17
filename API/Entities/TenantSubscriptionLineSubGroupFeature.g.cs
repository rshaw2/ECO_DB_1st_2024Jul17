using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsubscriptionlinesubgroupfeature entity with essential details
    /// </summary>
    public class TenantSubscriptionLineSubGroupFeature
    {
        /// <summary>
        /// Primary key for the TenantSubscriptionLineSubGroupFeature 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantSubscriptionLineSubGroupFeature belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantSubscriptionLineSubGroup to which the TenantSubscriptionLineSubGroupFeature belongs 
        /// </summary>
        [Required]
        public Guid TenantSubscriptionLineSubGroup { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantSubscriptionLineSubGroup
        /// </summary>
        [ForeignKey("TenantSubscriptionLineSubGroup")]
        public TenantSubscriptionLineSubGroup? TenantSubscriptionLineSubGroup_TenantSubscriptionLineSubGroup { get; set; }

        /// <summary>
        /// Foreign key referencing the PackageLineSubGroupFeature to which the TenantSubscriptionLineSubGroupFeature belongs 
        /// </summary>
        [Required]
        public Guid PackageLineSubGroupFeature { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLineSubGroupFeature
        /// </summary>
        [ForeignKey("PackageLineSubGroupFeature")]
        public PackageLineSubGroupFeature? PackageLineSubGroupFeature_PackageLineSubGroupFeature { get; set; }

        /// <summary>
        /// Required field Enabled of the TenantSubscriptionLineSubGroupFeature 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the TenantSubscriptionLineSubGroupFeature belongs 
        /// </summary>
        public Guid? FeatureParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("FeatureParameterId")]
        public ClinicalParameter? FeatureParameterId_ClinicalParameter { get; set; }
    }
}