using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationdeviation entity with essential details
    /// </summary>
    public class InvestigationDeviation
    {
        /// <summary>
        /// Primary key for the InvestigationDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Investigation to which the InvestigationDeviation belongs 
        /// </summary>
        [Required]
        public Guid Investigation { get; set; }

        /// <summary>
        /// Navigation property representing the associated Investigation
        /// </summary>
        [ForeignKey("Investigation")]
        public Investigation? Investigation_Investigation { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationDeviation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationDeviation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field DevationType of the InvestigationDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// ReplacedInvestigation of the InvestigationDeviation 
        /// </summary>
        public Guid? ReplacedInvestigation { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationDeviation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvestigationDeviation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}