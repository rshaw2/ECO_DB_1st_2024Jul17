using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a paymentmode entity with essential details
    /// </summary>
    public class PaymentMode
    {
        /// <summary>
        /// Initializes a new instance of the PaymentMode class.
        /// </summary>
        public PaymentMode()
        {
            Default = false;
            IsStandard = false;
            IsOnline = false;
        }

        /// <summary>
        /// Required field EntityCode of the PaymentMode 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PaymentMode 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PaymentMode belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PaymentMode 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the PaymentMode 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PaymentMode belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the PaymentMode 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Default of the PaymentMode 
        /// </summary>
        [Required]
        public bool Default { get; set; }

        /// <summary>
        /// Required field IsStandard of the PaymentMode 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Code of the PaymentMode 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PaymentMode belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PaymentMode 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Active of the PaymentMode 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// IsOnline of the PaymentMode 
        /// </summary>
        public bool? IsOnline { get; set; }
    }
}