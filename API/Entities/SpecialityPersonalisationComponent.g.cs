using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a specialitypersonalisationcomponent entity with essential details
    /// </summary>
    public class SpecialityPersonalisationComponent
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the SpecialityPersonalisationComponent belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SpecialityPersonalisationComponent 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the SpecialityPersonalisation to which the SpecialityPersonalisationComponent belongs 
        /// </summary>
        [Required]
        public Guid SpecialityPersonalisationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SpecialityPersonalisation
        /// </summary>
        [ForeignKey("SpecialityPersonalisationId")]
        public SpecialityPersonalisation? SpecialityPersonalisationId_SpecialityPersonalisation { get; set; }

        /// <summary>
        /// Required field Component of the SpecialityPersonalisationComponent 
        /// </summary>
        [Required]
        public byte Component { get; set; }

        /// <summary>
        /// Required field Sequence of the SpecialityPersonalisationComponent 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Visible of the SpecialityPersonalisationComponent 
        /// </summary>
        [Required]
        public bool Visible { get; set; }
    }
}