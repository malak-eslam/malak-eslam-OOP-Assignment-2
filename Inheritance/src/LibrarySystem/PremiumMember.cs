using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class PremiumMember : Member
{
    public PremiumMember(int id, string fullName, string phoneNumber, decimal discount) : base(id, fullName, phoneNumber, 10, discount)
    {
        if (discount < 0 || discount > 100)
            throw new ArgumentException("Discount must be between 0 and 100.");
    }

    public int ReadingPoints
    {
        get
        {
            int points = 0;
            foreach (var loan in Loans)
            {
                if(loan.Status == LoanStatus.Returned)
                {
                    points+=5;
                }
            }
            return points;
        }
    }
}
