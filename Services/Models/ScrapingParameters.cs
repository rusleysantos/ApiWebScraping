using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class ScrapingParameters
    {
        [Required]
        public string Url { get; set; }
    }
}
