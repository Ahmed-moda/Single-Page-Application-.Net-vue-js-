using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;
using Web.ViewModel;

namespace Web.Services
{
    public class BookService : IBookService
    {
        private ApplicationDbContext db ;

        public BookService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> Create(BookVm book)
        {
            try
            {
                var newbook = new Book
                {
                    Title = book.Title,
                    AuthorId = book.AuthorId
                };
                await db.Books.AddAsync(newbook);
                await db.SaveChangesAsync();
                return true;
            }

            catch
            {
                return false;
            }
            

        }

        public  bool Delete(int? id)
        {
            if (id != null)
            {
                try
                {

                    var book = db.Books.FirstOrDefault(x => x.Id == id);
                    if (book != null)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;

                }

                catch
                {
                    return false;
                }
                
            }
            else
                return false;
        }

        public List<BookVm> Getall()
        {
            var booklist = db.Books.ToList();
            return booklist != null ? db.Books.Select(x => new BookVm
            {
                id=x.Id,
                Title = x.Title,
                Author = x.Author.Name
            }).ToList() : null;
        }

        public List<BookVm> authors()
        {
            var autholist = db.Authors.ToList();
            if(autholist == null || autholist.Count == 0)
            {
                List<Author> items = new List<Author>()
                    {
                        new Author{Name="Ahmed"},
                        new Author{Name="Karim" },
                        new Author{Name="Mazen" }
                    };
                db.Authors.AddRange(items);
                db.SaveChanges();
                var list= db.Authors.Select(x => new BookVm
                {
                    AuthorId = x.Id,
                    Author = x.Name
                }).ToList();
                return list;
            }
            else
            {
                return autholist.Select(x => new BookVm
                {
                    AuthorId = x.Id,
                    Author = x.Name
                }).ToList();
            }
            
        }
    }
}
