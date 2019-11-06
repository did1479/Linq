<Query Kind="Program" />

void Main()
{
	GetOddNumberUsingLinq();
    ExtractUpperCaseWordsFromGivenString();
    GetNamesFromSecondToFifthPosition();
    GetProductAndCategoryList();
    LinqWithXML();
}

private static void GetOddNumberUsingLinq()
{
	Console.WriteLine("====================Question 3(Extract odd numbers from the list.)========================");
    IList<int> IntLst = new List<int>
    {
        11,15,22,48,66,44,20,177,85,99,66,56,29,34
    };

    try
    {
        var FilteredLst = (
                        from l1 in IntLst
                        where (l1 % 2) != 0
                        select l1
                       ).ToList();

        foreach (var item in FilteredLst)
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception e) 
    {
        Console.WriteLine("Exception occurred, Message is "+ e.Message);
    }
}



private static void ExtractUpperCaseWordsFromGivenString()
{
	Console.WriteLine("====================Question 4(Extract UPPER case words FROM THIS string)========================");
    try
    {
        string givenString = "Extract UPPER case words FROM THIS string.";
        IList<string> splittedLst = givenString.Split(' ');
        var extractedLst = (
                         from str in splittedLst
                         where (from c in str where (int)c >=65 && (int)c <= 90 select c).ToList().Count == str.Length
                         select str
                       ).ToList();

        foreach (var item in extractedLst)
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception occurred, Message is " + e.Message);
    }
}

