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
    public class DetailsModel : PageModel
    {
        private readonly Scripture_Journal.Data.Scripture_JournalContext _context;

        public DetailsModel(Scripture_Journal.Data.Scripture_JournalContext context)
        {
            _context = context;
        }

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
    }
}
