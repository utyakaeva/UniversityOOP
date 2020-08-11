using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Variant6
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Book(string n, string a, int y)
        {
            Name = n;
            Author = a;
            Year = y;
                   
        }
    }
}