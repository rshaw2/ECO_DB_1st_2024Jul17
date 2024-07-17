using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a currency entity with essential details
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Initializes a new instance of the Currency class.
        /// </summary>
        public Currency()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Currency belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Currency 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Currency 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Currency 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Currency belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Currency 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Currency 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Currency 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Flagged of the Currency 
        /// </summary>
        public bool? Flagged { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Currency belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Currency 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Symbol of the Currency 
        /// </summary>
        public string? Symbol { get; set; }
        /// <summary>
        /// Code of the Currency 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Currency 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// DecimalPrecision of the Currency 
        /// </summary>
        public byte? DecimalPrecision { get; set; }
        /// <summary>
        /// DecimalVisualization of the Currency 
        /// </summary>
        public byte? DecimalVisualization { get; set; }
        /// <summary>
        /// IsoCode of the Currency 
        /// </summary>
        public string? IsoCode { get; set; }
        /// <summary>
        /// Active of the Currency 
        /// </summary>
        public Guid? Active { get; set; }
    }
}