using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a proceduredeviation entity with essential details
    /// </summary>
    public class ProcedureDeviation
    {
        /// <summary>
        /// Primary key for the ProcedureDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProcedureDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Procedure to which the ProcedureDeviation belongs 
        /// </summary>
        [Required]
        public Guid Procedure { get; set; }

        /// <summary>
        /// Navigation property representing the associated Procedure
        /// </summary>
        [ForeignKey("Procedure")]
        public Procedure? Procedure_Procedure { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProcedureDeviation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProcedureDeviation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field DevationType of the ProcedureDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// ReplacedProcedure of the ProcedureDeviation 
        /// </summary>
        public Guid? ReplacedProcedure { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProcedureDeviation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProcedureDeviation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProcedureDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}