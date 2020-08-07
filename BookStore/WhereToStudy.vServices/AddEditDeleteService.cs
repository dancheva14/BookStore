using BookStore.vModel;
using BookStore.vRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.vServices
{
    public class AddEditDeleteService
    {
        public AddEditDeleteRepository addEditDeleteRepository;

        public AddEditDeleteService()
        {
            addEditDeleteRepository = new AddEditDeleteRepository();
        }

        #region Type
        public Types GetType(int id)
        {
            return addEditDeleteRepository.GetType(id);
        }

        public List<Types> GetTypes()
        {
            return addEditDeleteRepository.GetTypes();
        }

        public Types InsertType(Types type)
        {
            return addEditDeleteRepository.InsertType(type);
        }
        public Types UpdateType(Types type)
        {
            return addEditDeleteRepository.UpdateType(type);
        }

        public Types DeleteType(int id)
        {
            return addEditDeleteRepository.DeleteType(id);
        }
        #endregion

        #region Item
        public Item GetItem(int id)
        {
            return addEditDeleteRepository.GetItem(id);
        }

        public List<Item> GetItems()
        {
            return addEditDeleteRepository.GetItems();
        }

        public Image GetItemImage(int itemId)
        {
            return addEditDeleteRepository.GetItemImage(itemId);
        }
        

        public Item InsertItem(Item item)
        {
            return addEditDeleteRepository.InsertItem(item);
        }
        public Item UpdateItem(Item item)
        {
            return addEditDeleteRepository.UpdateItem(item);
        }

        public Item DeleteItem(int id)
        {
            return addEditDeleteRepository.DeleteItem(id);
        }

        public Item GetItemByName(string name)
        {
            return addEditDeleteRepository.GetItemByName(name);
        }

        public List<Item> GetItemsByType(int typeId)
        {
            return addEditDeleteRepository.GetItemsByType(typeId);
        }        
        public List<Sales> GetSalesByClientId(int clientId)
        {
            return addEditDeleteRepository.GetSalesByClientId(clientId);
        }

        #endregion

        #region Client
        public Client GetClient(int id)
        {
            return addEditDeleteRepository.GetClient(id);
        }

        public List<Client> GetClients()
        {
            return addEditDeleteRepository.GetClients();
        }

        public Client InsertClient(Client client)
        {
            return addEditDeleteRepository.InsertClient(client);
        }
        public Client UpdateClient(Client client)
        {
            return addEditDeleteRepository.UpdateClient(client);
        }

        public Client DeleteClient(int id)
        {
            return addEditDeleteRepository.DeleteClient(id);
        }
        #endregion

        #region Author
        public Authors GetAuthor(int id)
        {
            return addEditDeleteRepository.GetAuthor(id);
        }

        public List<Authors> GetAuthors()
        {
            return addEditDeleteRepository.GetAuthors();
        }

        public Authors InsertAuthor(Authors author)
        {
            return addEditDeleteRepository.InsertAuthor(author);
        }
        public Authors UpdateAuthor(Authors author)
        {
            return addEditDeleteRepository.UpdateAuthor(author);
        }

        public Authors DeleteAuthor(int id)
        {
            return addEditDeleteRepository.DeleteAuthor(id);
        }
        #endregion

        #region Genre
        public Genre GetGenre(int id)
        {
            return addEditDeleteRepository.GetGenre(id);
        }

        public List<Genre> GetGenres()
        {
            return addEditDeleteRepository.GetGenres();
        }

        public Genre InsertGenre(Genre genre)
        {
            return addEditDeleteRepository.InsertGenre(genre);
        }
        public Genre UpdateGenre(Genre genre)
        {
            return addEditDeleteRepository.UpdateGenre(genre);
        }

        public Genre DeleteGenre(int id)
        {
            return addEditDeleteRepository.DeleteGenre(id);
        }
        #endregion

        //#region Book
        //public Books GetBook(int id)
        //{
        //    return addEditDeleteRepository.GetBook(id);
        //}

        //public List<Books> GetBooks()
        //{
        //    return addEditDeleteRepository.GetBooks();
        //}

        //public Books InsertBook(Books book)
        //{
        //    return addEditDeleteRepository.InsertBook(book);
        //}
        //public Books UpdateBook(Books book)
        //{
        //    return addEditDeleteRepository.UpdateBook(book);
        //}

        //public Books DeleteBook(int id)
        //{
        //    return addEditDeleteRepository.DeleteBook(id);
        //}

        //public Books GetBookByName(string name, int pageCount)
        //{
        //    return addEditDeleteRepository.GetBookByName(name, pageCount);
        //}
        //#endregion

        //#region SchoolStuff
        //public SchoolStuffs GetSchoolStuff(int id)
        //{
        //    return addEditDeleteRepository.GetSchoolStuff(id);
        //}

        //public List<SchoolStuffs> GetSchoolStuffs()
        //{
        //    return addEditDeleteRepository.GetSchoolStuffs();
        //}

        //public SchoolStuffs InsertSchoolStuff(SchoolStuffs schoolStuffs)
        //{
        //    return addEditDeleteRepository.InsertSchoolStuff(schoolStuffs);
        //}
        //public SchoolStuffs UpdateSchoolStuff(SchoolStuffs schoolStuffs)
        //{
        //    return addEditDeleteRepository.UpdateSchoolStuff(schoolStuffs);
        //}

        //public SchoolStuffs DeleteSchoolStuff(int id)
        //{
        //    return addEditDeleteRepository.DeleteSchoolStuff(id);
        //}
        //#endregion

        #region Deliveries
        public Delivery GetDelivery(int id)
        {
            return addEditDeleteRepository.GetDelivery(id);
        }
        
        public List<Delivery> GetDeliverysByItem(int id)
        {
            return addEditDeleteRepository.GetDeliverysByItem(id);
        }

        public List<Delivery> GetDeliverys(DateTime? date)
        {
            return addEditDeleteRepository.GetDeliveries(date);
        }

        public Delivery InsertDelivery(Delivery delivery)
        {
            return addEditDeleteRepository.InsertDelivery(delivery);
        }
        public Delivery UpdateDelivery(Delivery delivery)
        {
            return addEditDeleteRepository.UpdateDelivery(delivery);
        }

        public Delivery DeleteDelivery(int id)
        {
            return addEditDeleteRepository.DeleteDelivery(id);
        }
        #endregion

        #region Sales
        public Sales GetSale(int id)
        {
            return addEditDeleteRepository.GetSale(id);
        }

        public List<Sales> GetSales()
        {
            return addEditDeleteRepository.GetSales();
        }

        public List<Sales> GetSalesByDate(DateTime? date)
        {
            return addEditDeleteRepository.GetSalesByDate(date);
        }

        public List<Sales> GetSalesByItem(Item item)
        {
            return addEditDeleteRepository.GetSalesByItem(item);
        }

        public Sales InsertSale(Sales sale)
        {
            return addEditDeleteRepository.InsertSale(sale);
        }
        public Sales UpdateBook(Sales sale)
        {
            return addEditDeleteRepository.UpdateSale(sale);
        }

        public Sales DeleteSale(int id)
        {
            return addEditDeleteRepository.DeleteSale(id);
        }
        #endregion

        public void UploadImageToDB(HttpPostedFileBase file, int itemId)
        {
            Image img = new Image();
            img.ContentType = file.ContentType;
            img.Name = file.FileName;
            img.Data = ConvertToBytes(file);
            img.ItemId = itemId;
            addEditDeleteRepository.InsertImage(img);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase Image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(Image.InputStream);
            imageBytes = reader.ReadBytes((int)Image.ContentLength);
            return imageBytes;
        }
    }
}
