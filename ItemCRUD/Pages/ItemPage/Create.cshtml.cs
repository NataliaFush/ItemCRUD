using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ItemCRUD.DAL;
using ItemCRUD.Models;

namespace ItemCRUD.Pages.ItemPage
{
    public class CreateModel : PageModel
    {
        private readonly ItemCRUD.DAL.AppDbContext _context;

        public CreateModel(ItemCRUD.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Random random = new Random();
            Item.Id = Guid.NewGuid();
            Item.Code = random.Next(10000000, 99999999);
            if (!ModelState.IsValid || _context.Items == null || Item == null)
            {
                return Page();
            }
            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
