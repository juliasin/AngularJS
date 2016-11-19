using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string PublishingOffice { get; set; }
        public Genre Genre { get; set; }
    }
}