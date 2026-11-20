using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class Shelver : Staff
{
    public string Section { get; private set; }
    public Shelver(int id, string fullName, string phoneNumber, DateOnly hireDate, decimal monthlySalary, string section) : base(id, fullName, phoneNumber, hireDate, monthlySalary, 0)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new ArgumentException("Section is required.");

        Section = section;
    }

    

    public void Reassign(string section)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new ArgumentException("Section is required.");

        Section = section;
    }
}
