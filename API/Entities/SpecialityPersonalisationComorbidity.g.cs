using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a specialitypersonalisationcomorbidity entity with essential details
    /// </summary>
    public class SpecialityPersonalisationComorbidity
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the SpecialityPersonalisationComorbidity belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SpecialityPersonalisationComorbidity 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the SpecialityPersonalisation to which the SpecialityPersonalisationComorbidity belongs 
        /// </summary>
        [Required]
        public Guid SpecialityPersonalisationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SpecialityPersonalisation
        /// </summary>
        [ForeignKey("SpecialityPersonalisationId")]
        public SpecialityPersonalisation? SpecialityPersonalisationId_SpecialityPersonalisation { get; set; }

        /// <summary>
        /// Foreign key referencing the Comorbidity to which the SpecialityPersonalisationComorbidity belongs 
        /// </summary>
        [Required]
        public Guid ComorbidityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Comorbidity
        /// </summary>
        [ForeignKey("ComorbidityId")]
        public Comorbidity? ComorbidityId_Comorbidity { get; set; }
    }
}