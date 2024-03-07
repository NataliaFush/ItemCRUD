using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ItemCRUD.DAL;
using ItemCRUD.Models;

namespace ItemCRUD.Pages.ItemPage
{
    public class IndexModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;

        public IndexModel(ItemCRUD.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Items != null)
            {
                Item = await _context.Items.ToListAsync();
            }
        }
    }
}
