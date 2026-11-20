using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class Librarian : Staff
{
    public Librarian(int id, string fullName, string phoneNumber, DateOnly hireDate, decimal monthlySalary) : base(id, fullName, phoneNumber, hireDate, monthlySalary, 0)
    {
    }
    public void ProcessReturn(Loan loan)
    {
        loan.Return(DateOnly.FromDateTime(DateTime.Today));
    }

    public void MarkLost(Loan loan)
    {
        loan.MarkLost();
    }
}
