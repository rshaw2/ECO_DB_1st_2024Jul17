using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a referralorderline entity with essential details
    /// </summary>
    public class ReferralOrderLine
    {
        /// <summary>
        /// Primary key for the ReferralOrderLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ReferralOrderLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ReferralOrder to which the ReferralOrderLine belongs 
        /// </summary>
        [Required]
        public Guid ReferralOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ReferralOrder
        /// </summary>
        [ForeignKey("ReferralOrderId")]
        public ReferralOrder? ReferralOrderId_ReferralOrder { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitReferral to which the ReferralOrderLine belongs 
        /// </summary>
        [Required]
        public Guid VisitReferralId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitReferral
        /// </summary>
        [ForeignKey("VisitReferralId")]
        public VisitReferral? VisitReferralId_VisitReferral { get; set; }

        /// <summary>
        /// Foreign key referencing the Contact to which the ReferralOrderLine belongs 
        /// </summary>
        [Required]
        public Guid ReferredToId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ReferredToId")]
        public Contact? ReferredToId_Contact { get; set; }

        /// <summary>
        /// Required field InvoiceStatus of the ReferralOrderLine 
        /// </summary>
        [Required]
        public byte InvoiceStatus { get; set; }

        /// <summary>
        /// Required field OrderLineStatus of the ReferralOrderLine 
        /// </summary>
        [Required]
        public Guid OrderLineStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ReferralOrderLine belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ReferralOrderLine 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ReferralOrderLine belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ReferralOrderLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the ReferralOrderLine belongs 
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("InvoiceId")]
        public Invoice? InvoiceId_Invoice { get; set; }
    }
}