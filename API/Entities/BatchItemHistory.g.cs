using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a batchitemhistory entity with essential details
    /// </summary>
    public class BatchItemHistory
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the BatchItemHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the BatchItemHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field BatchItemId of the BatchItemHistory 
        /// </summary>
        [Required]
        public Guid BatchItemId { get; set; }

        /// <summary>
        /// Required field Status of the BatchItemHistory 
        /// </summary>
        [Required]
        public byte Status { get; set; }
        /// <summary>
        /// FailedReason of the BatchItemHistory 
        /// </summary>
        public string? FailedReason { get; set; }

        /// <summary>
        /// RunTime of the BatchItemHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RunTime { get; set; }
        /// <summary>
        /// EntityCode of the BatchItemHistory 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// ReferenceId of the BatchItemHistory 
        /// </summary>
        public Guid? ReferenceId { get; set; }
    }
}