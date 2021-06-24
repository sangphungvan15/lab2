using Lap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lap2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
       
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("Html5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View(books);
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/Img/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual2", "Author Name Book 2", "/Content/Img/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual3", "Author Name Book 3", "/Content/Img/book3.jpg"));
            return View(books);
        }
            public string HelloTeacher( string university)
        {
            return "Hello Phùng Văn Sáng - University: " + university;
        }

        [HttpPost, ActionName("Editbook")]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/Img/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 2", "/Content/Img/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 2", "/Content/Img/book3.jpg"));

            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View(book);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual2", "Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual3", "Author Name Book 3", "/Content/images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Error Sava Data");
            }
            return View("ListBookModel", books);

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}