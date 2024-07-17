using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a countrycode entity with essential details
    /// </summary>
    public class CountryCode
    {
        /// <summary>
        /// Initializes a new instance of the CountryCode class.
        /// </summary>
        public CountryCode()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Required field IsStandard of the CountryCode 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Enabled of the CountryCode 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CountryCode belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CountryCode 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the CountryCode 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CountryCode belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }
        /// <summary>
        /// Code of the CountryCode 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the CountryCode 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CountryCode belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CountryCode 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// FlagUrl of the CountryCode 
        /// </summary>
        public string? FlagUrl { get; set; }
        /// <summary>
        /// AlphaTwoCode of the CountryCode 
        /// </summary>
        public string? AlphaTwoCode { get; set; }
        /// <summary>
        /// Foreign key referencing the Country to which the CountryCode belongs 
        /// </summary>
        public Guid? CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }
    }
}