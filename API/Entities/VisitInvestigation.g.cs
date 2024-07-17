using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitinvestigation entity with essential details
    /// </summary>
    public class VisitInvestigation
    {
        /// <summary>
        /// Initializes a new instance of the VisitInvestigation class.
        /// </summary>
        public VisitInvestigation()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitInvestigation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitInvestigation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitInvestigation 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitInvestigation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitInvestigation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitInvestigation 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitInvestigation 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the VisitInvestigation 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitInvestigation 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitInvestigation 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitInvestigation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DoctorInvestigationProfileName of the VisitInvestigation 
        /// </summary>
        public string? DoctorInvestigationProfileName { get; set; }
        /// <summary>
        /// Investigation of the VisitInvestigation 
        /// </summary>
        public Guid? Investigation { get; set; }
        /// <summary>
        /// InvestigationProfile of the VisitInvestigation 
        /// </summary>
        public Guid? InvestigationProfile { get; set; }
        /// <summary>
        /// ProductId of the VisitInvestigation 
        /// </summary>
        public Guid? ProductId { get; set; }
        /// <summary>
        /// ProductName of the VisitInvestigation 
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// Foreign key referencing the InvoiceLine to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? InvoiceLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvoiceLine
        /// </summary>
        [ForeignKey("InvoiceLineId")]
        public InvoiceLine? InvoiceLineId_InvoiceLine { get; set; }
        /// <summary>
        /// PackageItem of the VisitInvestigation 
        /// </summary>
        public bool? PackageItem { get; set; }
        /// <summary>
        /// Summary of the VisitInvestigation 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// DoctorInvestigation of the VisitInvestigation 
        /// </summary>
        public Guid? DoctorInvestigation { get; set; }
        /// <summary>
        /// DoctorInvestigationProfileItem of the VisitInvestigation 
        /// </summary>
        public Guid? DoctorInvestigationProfileItem { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }
    }
}