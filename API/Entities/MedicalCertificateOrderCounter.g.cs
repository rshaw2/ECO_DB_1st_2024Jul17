using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicalcertificateordercounter entity with essential details
    /// </summary>
    public class MedicalCertificateOrderCounter
    {
        /// <summary>
        /// Required field Prefix of the MedicalCertificateOrderCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the MedicalCertificateOrderCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the MedicalCertificateOrderCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the MedicalCertificateOrderCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the MedicalCertificateOrderCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the MedicalCertificateOrderCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the MedicalCertificateOrderCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}