private static void GetNamesFromSecondToFifthPosition()
{
	Console.WriteLine("====================Question 5(Extract the list having names from “Mike” till “Andy”.)========================");
    try
    {
        IList<string> strLst = new List<string>
        {
            "John", "Mike", "Chris", "Jack", "Andy", "Gretchen", "Helen"
        };

        IList<string> secondToFifthPositionNames =
            (
                from str in strLst
                where strLst.IndexOf(str) >= 1 && strLst.IndexOf(str) <= 4
                select str
            ).ToList();

        foreach (var item in secondToFifthPositionNames)
        {
            Console.WriteLine(item);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception occurred, Message is " + e.Message);
    }
}

private static void GetProductAndCategoryList()
{
    try
    {
        var productList = new List<Product>
        {
            new Product { ProductId = 1, ProductTitle = "Pen", CategoryId = 1},
            new Product { ProductId = 2, ProductTitle = "Pen Drive", CategoryId = 2},
            new Product { ProductId = 3, ProductTitle = "Air Conditioner", CategoryId = 3},
            new Product { ProductId = 4, ProductTitle = "Hard Disk", CategoryId = 2},
            new Product { ProductId = 5, ProductTitle = "Refrigerator", CategoryId = 3},
            new Product { ProductId = 6, ProductTitle = "TShirt", CategoryId = 4}
        };

        var categoryList = new List<Category>
        {
            new Category { CategoryId = 1, CategoryTitle = "Stationary"},
            new Category { CategoryId = 2, CategoryTitle = "Storage Device"},
            new Category { CategoryId = 3, CategoryTitle = "Electronics"},
            new Category { CategoryId = 4, CategoryTitle = "Clothing"},
            new Category { CategoryId = 5, CategoryTitle = "Fashion"}
        };

        var productCategoryList = 
            (
                from prod in productList 
                join category in categoryList on prod.CategoryId equals category.CategoryId
                select new { prod.ProductId, prod.ProductTitle, category.CategoryTitle }
            );

        var productCategoryTitleList =
            (
                from category in categoryList
                join prod in productList on category.CategoryId equals prod.CategoryId into catProd  
                from cp in catProd.DefaultIfEmpty()
                select new { Category = category, ProductTitle = cp == null ? "(No products)" : cp.ProductTitle }
            );

		Console.WriteLine("====================Question 6a(Write a linq query to display the ProductId, ProductTitle and its Category Title.)========================");
		Console.WriteLine(" ");
        foreach (var item in productCategoryList)
        {
            Console.WriteLine(item.ProductId.ToString()  + " " + item.ProductTitle + " " + item.CategoryTitle.ToString());
        }

		Console.WriteLine("====================Question 6b(Write a linq query to display the ProductTitle and Category Title.)========================");
		Console.WriteLine(" ");
        foreach (var item in productCategoryTitleList)
        {
            Console.WriteLine(item.ProductTitle.ToString() + " " + item.Category.CategoryTitle);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception occurred, Message is " + e.Message);
    }
}

private static void LinqWithXML()
{
    try
    {
        string xmlString = @"<?xml version=""1.0""?>" +
            "<catalog>" +
                "<book id='bk101'>" +
                      "<author>Gambardella, Matthew</author>" +
                      "<title>XML Developer's Guide</title>" +
                      "<genre>Computer</genre>" +
                      "<price>44.95</price>" +
                      "<publish_date>2000-10-01</publish_date>" +
                      "<description>An in-depth look at creating applications " +
                      "with XML.</description>" +
                "</book>" +
                "<book id='bk102'>" +
                      "<author>Ralls, Kim</author>" +
                      "<title>Midnight Rain</title>" +
                      "<genre>Fantasy</genre>" +
                      "<price>5.95</price>" +
                      " <publish_date>2000-12-16</publish_date>" +
                      "<description>A former architect battles corporate zombies," +
                      " an evil sorceress, and her own childhood to become queen" +
                      "of the world.</description>" +
                "</book>" + 
                "<book id='bk103'>" +
                      "<author>Corets, Eva</author>" +
                      "<title>Maeve Ascendant</title>" +
                      "<genre>Fantasy</genre>" +
                      "<price>5.95</price>" +
                      "<publish_date>2000-11-17</publish_date>" +
                      "<description>After the collapse of a nanotechnology " +
                      "society in England, the young survivors lay the" +
                      "foundation for a new society.</description>" +
                "</book>" +
                "<book id='bk104'>" +
                      "<author>Corets, Eva</author>" +
                      "<title>Oberon's Legacy</title>" +
                      "<genre>Fantasy</genre>" +
                      "<price>5.95</price>" +
                      "<publish_date>2001-03-10</publish_date>" +
                      "<description>In post-apocalypse England, the mysterious  " +
                      "agent known only as Oberon helps to create a new life " +
                      "for the inhabitants of London.Sequel to Maeve " +
                      "Ascendant.</description> " +
                "</book>" +
                "<book id='bk105'>" +
                      "<author>Gambardella, Matthew</author>" +
                      "<title>The Sundered Grail</title>" +
                      "<genre>Fantasy</genre>" +
                      "<price>44.95</price>" +
                      "<publish_date>2001-09-10</publish_date>" +
                      "<description>The two daughters of Maeve, half-sisters, battle one another for control of England.Sequel to Oberon's Legacy." +
                      "</description>" +
                "</book>" +
                "<book id='bk106'>" +
                      "<author>Randall, Cynthia</author>" +
                      "<title>Lover Birds</title>" +
                      "<genre>Romance</genre>" +
                      "<price>4.95</price>" +
                      "<publish_date>2000-09-02</publish_date>" +
                      "<description>When Carla meets Paul at an ornithology conference, tempers fly as feathers get ruffled." +
                      "</description>" +
                "</book>" +
                "<book id='bk107'>" +
                      "<author>Thurman, Paula</author>" +
                      "<title>Splish Splash</title>" +
                      "<genre>Romance</genre>" +
                      "<price>4.95</price>" +
                      "<publish_date>2000-11-02</publish_date>" +
                      "<description>A deep sea diver finds true love twenty" +
                      " thousand leagues beneath the sea." +
                      "</description> " +
                "</book>" +
                "<book id='bk108'>" +
                      "<author>Knorr, Stefan</author>" +
                      "<title>Creepy Crawlies</title>" +
                      "<genre>Horror</genre>" +
                      "<price>4.95</price>" +
                      "<publish_date>2000-12-06</publish_date>" +
                      "<description>An anthology of horror stories about roaches," +
                      " centipedes, scorpions and other insects." +
                      "</description> " +
                "</book>" +
                "<book id='bk109'>" +
                      "<author>Kress, Peter</author>" +
                      "<title>Paradox Lost</title>" +
                      "<genre>Science Fiction</genre>" +
                      "<price>6.95</price>" +
                      "<publish_date>2000-11-02</publish_date>" +
                      "<description>After an inadvertant trip through a Heisenberg Uncertainty Device, " +
                      "James Salway discovers the problems " +
                      "of being quantum." +
                      "</description>" +
                "</book>" +
                "<book id='bk110'>" +
                      "<author>O'Brien, Tim</author>" +
                      "<title>Microsoft .NET: The Programming Bible</title>" +
                      "<genre>Computer</genre>" +
                      "<price>36.95</price>" +
                      "<publish_date>2000-12-09</publish_date>" +
                      "<description>Microsoft's .NET initiative is explored in " +
                      "detail in this deep programmer's reference." +
                      "</description>" +
                "</book>" +
                "<book id='bk111'>" +
                      "<author>O'Brien, Tim</author>" +
                      "<title>MSXML3: A Comprehensive Guide</title>" +
                      "<genre>Computer</genre>" +
                      "<price>36.95</price>" +
                      "<publish_date>2000-12-01</publish_date>" +
                      "<description>The Microsoft MSXML3 parser is covered in detail, " +
                      "with attention to XML DOM interfaces, " +
                      "XSLT processing, SAX and more." +
                      "</description> " +
                "</book>" +
                "<book id='bk112'>" +
                      "<author>Galos, Mike</author>" +
                      "<title>Visual Studio 7: A Comprehensive Guide</title>" +
                      "<genre>Computer</genre>" +
                      "<price>49.95</price>" +
                      "<publish_date>2001-04-16</publish_date>" +
                      "<description>Microsoft Visual Studio 7 is explored in depth, looking at how Visual Basic, " +
                      "Visual C++, C#, and ASP+ are " +
                      "integrated into a compr'ehensive development environment." +
                      "</description>" +
                "</book>" +
            "</catalog>";

        var xmlDocument = XDocument.Parse(xmlString);
        var catlogElemnts = (
                                from emp in xmlDocument.Root.Elements()
                                select emp
                             ).ToList();							

        int bookCount = catlogElemnts.Count;
        var books = (
                        from ce in catlogElemnts
                        select new
                        { 
                            BookId = ce.Attribute("id").Value,
                            Author = ce.Element("author").Value,
                            Title = ce.Element("title").Value,
                            Genre = ce.Element("genre").Value,
                            Price = ce.Element("price").Value,
                        }
                        into resultBooks
                        orderby resultBooks.Title
                        select new
                        {
                            resultBooks.BookId,
                            resultBooks.Author,
                            resultBooks.Title,
                            resultBooks.Genre,
                            resultBooks.Price,
                        }
                    ).ToList();

		Console.WriteLine("====================Question 7b(Display Id, Title, Genre and Price of the Books, sorted by Title.)========================");
		Console.WriteLine(" ");
        foreach (var book in books)
        {
            Console.WriteLine(book.BookId + "; " + book.Author + "; " + book.Title + "; " + book.Genre + "; " + book.Price);
        }

        var groupedByGenreLst = (
                                    from b in books.GroupBy(x=>x.Genre)
                                    select new
                                    {
                                        GenreCount = b.Count(),
                                        b.First().Genre,
                                    }
                                );
		Console.WriteLine(" ");
		Console.WriteLine("====================Question 7c(Display the Genre and count of the books under that genre.)========================");
		Console.WriteLine(" ");
        foreach (var genreList in groupedByGenreLst)
        {
            Console.WriteLine(genreList.Genre + " = " + genreList.GenreCount);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception occurred, Message is " + e.Message);
    }
}
		
class Product
{
    public int ProductId { get; set; }

    public string ProductTitle { get; set; }

    public int CategoryId { get; set; }
}

class Category
{
    public int CategoryId { get; set; }

    public string CategoryTitle { get; set; }
}
// Define other methods and classes here