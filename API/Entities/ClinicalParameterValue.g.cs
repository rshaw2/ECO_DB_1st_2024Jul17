using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a clinicalparametervalue entity with essential details
    /// </summary>
    public class ClinicalParameterValue
    {
        /// <summary>
        /// Initializes a new instance of the ClinicalParameterValue class.
        /// </summary>
        public ClinicalParameterValue()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ClinicalParameterValue belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ClinicalParameterValue 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterValue
        /// </summary>
        [ForeignKey("Id")]
        public ClinicalParameterValue? Id_ClinicalParameterValue { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the ClinicalParameterValue belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Sequence of the ClinicalParameterValue 
        /// </summary>
        [Required]
        public decimal Sequence { get; set; }

        /// <summary>
        /// Required field Value of the ClinicalParameterValue 
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Required field EntityCode of the ClinicalParameterValue 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ClinicalParameterValue 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the ClinicalParameterValue 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ClinicalParameterValue 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ClinicalParameterValue belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ClinicalParameterValue belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ClinicalParameterValue 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the ClinicalParameterValue 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ClinicalParameterValue 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// IsAbnormal of the ClinicalParameterValue 
        /// </summary>
        public bool? IsAbnormal { get; set; }
    }
}