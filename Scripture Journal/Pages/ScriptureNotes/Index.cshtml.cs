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
        [BindProperty(SupportsGet = true)]
        public string SelectedBook { get; set; }

        // For sorting results
        [BindProperty(SupportsGet = true)]
        public string SortedBy { get; set; }

        // For sorting results
        [BindProperty(SupportsGet = true)]
        public string ClearFilter { get; set; }

        public async Task OnGetAsync()
        {
            // Create a dropdown list to search by book
            IQueryable<string> bookQuery = from m in _context.ScriptureNote
                                           orderby m.ScriptureBook
                                           select m.ScriptureBook;

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());

            // Create an empty linq statement for use in the switch statements
            IQueryable<ScriptureNote> allItems;

            // If Title and Bookname are both empty
            if (string.IsNullOrEmpty(TitleSearchString) && string.IsNullOrEmpty(BookSearchString))  {


                switch (SortedBy)
                {
                    case "book":
                        allItems = from items in _context.ScriptureNote
                                       orderby items.ScriptureBook ascending
                                       select items;

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    case "date":
                        allItems = from items in _context.ScriptureNote
                                       orderby items.EntryDate ascending
                                       select items;

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    default:
                        allItems = from items in _context.ScriptureNote
                                   select items;

                        ScriptureNote = await allItems.ToListAsync();
                        break;
                }
            }

            // Filter by Note Title only
            if (!string.IsNullOrEmpty(TitleSearchString) && string.IsNullOrEmpty(BookSearchString))
            {

                switch (SortedBy)
                {
                    case "book":
                        allItems = from items in _context.ScriptureNote
                                   orderby items.ScriptureBook ascending
                                   select items;

                        allItems = allItems.Where(s => s.Title.Contains(TitleSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    case "date":
                        allItems = from items in _context.ScriptureNote
                                   orderby items.EntryDate ascending
                                   select items;

                        allItems = allItems.Where(s => s.Title.Contains(TitleSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    default:
                        allItems = from items in _context.ScriptureNote
                                   select items;

                        allItems = allItems.Where(s => s.Title.Contains(TitleSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;
                }
            }

            // Filter by Book name only
            if (string.IsNullOrEmpty(TitleSearchString) && !string.IsNullOrEmpty(BookSearchString))
            {

                switch (SortedBy)
                {
                    case "book":
                        allItems = from items in _context.ScriptureNote
                                   orderby items.ScriptureBook ascending
                                   select items;

                        allItems = allItems.Where(s => s.ScriptureBook.Contains(BookSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    case "date":
                        allItems = from items in _context.ScriptureNote
                                   orderby items.EntryDate ascending
                                   select items;

                        allItems = allItems.Where(s => s.ScriptureBook.Contains(BookSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    default:
                        allItems = from items in _context.ScriptureNote
                                   select items;

                        allItems = allItems.Where(s => s.ScriptureBook == BookSearchString);

                        ScriptureNote = await allItems.ToListAsync();
                        break;
                }
            }

            // Filter by Title and Book name
            if (!string.IsNullOrEmpty(TitleSearchString) && !string.IsNullOrEmpty(BookSearchString))
            {

                switch (SortedBy)
                {
                    case "book":
                        allItems = from items in _context.ScriptureNote
                                   orderby items.ScriptureBook ascending
                                   select items;

                        allItems = allItems.Where(s => s.Title.Contains(TitleSearchString) && s.ScriptureBook.Contains(BookSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    case "date":
                        allItems = from items in _context.ScriptureNote
                                   orderby items.EntryDate ascending
                                   select items;

                        allItems = allItems.Where(s => s.Title.Contains(TitleSearchString) && s.ScriptureBook.Contains(BookSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;

                    default:
                        allItems = from items in _context.ScriptureNote
                                   select items;

                        allItems = allItems.Where(s => s.Title.Contains(TitleSearchString) && s.ScriptureBook.Contains(BookSearchString));

                        ScriptureNote = await allItems.ToListAsync();
                        break;
                }
            }
         
        }

        
    }
}
