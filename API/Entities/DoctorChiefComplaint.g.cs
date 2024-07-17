using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorchiefcomplaint entity with essential details
    /// </summary>
    public class DoctorChiefComplaint
    {
        /// <summary>
        /// Initializes a new instance of the DoctorChiefComplaint class.
        /// </summary>
        public DoctorChiefComplaint()
        {
            IsStandard = false;
            IsAbnormal = false;
            IsDeleted = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field Favourite of the DoctorChiefComplaint 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Required field Sequence of the DoctorChiefComplaint 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the DoctorChiefComplaint 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DoctorChiefComplaint 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DoctorChiefComplaint 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorChiefComplaint 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorChiefComplaint 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// ChiefComplaint of the DoctorChiefComplaint 
        /// </summary>
        public Guid? ChiefComplaint { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorChiefComplaint belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorChiefComplaint 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// IsAbnormal of the DoctorChiefComplaint 
        /// </summary>
        public bool? IsAbnormal { get; set; }
        /// <summary>
        /// IsDeleted of the DoctorChiefComplaint 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Code of the DoctorChiefComplaint 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DoctorChiefComplaint 
        /// </summary>
        public string? Name { get; set; }
    }
}