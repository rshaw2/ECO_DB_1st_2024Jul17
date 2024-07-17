using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a thirdpartyintegration entity with essential details
    /// </summary>
    public class ThirdPartyIntegration
    {
        /// <summary>
        /// Initializes a new instance of the ThirdPartyIntegration class.
        /// </summary>
        public ThirdPartyIntegration()
        {
            Active = false;
        }

        /// <summary>
        /// Primary key for the ThirdPartyIntegration 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Context of the ThirdPartyIntegration 
        /// </summary>
        [Required]
        public byte Context { get; set; }

        /// <summary>
        /// Required field Active of the ThirdPartyIntegration 
        /// </summary>
        [Required]
        public bool Active { get; set; }
        /// <summary>
        /// Name of the ThirdPartyIntegration 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// UserName of the ThirdPartyIntegration 
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// EndPoint of the ThirdPartyIntegration 
        /// </summary>
        public string? EndPoint { get; set; }
        /// <summary>
        /// Password of the ThirdPartyIntegration 
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Token of the ThirdPartyIntegration 
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// ExpiryDate of the ThirdPartyIntegration 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
    }
}