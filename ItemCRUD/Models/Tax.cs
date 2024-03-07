using System.ComponentModel.DataAnnotations;

namespace ItemCRUD.Models
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public double? IGST { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}
