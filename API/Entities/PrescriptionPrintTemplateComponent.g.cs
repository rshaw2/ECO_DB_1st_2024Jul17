using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a prescriptionprinttemplatecomponent entity with essential details
    /// </summary>
    public class PrescriptionPrintTemplateComponent
    {
        /// <summary>
        /// Primary key for the PrescriptionPrintTemplateComponent 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PrescriptionPrintTemplateComponent belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the PrescriptionPrintTemplate to which the PrescriptionPrintTemplateComponent belongs 
        /// </summary>
        [Required]
        public Guid PrescriptionPrintTemplateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PrescriptionPrintTemplate
        /// </summary>
        [ForeignKey("PrescriptionPrintTemplateId")]
        public PrescriptionPrintTemplate? PrescriptionPrintTemplateId_PrescriptionPrintTemplate { get; set; }

        /// <summary>
        /// Required field PrintComponent of the PrescriptionPrintTemplateComponent 
        /// </summary>
        [Required]
        public byte PrintComponent { get; set; }

        /// <summary>
        /// Required field Sequence of the PrescriptionPrintTemplateComponent 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Visible of the PrescriptionPrintTemplateComponent 
        /// </summary>
        [Required]
        public bool Visible { get; set; }
    }
}