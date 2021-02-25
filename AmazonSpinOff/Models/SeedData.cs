using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSpinOff.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            AmazonDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AmazonDbContext>();

            //Make sure all migrations are pulled over
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                //Bring in list of books given to us by Professor Hilton
                context.Books.AddRange(
                    
                    //Make sure each field is filled, as they are required. BookId will be populated automatically
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Pages = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },

                    new Book
                    { 
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Pages = 240
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Pages = 400
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        Pages = 642
                    },

                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        AuthorFirst = "Harper",
                        AuthorLast = "Lee",
                        Publisher = "J.B. Lippincott & Co.",
                        ISBN = "978-2253115847",
                        Classification = "Fiction",
                        Category = "Southern Gothic Fiction",
                        Price = 15.99,
                        Pages = 281
                    },

                    new Book
                    {
                        Title = "Red Rising",
                        AuthorFirst = "Pierce",
                        AuthorLast = "Brown",
                        Publisher = "Del Rey Books",
                        ISBN = "978-0345539786",
                        Classification = "Fiction",
                        Category = "Science Fiction",
                        Price = 18.99,
                        Pages = 382
                    },

                    new Book
                    {
                        Title = "Percy Jackson & the Olympians: The Lightning Thief",
                        AuthorFirst = "Rick",
                        AuthorLast = "Riordan",
                        Publisher = "Puffin Books",
                        ISBN = "978-0141346809",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 7.99,
                        Pages = 377
                    }
                );

                //Make sure that the changes are saved!!
                context.SaveChanges();
            }
        }
    }
}
