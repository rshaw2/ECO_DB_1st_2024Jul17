using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a referralorder entity with essential details
    /// </summary>
    public class ReferralOrder
    {
        /// <summary>
        /// Primary key for the ReferralOrder 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ReferralOrder belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field OrderNumber of the ReferralOrder 
        /// </summary>
        [Required]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the ReferralOrder belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field OrderStatus of the ReferralOrder 
        /// </summary>
        [Required]
        public byte OrderStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ReferralOrder belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ReferralOrder 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ReferralOrder belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ReferralOrder 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}