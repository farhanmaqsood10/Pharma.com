using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PharmaDotCom.Models
{
    public partial class Quote
    {
        public int Id { get; set; }
        [Required]

        public string FullName { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string CompanyName { get; set; }
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

        public string Comments { get; set; }
    }
}
