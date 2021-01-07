using Lab6WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab6WCF
{
    public class Service1 : IService1
    {
        private ApplicationContext context = new ApplicationContext();

        public void AddBook(Book book)
        {
            context.GetBooks.Add(book);
            context.SaveChanges();
        }

        public bool deleteBook(string isbn)
        {
            var model = context.GetBooks.Find(isbn);
            context.GetBooks.Remove(model);
            var deleted = context.SaveChanges();
            return deleted > 0;
        }

        public List<Book> findAll()
        {
            return context.GetBooks.ToList();
        }

        public Book findOne(string isbn)
        {
            return context.GetBooks.SingleOrDefault(m => m.ISBN.Equals(isbn));
        }

        public void updatedBook(Book book)
        {
            context.GetBooks.Update(book);
            context.SaveChanges();
        }
    }
}
