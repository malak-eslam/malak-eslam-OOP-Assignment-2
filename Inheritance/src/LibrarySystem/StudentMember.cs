using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem;
public class StudentMember : Member
{
    public StudentMember(int id, string fullName, string phoneNumber) : base(id, fullName, phoneNumber, 3, 0)
    {
    }
}
