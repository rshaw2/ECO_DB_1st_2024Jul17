using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a procedureorderline entity with essential details
    /// </summary>
    public class ProcedureOrderLine
    {
        /// <summary>
        /// Primary key for the ProcedureOrderLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProcedureOrderLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProcedureOrder to which the ProcedureOrderLine belongs 
        /// </summary>
        [Required]
        public Guid ProcedureOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProcedureOrder
        /// </summary>
        [ForeignKey("ProcedureOrderId")]
        public ProcedureOrder? ProcedureOrderId_ProcedureOrder { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientProcedure to which the ProcedureOrderLine belongs 
        /// </summary>
        [Required]
        public Guid PatientProcedureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientProcedure
        /// </summary>
        [ForeignKey("PatientProcedureId")]
        public PatientProcedure? PatientProcedureId_PatientProcedure { get; set; }

        /// <summary>
        /// Foreign key referencing the Procedure to which the ProcedureOrderLine belongs 
        /// </summary>
        [Required]
        public Guid ProcedureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Procedure
        /// </summary>
        [ForeignKey("ProcedureId")]
        public Procedure? ProcedureId_Procedure { get; set; }

        /// <summary>
        /// Required field InvoiceStatus of the ProcedureOrderLine 
        /// </summary>
        [Required]
        public byte InvoiceStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProcedureOrderLine belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProcedureOrderLine 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProcedureOrderLine belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProcedureOrderLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the ProcedureOrderLine belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
    }
}