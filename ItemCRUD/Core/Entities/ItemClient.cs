using ItemCRUD.Core.Enums;
using ItemCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ItemCRUD.Core.Entities
{
    public class ItemClient
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [Display(Name = "Code")]
        public int? Code { get; set; }
        [Display(Name = "Item Type", Prompt = "Select Item Type")]
        public ItemType? Type { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Display Name", Prompt = "Display Name")]
        public string? DisplayName { get; set; }
        [Display(Name = "Department", Prompt = "Select Department")]
        public ItemDepartment? Department { get; set; }
        [Required]
        [Display(Name = "HSN", Prompt = "HSN")]
        [Range(100000, 999999)]
        public int? HSN { get; set; }
        [Display(Name = "Smaller Buying Unit", Prompt = "Select Buying Unit")]
        public SmallestUnit? BuyingUnit { get; set; }
        [Display(Name = "Buying Unit Price", Prompt = "Select Buying Price")]
        public double? BuyingUnitPrice { get; set; }
        [Display(Name = "Smaller Selling Unit", Prompt = "Select Selling Unit")]
        public SmallestUnit? SellingUnit { get; set; }
        [Display(Name = "Selling Unit Price", Prompt = "Select Selling Price")]
        public double? SellingUnitPrice { get; set; }
        [Required]
        [Display(Name = "CGST", Prompt = "CGST")]
        public double? CGST { get; set; }
        [Display(Name = "SGST", Prompt = "SGST")]
        public double? SGST { get; set; }
        [Display(Name = "IGST", Prompt = "IGST")]
        public double? IGST { get; set; }
    }
}
