using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a emailtemplate entity with essential details
    /// </summary>
    public class EmailTemplate
    {
        /// <summary>
        /// Initializes a new instance of the EmailTemplate class.
        /// </summary>
        public EmailTemplate()
        {
            IsStandard = false;
            EntityObjectId = new Guid("00000000-0000-0000-0000-000000000000");
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EmailTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EmailTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the EmailTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the EmailTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Title of the EmailTemplate 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Required field Body of the EmailTemplate 
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the EmailTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the EmailTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the EmailTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the EmailTemplate 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the EmailTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the EmailTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the EmailTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the EmailTemplate 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ContextType of the EmailTemplate 
        /// </summary>
        public Guid? ContextType { get; set; }
        /// <summary>
        /// EntityObjectId of the EmailTemplate 
        /// </summary>
        public Guid? EntityObjectId { get; set; }
        /// <summary>
        /// Active of the EmailTemplate 
        /// </summary>
        public Guid? Active { get; set; }
    }
}