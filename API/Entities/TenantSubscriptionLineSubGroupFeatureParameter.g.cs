using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsubscriptionlinesubgroupfeatureparameter entity with essential details
    /// </summary>
    public class TenantSubscriptionLineSubGroupFeatureParameter
    {
        /// <summary>
        /// Primary key for the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TenantId of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Foreign key referencing the TenantSubscriptionLineSubGroupFeature to which the TenantSubscriptionLineSubGroupFeatureParameter belongs 
        /// </summary>
        [Required]
        public Guid TenantSubscriptionLineSubGroupFeature { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantSubscriptionLineSubGroupFeature
        /// </summary>
        [ForeignKey("TenantSubscriptionLineSubGroupFeature")]
        public TenantSubscriptionLineSubGroupFeature? TenantSubscriptionLineSubGroupFeature_TenantSubscriptionLineSubGroupFeature { get; set; }

        /// <summary>
        /// Foreign key referencing the PackageLineSubGroupFeatureParameter to which the TenantSubscriptionLineSubGroupFeatureParameter belongs 
        /// </summary>
        [Required]
        public Guid PackageLineSubGroupFeatureParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLineSubGroupFeatureParameter
        /// </summary>
        [ForeignKey("PackageLineSubGroupFeatureParameter")]
        public PackageLineSubGroupFeatureParameter? PackageLineSubGroupFeatureParameter_PackageLineSubGroupFeatureParameter { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the TenantSubscriptionLineSubGroupFeatureParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Name of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameterValue to which the TenantSubscriptionLineSubGroupFeatureParameter belongs 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterValue
        /// </summary>
        [ForeignKey("ClinicalParameterValue")]
        public ClinicalParameterValue? ClinicalParameterValue_ClinicalParameterValue { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// IsSpecificValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// TextValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the TenantSubscriptionLineSubGroupFeatureParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the TenantSubscriptionLineSubGroupFeatureParameter belongs 
        /// </summary>
        public Guid? UOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UOM")]
        public UOM? UOM_UOM { get; set; }
    }
}