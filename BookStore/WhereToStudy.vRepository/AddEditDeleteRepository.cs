using BookStore.vModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.vRepository
{
    public class AddEditDeleteRepository : BaseRepository
    {
        #region Type
        public Types GetType(int id)
        {
            return QueryFirst<Types>("GetType", new { @pId = id });
        }

        public List<Types> GetTypes()
        {
            return QueryMultiple<Types>("GetTypes");
        }

        public Types InsertType(Types type)
        {
            return QueryFirst<Types>("InsertType",
                new
                {
                    @pName = type.Name
                });
        }
        public Types UpdateType(Types type)
        {
            return QueryFirst<Types>("UpdateType",
                new
                {
                    @pId = type.Id,
                    @pName = type.Name
                });
        }

        public Types DeleteType(int id)
        {
            return QueryFirst<Types>("DeleteType", new { @pId = id });
        }
        #endregion

        #region Item
        public Item GetItem(int id)
        {
            return QueryFirst<Item>("GetItem", new { @pId = id });
        }

        public List<Item> GetItems()
        {
            return QueryMultiple<Item>("GetItems");
        }

        public Image GetItemImage(int itemId)
        {
            return QueryFirst<Image>("spGetImage",
                new
                {
                    @itemId = itemId
                });
        }

        public Item InsertItem(Item item)
        {
            return QueryFirst<Item>("InsertItem",
                new
                {
                    @pTypeId = item.TypeId
                    ,
                    @pName = item.Name
                    ,
                    @pYear = item.Year
                    ,
                    @pAuthorId = item.AuthorId
                    ,
                    @pGenreId = item.GenreId
                    ,
                    @pPageCount = item.PageCount
                    ,
                    @pPrice = item.Price
                    ,
                    @pSalePrice = item.SalePrice
                    ,
                    @pQuantity = item.Quantity
                });
        }
        public Item UpdateItem(Item item)
        {
            return QueryFirst<Item>("UpdateItem",
                new
                {
                    @pId = item.Id
                    ,
                    @pTypeId = item.TypeId
                    ,
                    @pName = item.Name
                    ,
                    @pYear = item.Year
                    ,
                    @pAuthorId = item.AuthorId
                    ,
                    @pGenreId = item.GenreId
                    ,
                    @pPageCount = item.PageCount
                    ,
                    @pPrice = item.Price
                    ,
                    @pSalePrice = item.SalePrice
                    ,
                    @pQuantity = item.Quantity
                });
        }

        public Item DeleteItem(int id)
        {
            return QueryFirst<Item>("DeleteItem", new { @pId = id });
        }

        public Item GetItemByName(string name)
        {
            return QueryFirst<Item>("GetItemByName", new { @pname = name });
        }

        public List<Item> GetItemsByType(int typeId)
        {
            return QueryMultiple<Item>("GetItemsByType", new { @ptypeId = typeId });
        }

        public List<Sales> GetSalesByClientId(int clientId)
        {
            return QueryMultiple<Sales>("GetSalesByClientId", new { @pclientId = clientId });
        }


        #endregion

        #region Client
        public Client GetClient(int id)
        {
            return QueryFirst<Client>("GetClient", new { @pId = id });
        }

        public List<Client> GetClients()
        {
            return QueryMultiple<Client>("GetClients");
        }

        public Client InsertClient(Client client)
        {
            return QueryFirst<Client>("InsertClient",
                new
                {
                    @pName = client.Name
                    ,
                    @pBulstat = client.Bulstat,
                    @pCode = client.Code,
                    @pAddress = client.Address,
                    @pFaks = client.Faks,
                    @pPhone = client.Phone
                });
        }
        public Client UpdateClient(Client client)
        {
            return QueryFirst<Client>("UpdateClient",
                new
                {
                    @pId = client.Id
                    ,
                    @pName = client.Name
                    ,
                    @pBulstat = client.Bulstat,
                    @pCode = client.Code,
                    @pAddress = client.Address,
                    @pFaks = client.Faks,
                    @pPhone = client.Phone
                });
        }

        public Client DeleteClient(int id)
        {
            return QueryFirst<Client>("DeleteClient", new { @pId = id });
        }
        #endregion

        #region Author
        public Authors GetAuthor(int id)
        {
            return QueryFirst<Authors>("GetAuthor", new { @pId = id });
        }

        public List<Authors> GetAuthors()
        {
            return QueryMultiple<Authors>("GetAuthors");
        }

        public Authors InsertAuthor(Authors author)
        {
            return QueryFirst<Authors>("InsertAuthor",
                new
                {
                    @pName = author.Name
                    ,
                    @pDate = author.Date
                });
        }
        public Authors UpdateAuthor(Authors author)
        {
            return QueryFirst<Authors>("UpdateAuthor",
                new
                {
                    @pId = author.Id
                    ,
                    @pName = author.Name
                    ,
                    @pDate = author.Date
                });
        }

        public Authors DeleteAuthor(int id)
        {
            return QueryFirst<Authors>("DeleteAuthor", new { @pId = id });
        }
        #endregion

        #region Genre
        public Genre GetGenre(int id)
        {
            return QueryFirst<Genre>("GetGenre", new { @pId = id });
        }

        public List<Genre> GetGenres()
        {
            return QueryMultiple<Genre>("GetGenres");
        }

        public Genre InsertGenre(Genre genre)
        {
            return QueryFirst<Genre>("InsertGenre",
                new
                {
                    @pName = genre.Name
                });
        }
        public Genre UpdateGenre(Genre genre)
        {
            return QueryFirst<Genre>("UpdateGenre",
                new
                {
                    @pId = genre.Id
                    ,
                    @pName = genre.Name
                });
        }

        public Genre DeleteGenre(int id)
        {
            return QueryFirst<Genre>("DeleteGenre", new { @pId = id });
        }
        #endregion

        //#region Books
        //public Books GetBook(int id)
        //{
        //    return QueryFirst<Books>("GetBook", new { @pId = id });
        //}

        //public List<Books> GetBooks()
        //{
        //    return QueryMultiple<Books>("GetBooks");
        //}

        //public Books InsertBook(Books book)
        //{
        //    return QueryFirst<Books>("InsertBook",
        //        new
        //        {
        //            @pName = book.Name
        //            ,
        //            @pYear = book.Year
        //            ,
        //            @pAuthorId = book.AuthorId
        //            ,
        //            @pGenreId = book.GenreId
        //            ,
        //            @pPageCount = book.PageCount
        //            ,
        //            @pPrice = book.Price
        //            ,
        //            @pSalePrice = book.SalePrice
        //            ,
        //            @pQuantity = book.Quantity
        //            ,
        //            @pTypeId = book.TypeId
        //        });
        //}
        //public Books UpdateBook(Books book)
        //{
        //    return QueryFirst<Books>("UpdateBook",
        //        new
        //        {
        //            @pId = book.Id
        //            ,
        //            @pName = book.Name
        //            ,
        //            @pYear = book.Year
        //            ,
        //            @pAuthorId = book.AuthorId
        //            ,
        //            @pGenreId = book.GenreId
        //            ,
        //            @pPageCount = book.PageCount
        //            ,
        //            @pPrice = book.Price
        //            ,
        //            @pSalePrice = book.SalePrice
        //            ,
        //            @pQuantity = book.Quantity
        //            ,
        //            @pTypeId = book.TypeId
        //        });
        //}

        //public Books DeleteBook(int id)
        //{
        //    return QueryFirst<Books>("DeleteBook", new { @pId = id });
        //}

        //public Books GetBookByName(string name, int pageCount)
        //{
        //    return QueryFirst<Books>("GetBookByName", new { @pName = name, @pPageCount = pageCount });
        //}

        //#endregion

        //#region SchoolStuffs
        //public SchoolStuffs GetSchoolStuff(int id)
        //{
        //    return QueryFirst<SchoolStuffs>("GetSchoolStuff", new { @pId = id });
        //}

        //public List<SchoolStuffs> GetSchoolStuffs()
        //{
        //    return QueryMultiple<SchoolStuffs>("GetSchoolStuffs");
        //}

        //public SchoolStuffs InsertSchoolStuff(SchoolStuffs schStuff)
        //{
        //    return QueryFirst<SchoolStuffs>("InsertSchoolStuff",
        //        new
        //        {
        //            @pName = schStuff.Name
        //            ,
        //            @pAuthorId = schStuff.AuthorId
        //            ,
        //            @pPrice = schStuff.Price
        //            ,
        //            @pSalePrice = schStuff.SalePrice
        //            ,
        //            @pQuantity = schStuff.Quantity
        //            ,
        //            @pTypeId = schStuff.TypeId
        //        });
        //}
        //public SchoolStuffs UpdateSchoolStuff(SchoolStuffs schStuff)
        //{
        //    return QueryFirst<SchoolStuffs>("UpdateSchoolStuff",
        //        new
        //        {
        //            @pId = schStuff.Id
        //            ,
        //            @pName = schStuff.Name
        //            ,
        //            @pAuthorId = schStuff.AuthorId
        //            ,
        //            @pPrice = schStuff.Price
        //            ,
        //            @pSalePrice = schStuff.SalePrice
        //            ,
        //            @pQuantity = schStuff.Quantity
        //        });
        //}

        //public SchoolStuffs DeleteSchoolStuff(int id)
        //{
        //    return QueryFirst<SchoolStuffs>("DeleteSchoolStuff", new { @pId = id });
        //}
        //#endregion

        #region Deliveries
        public Delivery GetDelivery(int id)
        {
            return QueryFirst<Delivery>("GetDelivery", new { @pId = id });
        }

        public List<Delivery> GetDeliverysByItem(int id)
        {
            return QueryMultiple<Delivery>("GetDeliverysByItem", new { @pid = id });
        }
        public List<Delivery> GetDeliveries(DateTime? date)
        {
            return QueryMultiple<Delivery>("GetDeliveries", new { @pdate = date });
        }

        public Delivery InsertDelivery(Delivery delivery)
        {
            return QueryFirst<Delivery>("InsertDelivery",
                new
                {
                    @pItemId = delivery.ItemId
                    ,
                    @pQuantity = delivery.Quantity
                    ,
                    @pDate = delivery.Date
                });
        }
        public Delivery UpdateDelivery(Delivery delivery)
        {
            return QueryFirst<Delivery>("UpdateDelivery",
                new
                {
                    @pId = delivery.Id
                    ,
                    @pItemId = delivery.ItemId
                    ,
                    @pQuantity = delivery.Quantity
                    ,
                    @pDate = delivery.Date
                });
        }

        public Delivery DeleteDelivery(int id)
        {
            return QueryFirst<Delivery>("DeleteDelivery", new { @pId = id });
        }
        #endregion

        #region Sales
        public Sales GetSale(int id)
        {
            return QueryFirst<Sales>("GetSale", new { @pId = id });
        }

        public List<Sales> GetSales()
        {
            return QueryMultiple<Sales>("GetSales");
        }

        public List<Sales> GetSalesByDate(DateTime? date)
        {
            return QueryMultiple<Sales>("GetSalesByDate", new { @pdate = date });
        }

        public List<Sales> GetSalesByItem(Item item)
        {
            return QueryMultiple<Sales>("GetSalesByItem", new { @pItemId = item.Id });
        }

        public Sales InsertSale(Sales sale)
        {
            return QueryFirst<Sales>("InsertSale",
                new
                {
                    @pItemId = sale.ItemId
                    ,
                    @pQuantity = sale.Quantity
                    ,
                    @pClientId = sale.ClientId
                    ,
                    @pDate = sale.Date
                });
        }
        public Sales UpdateSale(Sales sale)
        {
            return QueryFirst<Sales>("UpdateSale",
                new
                {
                    @pId = sale.Id
                    ,
                    @pItemId = sale.ItemId
                    ,
                    @pQuantity = sale.Quantity
                    ,
                    @pClientId = sale.Client
                    ,
                    @pDate = sale.Date
                });
        }

        public Sales DeleteSale(int id)
        {
            return QueryFirst<Sales>("DeleteSale", new { @pId = id });
        }
        #endregion

        public Image InsertImage(Image image)
        {
            return QueryFirst<Image>("spInsertImage", new
            {
                @id = image.Id,
                @name = image.Name,
                @data = image.Data,
                @length = image.Length,
                @contentType = image.ContentType,
                @itemId = image.ItemId
            });
        }
    }
}
