using BookStore.ViewModels;
using BookStore.vModel;
using BookStore.vServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhereToStudy.Controllers
{
    public class ItemsReportController : Controller
    {
        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        // GET: ItemsReport
        public ActionResult Items()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var vm = new SaleReportViewModel();
                var date = DateTime.Now;
                var sales = addEditDeleteService.GetSalesByDate(date);
                vm.Items = new List<BookStore.vModel.Item>();

                foreach (var sale in sales)
                {
                    var item = addEditDeleteService.GetItem(sale.ItemId);
                    item.Quantity = sale.Quantity;
                    vm.Items.Add(item);
                }
                vm.Date = date;
                return View(vm);
            }
        }

        [HttpPost]
        public ViewResult Items(string sortOrder, DateTime? searchDate = null)
        {
            if (!searchDate.HasValue)
                searchDate = DateTime.Now;

            var vm = new SaleReportViewModel();
            var sales = addEditDeleteService.GetSalesByDate(searchDate);
            vm.Items = new List<BookStore.vModel.Item>();

            vm.Date = searchDate;
            if (sales.Count < 1)
            {
                return View(vm);
            }

            foreach (var sale in sales)
            {
                var item = addEditDeleteService.GetItem(sale.ItemId);
                item.Quantity = sale.Quantity;
                vm.Items.Add(item);
            }
            vm.Date = searchDate;
            return View(vm);
        }

        public ActionResult IndexName()
        {
            var items = addEditDeleteService.GetItems();
            return View("Items", items.OrderBy(m => m.Name));
        }

        public ActionResult IndexQuantity()
        {
            var items = addEditDeleteService.GetItems();
            return View("Items", items.OrderBy(m => m.Quantity));
        }



        public ActionResult ItemsSaleReport()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                    return View();
            }
        }

        [HttpPost]
        public ViewResult ItemsSaleReport(string sortOrder,int id =0)
        {
            var sortItem =  addEditDeleteService.GetItem(id);

            var vm = new SaleReportViewModel();
            var sales = addEditDeleteService.GetSalesByItem(sortItem);
            vm.Items = new List<BookStore.vModel.Item>();

            vm.Item = new BookStore.ViewModels.Item() { Id = sortItem.Id,Price = sortItem.Price,Quantity = sortItem.Quantity,SalePrice = sortItem.SalePrice,TypeId = sortItem.TypeId};
            if (sales.Count < 1)
            {
                return View(vm);
            }

            foreach (var sale in sales)
            {
                var item = addEditDeleteService.GetItem(sale.ItemId);
                item.Quantity = sale.Quantity;
                item.Date = sale.Date;
                vm.Items.Add(item);
            }
            return View(vm);
        }
    }
}