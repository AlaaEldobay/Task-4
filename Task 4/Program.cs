namespace Task_4
{
        class Library
        {
            List<Book> books = [];

            public Library(List<Book> books)
            {
                this.books = books;
            }

            public void AddBook(Book book)
            {
                books.Add(book);
                Console.WriteLine("added sucesfully");

            }
            public List<Book> SearchBook(String x)
            {
                List<Book> result = new List<Book>();
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].Title == x)
                    {
                        result.Add(books[i]);
                    }
                    else if (books[i].Author == x)
                    {
                        result.Add(books[i]);
                    }
                }
                return result;
            }
            public void BorrowBook(string isbn)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].ISBN == isbn)
                    {
                        if (books[i].Available)
                        {
                            books[i].Available = false;
                            Console.WriteLine("borrowed successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book is not available.");
                        }
                        return;
                    }
                }
                Console.WriteLine("book not found");
            }
            public void ReturnBook(string isbn)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].ISBN == isbn)
                    {
                        books[i].Available = true;
                        Console.WriteLine("returned successfully");
                        return;
                    }
                    Console.WriteLine("Book not found.");
                }
            }
        }
        class Book
        {
            public String Title;
            public string Author;
            public string ISBN;
            public bool Available;

            public Book(string title, string author, string iSBN)
            {
                Title = title;
                Author = author;
                ISBN = iSBN;
                Available = true;
            }
        }


        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library(new List<Book>());
                while (true)
                {
                    Console.WriteLine("--- Library Menu ---");
                    Console.WriteLine("1 : Add Book");
                    Console.WriteLine("2 : Search Book");
                    Console.WriteLine("3 : Borrow Book");
                    Console.WriteLine("4 : Return Book");
                    Console.WriteLine("5 : Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter ISBN: ");
                            string isbn = Console.ReadLine();
                            library.AddBook(new Book(title, author, isbn));
                            break;

                        case "2":
                            Console.Write("Enter Title or Author to search: ");
                            string z = Console.ReadLine();
                            List<Book> results = library.SearchBook(z);
                            if (results.Count == 0)
                            {
                                Console.WriteLine("No books found.");
                            }
                            else
                            {
                                for (int i = 0; i < results.Count; i++)
                                {
                                    Console.WriteLine($"Title: {results[i].Title}, Author: {results[i].Author}, ISBN: {results[i].ISBN}, Available: {results[i].Available}");
                                }
                            }
                            break;

                        case "3":
                            Console.Write("Enter ISBN to borrow: ");
                            string borrowIsbn = Console.ReadLine();
                            library.BorrowBook(borrowIsbn);
                            break;

                        case "4":
                            Console.Write("Enter ISBN to return: ");
                            string returnIsbn = Console.ReadLine();
                            library.ReturnBook(returnIsbn);
                            break;

                        case "5":
                            Console.WriteLine("Exiting program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }
                }

            }
        }
    
}
