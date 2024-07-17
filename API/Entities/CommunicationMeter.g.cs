using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a communicationmeter entity with essential details
    /// </summary>
    public class CommunicationMeter
    {
        /// <summary>
        /// Initializes a new instance of the CommunicationMeter class.
        /// </summary>
        public CommunicationMeter()
        {
            Limit = 0;
            Consumed = 0;
        }

        /// <summary>
        /// Primary key for the CommunicationMeter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CommunicationMeter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field StartDate of the CommunicationMeter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required field EndDate of the CommunicationMeter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Required field CommunicationType of the CommunicationMeter 
        /// </summary>
        [Required]
        public byte CommunicationType { get; set; }

        /// <summary>
        /// Required field Limit of the CommunicationMeter 
        /// </summary>
        [Required]
        public int Limit { get; set; }

        /// <summary>
        /// Required field Consumed of the CommunicationMeter 
        /// </summary>
        [Required]
        public int Consumed { get; set; }

        /// <summary>
        /// Required field Active of the CommunicationMeter 
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}