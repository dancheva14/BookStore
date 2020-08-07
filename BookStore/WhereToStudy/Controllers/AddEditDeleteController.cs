using BookStore.ViewModels;
using BookStore.vModel;
using BookStore.vServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AddEditDeleteController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        #region Type
        [HttpGet]
        public ActionResult AddType()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddType(Types type)
        {
            addEditDeleteService.InsertType(type);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                {
                    if (addEditDeleteService.GetItems().Any(m => m.TypeId == id))
                        ViewData["Message"] = "Съществуват артикули от този тип. Типът не може да бъде изтрит.";
                    else
                        addEditDeleteService.DeleteType(id);
                }

                return View(addEditDeleteService.GetTypes());
            }
        }
        
        [HttpGet]
        public ActionResult EditType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var type = addEditDeleteService.GetType(id);
                return View(type);
            }
        }

        [HttpPost]
        public ActionResult EditType(Types type)
        {
            addEditDeleteService.UpdateType(type);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Client
        
        [HttpGet]
        public ActionResult AddClient()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            addEditDeleteService.InsertClient(client);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteClient(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetSalesByClientId(id).Any())
                        ViewData["Message"] = string.Format("Съществуват продажби към клиент {0}. Клиентът не може да бъде изтрит.", addEditDeleteService.GetClient(id).Name);
                    else
                        addEditDeleteService.DeleteClient(id);

                return View(addEditDeleteService.GetClients());
            }
        }
        
        [HttpGet]
        public ActionResult EditClient(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetClient(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            addEditDeleteService.UpdateClient(client);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Author
        
        [HttpGet]
        public ActionResult AddAuthor()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Authors author)
        {
            addEditDeleteService.InsertAuthor(author);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteAuthor(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetItems().Any(m => m.AuthorId == id))
                        ViewData["Message"] = string.Format("Съществуват артикули с автор/издател {0}. Артикулът не може да бъде изтрит.", addEditDeleteService.GetAuthor(id).Name);
                    else
                        addEditDeleteService.DeleteAuthor(id);

                return View(addEditDeleteService.GetAuthors());
            }
        }
        
        [HttpGet]
        public ActionResult EditAuthor(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetAuthor(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditAuthor(Authors author)
        {
            addEditDeleteService.UpdateAuthor(author);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Genre
        
        [HttpGet]
        public ActionResult AddGenre()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddGenre(Genre genre)
        {
            addEditDeleteService.InsertGenre(genre);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteGenre(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetItems().Any(m => m.GenreId == id))
                        ViewData["Message"] = string.Format("Съществуват артикули от жанр {0}. Жанрът не може да бъде изтрит.", addEditDeleteService.GetGenre(id).Name);
                    else
                        addEditDeleteService.DeleteGenre(id);

                return View(addEditDeleteService.GetGenres());
            }
        }
        
        [HttpGet]
        public ActionResult EditGenre(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetGenre(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditGenre(Genre genre)
        {
            addEditDeleteService.UpdateGenre(genre);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Book
        
        [HttpGet]
        public ActionResult AddBook()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddBook(vModel.Item item)
        {
            addEditDeleteService.InsertItem(item);
            var itemId = addEditDeleteService.GetItemByName(item.Name).Id;
            addEditDeleteService.UploadImageToDB(Session["file"] as HttpPostedFileBase, itemId);
            return RedirectToAction("Index", "Availability");
        }
        
        [HttpGet]
        public ActionResult DeleteBook(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetSales().Any(m => m.ItemId == id))
                        ViewData["Message"] = string.Format("Съществуват продажби на артикул {0}. Артикулът не може да бъде изтрит.", addEditDeleteService.GetItem(id).Name);
                    else
                        addEditDeleteService.DeleteItem(id);

                return View(addEditDeleteService.GetItems());
            }
        }
        
        [HttpGet]
        public ActionResult EditItem(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var book = addEditDeleteService.GetItem(id);
                return View(book);
            }
        }

        [HttpPost]
        public ActionResult EditItem(vModel.Item item)
        {
            addEditDeleteService.UpdateItem(item);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void UploadImage(IEnumerable<HttpPostedFileBase> files)
        {
            Session["file"] = files.FirstOrDefault(); ;
        }
    }
}