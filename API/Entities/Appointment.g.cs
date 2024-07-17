using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a appointment entity with essential details
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Initializes a new instance of the Appointment class.
        /// </summary>
        public Appointment()
        {
            AppointmentType = 0;
            AppointmentStatus = 0;
            AppointmentArrivalStatus = 0;
            FromVisit = false;
            GeneratePaymentLink = false;
            GeneralStatus = 0;
            Priority = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the Appointment belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Primary key for the Appointment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Appointment belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field AppointmentType of the Appointment 
        /// </summary>
        [Required]
        public byte AppointmentType { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Appointment belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Appointment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field AppointmentStatus of the Appointment 
        /// </summary>
        [Required]
        public byte AppointmentStatus { get; set; }

        /// <summary>
        /// PatientArrivalTime of the Appointment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PatientArrivalTime { get; set; }
        /// <summary>
        /// AppointmentArrivalStatus of the Appointment 
        /// </summary>
        public byte? AppointmentArrivalStatus { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the Appointment belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the Appointment belongs 
        /// </summary>
        public Guid? Visitid { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visitid")]
        public Visit? Visitid_Visit { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Appointment belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Appointment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// FromVisit of the Appointment 
        /// </summary>
        public bool? FromVisit { get; set; }
        /// <summary>
        /// GeneratePaymentLink of the Appointment 
        /// </summary>
        public bool? GeneratePaymentLink { get; set; }
        /// <summary>
        /// PaymentLinkAmount of the Appointment 
        /// </summary>
        public decimal? PaymentLinkAmount { get; set; }
        /// <summary>
        /// VideoLink of the Appointment 
        /// </summary>
        public string? VideoLink { get; set; }
        /// <summary>
        /// PaymentLink of the Appointment 
        /// </summary>
        public string? PaymentLink { get; set; }
        /// <summary>
        /// GeneralStatus of the Appointment 
        /// </summary>
        public byte? GeneralStatus { get; set; }
        /// <summary>
        /// CancelReason of the Appointment 
        /// </summary>
        public string? CancelReason { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Appointment belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// GoogleEventId of the Appointment 
        /// </summary>
        public string? GoogleEventId { get; set; }
        /// <summary>
        /// Priority of the Appointment 
        /// </summary>
        public bool? Priority { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the Appointment belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
        /// <summary>
        /// Code of the Appointment 
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// AppointmentStartDate of the Appointment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? AppointmentStartDate { get; set; }

        /// <summary>
        /// AppointmentEndDate of the Appointment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? AppointmentEndDate { get; set; }
        /// <summary>
        /// Reason of the Appointment 
        /// </summary>
        public string? Reason { get; set; }
    }
}