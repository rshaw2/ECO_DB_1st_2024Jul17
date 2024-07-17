using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a chiefcomplaint entity with essential details
    /// </summary>
    public class ChiefComplaint
    {
        /// <summary>
        /// Initializes a new instance of the ChiefComplaint class.
        /// </summary>
        public ChiefComplaint()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ChiefComplaint 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the ChiefComplaint 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the ChiefComplaint 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ChiefComplaint 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the ChiefComplaint 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ChiefComplaint 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ChiefComplaint belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ChiefComplaint 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the ChiefComplaint 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ChiefComplaint 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Favourite of the ChiefComplaint 
        /// </summary>
        public bool? Favourite { get; set; }
        /// <summary>
        /// IsDeleted of the ChiefComplaint 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// IsAbnormal of the ChiefComplaint 
        /// </summary>
        public bool? IsAbnormal { get; set; }
        /// <summary>
        /// Foreign key referencing the ChiefComplaintTemplate to which the ChiefComplaint belongs 
        /// </summary>
        public Guid? ChiefComplaintTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated ChiefComplaintTemplate
        /// </summary>
        [ForeignKey("ChiefComplaintTemplate")]
        public ChiefComplaintTemplate? ChiefComplaintTemplate_ChiefComplaintTemplate { get; set; }
    }
}