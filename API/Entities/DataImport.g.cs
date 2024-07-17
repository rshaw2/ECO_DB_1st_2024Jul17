using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dataimport entity with essential details
    /// </summary>
    public class DataImport
    {
        /// <summary>
        /// Primary key for the DataImport 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DataImport belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field FileName of the DataImport 
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Required field ImportType of the DataImport 
        /// </summary>
        [Required]
        public byte ImportType { get; set; }

        /// <summary>
        /// Required field ValidData of the DataImport 
        /// </summary>
        [Required]
        public string ValidData { get; set; }

        /// <summary>
        /// Required field ImportProcessStatus of the DataImport 
        /// </summary>
        [Required]
        public byte ImportProcessStatus { get; set; }

        /// <summary>
        /// Required field ImportStart of the DataImport 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ImportStart { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DataImport belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DataImport 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DataImport belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DataImport 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// FailedReason of the DataImport 
        /// </summary>
        public string? FailedReason { get; set; }

        /// <summary>
        /// ImportEnd of the DataImport 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ImportEnd { get; set; }
        /// <summary>
        /// RecordsImported of the DataImport 
        /// </summary>
        public int? RecordsImported { get; set; }
        /// <summary>
        /// InvalidData of the DataImport 
        /// </summary>
        public string? InvalidData { get; set; }
    }
}