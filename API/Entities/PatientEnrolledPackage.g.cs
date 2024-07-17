using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientenrolledpackage entity with essential details
    /// </summary>
    public class PatientEnrolledPackage
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientEnrolledPackage belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientEnrolledPackage 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PatientEnrolledPackage belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the PatientEnrolledPackage belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field PackageName of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        public string PackageName { get; set; }

        /// <summary>
        /// Required field PackagePrice of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        public decimal PackagePrice { get; set; }

        /// <summary>
        /// Required field EnrollmentState of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        public byte EnrollmentState { get; set; }

        /// <summary>
        /// Required field PackageEnrollmentStatus of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        public byte PackageEnrollmentStatus { get; set; }

        /// <summary>
        /// Required field EnrollmentDate of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Required field ExpiryDate of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientEnrolledPackage belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientEnrolledPackage 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the PatientEnrolledPackage belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the PatientEnrolledPackage belongs 
        /// </summary>
        public Guid? SublocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SublocationId")]
        public SubLocation? SublocationId_SubLocation { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientEnrolledPackage belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientEnrolledPackage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the PatientEnrolledPackage belongs 
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the PatientEnrolledPackage belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
        /// <summary>
        /// MultiVisit of the PatientEnrolledPackage 
        /// </summary>
        public bool? MultiVisit { get; set; }
        /// <summary>
        /// PaymentPlan of the PatientEnrolledPackage 
        /// </summary>
        public bool? PaymentPlan { get; set; }
    }
}