using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a mobileverification entity with essential details
    /// </summary>
    public class MobileVerification
    {
        /// <summary>
        /// Primary key for the MobileVerification 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field MobileNo of the MobileVerification 
        /// </summary>
        [Required]
        public string MobileNo { get; set; }

        /// <summary>
        /// Required field Otp of the MobileVerification 
        /// </summary>
        [Required]
        public int Otp { get; set; }
    }
}