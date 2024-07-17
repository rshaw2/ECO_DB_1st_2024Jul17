using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationprofileitem entity with essential details
    /// </summary>
    public class InvestigationProfileItem
    {
        /// <summary>
        /// Initializes a new instance of the InvestigationProfileItem class.
        /// </summary>
        public InvestigationProfileItem()
        {
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationProfileItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the InvestigationProfileItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the InvestigationProfileItem 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the InvestigationProfileItem 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the InvestigationProfileItem 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the InvestigationProfileItem 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationProfileItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationProfileItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the InvestigationProfileItem 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the InvestigationProfileItem 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationProfileItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvestigationProfileItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the InvestigationProfileItem 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InvestigationProfileItem 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the InvestigationProfileItem 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Investigation of the InvestigationProfileItem 
        /// </summary>
        public Guid? Investigation { get; set; }
        /// <summary>
        /// InvestigationProfile of the InvestigationProfileItem 
        /// </summary>
        public Guid? InvestigationProfile { get; set; }
    }
}