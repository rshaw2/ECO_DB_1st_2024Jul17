using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a clinicalparameterrange entity with essential details
    /// </summary>
    public class ClinicalParameterRange
    {
        /// <summary>
        /// Primary key for the ClinicalParameterRange 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterRange
        /// </summary>
        [ForeignKey("Id")]
        public ClinicalParameterRange? Id_ClinicalParameterRange { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ClinicalParameterRange belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the ClinicalParameterRange belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }
        /// <summary>
        /// RangeType of the ClinicalParameterRange 
        /// </summary>
        public byte? RangeType { get; set; }
        /// <summary>
        /// StartValue of the ClinicalParameterRange 
        /// </summary>
        public decimal? StartValue { get; set; }
        /// <summary>
        /// EndValue of the ClinicalParameterRange 
        /// </summary>
        public decimal? EndValue { get; set; }
        /// <summary>
        /// Foreign key referencing the Gender to which the ClinicalParameterRange belongs 
        /// </summary>
        public Guid? GenderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Gender
        /// </summary>
        [ForeignKey("GenderId")]
        public Gender? GenderId_Gender { get; set; }
        /// <summary>
        /// FromAge of the ClinicalParameterRange 
        /// </summary>
        public byte? FromAge { get; set; }
        /// <summary>
        /// ToAge of the ClinicalParameterRange 
        /// </summary>
        public byte? ToAge { get; set; }
        /// <summary>
        /// ReferenceType of the ClinicalParameterRange 
        /// </summary>
        public byte? ReferenceType { get; set; }
    }
}