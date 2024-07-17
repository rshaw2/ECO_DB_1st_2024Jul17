using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a email entity with essential details
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Initializes a new instance of the Email class.
        /// </summary>
        public Email()
        {
            IsStandard = false;
            Status = 1;
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Email belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Email 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Email 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Email 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Date of the Email 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Required field Recipient of the Email 
        /// </summary>
        [Required]
        public string Recipient { get; set; }

        /// <summary>
        /// Required field Sender of the Email 
        /// </summary>
        [Required]
        public string Sender { get; set; }

        /// <summary>
        /// Required field Subject of the Email 
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Required field Body of the Email 
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Email belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Email 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Email 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Email 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Email belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Email 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Status of the Email 
        /// </summary>
        public byte? Status { get; set; }
        /// <summary>
        /// Active of the Email 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Code of the Email 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Email 
        /// </summary>
        public string? Name { get; set; }
    }
}