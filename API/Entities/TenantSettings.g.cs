using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantsettings entity with essential details
    /// </summary>
    public class TenantSettings
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the TenantSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Frequency of the TenantSettings 
        /// </summary>
        [Required]
        public int Frequency { get; set; }

        /// <summary>
        /// Required field UOM of the TenantSettings 
        /// </summary>
        [Required]
        public Guid UOM { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the TenantSettings belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TenantSettings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the TenantSettings belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the TenantSettings 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// WhatsAppAppointmentTemplate of the TenantSettings 
        /// </summary>
        public byte? WhatsAppAppointmentTemplate { get; set; }
        /// <summary>
        /// ShortcutLimit of the TenantSettings 
        /// </summary>
        public int? ShortcutLimit { get; set; }
    }
}