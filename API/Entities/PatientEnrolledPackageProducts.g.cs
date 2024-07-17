using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientenrolledpackageproducts entity with essential details
    /// </summary>
    public class PatientEnrolledPackageProducts
    {
        /// <summary>
        /// Initializes a new instance of the PatientEnrolledPackageProducts class.
        /// </summary>
        public PatientEnrolledPackageProducts()
        {
            EnrolledProductStatus = 1;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientEnrolledPackageProducts belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientEnrolledPackageProducts 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientEnrolledPackage to which the PatientEnrolledPackageProducts belongs 
        /// </summary>
        [Required]
        public Guid PatientEnrolledPackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientEnrolledPackage
        /// </summary>
        [ForeignKey("PatientEnrolledPackageId")]
        public PatientEnrolledPackage? PatientEnrolledPackageId_PatientEnrolledPackage { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the PatientEnrolledPackageProducts belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field ProductName of the PatientEnrolledPackageProducts 
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Required field Sequence of the PatientEnrolledPackageProducts 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }

        /// <summary>
        /// Required field Quantity of the PatientEnrolledPackageProducts 
        /// </summary>
        [Required]
        public byte Quantity { get; set; }

        /// <summary>
        /// Required field EnrolledProductStatus of the PatientEnrolledPackageProducts 
        /// </summary>
        [Required]
        public byte EnrolledProductStatus { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientEnrolledPackageSchedule to which the PatientEnrolledPackageProducts belongs 
        /// </summary>
        public Guid? PatientEnrolledScheduleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientEnrolledPackageSchedule
        /// </summary>
        [ForeignKey("PatientEnrolledScheduleId")]
        public PatientEnrolledPackageSchedule? PatientEnrolledScheduleId_PatientEnrolledPackageSchedule { get; set; }
    }
}