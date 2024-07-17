using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a specialitypersonalisationprocedure entity with essential details
    /// </summary>
    public class SpecialityPersonalisationProcedure
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the SpecialityPersonalisationProcedure belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SpecialityPersonalisationProcedure 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the SpecialityPersonalisation to which the SpecialityPersonalisationProcedure belongs 
        /// </summary>
        [Required]
        public Guid SpecialityPersonalisationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SpecialityPersonalisation
        /// </summary>
        [ForeignKey("SpecialityPersonalisationId")]
        public SpecialityPersonalisation? SpecialityPersonalisationId_SpecialityPersonalisation { get; set; }

        /// <summary>
        /// Foreign key referencing the Procedure to which the SpecialityPersonalisationProcedure belongs 
        /// </summary>
        [Required]
        public Guid ProcedureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Procedure
        /// </summary>
        [ForeignKey("ProcedureId")]
        public Procedure? ProcedureId_Procedure { get; set; }
    }
}