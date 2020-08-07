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
    public class DeliveriesController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        // GET: Deliveries
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var items = new BookStore.ViewModels.Item()
                {
                    Id = 1,
                    Price = 0,
                    Quantity = 0,
                    SalePrice = 0,
                    TypeId = 1
                };
                var vm = new SaleViewModel()
                {
                    Items = new List<ViewModels.Item>()
                {
                    new ViewModels.Item()
                    {
                        Id = 1,
                Price = 0,
                Quantity = 0,
                SalePrice = 0,
                TypeId = 1
                    }
                }

                };

                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection formData)
        {
            var items = new List<vModel.Item>();
            var deliveries = new List<Delivery>();
            var realItems = new List<vModel.Item>();
            for (int i = 0; i < ((formData.Count - 1) / 2); i++)
            {

                int.TryParse(formData["Items[" + i + "].Quantity"], out int qtty);
                items.Add(new vModel.Item()
                {
                    Name = formData["Items[" + i + "].Name"],
                    Quantity = qtty
                });
            }
            var date = DateTime.Now;

            foreach (var i in items)
            {
               // var quantity = items.FirstOrDefault(m => m.Name == i.Name).Quantity;
                addEditDeleteService.InsertDelivery(new Delivery()
                {
                    ItemId = int.Parse(i.Name),
                    Date = date,
                    Quantity = i.Quantity
                });
                var item = addEditDeleteService.GetItem(int.Parse(i.Name));
                item.Quantity += i.Quantity;

                addEditDeleteService.UpdateItem(item);
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var phones = new List<Phone>();
            phones.Add(new Phone()
            {
                Number = "2465452",
                Type = Phone.Types.Business
            });
            phones = new List<Phone>();
            phones.Add(new Phone()
            {
                Number = "2323",
                Type = Phone.Types.Cell
            });
            var vm = new EmployeeViewModel();
            vm.Name = "Gosho";
            vm.Phones.AddRange(phones);


            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            string name = formData["Name"];
            string phones0Type = formData["Phones[0].Type"];
            string phones1Number = formData["Phones[0].Number"];
            return RedirectToAction("Index");
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
        public ActionResult ItemsDeliveries(int id = 0)
        {
            var items = new List<vModel.Item>();
            var deliveries = new List<Delivery>();
            var realItems = new List<vModel.Item>();
            //for (int i = 0; i < ((formData.Count - 1) / 2); i++)
            //{
            //    items.Add(new vModel.Item()
            //    {
            //        Name = formData["Items[" + i + "].Name"],
            //        Quantity = int.Parse(formData["Items[" + i + "].Quantity"])
            //    });
            //}
            var date = DateTime.Now;

            foreach (var i in items)
            {
                // var quantity = items.FirstOrDefault(m => m.Name == i.Name).Quantity;
                addEditDeleteService.InsertDelivery(new Delivery()
                {
                    ItemId = int.Parse(i.Name),
                    Date = date,
                    Quantity = i.Quantity
                });
                var item = addEditDeleteService.GetItem(int.Parse(i.Name));
                item.Quantity += i.Quantity;

                addEditDeleteService.UpdateItem(item);
            }

            return RedirectToAction("Index");
        }

    }
}