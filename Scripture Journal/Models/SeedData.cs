using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scripture_Journal.Data;


namespace Scripture_Journal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Scripture_JournalContext(serviceProvider.GetRequiredService<DbContextOptions<Scripture_JournalContext>>()))
            {
                // Look for records in the DB
                if (context.ScriptureNote.Any())
                {
                    return;
                }

                context.ScriptureNote.AddRange(

                    new ScriptureNote
                    {
                        Title = "Note 1",
                        EntryDate = DateTime.Parse("2020-2-12"),
                        ScriptureBook = "1 Ne",
                        ScriptureChapter = "1",
                        ScriptureVerse = "1",
                        JournalEntry = "This is an entry into the journal"
                    },

                    new ScriptureNote
                    {
                        Title = "Humility",
                        EntryDate = DateTime.Parse("2020-1-12"),
                        ScriptureBook = "2 Ne",
                        ScriptureChapter = "2",
                        ScriptureVerse = "12",
                        JournalEntry = "This is why we should pay attention"
                    },

                    new ScriptureNote
                    {
                        Title = "Darkness",
                        EntryDate = DateTime.Parse("2020-1-23"),
                        ScriptureBook = "Alma",
                        ScriptureChapter = "32",
                        ScriptureVerse = "1",
                        JournalEntry = "Example of not learning what we should learn"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
