using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSpinOff.Models
{
    public interface IAmazonRepository
    {
        IQueryable<Book> Books { get; }
    }
}
