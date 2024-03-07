using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ItemCRUD.Core.Entities;
using ItemCRUD.Core.Services;
using ItemCRUD.DAL;
using System.Xml.Serialization;
using ItemCRUD.Models;

namespace ItemCRUD.Pages.Item
{
    public class CreateModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;
        protected readonly ItemService _itemService;
        public CreateModel(ItemCRUD.DAL.AppDbContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemClient ItemClient { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Items == null || ItemClient == null)
            {
                return Page();
            }
            var itemDB = new Models.Item();
            Random random = new Random();
            ItemClient.Id = Guid.NewGuid();
            ItemClient.Code = random.Next(10000000, 99999999);
            itemDB = _itemService.CastToItemDB(ItemClient);
            _context.Items.Add(itemDB);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

       
    }
}
