using Microsoft.Net.Http.Headers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ItemsOfVendor.Models
{
    public class Vendor
    {
        [Key]
        public System.Guid VId { get; set; }
        [DisplayName("Name")]
        [Required]
        
        public string VName { get; set; }
        [DisplayName("Vendor code")]
        [Required]
        public decimal VCode { get; set; }
        [DisplayName("Contace Name")]
        [Required]
        public string CName { get; set; }
        [DisplayName("Contact Number")]
        [Required]
        public decimal VContact_No { get; set; }
    }
}
