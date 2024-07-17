using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a comorbiditydeviation entity with essential details
    /// </summary>
    public class ComorbidityDeviation
    {
        /// <summary>
        /// Primary key for the ComorbidityDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ComorbidityDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Comorbidity to which the ComorbidityDeviation belongs 
        /// </summary>
        [Required]
        public Guid Comorbidity { get; set; }

        /// <summary>
        /// Navigation property representing the associated Comorbidity
        /// </summary>
        [ForeignKey("Comorbidity")]
        public Comorbidity? Comorbidity_Comorbidity { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ComorbidityDeviation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ComorbidityDeviation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field DevationType of the ComorbidityDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// ReplacedComorbidity of the ComorbidityDeviation 
        /// </summary>
        public Guid? ReplacedComorbidity { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ComorbidityDeviation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ComorbidityDeviation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ComorbidityDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}