using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visittypechecklist entity with essential details
    /// </summary>
    public class VisitTypeCheckList
    {
        /// <summary>
        /// Initializes a new instance of the VisitTypeCheckList class.
        /// </summary>
        public VisitTypeCheckList()
        {
            Enabled = false;
        }

        /// <summary>
        /// Primary key for the VisitTypeCheckList 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitTypeCheckList belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitType to which the VisitTypeCheckList belongs 
        /// </summary>
        [Required]
        public Guid VisitTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitType
        /// </summary>
        [ForeignKey("VisitTypeId")]
        public VisitType? VisitTypeId_VisitType { get; set; }

        /// <summary>
        /// Required field Name of the VisitTypeCheckList 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Enabled of the VisitTypeCheckList 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Required field CheckListType of the VisitTypeCheckList 
        /// </summary>
        [Required]
        public byte CheckListType { get; set; }
        /// <summary>
        /// Mandatory of the VisitTypeCheckList 
        /// </summary>
        public bool? Mandatory { get; set; }
    }
}