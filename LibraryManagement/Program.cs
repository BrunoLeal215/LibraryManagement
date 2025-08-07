using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Services;

// Create an in-memory repository and a service for managing books
var repository = new InMemoryBookRepository();
var service = new BookService(repository);

// Main application loop
while (true)
{
    // Display menu options
    Console.WriteLine("\nLibrary Management System:");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Update Book");
    Console.WriteLine("3. Delete Book");
    Console.WriteLine("4. List All Books");
    Console.WriteLine("5. View Book Details");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    Console.WriteLine();

    var input = Console.ReadLine();

    try
    {
        switch (input)
        {
            case "1":
                // Add a new book
                var newBook = GetBookInput();
                service.AddBook(newBook);
                Console.WriteLine("Book added!");
                break;

            case "2":
                // Update an existing book
                Console.Write("Enter Book ID: ");
                int idToUpdate = int.Parse(Console.ReadLine()!);
                var bookToUpdate = GetBookInput();
                bookToUpdate.Id = idToUpdate;
                service.UpdateBook(bookToUpdate);
                Console.WriteLine("Book updated.");
                break;

            case "3":
                // Delete a book by ID
                Console.Write("Enter Book ID: ");
                int idToDelete = int.Parse(Console.ReadLine()!);
                service.DeleteBook(idToDelete);
                Console.WriteLine("Book deleted.");
                break;

            case "4":
                // List all books
                foreach (var book in service.GetAllBooks())
                    Console.WriteLine($"{book.Id}: {book.Title} by {book.Author}");
                break;

            case "5":
                // View details of a specific book
                Console.Write("Enter Book ID: ");
                int id = int.Parse(Console.ReadLine()!);
                var bookDetails = service.GetBookById(id);
                if (bookDetails != null)
                {
                    Console.WriteLine($"Title: {bookDetails.Title}");
                    Console.WriteLine($"Author: {bookDetails.Author}");
                    Console.WriteLine($"ISBN: {bookDetails.ISBN}");
                    Console.WriteLine($"Description: {bookDetails.Description}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
                break;

            case "0":
                // Exit the application
                return;

            default:
                // Handle invalid menu option
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    catch (Exception ex)
    {
        // Display error message for any exceptions
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// Helper method to get book details from user input
Book GetBookInput()
{
    Console.Write("Title: ");
    var title = Console.ReadLine()!;
    Console.Write("Author: ");
    var author = Console.ReadLine()!;
    Console.Write("ISBN (13 digits): ");
    var isbn = Console.ReadLine()!;
    Console.Write("Description: ");
    var description = Console.ReadLine()!;
    return new Book { Title = title, Author = author, ISBN = isbn, Description = description };
}
