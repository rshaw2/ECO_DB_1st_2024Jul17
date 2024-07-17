using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsubscription entity with essential details
    /// </summary>
    public class TenantSubscription
    {
        /// <summary>
        /// Initializes a new instance of the TenantSubscription class.
        /// </summary>
        public TenantSubscription()
        {
            CurrentPlan = false;
        }

        /// <summary>
        /// Primary key for the TenantSubscription 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantSubscription belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Package to which the TenantSubscription belongs 
        /// </summary>
        [Required]
        public Guid PackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Package
        /// </summary>
        [ForeignKey("PackageId")]
        public Package? PackageId_Package { get; set; }

        /// <summary>
        /// Required field PaymentTerm of the TenantSubscription 
        /// </summary>
        [Required]
        public byte PaymentTerm { get; set; }

        /// <summary>
        /// Required field StartDate of the TenantSubscription 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required field EndDate of the TenantSubscription 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Required field ExpiryDate of the TenantSubscription 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Required field Active of the TenantSubscription 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Required field PackagePrice of the TenantSubscription 
        /// </summary>
        [Required]
        public decimal PackagePrice { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the TenantSubscription belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantSubscription 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field NumberOfUser of the TenantSubscription 
        /// </summary>
        [Required]
        public short NumberOfUser { get; set; }
        /// <summary>
        /// Discount of the TenantSubscription 
        /// </summary>
        public decimal? Discount { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the TenantSubscription belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the TenantSubscription 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// CurrentPlan of the TenantSubscription 
        /// </summary>
        public bool? CurrentPlan { get; set; }

        /// <summary>
        /// TrialEndDate of the TenantSubscription 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TrialEndDate { get; set; }
    }
}