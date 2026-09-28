using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class LibraryItem
{
    protected LibraryItem(string catalogNumber, string title, int loanPeriod, decimal baseLateFee, decimal lateFeeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNumber))
            throw new ArgumentException("Catalog number is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        if (loanPeriod <= 0)
            throw new ArgumentException("Loan period must be positive.");

        if (baseLateFee <= 0)
            throw new ArgumentException("Base late fee must be positive.");

        CatalogNumber = catalogNumber;
        Title = title;
        LoanPeriod = loanPeriod;
        BaseLateFee = baseLateFee;
        LateFeeMultiplier = lateFeeMultiplier;
    }

    public string CatalogNumber { get; }
    public string Title { get; }
    public int LoanPeriod { get; }
    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan { get; internal set; }
    private decimal LateFeeMultiplier { get; }

    public decimal DailyLateFee => BaseLateFee * LateFeeMultiplier;


    public void SetLateFee(decimal fee)
    {
        if (fee <= 0)
            throw new ArgumentException("Late fee must be positive.");

        BaseLateFee = fee;
    }
    public void Withdraw()
    {
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }


}
