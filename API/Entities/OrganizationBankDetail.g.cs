using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organizationbankdetail entity with essential details
    /// </summary>
    public class OrganizationBankDetail
    {
        /// <summary>
        /// Primary key for the OrganizationBankDetail 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the OrganizationBankDetail belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field GSTINUINNumber of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string GSTINUINNumber { get; set; }

        /// <summary>
        /// Required field CINNumber of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string CINNumber { get; set; }

        /// <summary>
        /// Required field BankName of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string BankName { get; set; }

        /// <summary>
        /// Required field AccountNumber of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Required field Branch of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string Branch { get; set; }

        /// <summary>
        /// Required field Ifscode of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string Ifscode { get; set; }

        /// <summary>
        /// Required field PanNumber of the OrganizationBankDetail 
        /// </summary>
        [Required]
        public string PanNumber { get; set; }
        /// <summary>
        /// HSNCode of the OrganizationBankDetail 
        /// </summary>
        public int? HSNCode { get; set; }
    }
}