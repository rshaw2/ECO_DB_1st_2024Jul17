using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationorderline entity with essential details
    /// </summary>
    public class InvestigationOrderLine
    {
        /// <summary>
        /// Primary key for the InvestigationOrderLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationOrderLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InvestigationOrder to which the InvestigationOrderLine belongs 
        /// </summary>
        [Required]
        public Guid InvestigationOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvestigationOrder
        /// </summary>
        [ForeignKey("InvestigationOrderId")]
        public InvestigationOrder? InvestigationOrderId_InvestigationOrder { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitInvestigation to which the InvestigationOrderLine belongs 
        /// </summary>
        [Required]
        public Guid VisitInvestigationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitInvestigation
        /// </summary>
        [ForeignKey("VisitInvestigationId")]
        public VisitInvestigation? VisitInvestigationId_VisitInvestigation { get; set; }

        /// <summary>
        /// Required field InvoiceStatus of the InvestigationOrderLine 
        /// </summary>
        [Required]
        public byte InvoiceStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationOrderLine belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationOrderLine 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationOrderLine belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvestigationOrderLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the InvestigationOrderLine belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
    }
}