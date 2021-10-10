using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PharmaDotCom.Models
{
    public partial class Career
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]

        public string EmailAddress { get; set; }
        [Required]

        public string CompanyName { get; set; }
        [Required]

        public string CurrentPost { get; set; }
        [Required]

        public string JobField { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Country { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string College { get; set; }
        
        public string ChooseFile { get; set; }
        [NotMapped]
        public IFormFile Resume { get; set; }
    }
}
