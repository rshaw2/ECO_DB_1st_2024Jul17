using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorinvestigationprofileitem entity with essential details
    /// </summary>
    public class DoctorInvestigationProfileItem
    {
        /// <summary>
        /// Initializes a new instance of the DoctorInvestigationProfileItem class.
        /// </summary>
        public DoctorInvestigationProfileItem()
        {
            IsStandard = false;
            IsDeleted = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorInvestigationProfileItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorInvestigationProfileItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorInvestigationProfileItem belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field Sequence of the DoctorInvestigationProfileItem 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the DoctorInvestigationProfileItem 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DoctorInvestigationProfileItem 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DoctorInvestigationProfileItem 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorInvestigationProfileItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorInvestigationProfileItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorInvestigationProfileItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorInvestigationProfileItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Investigation of the DoctorInvestigationProfileItem 
        /// </summary>
        public Guid? Investigation { get; set; }
        /// <summary>
        /// InvestigationProfile of the DoctorInvestigationProfileItem 
        /// </summary>
        public Guid? InvestigationProfile { get; set; }
        /// <summary>
        /// Code of the DoctorInvestigationProfileItem 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DoctorInvestigationProfileItem 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the DoctorInvestigationProfileItem 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// IsDeleted of the DoctorInvestigationProfileItem 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Favourite of the DoctorInvestigationProfileItem 
        /// </summary>
        public bool? Favourite { get; set; }
        /// <summary>
        /// DoctorInvestigation of the DoctorInvestigationProfileItem 
        /// </summary>
        public Guid? DoctorInvestigation { get; set; }
        /// <summary>
        /// DoctorInvestigationProfile of the DoctorInvestigationProfileItem 
        /// </summary>
        public Guid? DoctorInvestigationProfile { get; set; }
    }
}