using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a producttheraputicsubclassification entity with essential details
    /// </summary>
    public class ProductTheraputicSubClassification
    {
        /// <summary>
        /// Primary key for the ProductTheraputicSubClassification 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductTheraputicSubClassification belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProductTheraputicClassification to which the ProductTheraputicSubClassification belongs 
        /// </summary>
        [Required]
        public Guid ProductTheraputicClassificationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductTheraputicClassification
        /// </summary>
        [ForeignKey("ProductTheraputicClassificationId")]
        public ProductTheraputicClassification? ProductTheraputicClassificationId_ProductTheraputicClassification { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugSystemOrganType to which the ProductTheraputicSubClassification belongs 
        /// </summary>
        [Required]
        public Guid DrugSystemOrganTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSystemOrganType
        /// </summary>
        [ForeignKey("DrugSystemOrganTypeId")]
        public DrugSystemOrganType? DrugSystemOrganTypeId_DrugSystemOrganType { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugSystemTherapeuticClass to which the ProductTheraputicSubClassification belongs 
        /// </summary>
        [Required]
        public Guid DrugSystemTherapeuticClassId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSystemTherapeuticClass
        /// </summary>
        [ForeignKey("DrugSystemTherapeuticClassId")]
        public DrugSystemTherapeuticClass? DrugSystemTherapeuticClassId_DrugSystemTherapeuticClass { get; set; }
    }
}