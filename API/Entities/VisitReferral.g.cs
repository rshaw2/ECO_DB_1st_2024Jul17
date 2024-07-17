using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitreferral entity with essential details
    /// </summary>
    public class VisitReferral
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitReferral belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitReferral 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitReferral belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitReferral belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitReferral 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitReferral belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitReferral 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ProductId of the VisitReferral 
        /// </summary>
        public Guid? ProductId { get; set; }
        /// <summary>
        /// ProductName of the VisitReferral 
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// Foreign key referencing the InvoiceLine to which the VisitReferral belongs 
        /// </summary>
        public Guid? InvoiceLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvoiceLine
        /// </summary>
        [ForeignKey("InvoiceLineId")]
        public InvoiceLine? InvoiceLineId_InvoiceLine { get; set; }
        /// <summary>
        /// ReferredToId of the VisitReferral 
        /// </summary>
        public Guid? ReferredToId { get; set; }
        /// <summary>
        /// ReferralName of the VisitReferral 
        /// </summary>
        public string? ReferralName { get; set; }
        /// <summary>
        /// Notes of the VisitReferral 
        /// </summary>
        public string? Notes { get; set; }
    }
}