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
    public class DetailsModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;
        protected readonly ItemService _itemService;
        public DetailsModel(ItemCRUD.DAL.AppDbContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService;
            ItemClient = new ItemClient();
        }

        public ItemClient ItemClient { get; set; } 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemDB = await _context.Items.Include(x => x.Tax).FirstOrDefaultAsync(m => m.Id == id);
            if (itemDB == null)
            {
                return NotFound();
            }
            else 
            {
                ItemClient = _itemService.CastToItemsClient(itemDB);
            }
            return Page();
        }
    }
}
