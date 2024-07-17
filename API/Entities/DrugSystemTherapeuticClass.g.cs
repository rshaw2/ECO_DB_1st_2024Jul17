using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drugsystemtherapeuticclass entity with essential details
    /// </summary>
    public class DrugSystemTherapeuticClass
    {
        /// <summary>
        /// Initializes a new instance of the DrugSystemTherapeuticClass class.
        /// </summary>
        public DrugSystemTherapeuticClass()
        {
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugSystemTherapeuticClass belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DrugSystemTherapeuticClass 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the DrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the DrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the DrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DrugSystemTherapeuticClass belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the DrugSystemTherapeuticClass 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the DrugSystemTherapeuticClass 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DrugSystemTherapeuticClass belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DrugSystemTherapeuticClass 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the DrugSystemTherapeuticClass 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DrugSystemTherapeuticClass 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the DrugSystemTherapeuticClass 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the DrugSystemOrganType to which the DrugSystemTherapeuticClass belongs 
        /// </summary>
        public Guid? DrugSystemOrganType { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSystemOrganType
        /// </summary>
        [ForeignKey("DrugSystemOrganType")]
        public DrugSystemOrganType? DrugSystemOrganType_DrugSystemOrganType { get; set; }
    }
}