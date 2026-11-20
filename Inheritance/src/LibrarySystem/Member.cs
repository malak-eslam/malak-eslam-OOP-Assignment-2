using System;
using System.Collections.Generic;

namespace LibrarySystem;

public class Member : Person
{

    protected int MaxLoans { get; }
    public decimal Discount { get; }

    private readonly List<Loan> _loans = new List<Loan>();
    public IReadOnlyList<Loan> Loans => _loans;

    protected Member(int id, string fullName, string phoneNumber, int maxLoans, decimal discount) : base(id, fullName, phoneNumber)
    {
        MaxLoans = maxLoans;
        Discount = discount;

    }

    public Loan Borrow(LibraryItem item)
    {
        int activeLoans = 0;
        foreach (var loan in _loans)
        {
            if (loan.Status == LoanStatus.Borrowed)
                activeLoans++;
        }

        if (activeLoans >= MaxLoans)
            throw new InvalidOperationException("Loan limit reached.");

        if (item.IsWithdrawn)
            throw new InvalidOperationException("Withdrawn item cannot be borrowed.");

        if (item.IsOnLoan)
            throw new InvalidOperationException("Item is already on loan.");

        var newLoan = new Loan
        (
            _loans.Count + 1,
            DateOnly.FromDateTime(DateTime.Today),
            this,
            item
        );

        item.IsOnLoan = true;

        _loans.Add(newLoan);

        return newLoan;
    }

}