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
    public class ClientReportController : Controller
    {
        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();

        ClientsViewModel list = new ClientsViewModel();
        // GET: ClientReport
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                int clientId = 0;
                var sales = new List<vModel.Sales>();
                var items = new List<vModel.Item>();
                if (clientId == 0)
                    sales = addEditDeleteService.GetSales();
                else
                    sales = addEditDeleteService.GetSalesByClientId(clientId);

                list.Client = addEditDeleteService.GetClient(clientId);
                foreach (var sale in sales)
                {
                    var item = addEditDeleteService.GetItem(sale.ItemId);
                    item.Quantity = sale.Quantity;
                    items.Add(item);

                }
                list.Items = items;

                return View(list);
            }
        }

        [HttpPost]
        public ViewResult Index(string sortOrder, int clientId = 0)
        {
            var items = new List<vModel.Item>();
            var sales = new List<vModel.Sales>();
            if (clientId == 0)
                sales = addEditDeleteService.GetSales();
            else
                sales = addEditDeleteService.GetSalesByClientId(clientId);
            foreach (var sale in sales)
            {
                items.Add(addEditDeleteService.GetItem(sale.ItemId));
            }

            list.Items = items;
            list.Client = addEditDeleteService.GetClient(clientId);
            return View(list);
        }
    }
}