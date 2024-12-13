

namespace Visitor;

class Program
{
    static void Main(string[] args)
    {
        Manager ceo = new Manager { Name = "Engin", Salary = 1000};
        Manager cto = new Manager { Name = "Salih", Salary = 900};

        Worker worker1 = new Worker { Name = "Hasan", Salary = 750};
        Worker worker2 = new Worker { Name = "Mert", Salary = 750};


        ceo.Subordinates.Add(cto);
        cto.Subordinates.Add(worker1);
        cto.Subordinates.Add(worker2);

        OrganisationalStructure organisationalStructure = new OrganisationalStructure(ceo);

        PayroolVisitor payroolVisitor = new PayroolVisitor();
        PayriseVisitor payriseVisitor = new PayriseVisitor();

        organisationalStructure.Accept(payroolVisitor);
        organisationalStructure.Accept(payriseVisitor);

    }
}

class OrganisationalStructure
{
    public EmployeeBase Employee;

    public OrganisationalStructure(EmployeeBase firstEmployee)
    {
        Employee = firstEmployee;
    }

    public void Accept(VisitorBase visitorBase)
    {
        Employee.Accept(visitorBase);
    }
}

abstract class EmployeeBase
{
    public abstract void Accept(VisitorBase visitorBase);
    public string Name { get; set; }
    public decimal Salary { get; set; }
}

abstract class VisitorBase
{
    public abstract void Visit(Manager manager);
    public abstract void Visit(Worker worker);

}

class Manager : EmployeeBase
{
    public List<EmployeeBase> Subordinates { get; set; }
    public Manager()
    {
        Subordinates = new List<EmployeeBase>();
    }
    public override void Accept(VisitorBase visitor)
    {
        visitor.Visit(this);

        foreach (var empoyee in Subordinates)
        {
            empoyee.Accept(visitor);
        }
    }
}

class Worker : EmployeeBase
{
    public override void Accept(VisitorBase visitor)
    {
        visitor.Visit(this);
    }
}

class PayroolVisitor : VisitorBase
{
    public override void Visit(Manager manager)
    {
        Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary );
    }

    public override void Visit(Worker worker)
    {
        Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary );
    }
}

class PayriseVisitor : VisitorBase
{
    public override void Visit(Manager manager)
    {
        Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal) 1.1 );
    }

    public override void Visit(Worker worker)
    {
        Console.WriteLine("{0}  salary increased to {1}", worker.Name, worker.Salary * (decimal) 1.2 );
    }
}