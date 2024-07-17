using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aiprocess entity with essential details
    /// </summary>
    public class AiProcess
    {
        /// <summary>
        /// Primary key for the AiProcess 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AiProcess belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field AiProcessType of the AiProcess 
        /// </summary>
        [Required]
        public byte AiProcessType { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the AiProcess belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the AiProcess 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the AiProcess belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the AiProcess 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// AiModule of the AiProcess 
        /// </summary>
        public byte? AiModule { get; set; }
        /// <summary>
        /// Active of the AiProcess 
        /// </summary>
        public bool? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the AiProcessTemplate to which the AiProcess belongs 
        /// </summary>
        public Guid? AiProcessTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated AiProcessTemplate
        /// </summary>
        [ForeignKey("AiProcessTemplateId")]
        public AiProcessTemplate? AiProcessTemplateId_AiProcessTemplate { get; set; }
    }
}