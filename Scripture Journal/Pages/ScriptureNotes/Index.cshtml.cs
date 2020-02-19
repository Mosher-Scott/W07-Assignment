using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scripture_Journal.Data;
using Scripture_Journal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        // Search by title
        public string TitleSearchString { get; set; }

        // Search by Book
        [BindProperty(SupportsGet = true)]
        public string BookSearchString { get; set; }

        public SelectList Books { get; set; }
        public string SelectedBook { get; set; }

        // For sorting results
        [BindProperty(SupportsGet = true)]
        public string SortByBook { get; set; }

        // For sorting results
        [BindProperty(SupportsGet = true)]
        public string SortByDate { get; set; }

        public async Task OnGetAsync()
        {
            // This section will search by Book Name
            if (!string.IsNullOrEmpty(BookSearchString))
            {
                var BookNames = from b in _context.ScriptureNote
                                select b;

                BookNames = BookNames.Where(s => s.ScriptureBook.Contains(BookSearchString));

                ScriptureNote = await BookNames.ToListAsync();
            }

            // This section will search by the journal entry title
            if (!string.IsNullOrEmpty(TitleSearchString))
            {
                var entryTitles = from b in _context.ScriptureNote
                                  select b;

                entryTitles = entryTitles.Where(s => s.Title.Contains(TitleSearchString));

                ScriptureNote = await entryTitles.ToListAsync();
            }


            // TODO: Add logic so if there is a search string, filter by the string & sort results

            // Sort results by book
            if (SortByBook == "true")
            {
                var allItems = from notes in _context.ScriptureNote
                               orderby notes.ScriptureBook ascending
                               select notes;

                ScriptureNote = await allItems.ToListAsync();
            }

            // Sort results by Date
            if (SortByDate == "true")
            {
                var allItems = from notes in _context.ScriptureNote
                               orderby notes.EntryDate ascending
                               select notes;

                ScriptureNote = await allItems.ToListAsync();
            }


            // If both strings are empty, display everything
            else if(string.IsNullOrEmpty(BookSearchString) && string.IsNullOrEmpty(TitleSearchString))
            {
                // Original
                ScriptureNote = await _context.ScriptureNote.ToListAsync();
            }

           
        }
    }
}
