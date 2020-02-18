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
    public class IndexModel : PageModel
    {
        private readonly Scripture_Journal.Data.Scripture_JournalContext _context;

        public IndexModel(Scripture_Journal.Data.Scripture_JournalContext context)
        {
            _context = context;
        }

        public IList<ScriptureNote> ScriptureNote { get;set; }

        public async Task OnGetAsync()
        {
            ScriptureNote = await _context.ScriptureNote.ToListAsync();
        }
    }
}
