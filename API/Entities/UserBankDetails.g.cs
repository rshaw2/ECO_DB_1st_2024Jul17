using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a userbankdetails entity with essential details
    /// </summary>
    public class UserBankDetails
    {
        /// <summary>
        /// Initializes a new instance of the UserBankDetails class.
        /// </summary>
        public UserBankDetails()
        {
            RazorPayAccountTncAccepted = false;
        }

        /// <summary>
        /// Primary key for the UserBankDetails 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UserBankDetails belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserBankDetails belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Required field BankName of the UserBankDetails 
        /// </summary>
        [Required]
        public string BankName { get; set; }

        /// <summary>
        /// Required field IFSCCode of the UserBankDetails 
        /// </summary>
        [Required]
        public string IFSCCode { get; set; }

        /// <summary>
        /// Required field AccountNumber of the UserBankDetails 
        /// </summary>
        [Required]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Required field BeneficiaryName of the UserBankDetails 
        /// </summary>
        [Required]
        public string BeneficiaryName { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserBankDetails belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the UserBankDetails 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the UserBankDetails belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the UserBankDetails 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// RazorPayAccountStatus of the UserBankDetails 
        /// </summary>
        public string? RazorPayAccountStatus { get; set; }
        /// <summary>
        /// RazorPayAccountId of the UserBankDetails 
        /// </summary>
        public string? RazorPayAccountId { get; set; }

        /// <summary>
        /// RazorPayAccountActivatedAt of the UserBankDetails 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RazorPayAccountActivatedAt { get; set; }
        /// <summary>
        /// RazorPayAccountDestinationId of the UserBankDetails 
        /// </summary>
        public string? RazorPayAccountDestinationId { get; set; }
        /// <summary>
        /// RazorPayAccountTncAccepted of the UserBankDetails 
        /// </summary>
        public bool? RazorPayAccountTncAccepted { get; set; }
        /// <summary>
        /// RazorPayBankDetailVerificationError of the UserBankDetails 
        /// </summary>
        public string? RazorPayBankDetailVerificationError { get; set; }
    }
}