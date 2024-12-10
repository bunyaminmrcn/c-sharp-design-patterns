namespace Facade;

class Program
{
    static void Main(string[] args)
    {
        CustomerManager customerManager= new CustomerManager();
        customerManager.Save();
    }
}

class Logging : ILogging{
    public void Log(string message) {
        Console.WriteLine(message + " logged");
    }
}

internal interface ILogging
{
    void Log(string message);
}

class Caching: ICaching {
    public void Cache(string key) {
        Console.WriteLine(key + " cached");
    }
}

internal interface ICaching
{
    void Cache(string message);
}

class Authorize : IAuthorizer {
    public void CheckUser(string username) {
        Console.WriteLine(username + " cheched");        
    }
}

class Validation : IValidation {
    public void Validate(string message) {
        Console.WriteLine(message + " validated");
    }
}

internal interface IValidation
{
    void Validate(string message);
}

internal interface IAuthorizer
{
    void CheckUser(string username);
}

class CustomerManager {
    private CrossCuttingConcernsFacade _concerns;
    public CustomerManager() {
      _concerns = new CrossCuttingConcernsFacade();
    }
    public void Save() {
        //_logging.Log("");
        //_caching.Cache("");
        //_authorizer.CheckUser("");
        _concerns.logging.Log("");
        _concerns.caching.Cache("");
        _concerns.authorizer.CheckUser("");
        _concerns.validation.Validate("");
        Console.WriteLine("Saved");
    }
}

class CrossCuttingConcernsFacade {

    public ILogging logging;
    public ICaching caching;
    public IAuthorizer authorizer;
    public IValidation validation;
    public CrossCuttingConcernsFacade() {
        caching = new Caching();
        authorizer = new Authorize();
        logging = new Logging();
        validation = new Validation();
    }
}