using System;

namespace LibrarySystem;

public class Person
{
    public int Id { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }

    protected Person(int id, string fullName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone is required.");

        Id = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
}