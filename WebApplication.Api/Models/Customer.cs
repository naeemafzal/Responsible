using System.ComponentModel.DataAnnotations;

namespace WebApplication.Api.Models
{
    /// <summary>
    /// Represents a Customer Object
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique Id of the customer
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Firstname of the customer
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length of Customer's Firstname should be no more than 50 characters")]
        [MinLength(2, ErrorMessage = "Minimum length of Customer's Firstname should be atleast 2 characters")]
        public string Firstname { get; set; }
        /// <summary>
        /// Lastname of the customer
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length of Customer's Lastname should be no more than 50 characters")]
        [MinLength(2, ErrorMessage = "Minimum length of Customer's Lastname should be atleast 2 characters")]
        public string Lastname { get; set; }
        /// <summary>
        /// Fullname of the customer
        /// </summary>
        public string Fullname => $"{Firstname} {Lastname}";
    }
}