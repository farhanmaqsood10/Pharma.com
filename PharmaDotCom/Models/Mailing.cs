using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PharmaDotCom.Models
{
    public partial class Mailing
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
