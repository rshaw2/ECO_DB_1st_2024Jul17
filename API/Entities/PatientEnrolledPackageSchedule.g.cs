using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientenrolledpackageschedule entity with essential details
    /// </summary>
    public class PatientEnrolledPackageSchedule
    {
        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackageSchedule class.
        /// </summary>
        public PatientEnrolledPackageSchedule()
        {
            PackageScheduleStatus = 1;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientEnrolledPackageSchedule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientEnrolledPackageSchedule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientEnrolledPackage to which the PatientEnrolledPackageSchedule belongs 
        /// </summary>
        [Required]
        public Guid PatientEnrolledPackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientEnrolledPackage
        /// </summary>
        [ForeignKey("PatientEnrolledPackageId")]
        public PatientEnrolledPackage? PatientEnrolledPackageId_PatientEnrolledPackage { get; set; }

        /// <summary>
        /// Required field Title of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Required field Sequence of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }

        /// <summary>
        /// Required field ScheduleDueDate of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ScheduleDueDate { get; set; }

        /// <summary>
        /// Required field PaymentPlanType of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Required]
        public byte PaymentPlanType { get; set; }

        /// <summary>
        /// Required field PackageScheduleStatus of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Required]
        public byte PackageScheduleStatus { get; set; }

        /// <summary>
        /// ScheduleCompleteDate of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ScheduleCompleteDate { get; set; }

        /// <summary>
        /// ScheduleCancelDate of the PatientEnrolledPackageSchedule 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ScheduleCancelDate { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the PatientEnrolledPackageSchedule belongs 
        /// </summary>
        public Guid? VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the PatientEnrolledPackageSchedule belongs 
        /// </summary>
        public Guid? AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }
        /// <summary>
        /// Description of the PatientEnrolledPackageSchedule 
        /// </summary>
        public string? Description { get; set; }
    }
}