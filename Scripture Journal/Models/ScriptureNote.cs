using System;
using System.ComponentModel.DataAnnotations;

namespace Scripture_Journal.Models
{
    public class ScriptureNote
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        // These hold the scripture book/chapter/verse info
        public string ScriptureBook { get; set; }
        public string ScriptureChapter { get; set; }
        public string ScriptureVerse { get; set; }

        // Hold the journal entry
        public string JournalEntry { get; set; }

    }
}
