using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HeapADT
{
    class HeapTest
    {
        Book book1;
        Book book2;
        Book book3;
        Book book4;
        Book book5;

        Heap<Book> heap;

        [SetUp]
        public void initialize()
        {
            book1 = new Book("Jim Carry", "The Lion, The Witch, and the Programmer", "Some Publisher", 99.99m);
            book2 = new Book("Calvin Smith", "The Hunger Cards", "Some Other Publisher", 3.99m);
            book3 = new Book("Cary Overwood", "Lines", "Publisher", 9.99m);
            book4 = new Book("Jake morris", "Steve Jobs s", "Apple", 104.99m);
            book5 = new Book("Peter Peter", "Doctor Doctor", "Pub", 99.99m);

            heap = new Heap<Book>(10);
        }

        [Test]
        public void testHeapSize()
        {
            Assert.Throws<IndexOutOfRangeException>(() => heap = new Heap<Book>(3000000));
        }

        [Test]
        public void testEntriesEmpty()
        {
            Assert.AreEqual(heap.Entries(), 0);
        }

        [Test]
        public void testEntriesFull()
        {
            heap.Insert(book1);
            heap.Insert(book2);
            heap.Insert(book3);

            Assert.AreEqual(heap.Entries(), 3);
        }

        [Test]
        public void testIsEmptyTrue()
        {
            Assert.IsTrue(heap.IsEmpty());
        }

        [Test]
        public void testIsEmptyFalse()
        {
            heap.Insert(book1);

            Assert.IsFalse(heap.IsEmpty());
        }

        [Test]
        public void testHeapOverflow()
        {
            heap = new Heap<Book>(2);
            heap.Insert(book1);
            heap.Insert(book2);

            Assert.Throws<ArgumentException>(() => heap.Insert(book3));
        }

        [Test]
        public void testNullHeapPull()
        {
            Assert.IsNull(heap.getMin());
        }

        [Test]
        public void testSingleInsert()
        {
            heap.Insert(book1);

            Assert.AreEqual(heap.getMin(), book1);
        }

        [Test]
        public void testMultipleInserts()
        {
            heap.Insert(book1);
            heap.Insert(book2);
            heap.Insert(book3);
            heap.Insert(book4);
            heap.Insert(book5);

            Assert.AreEqual(heap.getMin(), book5);
        }

        [Test]
        public void testRemove()
        {
            heap.Insert(book1);
            heap.getMin();
            Assert.IsNull(heap.getMin());
        }

        [Test]
        public void testMultipleRemove()
        {
            heap.Insert(book1);
            heap.Insert(book2);
            heap.Insert(book3);
            heap.Insert(book4);
            heap.Insert(book5);
            heap.getMin();
            heap.getMin();

            Assert.AreEqual(heap.getMin(), book1);
        }
    }
}
