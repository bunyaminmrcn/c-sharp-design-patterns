
namespace Mediator;

class Program
{
    static void Main(string[] args)
    {
        Mediator mediator = new Mediator();
        Teacher john = new Teacher(mediator);
        john.Name = "John";

        Student steve = new Student(mediator);
        steve.Name = "Steve";
        Student salih = new Student(mediator);
        salih.Name = "Salih";

        mediator.Students = new List<Student> { salih , steve};

        john.SendNewImage("slide1.jpg");
        john.ReceiveQuestion("Whats up?", salih);
    }
}


abstract class CourseMember {
    protected Mediator Mediator;
    protected CourseMember(Mediator mediator) {
        Mediator = mediator;
    }
}

class Teacher : CourseMember
{
    public string Name { get; set; }

    public Teacher(Mediator mediator) : base(mediator)
    {
        
    }

    public void ReceiveQuestion(string question, Student student)
    {
        Console.WriteLine("Teacher received a question from {0}, {1}", student.Name, question);
    }

    public void SendNewImage(string url) {
        Console.WriteLine("Teacher changed the slide {0}", url);
        Mediator.UpdateImage(url);
    }
    public void AnswerQuestion(string question , Student student) {
        Console.WriteLine("Teacher answered the question from {0}, {1}", student.Name, question);
    }
}

class Student : CourseMember
{
    public Student(Mediator mediator) : base(mediator)
    {
    }

    public string Name { get; set; }

    public void ReceiveImage(string url)
    {
        Console.WriteLine("{1} Student received image: {0}", url, Name);
    }

    public void ReceiveAnswer(string answer)
    {
        Console.WriteLine("Student received the answer: {0}", answer);
    }
}

class Mediator {
    public Teacher Teacher { get;set; }
    public List<Student> Students { get;set; }

    public void UpdateImage(string url) {
        foreach (var student in Students)
        {
            student.ReceiveImage(url);
        }
    }

    public void SendQuestion(string question, Student student) {
        Teacher.ReceiveQuestion(question, student);
    }
    public void SendAnswer(string answer, Student student) {
        student.ReceiveAnswer(answer);
    }
}