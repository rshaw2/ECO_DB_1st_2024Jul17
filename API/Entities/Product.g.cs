using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a product entity with essential details
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            Default = false;
            IsStandard = false;
            IsOnline = false;
            ReOrderLevel = 0;
            ReOrderQuantity = 0;
            MultiVisit = false;
            PaymentPlan = false;
        }

        /// <summary>
        /// Required field EntityCode of the Product 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Product 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Product belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Product 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the Product 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Product belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the Product 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Default of the Product 
        /// </summary>
        [Required]
        public bool Default { get; set; }

        /// <summary>
        /// Required field IsStandard of the Product 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Code of the Product 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Price of the Product 
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Product belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Product 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// IsOnline of the Product 
        /// </summary>
        public bool? IsOnline { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductCategory to which the Product belongs 
        /// </summary>
        public Guid? ProductCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductCategory
        /// </summary>
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategoryId_ProductCategory { get; set; }
        /// <summary>
        /// ProductType of the Product 
        /// </summary>
        public byte? ProductType { get; set; }
        /// <summary>
        /// Inventoried of the Product 
        /// </summary>
        public bool? Inventoried { get; set; }
        /// <summary>
        /// HSNCode of the Product 
        /// </summary>
        public string? HSNCode { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductManufacture to which the Product belongs 
        /// </summary>
        public Guid? ProductManufactureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductManufacture
        /// </summary>
        [ForeignKey("ProductManufactureId")]
        public ProductManufacture? ProductManufactureId_ProductManufacture { get; set; }
        /// <summary>
        /// Description of the Product 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductFormulation to which the Product belongs 
        /// </summary>
        public Guid? ProductFormulationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductFormulation
        /// </summary>
        [ForeignKey("ProductFormulationId")]
        public ProductFormulation? ProductFormulationId_ProductFormulation { get; set; }
        /// <summary>
        /// ScheduleDrug of the Product 
        /// </summary>
        public byte? ScheduleDrug { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductClassification to which the Product belongs 
        /// </summary>
        public Guid? ProductClassificationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductClassification
        /// </summary>
        [ForeignKey("ProductClassificationId")]
        public ProductClassification? ProductClassificationId_ProductClassification { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the Product belongs 
        /// </summary>
        public Guid? LowestUOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("LowestUOM")]
        public UOM? LowestUOM_UOM { get; set; }
        /// <summary>
        /// BaseType of the Product 
        /// </summary>
        public byte? BaseType { get; set; }
        /// <summary>
        /// Status of the Product 
        /// </summary>
        public bool? Status { get; set; }
        /// <summary>
        /// ReOrderLevel of the Product 
        /// </summary>
        public int? ReOrderLevel { get; set; }
        /// <summary>
        /// ReOrderQuantity of the Product 
        /// </summary>
        public int? ReOrderQuantity { get; set; }
        /// <summary>
        /// Foreign key referencing the GstSettings to which the Product belongs 
        /// </summary>
        public Guid? GstCategory { get; set; }

        /// <summary>
        /// Navigation property representing the associated GstSettings
        /// </summary>
        [ForeignKey("GstCategory")]
        public GstSettings? GstCategory_GstSettings { get; set; }
        /// <summary>
        /// GSTPercentage of the Product 
        /// </summary>
        public int? GSTPercentage { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the Product belongs 
        /// </summary>
        public Guid? ReOrderQuantityUom { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ReOrderQuantityUom")]
        public ProductUom? ReOrderQuantityUom_ProductUom { get; set; }
        /// <summary>
        /// Foreign key referencing the DrugSchedule to which the Product belongs 
        /// </summary>
        public Guid? DrugScheduleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugSchedule
        /// </summary>
        [ForeignKey("DrugScheduleId")]
        public DrugSchedule? DrugScheduleId_DrugSchedule { get; set; }
        /// <summary>
        /// Foreign key referencing the Formulation to which the Product belongs 
        /// </summary>
        public Guid? FormulationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Formulation
        /// </summary>
        [ForeignKey("FormulationId")]
        public Formulation? FormulationId_Formulation { get; set; }
        /// <summary>
        /// ComponentType of the Product 
        /// </summary>
        public byte? ComponentType { get; set; }
        /// <summary>
        /// Foreign key referencing the Investigation to which the Product belongs 
        /// </summary>
        public Guid? InvestigationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Investigation
        /// </summary>
        [ForeignKey("InvestigationId")]
        public Investigation? InvestigationId_Investigation { get; set; }
        /// <summary>
        /// Foreign key referencing the Procedure to which the Product belongs 
        /// </summary>
        public Guid? ProcedureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Procedure
        /// </summary>
        [ForeignKey("ProcedureId")]
        public Procedure? ProcedureId_Procedure { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the Product belongs 
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }
        /// <summary>
        /// MedicationId of the Product 
        /// </summary>
        public Guid? MedicationId { get; set; }
        /// <summary>
        /// Import of the Product 
        /// </summary>
        public bool? Import { get; set; }

        /// <summary>
        /// SellingStartDate of the Product 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SellingStartDate { get; set; }

        /// <summary>
        /// SellingEndDate of the Product 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SellingEndDate { get; set; }
        /// <summary>
        /// MultiVisit of the Product 
        /// </summary>
        public bool? MultiVisit { get; set; }
        /// <summary>
        /// PaymentPlan of the Product 
        /// </summary>
        public bool? PaymentPlan { get; set; }
        /// <summary>
        /// Foreign key referencing the Gender to which the Product belongs 
        /// </summary>
        public Guid? GenderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Gender
        /// </summary>
        [ForeignKey("GenderId")]
        public Gender? GenderId_Gender { get; set; }
        /// <summary>
        /// FromAge of the Product 
        /// </summary>
        public byte? FromAge { get; set; }
        /// <summary>
        /// ToAge of the Product 
        /// </summary>
        public byte? ToAge { get; set; }
        /// <summary>
        /// PackageExpiryDuration of the Product 
        /// </summary>
        public byte? PackageExpiryDuration { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the Product belongs 
        /// </summary>
        public Guid? PackageExpiryDurationUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("PackageExpiryDurationUomId")]
        public UOM? PackageExpiryDurationUomId_UOM { get; set; }
        /// <summary>
        /// PackageExpiryDurationInDays of the Product 
        /// </summary>
        public short? PackageExpiryDurationInDays { get; set; }
    }
}