using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AmazonSpinOff.Models;
using AmazonSpinOff.Infrastructure;

namespace AmazonSpinOff.Pages
{
    public class BuyModel : PageModel
    {
        //Bring in repository
        private IAmazonRepository repository;

        //Set repository & cart (constructor)
        public BuyModel (IAmazonRepository repo, Cart cartservice)
        {
            repository = repo;
            Cart = cartservice;
        }

        //Properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //Get Method
        public void OnGet(string returnUrl)
        {
            //If null, set to "/"
            ReturnUrl = returnUrl ?? "/";
            //Get cart from session or create new cart
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //Post Method
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            //Go look at repository at first or default of where the Id's match
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            //Get cart or create new cart
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            //Add item
            Cart.AddItem(book, 1);

            //Set cart
            HttpContext.Session.SetJson("cart", Cart);

            //Return page
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //Post Method (Remove)
        public IActionResult OnPostRemove (long bookId, string returnUrl)
        {
            //Get cart
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            //Remove item from cart
            Cart.RemoveLine(Cart.LineItems.First(cl =>
                cl.Book.BookId == bookId).Book);

            //Set cart
            HttpContext.Session.SetJson("cart", Cart);

            //Return page
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
