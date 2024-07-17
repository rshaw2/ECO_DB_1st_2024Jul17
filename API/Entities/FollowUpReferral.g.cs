using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a followupreferral entity with essential details
    /// </summary>
    public class FollowUpReferral
    {
        /// <summary>
        /// Initializes a new instance of the FollowUpReferral class.
        /// </summary>
        public FollowUpReferral()
        {
            IsSpecificValue = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the FollowUpReferral belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the FollowUpReferral 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the FollowUpReferral belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field IsSpecificValue of the FollowUpReferral 
        /// </summary>
        [Required]
        public bool IsSpecificValue { get; set; }

        /// <summary>
        /// Required field IsStandard of the FollowUpReferral 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the FollowUpReferral belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the FollowUpReferral 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the FollowUpReferral 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the FollowUpReferral 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the FollowUpReferral 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the FollowUpReferral 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the FollowUpReferral 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the FollowUpReferral belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the FollowUpReferral 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the FollowUpReferral belongs 
        /// </summary>
        public Guid? ReferredToId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ReferredToId")]
        public Contact? ReferredToId_Contact { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the FollowUpReferral belongs 
        /// </summary>
        public Guid? FollowUpUnit { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("FollowUpUnit")]
        public UOM? FollowUpUnit_UOM { get; set; }
        /// <summary>
        /// FollowUpValue of the FollowUpReferral 
        /// </summary>
        public short? FollowUpValue { get; set; }
        /// <summary>
        /// Summary of the FollowUpReferral 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// ReferralName of the FollowUpReferral 
        /// </summary>
        public string? ReferralName { get; set; }
        /// <summary>
        /// Notes of the FollowUpReferral 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// NextFollowUp of the FollowUpReferral 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NextFollowUp { get; set; }
    }
}