using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationtemplate entity with essential details
    /// </summary>
    public class InvestigationTemplate
    {
        /// <summary>
        /// Initializes a new instance of the InvestigationTemplate class.
        /// </summary>
        public InvestigationTemplate()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the InvestigationTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the InvestigationTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the InvestigationTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the InvestigationTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Flagged of the InvestigationTemplate 
        /// </summary>
        public bool? Flagged { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvestigationTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationTemplate belongs 
        /// </summary>
        public Guid? User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }
        /// <summary>
        /// Code of the InvestigationTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InvestigationTemplate 
        /// </summary>
        public string? Name { get; set; }
    }
}