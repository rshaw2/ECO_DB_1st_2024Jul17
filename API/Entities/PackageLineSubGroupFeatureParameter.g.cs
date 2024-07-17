using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a packagelinesubgroupfeatureparameter entity with essential details
    /// </summary>
    public class PackageLineSubGroupFeatureParameter
    {
        /// <summary>
        /// Primary key for the PackageLineSubGroupFeatureParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PackageLineSubGroupFeature to which the PackageLineSubGroupFeatureParameter belongs 
        /// </summary>
        [Required]
        public Guid PackageLineSubGroupFeature { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLineSubGroupFeature
        /// </summary>
        [ForeignKey("PackageLineSubGroupFeature")]
        public PackageLineSubGroupFeature? PackageLineSubGroupFeature_PackageLineSubGroupFeature { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the PackageLineSubGroupFeatureParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Name of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameterValue to which the PackageLineSubGroupFeatureParameter belongs 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterValue
        /// </summary>
        [ForeignKey("ClinicalParameterValue")]
        public ClinicalParameterValue? ClinicalParameterValue_ClinicalParameterValue { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// IsSpecificValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// TextValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the PackageLineSubGroupFeatureParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the PackageLineSubGroupFeatureParameter belongs 
        /// </summary>
        public Guid? UOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UOM")]
        public UOM? UOM_UOM { get; set; }
    }
}