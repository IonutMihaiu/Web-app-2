﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mihaiu_Ionut_Lab2.Data;
using Mihaiu_Ionut_Lab2.Models;

using Mihaiu_Ionut_Lab2.Models;
using Mihaiu_Ionut_Lab2.Models;

namespace Mihaiu_Ionut_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Mihaiu_Ionut_Lab2.Data.Mihaiu_Ionut_Lab2Context _context;
        public CreateModel(Mihaiu_Ionut_Lab2.Data.Mihaiu_Ionut_Lab2Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
           
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });

            
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID","PublisherName");

           
            return Page();
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Book>(
            newBook,
            "Book",
            i => i.Title, i => i.AuthorID,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}

