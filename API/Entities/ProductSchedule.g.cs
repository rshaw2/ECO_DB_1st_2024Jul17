using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productschedule entity with essential details
    /// </summary>
    public class ProductSchedule
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductSchedule belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProductSchedule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Title of the ProductSchedule 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Required field Sequence of the ProductSchedule 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }

        /// <summary>
        /// Required field After of the ProductSchedule 
        /// </summary>
        [Required]
        public byte After { get; set; }

        /// <summary>
        /// Required field DueDurationInDays of the ProductSchedule 
        /// </summary>
        [Required]
        public int DueDurationInDays { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProductSchedule belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProductSchedule 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductSchedule belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductSchedule to which the ProductSchedule belongs 
        /// </summary>
        public Guid? ReferenceProductScheduleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductSchedule
        /// </summary>
        [ForeignKey("ReferenceProductScheduleId")]
        public ProductSchedule? ReferenceProductScheduleId_ProductSchedule { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProductSchedule belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProductSchedule 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Description of the ProductSchedule 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Duration of the ProductSchedule 
        /// </summary>
        public byte? Duration { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the ProductSchedule belongs 
        /// </summary>
        public Guid? DurationUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("DurationUomId")]
        public UOM? DurationUomId_UOM { get; set; }
    }
}