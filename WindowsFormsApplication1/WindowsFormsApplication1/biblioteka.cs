using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Variant6
{
    class biblioteka
    {
        private static int id;
        private Dictionary <int, Book> books;

        public biblioteka()
        {
            books = new Dictionary<int, Book>();
        }
        
        public DataTable GetAllBooks()
        {
            DataTable dt = new DataTable("Домашняя библиотека");
            dt.Columns.Add("Номер", typeof(int));
            dt.Columns.Add("Название", typeof(string));
            dt.Columns.Add("Автор", typeof(string));
            dt.Columns.Add("Год выпуска", typeof(int));
            //dt.Columns.Add("Жанр", typeof(string));
            foreach (var a in books)
            {
                dt.Rows.Add(a.Key, a.Value.Name, a.Value.Author, a.Value.Year);
            }
            return dt;
        }
       
        public bool ContainsBook(Book b)
        {
            bool aa = books.Any(a => ((a.Value.Name == b.Name) &&
                    (a.Value.Author == b.Author) &&
                    (a.Value.Year == b.Year)));
            return aa;
        }
                             
        public void AddBook(Book b)
        {
            if (!ContainsBook(b))
                books[id++] = b;
            else throw new Exception("Такая книга уже есть");
        }
        
        public Book this[int n]
        {
            get
            {
                if (books.ContainsKey(n))
                    return books[n];
                else
                    throw new IndexOutOfRangeException("Книга с номером " +
                        n + " не суще-ствует");
            }
        }
        //удаление
        public bool RemoveBook(int key)
        {
            if (books.ContainsKey(key))
            {
                books.Remove(key);
                return true;
            }
            else
                throw new IndexOutOfRangeException("Книга с номером " +
                   key + " не существует");
        }
        //редактирование
        public void UpdBook(int id, Book b)
        {

            if (!ContainsBook(b))

                books[id] = b;
            else throw new Exception("Такая книга уже есть");
        }

    }
}
