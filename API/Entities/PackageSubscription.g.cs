using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a packagesubscription entity with essential details
    /// </summary>
    public class PackageSubscription
    {
        /// <summary>
        /// Initializes a new instance of the PackageSubscription class.
        /// </summary>
        public PackageSubscription()
        {
            IsStandard = false;
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PackageSubscription belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PackageSubscription 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the PackageSubscription 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PackageSubscription 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PackageSubscription belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PackageSubscription 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the PackageSubscription 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Active of the PackageSubscription 
        /// </summary>
        [Required]
        public Guid Active { get; set; }
        /// <summary>
        /// Duration of the PackageSubscription 
        /// </summary>
        public Guid? Duration { get; set; }
        /// <summary>
        /// ParentId of the PackageSubscription 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the PackageSubscription 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PackageSubscription belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PackageSubscription 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Name of the PackageSubscription 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Group of the PackageSubscription 
        /// </summary>
        public Guid? Group { get; set; }
        /// <summary>
        /// RecurringPrice of the PackageSubscription 
        /// </summary>
        public decimal? RecurringPrice { get; set; }
        /// <summary>
        /// SetUpPrice of the PackageSubscription 
        /// </summary>
        public decimal? SetUpPrice { get; set; }
        /// <summary>
        /// Status of the PackageSubscription 
        /// </summary>
        public bool? Status { get; set; }
    }
}