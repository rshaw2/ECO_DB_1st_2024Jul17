using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a smsgatewaytype entity with essential details
    /// </summary>
    public class SmsGatewayType
    {
        /// <summary>
        /// Initializes a new instance of the SmsGatewayType class.
        /// </summary>
        public SmsGatewayType()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the SmsGatewayType belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SmsGatewayType 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field IsStandard of the SmsGatewayType 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Flagged of the SmsGatewayType 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }
        /// <summary>
        /// Active of the SmsGatewayType 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// EntityCode of the SmsGatewayType 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// EntitySubTypeCode of the SmsGatewayType 
        /// </summary>
        public string? EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the SmsGatewayType 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the SmsGatewayType 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the SmsGatewayType belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the SmsGatewayType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the SmsGatewayType belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the SmsGatewayType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// ParentId of the SmsGatewayType 
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}