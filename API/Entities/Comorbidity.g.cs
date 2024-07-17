using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a comorbidity entity with essential details
    /// </summary>
    public class Comorbidity
    {
        /// <summary>
        /// Initializes a new instance of the Comorbidity class.
        /// </summary>
        public Comorbidity()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Required field Sequence of the Comorbidity 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the Comorbidity 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Comorbidity 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the Comorbidity 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Comorbidity belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Comorbidity 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Comorbidity belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Comorbidity 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// NoKnownComorbidity of the Comorbidity 
        /// </summary>
        public bool? NoKnownComorbidity { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Comorbidity belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Comorbidity 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Comorbidity 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Comorbidity 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Favourite of the Comorbidity 
        /// </summary>
        public bool? Favourite { get; set; }
        /// <summary>
        /// IsDeleted of the Comorbidity 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Foreign key referencing the ComorbidityTemplate to which the Comorbidity belongs 
        /// </summary>
        public Guid? ComorbidityTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated ComorbidityTemplate
        /// </summary>
        [ForeignKey("ComorbidityTemplate")]
        public ComorbidityTemplate? ComorbidityTemplate_ComorbidityTemplate { get; set; }
    }
}