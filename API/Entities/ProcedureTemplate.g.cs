using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a proceduretemplate entity with essential details
    /// </summary>
    public class ProcedureTemplate
    {
        /// <summary>
        /// Initializes a new instance of the ProcedureTemplate class.
        /// </summary>
        public ProcedureTemplate()
        {
            IsDefaultTemplate = false;
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Required field Name of the ProcedureTemplate 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field IsDefaultTemplate of the ProcedureTemplate 
        /// </summary>
        [Required]
        public bool IsDefaultTemplate { get; set; }

        /// <summary>
        /// Required field IsStandard of the ProcedureTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProcedureTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProcedureTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProcedureTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProcedureTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the ProcedureTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ProcedureTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the ProcedureTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Flagged of the ProcedureTemplate 
        /// </summary>
        public bool? Flagged { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProcedureTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProcedureTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// User of the ProcedureTemplate 
        /// </summary>
        public Guid? User { get; set; }
    }
}