using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitinvestigationresult entity with essential details
    /// </summary>
    public class VisitInvestigationResult
    {
        /// <summary>
        /// Initializes a new instance of the VisitInvestigationResult class.
        /// </summary>
        public VisitInvestigationResult()
        {
            IsStandard = false;
            ResultDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitInvestigationResult belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitInvestigationResult 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitInvestigationResult 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the Investigation to which the VisitInvestigationResult belongs 
        /// </summary>
        [Required]
        public Guid Investigation { get; set; }

        /// <summary>
        /// Navigation property representing the associated Investigation
        /// </summary>
        [ForeignKey("Investigation")]
        public Investigation? Investigation_Investigation { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitInvestigationResult 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitInvestigationResult 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitInvestigationResult 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigationResult belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitInvestigationResult 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field ResultDate of the VisitInvestigationResult 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ResultDate { get; set; }
        /// <summary>
        /// Foreign key referencing the InvestigationRecordResult to which the VisitInvestigationResult belongs 
        /// </summary>
        public Guid? InvestigationRecordResult { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvestigationRecordResult
        /// </summary>
        [ForeignKey("InvestigationRecordResult")]
        public InvestigationRecordResult? InvestigationRecordResult_InvestigationRecordResult { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the VisitInvestigationResult belongs 
        /// </summary>
        public Guid? Lab { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("Lab")]
        public Contact? Lab_Contact { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the VisitInvestigationResult belongs 
        /// </summary>
        public Guid? Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigationResult belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitInvestigationResult 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VisitInvestigationResult 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitInvestigationResult 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitInvestigationResult 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// FileId of the VisitInvestigationResult 
        /// </summary>
        public Guid? FileId { get; set; }
        /// <summary>
        /// Summary of the VisitInvestigationResult 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the VisitInvestigationResult belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
        /// <summary>
        /// Notes of the VisitInvestigationResult 
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// Abnormal of the VisitInvestigationResult 
        /// </summary>
        public bool? Abnormal { get; set; }
    }
}