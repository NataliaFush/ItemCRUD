using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ItemCRUD.Core.Entities;
using ItemCRUD.DAL;
using ItemCRUD.Core.Services;

namespace ItemCRUD.Pages.Item
{
    public class DeleteModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;
        protected readonly ItemService _itemService;
        public DeleteModel(ItemCRUD.DAL.AppDbContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService;
            ItemClient = new ItemClient();
        }

        [BindProperty]
        public ItemClient ItemClient { get; set; } 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemDB = await _context.Items.Include(x => x.Tax).FirstOrDefaultAsync(m => m.Id == id);
            var itemClient = _itemService.CastToItemsClient(itemDB);

            if (itemClient == null)
            {
                return NotFound();
            }
            else
            {
                ItemClient = itemClient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }
            var itemDB = await _context.Items.FindAsync(id);
            //var itemClient = _itemService.CastToItemsClient(itemDB);

            if (itemDB != null)
            {
                //ItemClient = itemClient;
                //itemDB = _itemService.CastToItemDB(ItemClient);
                _context.Items.Remove(itemDB);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
