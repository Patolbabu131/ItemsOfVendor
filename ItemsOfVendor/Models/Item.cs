using Microsoft.Net.Http.Headers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemsOfVendor.Models
{
    public class Item
    {
        [Key]
        public System.Guid IId { get; set; }
        public System.Guid VId { get; set; }
  
        [ForeignKey("VId")]
        [Required]
        [DisplayName("Item Name")]
        public string? IName { get; set; }
        [DisplayName("Item Code")]
        [Required]
        public decimal ICode { get; set; }
        [DisplayName("Item Price")]
        [Required]
        public decimal IPrice { get; set; }

    }
}
