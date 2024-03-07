using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ItemCRUD.Core.Entities;
using ItemCRUD.DAL;
using ItemCRUD.Core.Services;

namespace ItemCRUD.Pages.Item
{
    public class EditModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;
        protected readonly ItemService _itemService;
        public EditModel(ItemCRUD.DAL.AppDbContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        [BindProperty]
        public ItemClient ItemClient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ItemClient == null)
            {
                return NotFound();
            }

            var itemDB =  await _context.Items.Include(x => x.Tax).FirstOrDefaultAsync(m => m.Id == id);
            if (itemDB == null)
            {
                return NotFound();
            }
            
            ItemClient = _itemService.CastToItemsClient(itemDB);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var itemDB = _itemService.CastToItemDB(ItemClient);
            _context.Attach(itemDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemClientExists(ItemClient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemClientExists(Guid id)
        {
          return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
