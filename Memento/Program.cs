namespace Memento;

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book {
            Title = "Up",
            Author = "David Doe",
            Isbn = "12345"
        };

        book.ShowBook();
        CareTaker history = new CareTaker();
        history.Memento = book.CreateUndo();
        
        book.Isbn = "23451";
        book.Title = "Look Down";
        book.ShowBook();

        book.RestoreFromUndo(history.Memento);
        book.ShowBook();

    }
}

class Book {
    private string _title;
    private string _author;
    private string _isbn;

    private DateTime _lastEdited;
    public string Title {
        get {
            return _title;
        }
        set {
            _title = value;
            SetLastEdited();
        }
    }

    public string Author {
        get {
            return _author;
        }
        set {
            _author = value;
            SetLastEdited();
        }
    }

    public string Isbn {
        get {
            return _isbn;
        }
        set {
            _isbn = value;
            SetLastEdited();
        }
    }

    private void SetLastEdited() {
        _lastEdited = DateTime.UtcNow;
    }
    public Memento CreateUndo() {
        return new Memento(_title, _author, _isbn, _lastEdited);
    }
    public void RestoreFromUndo(Memento memento) {
        _title = memento.Title;
        _author = memento.Author;
        _isbn = memento.Isbn;
        _lastEdited = memento.LastEdited;
    }

    public void ShowBook() {
        Console.WriteLine("{0}, {1}, {2} edited: {3}", _isbn, _author, _title, _lastEdited);
    }
}

class Memento {
    public string Title { get;set;}
    public string Isbn { get;set;}
    public string Author { get;set;}
    public DateTime LastEdited { get;set;} 
    public Memento(string title,string author,string isbn,DateTime lastEdited) {
        Title = title;
        Isbn = isbn;
        Author = author;
        LastEdited = lastEdited;
    }
}

class CareTaker {
    public Memento Memento { get; set; }
}