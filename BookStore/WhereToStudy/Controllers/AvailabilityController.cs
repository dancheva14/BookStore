using BookStore.ViewModels;
using BookStore.vModel;
using BookStore.vServices;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BookStore.Controllers
{
    public class AvailabilityController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();

        public UserService userService = new UserService();
        // GET: Availability
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var vm = new ItemViewModel();
                vm.Items = GetAllItems();
                return View(vm);
            }

        }

        [HttpPost]
        public ActionResult Index(ItemViewModel vm)
        {
            //var user = Session["USER"] as User;

            //user = userService.GetUser(user);
            //if (user != null)
            //{
            var items = addEditDeleteService.GetItemsByType(vm.Id);

            foreach (var item in items)
            {
                item.Image = addEditDeleteService.GetItemImage(item.Id);
                if (item.Image == null)
                    item.Image = addEditDeleteService.GetItemImage(0);

                item.Author = addEditDeleteService.GetAuthor(item.AuthorId);
                if (item.Author == null)
                {
                    item.Author = new Authors();
                    item.Author.Name = string.Empty;
                }
                item.Genre = addEditDeleteService.GetGenre(item.GenreId);
                if (item.Genre == null)
                {
                    item.Genre = new Genre();
                    item.Genre.Name = string.Empty;
                }
                item.Type = addEditDeleteService.GetType(item.TypeId);
                if (item.Type == null)
                {
                    item.Type = new Types();
                    item.Type.Name = string.Empty;
                }
            }
            vm.Items = items;
            return View(vm);
            //}
            //else
            //    return RedirectToAction("Login", "User");
        }

        public List<vModel.Item> GetAllItems()
        {
            var items = addEditDeleteService.GetItems();
            foreach (var item in items)
            {
                item.Image = addEditDeleteService.GetItemImage(item.Id);
                if (item.Image == null)
                    item.Image = addEditDeleteService.GetItemImage(0);

                item.Author = addEditDeleteService.GetAuthor(item.AuthorId);
                if (item.Author == null)
                {
                    item.Author = new Authors();
                    item.Author.Name = string.Empty;
                }
                item.Genre = addEditDeleteService.GetGenre(item.GenreId);
                if (item.Genre == null)
                {
                    item.Genre = new Genre();
                    item.Genre.Name = string.Empty;
                }
                item.Type = addEditDeleteService.GetType(item.TypeId);
                if (item.Type == null)
                {
                    item.Type = new Types();
                    item.Type.Name = string.Empty;
                }
            }
            return items;
        }

        [HttpPost]
        public ActionResult AddToCart(int itemId = 0)
        {
            List<vModel.Item> cart = new List<vModel.Item>();
            if ((List<vModel.Item>)Session["cart"] != null)
                cart = (List<vModel.Item>)Session["cart"];

            var item = addEditDeleteService.GetItem(itemId);
            cart.Add(item);
            Session["cart"] = cart;

            return RedirectToAction("Index", "Availability");
        }

        //install-package epplus
        public void ExportToXls()
        {
            List<ExcelExportViewModel> excelModel = new List<ExcelExportViewModel>();
            var data = GetAllItems();
            if (data.Count() > 0)
            {
                foreach (var item in data)
                {
                    var temp = new ExcelExportViewModel()
                    {
                        Name = item.Name,
                        AuthorName = item.Author.Name,
                        GenreName = item.Genre.Name,
                        PageCount = item.PageCount,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        SalePrice = item.SalePrice,
                        TypeName = item.Type.Name,
                        Year = item.Year
                    };
                    excelModel.Add(temp);
                }
            }

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            workSheet.Cells[1, 1].LoadFromCollection(excelModel, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Наличност.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            excel.Save();
        }

    }
}