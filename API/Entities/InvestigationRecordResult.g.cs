using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationrecordresult entity with essential details
    /// </summary>
    public class InvestigationRecordResult
    {
        /// <summary>
        /// Initializes a new instance of the InvestigationRecordResult class.
        /// </summary>
        public InvestigationRecordResult()
        {
            Sequence = 0;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationRecordResult belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the InvestigationRecordResult 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the InvestigationRecordResult 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the InvestigationRecordResult 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the InvestigationRecordResult 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the InvestigationRecordResult 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationRecordResult belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationRecordResult 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationRecordResult belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvestigationRecordResult 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the InvestigationRecordResult belongs 
        /// </summary>
        public Guid? Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }
        /// <summary>
        /// Code of the InvestigationRecordResult 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InvestigationRecordResult 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the InvestigationRecordResult 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Investigation of the InvestigationRecordResult 
        /// </summary>
        public Guid? Investigation { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitInvestigation to which the InvestigationRecordResult belongs 
        /// </summary>
        public Guid? VisitInvestigation { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitInvestigation
        /// </summary>
        [ForeignKey("VisitInvestigation")]
        public VisitInvestigation? VisitInvestigation_VisitInvestigation { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the InvestigationRecordResult belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
    }
}