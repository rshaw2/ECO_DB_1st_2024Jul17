using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctordrugsystemtherapeuticclass entity with essential details
    /// </summary>
    public class DoctorDrugSystemTherapeuticClass
    {
        /// <summary>
        /// Initializes a new instance of the DoctorDrugSystemTherapeuticClass class.
        /// </summary>
        public DoctorDrugSystemTherapeuticClass()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorDrugSystemTherapeuticClass belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Favourite of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugSystemTherapeuticClass to which the DoctorDrugSystemTherapeuticClass belongs 
        /// </summary>
        [Required]
        public Guid DrugSystemTherapeuticClass { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSystemTherapeuticClass
        /// </summary>
        [ForeignKey("DrugSystemTherapeuticClass")]
        public DrugSystemTherapeuticClass? DrugSystemTherapeuticClass_DrugSystemTherapeuticClass { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorDrugSystemTherapeuticClass belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field EntityCode of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorDrugSystemTherapeuticClass belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DoctorDrugSystemTherapeuticClass belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the DoctorDrugSystemTherapeuticClass 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the DrugSystemOrganType to which the DoctorDrugSystemTherapeuticClass belongs 
        /// </summary>
        public Guid? DrugSystemOrganType { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSystemOrganType
        /// </summary>
        [ForeignKey("DrugSystemOrganType")]
        public DrugSystemOrganType? DrugSystemOrganType_DrugSystemOrganType { get; set; }
    }
}