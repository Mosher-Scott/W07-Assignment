using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scripture_Journal.Models
{
    public class ScriptureNote
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Entry Date"), DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        // These hold the scripture book/chapter/verse info
        [Display(Name ="Book")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(20)]
        public string ScriptureBook { get; set; }

        [Display(Name = "Chapter")]
        public string ScriptureChapter { get; set; }

        [Display(Name = "Verse")]
        public string ScriptureVerse { get; set; }

        // Hold the journal entry
        [Display(Name = "Notes")]
        public string JournalEntry { get; set; }

    }
}
