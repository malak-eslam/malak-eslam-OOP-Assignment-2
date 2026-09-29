using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class Staff : Person
{
    public DateOnly HireDate { get; }
    public decimal MonthlySalary { get; private set; }
    public decimal ResponsibilityAllowance { get; }
    public decimal MonthlyPay => MonthlySalary + ResponsibilityAllowance;

        
    protected Staff(int id, string fullName,string phoneNumber,DateOnly hireDate,decimal monthlySalary,
                 decimal responsibilityAllowance): base(id, fullName, phoneNumber)
         {
            if (monthlySalary <= 0)
               throw new ArgumentException("Monthly salary must be positive.");

           HireDate = hireDate;
           MonthlySalary = monthlySalary;
           ResponsibilityAllowance = responsibilityAllowance;
    }
    

   
    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new ArgumentException("Raise percentage must be positive.");

        MonthlySalary += MonthlySalary * percentage / 100;
    }

}
