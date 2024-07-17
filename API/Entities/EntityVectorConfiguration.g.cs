using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entityvectorconfiguration entity with essential details
    /// </summary>
    public class EntityVectorConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the EntityVectorConfiguration class.
        /// </summary>
        public EntityVectorConfiguration()
        {
            Enable = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EntityVectorConfiguration belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EntityVectorConfiguration 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityName of the EntityVectorConfiguration 
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Required field PropertyName of the EntityVectorConfiguration 
        /// </summary>
        [Required]
        public string PropertyName { get; set; }

        /// <summary>
        /// Required field Enable of the EntityVectorConfiguration 
        /// </summary>
        [Required]
        public bool Enable { get; set; }
        /// <summary>
        /// DataSyncStatus of the EntityVectorConfiguration 
        /// </summary>
        public byte? DataSyncStatus { get; set; }

        /// <summary>
        /// SyncDate of the EntityVectorConfiguration 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SyncDate { get; set; }
        /// <summary>
        /// SyncError of the EntityVectorConfiguration 
        /// </summary>
        public string? SyncError { get; set; }
        /// <summary>
        /// RetryCount of the EntityVectorConfiguration 
        /// </summary>
        public byte? RetryCount { get; set; }
    }
}