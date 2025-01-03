﻿namespace Prototype;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1= new Customer { City = "Ankara", FirstName = "John", LastName  = "Doe", Id = 1 };
        Customer customer2= (Customer)customer1.Clone();
        customer2.FirstName = "Jane";

        Console.WriteLine(customer1.FirstName);
        Console.WriteLine(customer2.FirstName);
    }
}


public abstract class Person {
    public abstract Person Clone();
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

public class Customer : Person
{
    public string City { get; set; }
    public override Person Clone()
    {
        return (Person) MemberwiseClone();
    }
}

public class Employee : Person
{
    public decimal Salary { get; set; }
    public override Person Clone()
    {
        return (Person) MemberwiseClone();
    }
}