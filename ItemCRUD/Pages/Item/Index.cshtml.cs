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
using ItemCRUD.Models;

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
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public int CurrentSort { get; set; }
        public IList<ItemClient> ItemClient { get;set; } 
        public PaginatedList<Models.Item> Items { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            IQueryable<Models.Item> itemIQ = _context.Items.Include(x => x.Tax);

            if (!String.IsNullOrEmpty(searchString) )
            {
                itemIQ = itemIQ.Where(i=>i.DisplayName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (sortOrder == "name_desc")
            {
                itemIQ = itemIQ.OrderByDescending(i => i.DisplayName);
            }
            else
            {
                itemIQ = itemIQ.OrderBy(i => i.DisplayName);
            }

            int pageSize = 10;
            Items = await PaginatedList<Models.Item>.CreateAsync(
                itemIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            if (Items.Any())
            {
                foreach (var item in Items)
                {
                    if (item != null)
                    {
                        ItemClient.Add(_itemService.CastToItemsClient(item));
                    }
                }
            }


            //if (_context.Items != null)
            //{
            //    var items = await _context.Items.Include(x => x.Tax).ToListAsync();
            //    if (items.Any())
            //    {
            //        foreach (var item in items)
            //        {
            //            if (item != null && item.Tax != null)
            //            {
            //                ItemClient.Add(_itemService.CastToItemsClient(item));
            //            }
            //        }
            //    }
            //}
        }


    }
}
