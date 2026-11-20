using System;


namespace LibrarySystem;
public class Loan
{
    public Loan(int id, DateOnly borrowDate, Member member, LibraryItem item)
    {
        Id = id;
        BorrowDate = borrowDate;
        Member = member;
        Item = item;

        DueDate = borrowDate.AddDays(item.LoanPeriod);
        Status = LoanStatus.Borrowed;
    }

    public int Id { get; }
    public DateOnly BorrowDate { get; }
    public DateOnly DueDate { get; }
    public DateOnly? ReturnDate { get; private set; }
    public LoanStatus Status { get; private set; }
    public Member Member { get; }
    public LibraryItem Item { get; }
    public decimal LateFee
    {
        get
        {
            if (ReturnDate == null || ReturnDate <= DueDate)
                return 0;

            int lateDays = ReturnDate.Value.DayNumber - DueDate.DayNumber;

            decimal fee = lateDays * Item.DailyLateFee;

            return fee - (fee * Member.Discount / 100);
        }
    }
    public void Return(DateOnly returnDate)
    {
        if(Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Loan is not active.");

       if(returnDate <  BorrowDate)
            throw new ArgumentException("Return date cannot be before borrow date.");

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;
        Item.IsOnLoan = false;

    }

    public void MarkLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only borrowed loans can be marked as lost.");

        Status = LoanStatus.Lost;
    }

}
