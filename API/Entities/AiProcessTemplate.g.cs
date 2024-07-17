using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aiprocesstemplate entity with essential details
    /// </summary>
    public class AiProcessTemplate
    {
        /// <summary>
        /// Primary key for the AiProcessTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AiProcessTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the AiProcess to which the AiProcessTemplate belongs 
        /// </summary>
        [Required]
        public Guid AiProcessId { get; set; }

        /// <summary>
        /// Navigation property representing the associated AiProcess
        /// </summary>
        [ForeignKey("AiProcessId")]
        public AiProcess? AiProcessId_AiProcess { get; set; }

        /// <summary>
        /// Required field Title of the AiProcessTemplate 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Required field SystemRolePrompt of the AiProcessTemplate 
        /// </summary>
        [Required]
        public string SystemRolePrompt { get; set; }

        /// <summary>
        /// Required field UserRolePrompt of the AiProcessTemplate 
        /// </summary>
        [Required]
        public string UserRolePrompt { get; set; }

        /// <summary>
        /// Required field Model of the AiProcessTemplate 
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Required field Temperature of the AiProcessTemplate 
        /// </summary>
        [Required]
        public decimal Temperature { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the AiProcessTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the AiProcessTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the AiProcessTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the AiProcessTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// MaxToken of the AiProcessTemplate 
        /// </summary>
        public int? MaxToken { get; set; }
    }
}