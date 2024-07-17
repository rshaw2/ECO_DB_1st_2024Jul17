using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a language entity with essential details
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Initializes a new instance of the Language class.
        /// </summary>
        public Language()
        {
            ShortDateFormat = new Guid("00000000-0000-0000-0000-000000000000");
            LongDateFormat = new Guid("00000000-0000-0000-0000-000000000000");
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Language belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Language 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Language 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Language 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Language belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Language 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Language belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Language 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// TranslationSupport of the Language 
        /// </summary>
        public bool? TranslationSupport { get; set; }
        /// <summary>
        /// Code of the Language 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Language 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ParentId of the Language 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// IsoCode of the Language 
        /// </summary>
        public string? IsoCode { get; set; }
        /// <summary>
        /// ShortDateFormat of the Language 
        /// </summary>
        public Guid? ShortDateFormat { get; set; }
        /// <summary>
        /// LongDateFormat of the Language 
        /// </summary>
        public Guid? LongDateFormat { get; set; }
        /// <summary>
        /// ShortDateTimeFormat of the Language 
        /// </summary>
        public Guid? ShortDateTimeFormat { get; set; }
        /// <summary>
        /// LongDateTimeFormat of the Language 
        /// </summary>
        public Guid? LongDateTimeFormat { get; set; }
        /// <summary>
        /// Active of the Language 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// IsStandard of the Language 
        /// </summary>
        public bool? IsStandard { get; set; }
        /// <summary>
        /// Flagged of the Language 
        /// </summary>
        public bool? Flagged { get; set; }
    }
}