using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSpinOff.Models
{
    public class Cart
    {
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();

        //Add item to cart
        public virtual void AddItem(Book book, int qty)
        {
            //Compare BookId of Book with the one that was passed in
            LineItem line = LineItems
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            //Check whether we are adding item for first time or adding to quantity in cart
            if (line == null)
            {
                LineItems.Add(new LineItem
                {
                    Book = book,
                    Quantity = qty
                    
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //Remove item from cart
        public virtual void RemoveLine(Book book) =>
            LineItems.RemoveAll(x => x.Book.BookId == book.BookId);

        //Clear all
        public virtual void Clear() => LineItems.Clear();

        //Total sum of cart items
        //Change decimal to double (matching price variable)
        public double ComputeTotalSum() => LineItems.Sum(e => e.Book.Price * e.Quantity);

        //Declare properties
        public class LineItem
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
