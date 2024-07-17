using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visit entity with essential details
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// Initializes a new instance of the Visit class.
        /// </summary>
        public Visit()
        {
            IsStandard = false;
            MedicationLayout = 0;
            VisitAttending = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Visit belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Visit 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitType to which the Visit belongs 
        /// </summary>
        [Required]
        public Guid VisitType { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitType
        /// </summary>
        [ForeignKey("VisitType")]
        public VisitType? VisitType_VisitType { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitMode to which the Visit belongs 
        /// </summary>
        [Required]
        public Guid VisitMode { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMode
        /// </summary>
        [ForeignKey("VisitMode")]
        public VisitMode? VisitMode_VisitMode { get; set; }

        /// <summary>
        /// Required field Patient of the Visit 
        /// </summary>
        [Required]
        public Guid Patient { get; set; }

        /// <summary>
        /// Required field VisitStartDate of the Visit 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime VisitStartDate { get; set; }

        /// <summary>
        /// Required field EntityCode of the Visit 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Visit 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Visit belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Visit 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Visit 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field MedicationLayout of the Visit 
        /// </summary>
        [Required]
        public byte MedicationLayout { get; set; }
        /// <summary>
        /// Foreign key referencing the SubscriptionCategory to which the Visit belongs 
        /// </summary>
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubscriptionCategory
        /// </summary>
        [ForeignKey("SubscriptionId")]
        public SubscriptionCategory? SubscriptionId_SubscriptionCategory { get; set; }
        /// <summary>
        /// Foreign key referencing the EmrTemplate to which the Visit belongs 
        /// </summary>
        public Guid? VisitTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EmrTemplate
        /// </summary>
        [ForeignKey("VisitTemplateId")]
        public EmrTemplate? VisitTemplateId_EmrTemplate { get; set; }
        /// <summary>
        /// ReferenceNo of the Visit 
        /// </summary>
        public string? ReferenceNo { get; set; }
        /// <summary>
        /// Priority of the Visit 
        /// </summary>
        public bool? Priority { get; set; }

        /// <summary>
        /// PriorityDate of the Visit 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PriorityDate { get; set; }
        /// <summary>
        /// DoctorId of the Visit 
        /// </summary>
        public Guid? DoctorId { get; set; }
        /// <summary>
        /// PrescriptionConverted of the Visit 
        /// </summary>
        public bool? PrescriptionConverted { get; set; }
        /// <summary>
        /// VisitAttending of the Visit 
        /// </summary>
        public bool? VisitAttending { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Visit belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the Visit belongs 
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }
        /// <summary>
        /// CreditVisit of the Visit 
        /// </summary>
        public bool? CreditVisit { get; set; }
        /// <summary>
        /// Foreign key referencing the CoverCategory to which the Visit belongs 
        /// </summary>
        public Guid? CoverCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CoverCategory
        /// </summary>
        [ForeignKey("CoverCategoryId")]
        public CoverCategory? CoverCategoryId_CoverCategory { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Visit belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Visit 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Visit 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Visit 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Visit 
        /// </summary>
        public Guid? Active { get; set; }

        /// <summary>
        /// VisitCloseDate of the Visit 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VisitCloseDate { get; set; }

        /// <summary>
        /// PreviousVisitDate of the Visit 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PreviousVisitDate { get; set; }
        /// <summary>
        /// PreviousVisitId of the Visit 
        /// </summary>
        public Guid? PreviousVisitId { get; set; }
    }
}