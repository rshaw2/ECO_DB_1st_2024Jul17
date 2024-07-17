using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a druglist entity with essential details
    /// </summary>
    public class DrugList
    {
        /// <summary>
        /// Initializes a new instance of the DrugList class.
        /// </summary>
        public DrugList()
        {
            Brand = false;
            Generic = false;
            Common = false;
        }

        /// <summary>
        /// Primary key for the DrugList 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugList belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the DrugList 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Brand of the DrugList 
        /// </summary>
        [Required]
        public bool Brand { get; set; }

        /// <summary>
        /// Required field Generic of the DrugList 
        /// </summary>
        [Required]
        public bool Generic { get; set; }

        /// <summary>
        /// Required field FileUrl of the DrugList 
        /// </summary>
        [Required]
        public string FileUrl { get; set; }

        /// <summary>
        /// Required field FileName of the DrugList 
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Required field Common of the DrugList 
        /// </summary>
        [Required]
        public bool Common { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DrugList belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DrugList 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DrugList belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DrugList 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// MimeType of the DrugList 
        /// </summary>
        public string? MimeType { get; set; }
    }
}