using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorinvestigation entity with essential details
    /// </summary>
    public class DoctorInvestigation
    {
        /// <summary>
        /// Initializes a new instance of the DoctorInvestigation class.
        /// </summary>
        public DoctorInvestigation()
        {
            IsStandard = false;
            IsDeleted = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorInvestigation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorInvestigation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Investigation of the DoctorInvestigation 
        /// </summary>
        [Required]
        public Guid Investigation { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorInvestigation belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field EntityCode of the DoctorInvestigation 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DoctorInvestigation 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DoctorInvestigation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorInvestigation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorInvestigation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Sequence of the DoctorInvestigation 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// InvestigationProfile of the DoctorInvestigation 
        /// </summary>
        public bool? InvestigationProfile { get; set; }
        /// <summary>
        /// IsDeleted of the DoctorInvestigation 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorInvestigation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorInvestigation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the DoctorInvestigation 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DoctorInvestigation 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Favourite of the DoctorInvestigation 
        /// </summary>
        public bool? Favourite { get; set; }
    }
}