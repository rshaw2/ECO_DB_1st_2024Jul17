using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenant entity with essential details
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Initializes a new instance of the Tenant class.
        /// </summary>
        public Tenant()
        {
            IsStandard = false;
            TenantType = new Guid("00000000-0000-0000-0000-000000000000");
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Required field TenantId of the Tenant 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Tenant 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("Id")]
        public Tenant? Id_Tenant { get; set; }

        /// <summary>
        /// Required field IsStandard of the Tenant 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field TenantType of the Tenant 
        /// </summary>
        [Required]
        public Guid TenantType { get; set; }
        /// <summary>
        /// Active of the Tenant 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// TemplateTenantId of the Tenant 
        /// </summary>
        public Guid? TemplateTenantId { get; set; }
        /// <summary>
        /// Foreign key referencing the TenantExtension to which the Tenant belongs 
        /// </summary>
        public Guid? ExtensionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TenantExtension
        /// </summary>
        [ForeignKey("ExtensionId")]
        public TenantExtension? ExtensionId_TenantExtension { get; set; }
        /// <summary>
        /// DigitalSignatureId of the Tenant 
        /// </summary>
        public Guid? DigitalSignatureId { get; set; }
        /// <summary>
        /// PackageSubscriptionId of the Tenant 
        /// </summary>
        public Guid? PackageSubscriptionId { get; set; }
        /// <summary>
        /// Trial of the Tenant 
        /// </summary>
        public bool? Trial { get; set; }
        /// <summary>
        /// Paid of the Tenant 
        /// </summary>
        public bool? Paid { get; set; }
        /// <summary>
        /// TestTenant of the Tenant 
        /// </summary>
        public bool? TestTenant { get; set; }
        /// <summary>
        /// IsOrganization of the Tenant 
        /// </summary>
        public bool? IsOrganization { get; set; }
        /// <summary>
        /// OrgNo of the Tenant 
        /// </summary>
        public string? OrgNo { get; set; }
        /// <summary>
        /// IsLegalEntity of the Tenant 
        /// </summary>
        public bool? IsLegalEntity { get; set; }
        /// <summary>
        /// ContactInformationId of the Tenant 
        /// </summary>
        public Guid? ContactInformationId { get; set; }
        /// <summary>
        /// ContactId of the Tenant 
        /// </summary>
        public Guid? ContactId { get; set; }
        /// <summary>
        /// OfficialAddressId of the Tenant 
        /// </summary>
        public Guid? OfficialAddressId { get; set; }
        /// <summary>
        /// InvoiceAddressId of the Tenant 
        /// </summary>
        public Guid? InvoiceAddressId { get; set; }
        /// <summary>
        /// PostalAddressId of the Tenant 
        /// </summary>
        public Guid? PostalAddressId { get; set; }
        /// <summary>
        /// Foreign key referencing the Image to which the Tenant belongs 
        /// </summary>
        public Guid? AvatarId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Image
        /// </summary>
        [ForeignKey("AvatarId")]
        public Image? AvatarId_Image { get; set; }
        /// <summary>
        /// PasswordPolicyId of the Tenant 
        /// </summary>
        public Guid? PasswordPolicyId { get; set; }
        /// <summary>
        /// IsSystemRoot of the Tenant 
        /// </summary>
        public bool? IsSystemRoot { get; set; }
        /// <summary>
        /// DefaultTimezoneId of the Tenant 
        /// </summary>
        public Guid? DefaultTimezoneId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Tenant belongs 
        /// </summary>
        public Guid? SuperAdminId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("SuperAdminId")]
        public User? SuperAdminId_User { get; set; }
        /// <summary>
        /// SubscriptionId of the Tenant 
        /// </summary>
        public Guid? SubscriptionId { get; set; }
        /// <summary>
        /// TenantServiceStatusId of the Tenant 
        /// </summary>
        public Guid? TenantServiceStatusId { get; set; }
        /// <summary>
        /// Foreign key referencing the Language to which the Tenant belongs 
        /// </summary>
        public Guid? PreferredLanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("PreferredLanguageId")]
        public Language? PreferredLanguageId_Language { get; set; }
        /// <summary>
        /// EntityCode of the Tenant 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// EntitySubTypeCode of the Tenant 
        /// </summary>
        public string? EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the Tenant 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Tenant 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Tenant belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Tenant 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Tenant belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the Tenant 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// ParentId of the Tenant 
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}