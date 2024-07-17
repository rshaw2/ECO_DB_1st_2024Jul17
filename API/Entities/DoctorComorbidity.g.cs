using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorcomorbidity entity with essential details
    /// </summary>
    public class DoctorComorbidity
    {
        /// <summary>
        /// Initializes a new instance of the DoctorComorbidity class.
        /// </summary>
        public DoctorComorbidity()
        {
            IsStandard = false;
            NoKnownComorbidity = false;
            IsDeleted = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorComorbidity belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field Favourite of the DoctorComorbidity 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Required field Sequence of the DoctorComorbidity 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the DoctorComorbidity 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DoctorComorbidity 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DoctorComorbidity 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorComorbidity belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorComorbidity 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorComorbidity belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorComorbidity 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Comorbidity of the DoctorComorbidity 
        /// </summary>
        public Guid? Comorbidity { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorComorbidity belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorComorbidity 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// NoKnownComorbidity of the DoctorComorbidity 
        /// </summary>
        public bool? NoKnownComorbidity { get; set; }
        /// <summary>
        /// IsDeleted of the DoctorComorbidity 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Code of the DoctorComorbidity 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DoctorComorbidity 
        /// </summary>
        public string? Name { get; set; }
    }
}