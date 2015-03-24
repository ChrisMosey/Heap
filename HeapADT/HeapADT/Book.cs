/* book.cs
 * object for book information
 * 
 * revision history:
 *  chris mosey: 20.03.2015: created/finished
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapADT
{
    class Book : IComparable
    {
        private string author;
        private string title;
        private string publisher;
        private decimal price;

        public Book(string author, string title, string publisher, decimal price)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.price = price;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Book compareBook = obj as Book;
            if (compareBook == null)
            {
                throw new ArgumentException("Object is not a Book");
            }
            return CompareTo(compareBook);
        }

        public int CompareTo(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            return string.Compare(this.title, book.title);
        }
    }
}
