using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigation entity with essential details
    /// </summary>
    public class Investigation
    {
        /// <summary>
        /// Initializes a new instance of the Investigation class.
        /// </summary>
        public Investigation()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Investigation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Investigation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the Investigation 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the Investigation 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Investigation 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the Investigation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Flagged of the Investigation 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Investigation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Investigation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Investigation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Investigation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// IsDeleted of the Investigation 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the Investigation belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// InvestigationType of the Investigation 
        /// </summary>
        public byte? InvestigationType { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the Investigation belongs 
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }
        /// <summary>
        /// Code of the Investigation 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Investigation 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// InvestigationProfile of the Investigation 
        /// </summary>
        public bool? InvestigationProfile { get; set; }
        /// <summary>
        /// Foreign key referencing the InvestigationTemplate to which the Investigation belongs 
        /// </summary>
        public Guid? InvestigationTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvestigationTemplate
        /// </summary>
        [ForeignKey("InvestigationTemplate")]
        public InvestigationTemplate? InvestigationTemplate_InvestigationTemplate { get; set; }
    }
}