using System.Collections;

namespace Composite;

class Program
{
    static void Main(string[] args)
    {
        Employee john = new Employee { Name = "John Doe"};
        Employee maria = new Employee { Name = "Maria Black"};
        Employee can = new Employee { Name = "Can Demirbas"};

        john.AddSubordinate(maria);
        john.AddSubordinate(can);

        Employee tom = new Employee { Name = "Tom Greek"};
        maria.AddSubordinate(tom);

        Contractor ali = new Contractor { Name = "Ali Hikmet"};
        can.AddSubordinate(ali);

        foreach(Employee manager in john) {
            Console.WriteLine("  {0}", manager.Name);

            foreach (IPerson employee in manager)
            {
                Console.WriteLine("    {0}", employee.Name);
            }
        }
    }
}

interface IPerson {
    string Name { get; set;}
}


class Contractor : IPerson
{
    public string Name { get; set; }
}
class Employee : IPerson, IEnumerable<IPerson>
{
    List<IPerson> _subordinates = new List<IPerson>();
    public string Name { get; set; }

    public void AddSubordinate(IPerson person) {
        _subordinates.Add(person);
    }

    public void RemoveSubordinate(IPerson person) {
        _subordinates.Remove(person);
    }
    public IPerson GetPerson(int index) {
        return _subordinates[index];
    }
    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach (var subordinate in _subordinates)
        {
            yield return subordinate;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}