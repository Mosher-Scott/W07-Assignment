using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scripture_Journal.Data;
using Scripture_Journal.Models;

namespace Scripture_Journal
{
    public class DeleteModel : PageModel
    {
        private readonly Scripture_Journal.Data.Scripture_JournalContext _context;

        public DeleteModel(Scripture_Journal.Data.Scripture_JournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScriptureNote ScriptureNote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureNote = await _context.ScriptureNote.FirstOrDefaultAsync(m => m.ID == id);

            if (ScriptureNote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureNote = await _context.ScriptureNote.FindAsync(id);

            if (ScriptureNote != null)
            {
                _context.ScriptureNote.Remove(ScriptureNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
