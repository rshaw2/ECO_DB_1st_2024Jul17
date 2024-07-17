using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a pricelistversioncomponent entity with essential details
    /// </summary>
    public class PriceListVersionComponent
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PriceListVersionComponent belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PriceListVersionComponent 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PriceList to which the PriceListVersionComponent belongs 
        /// </summary>
        [Required]
        public Guid PriceListId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceList
        /// </summary>
        [ForeignKey("PriceListId")]
        public PriceList? PriceListId_PriceList { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the PriceListVersionComponent belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the PriceListVersionComponent belongs 
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }
        /// <summary>
        /// MembershipId of the PriceListVersionComponent 
        /// </summary>
        public Guid? MembershipId { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the PriceListVersionComponent belongs 
        /// </summary>
        public Guid? SupplierId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("SupplierId")]
        public Contact? SupplierId_Contact { get; set; }
        /// <summary>
        /// Foreign key referencing the PriceListVersion to which the PriceListVersionComponent belongs 
        /// </summary>
        public Guid? PriceListVersionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceListVersion
        /// </summary>
        [ForeignKey("PriceListVersionId")]
        public PriceListVersion? PriceListVersionId_PriceListVersion { get; set; }
    }
}