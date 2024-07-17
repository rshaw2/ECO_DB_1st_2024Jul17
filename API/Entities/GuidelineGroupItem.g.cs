using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a guidelinegroupitem entity with essential details
    /// </summary>
    public class GuidelineGroupItem
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the GuidelineGroupItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GuidelineGroupItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the GuidelineGroupItem 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GuidelineGroupItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GuidelineGroupItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GuidelineGroupItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GuidelineGroupItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Guideline to which the GuidelineGroupItem belongs 
        /// </summary>
        public Guid? GuidelineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Guideline
        /// </summary>
        [ForeignKey("GuidelineId")]
        public Guideline? GuidelineId_Guideline { get; set; }
        /// <summary>
        /// GuidelineGroupId of the GuidelineGroupItem 
        /// </summary>
        public Guid? GuidelineGroupId { get; set; }
    }
}