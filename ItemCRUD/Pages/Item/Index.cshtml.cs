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
    public class IndexModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;
        protected readonly ItemService _itemService;
        public IndexModel(ItemCRUD.DAL.AppDbContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService;
            ItemClient = new List<ItemClient>();
        }

        public IList<ItemClient> ItemClient { get;set; } 

        public async Task OnGetAsync()
        {
            if (_context.Items != null)
            {
                var items = await _context.Items.Include(x => x.Tax).ToListAsync();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        if (item != null && item.Tax != null)
                        {
                            ItemClient.Add(_itemService.CastToItemsClient(item));
                        }
                    }
                }
            }
        }

        
    }
}
