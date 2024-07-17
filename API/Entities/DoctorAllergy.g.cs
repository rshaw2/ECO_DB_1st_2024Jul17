using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorallergy entity with essential details
    /// </summary>
    public class DoctorAllergy
    {
        /// <summary>
        /// Initializes a new instance of the DoctorAllergy class.
        /// </summary>
        public DoctorAllergy()
        {
            Favourite = false;
            IsStandard = false;
            NoKnownAllergy = false;
            IsDeleted = false;
        }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorAllergy belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field Favourite of the DoctorAllergy 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Required field Sequence of the DoctorAllergy 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the DoctorAllergy 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DoctorAllergy 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DoctorAllergy 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorAllergy belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorAllergy 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorAllergy belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorAllergy 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Allergy of the DoctorAllergy 
        /// </summary>
        public Guid? Allergy { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorAllergy belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorAllergy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// NoKnownAllergy of the DoctorAllergy 
        /// </summary>
        public bool? NoKnownAllergy { get; set; }
        /// <summary>
        /// IsDeleted of the DoctorAllergy 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// AllergyTemplate of the DoctorAllergy 
        /// </summary>
        public Guid? AllergyTemplate { get; set; }
        /// <summary>
        /// Code of the DoctorAllergy 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DoctorAllergy 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the DoctorAllergy 
        /// </summary>
        public Guid? Active { get; set; }
    }
}