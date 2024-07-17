using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a procedurevector entity with essential details
    /// </summary>
    public class ProcedureVector
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ProcedureVector belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProcedureVector 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Procedure to which the ProcedureVector belongs 
        /// </summary>
        [Required]
        public Guid ProcedureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Procedure
        /// </summary>
        [ForeignKey("ProcedureId")]
        public Procedure? ProcedureId_Procedure { get; set; }

        /// <summary>
        /// Required field VectorValue of the ProcedureVector 
        /// </summary>
        [Required]
        public string VectorValue { get; set; }

        /// <summary>
        /// SyncDate of the ProcedureVector 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SyncDate { get; set; }
    }
}