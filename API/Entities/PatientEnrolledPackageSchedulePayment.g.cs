using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientenrolledpackageschedulepayment entity with essential details
    /// </summary>
    public class PatientEnrolledPackageSchedulePayment
    {
        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackageSchedulePayment class.
        /// </summary>
        public PatientEnrolledPackageSchedulePayment()
        {
            PaymentStatus = 3;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientEnrolledPackageSchedulePayment belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientEnrolledPackage to which the PatientEnrolledPackageSchedulePayment belongs 
        /// </summary>
        [Required]
        public Guid PatientEnrolledPackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientEnrolledPackage
        /// </summary>
        [ForeignKey("PatientEnrolledPackageId")]
        public PatientEnrolledPackage? PatientEnrolledPackageId_PatientEnrolledPackage { get; set; }

        /// <summary>
        /// Foreign key referencing the Payment to which the PatientEnrolledPackageSchedulePayment belongs 
        /// </summary>
        [Required]
        public Guid PaymentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Payment
        /// </summary>
        [ForeignKey("PaymentId")]
        public Payment? PaymentId_Payment { get; set; }

        /// <summary>
        /// Required field PaymentStatus of the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Required]
        public byte PaymentStatus { get; set; }

        /// <summary>
        /// Required field Sequence of the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }

        /// <summary>
        /// Required field InstallmentPercentage of the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Required]
        public decimal InstallmentPercentage { get; set; }

        /// <summary>
        /// Required field InstallmentDueDate of the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime InstallmentDueDate { get; set; }

        /// <summary>
        /// Required field InstallmentAmount of the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Required]
        public decimal InstallmentAmount { get; set; }

        /// <summary>
        /// Required field Selected of the PatientEnrolledPackageSchedulePayment 
        /// </summary>
        [Required]
        public bool Selected { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientEnrolledPackageSchedule to which the PatientEnrolledPackageSchedulePayment belongs 
        /// </summary>
        public Guid? PatientEnrolledPackageScheduleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientEnrolledPackageSchedule
        /// </summary>
        [ForeignKey("PatientEnrolledPackageScheduleId")]
        public PatientEnrolledPackageSchedule? PatientEnrolledPackageScheduleId_PatientEnrolledPackageSchedule { get; set; }
    }
}