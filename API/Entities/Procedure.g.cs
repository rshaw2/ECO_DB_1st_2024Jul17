using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a procedure entity with essential details
    /// </summary>
    public class Procedure
    {
        /// <summary>
        /// Initializes a new instance of the Procedure class.
        /// </summary>
        public Procedure()
        {
            Flagged = false;
            Favourite = false;
            IsDeleted = false;
            FemaleOnly = false;
            NoKnownProcedure = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Procedure belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Procedure 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Flagged of the Procedure 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the Procedure 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Procedure 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Name of the Procedure 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Sequence of the Procedure 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Favourite of the Procedure 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Required field IsDeleted of the Procedure 
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Required field FemaleOnly of the Procedure 
        /// </summary>
        [Required]
        public bool FemaleOnly { get; set; }

        /// <summary>
        /// Required field NoKnownProcedure of the Procedure 
        /// </summary>
        [Required]
        public bool NoKnownProcedure { get; set; }

        /// <summary>
        /// Required field IsStandard of the Procedure 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Procedure belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Procedure 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Procedure belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Procedure 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the Procedure belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// Foreign key referencing the ProcedureTemplate to which the Procedure belongs 
        /// </summary>
        public Guid? ProcedureTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProcedureTemplate
        /// </summary>
        [ForeignKey("ProcedureTemplate")]
        public ProcedureTemplate? ProcedureTemplate_ProcedureTemplate { get; set; }
        /// <summary>
        /// Code of the Procedure 
        /// </summary>
        public string? Code { get; set; }
    }
}