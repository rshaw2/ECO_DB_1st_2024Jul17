using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a timezone entity with essential details
    /// </summary>
    public class Timezone
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the Timezone belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Timezone 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Timezone 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Timezone 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field CreatedBy of the Timezone 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Timezone 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Timezone 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Flagged of the Timezone 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }
        /// <summary>
        /// GmtDeviation of the Timezone 
        /// </summary>
        public decimal? GmtDeviation { get; set; }
        /// <summary>
        /// SummerTimeStart of the Timezone 
        /// </summary>
        public string? SummerTimeStart { get; set; }
        /// <summary>
        /// WinterTimeStart of the Timezone 
        /// </summary>
        public string? WinterTimeStart { get; set; }
        /// <summary>
        /// TzDbName of the Timezone 
        /// </summary>
        public string? TzDbName { get; set; }
        /// <summary>
        /// Active of the Timezone 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// ParentId of the Timezone 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the Timezone 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Timezone 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// UpdatedBy of the Timezone 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Timezone 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}