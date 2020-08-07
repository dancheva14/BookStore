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
    public class DeliveriesReportController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();

        DeliveriesViewModel list = new DeliveriesViewModel();

        // GET: DeliveriesReport
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var date = DateTime.Now;
                var deliveries = addEditDeleteService.GetDeliverys(date);
                List<BookStore.vModel.Item> items = new List<BookStore.vModel.Item>();

                if (deliveries == null || deliveries.Count() < 1)
                {
                    var del = new DeliveriesViewModel();
                    del.Date = date;
                    return View(del);
                }

                foreach (var del in deliveries)
                {
                    var item = addEditDeleteService.GetItem(del.ItemId);
                    item.Quantity = del.Quantity;
                    items.Add(item);
                }

                list.Date = deliveries.FirstOrDefault().Date;
                list.Items = items;

                return View(list);
            }
        }

        [HttpPost]
        public ViewResult Index(string sortOrder, DateTime? searchDate = null)
        {
            if (!searchDate.HasValue)
                searchDate = DateTime.Now;

            var deliveries = addEditDeleteService.GetDeliverys(searchDate);
            List<BookStore.vModel.Item> items = new List<BookStore.vModel.Item>();

            list.Date = searchDate;
            if (deliveries.Count < 1)
            {
                return View(list);
            }

            foreach (var del in deliveries)
            {
                var item = addEditDeleteService.GetItem(del.ItemId);
                item.Quantity = del.Quantity;
                items.Add(item);
            }
            list.Items = items;

            return View(list);
        }

        public ActionResult IndexName()
        {
            var date = DateTime.Now;
            var deliveries = addEditDeleteService.GetDeliverys(date);
            List<BookStore.vModel.Item> items = new List<BookStore.vModel.Item>();

            foreach (var del in deliveries)
            {
                var item = addEditDeleteService.GetItem(del.ItemId);
                item.Quantity = del.Quantity;
                items.Add(item);
            }

            list.Date = deliveries.FirstOrDefault().Date;
            list.Items = items.OrderBy(m => m.Name).ToList();

            var result = list;
            return View("Items", result);
        }

        public ActionResult IndexQuantity()
        {
            var date = DateTime.Now;
            var deliveries = addEditDeleteService.GetDeliverys(date);
            List<BookStore.vModel.Item> items = new List<BookStore.vModel.Item>();

            foreach (var del in deliveries)
            {
                var item = addEditDeleteService.GetItem(del.ItemId);
                item.Quantity = del.Quantity;
                items.Add(item);
            }

            list.Date = deliveries.FirstOrDefault().Date;
            list.Items = items.OrderBy(m => m.Quantity).ToList();

            var result = list;
            return View("Items", result);
        }



        public ActionResult ItemsDeliveries()
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
        public ViewResult ItemsDeliveries(string sortOrder, int id = 0)
        {
            var sortitem = addEditDeleteService.GetItem(id);

            var deliveries = addEditDeleteService.GetDeliverysByItem(sortitem.Id);
            List<BookStore.vModel.Item> items = new List<BookStore.vModel.Item>();
            
            if (deliveries.Count < 1)
            {
                return View(list);
            }

            foreach (var del in deliveries)
            {
                var item = addEditDeleteService.GetItem(del.ItemId);
                item.Quantity = del.Quantity;
                item.Date = del.Date;
                items.Add(item);
            }
            list.Items = items;

            return View(list);
        }
    }
}