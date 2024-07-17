using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a sms entity with essential details
    /// </summary>
    public class SMS
    {
        /// <summary>
        /// Initializes a new instance of the SMS class.
        /// </summary>
        public SMS()
        {
            IsStandard = false;
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the SMS belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SMS 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Date of the SMS 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Required field Recipient of the SMS 
        /// </summary>
        [Required]
        public string Recipient { get; set; }

        /// <summary>
        /// Required field Sender of the SMS 
        /// </summary>
        [Required]
        public string Sender { get; set; }

        /// <summary>
        /// Required field Message of the SMS 
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Required field CommunicationDirectionId of the SMS 
        /// </summary>
        [Required]
        public Guid CommunicationDirectionId { get; set; }

        /// <summary>
        /// Required field EntityCode of the SMS 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the SMS 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the SMS belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the SMS 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the SMS 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Active of the SMS 
        /// </summary>
        [Required]
        public Guid Active { get; set; }
        /// <summary>
        /// ParentId of the SMS 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the SMS 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the SMS 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the SMS belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the SMS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}