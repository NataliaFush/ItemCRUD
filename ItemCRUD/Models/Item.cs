using ItemCRUD.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ItemCRUD.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(10)]
        public int? Code { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public ItemType? Type { get; set; }
        [Required]
        [StringLength(100)]
        public string? DisplayName { get; set; }
        public ItemDepartment? Department { get; set; }
        [Required]
        [Range(100000, 999999)]
        public int? HSN { get; set; }
        public SmallestUnit? BuyingUnit { get; set; }
        public double? BuyingUnitPrice { get; set; }
        public SmallestUnit? SellingUnit { get; set; }
        public double? SellingUnitPrice { get; set; }
        [ForeignKey(nameof(Tax))]
        public int? TaxId { get; set; }
        public Tax? Tax { get; set; }

    }
}
