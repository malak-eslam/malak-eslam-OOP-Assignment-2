using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class HeadLibrarian : Staff
{
    public HeadLibrarian(int id, string fullName, string phoneNumber, DateOnly hireDate, decimal monthlySalary) : base(id, fullName, phoneNumber, hireDate, monthlySalary, 400)
    {

    }

    public void ChangeLateFee(LibraryItem item, decimal fee)
    {
        item.SetLateFee(fee);
    }

    public void Withdraw(LibraryItem item)
    {
        item.Withdraw();
    }

    public void Restore(LibraryItem item)
    {
        item.Restore();
    }

}
