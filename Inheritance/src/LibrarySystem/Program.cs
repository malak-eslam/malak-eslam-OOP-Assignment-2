using System;

namespace LibrarySystem;

public class Program
{
    public static void Main()
    {
        var student = new StudentMember(
            1,
            "Malak",
            "01000000000");

        var premium = new PremiumMember(
            2,
            "Sara",
            "01111111111",
            20);

        var book = new Book("B1", "C# Book", 10);
        var dvd = new DVD("D1", "Inception", 10);
        var magazine = new Magazine("M1", "Tech Magazine", 10);

        // Withdrawn item
        book.Withdraw();

        try
        {
            student.Borrow(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        book.Restore();

        // Successful borrow
        var studentLoan1 = student.Borrow(book);

        // Same item already on loan
        try
        {
            premium.Borrow(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Student fourth loan
        var book2 = new Book("B2", "Book 2", 10);
        var book3 = new Book("B3", "Book 3", 10);
        var magazine2 = new Magazine("M2", "Magazine 2", 10);

        student.Borrow(book2);
        student.Borrow(book3);

        try
        {
            student.Borrow(magazine2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Staff monthly pay
        var staff = new List<Staff>
        {
            new Librarian(3, "Ali", "01222222222", DateOnly.FromDateTime(DateTime.Today), 5000),
            new Shelver(4, "Omar", "01333333333", DateOnly.FromDateTime(DateTime.Today), 4500, "Fiction"),
            new HeadLibrarian(5, "Mona", "01444444444", DateOnly.FromDateTime(DateTime.Today), 7000)
        };

        foreach (var employee in staff)
        {
            Console.WriteLine($"{employee.FullName}: {employee.MonthlyPay}");
        }

        // Item information
        var items = new List<LibraryItem>
        {
            book,
            dvd,
            magazine
        };

        foreach (var item in items)
        {
            Console.WriteLine(
                $"{item.Title}: {item.LoanPeriod} days, Daily Fee = {item.DailyLateFee}");
        }

        // Premium member returns DVD 5 days late
        var premiumLoan = premium.Borrow(dvd);

        var returnDate = premiumLoan.DueDate.AddDays(5);

        premiumLoan.Return(returnDate);

        Console.WriteLine($"Due Date: {premiumLoan.DueDate}");
        Console.WriteLine($"Late Fee: {premiumLoan.LateFee}");
        Console.WriteLine($"Reading Points: {premium.ReadingPoints}");

        // Return same loan twice
        try
        {
            premiumLoan.Return(returnDate);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Mark returned loan as lost
        try
        {
            premiumLoan.MarkLost();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}