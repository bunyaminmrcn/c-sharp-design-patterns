namespace AbstractFactory;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new Factory1());
        productManager.GetAll();
    }
}

public abstract class Logging() {
    public abstract void Log(string message);
}

public class Log4Net: Logging {
    public override void Log(string message)
    {
        Console.WriteLine("Logged with Log4Net");
    }
}

public class NLogger: Logging {
    public override void Log(string message)
    {
        Console.WriteLine("Logged with NLogger");
    }
}

public abstract class Caching() {
    public abstract void Cache(string data);
}

public class MemCache: Caching {
    public override void Cache(string data)
    {
        Console.WriteLine("Cached with MemCache");
    }
}

public class RedisCache: Caching {
    public override void Cache(string data)
    {
        Console.WriteLine("Cached with Redis");
    }
}


public abstract class CrossCuttingCorcernsFactory {
    public abstract Logging CreateLogger();
    public abstract Caching CreateCaching();
}


public class Factory1 : CrossCuttingCorcernsFactory
{
    public override Caching CreateCaching()
    {
        return new RedisCache();
    }

    public override Logging CreateLogger()
    {
        return new Log4Net();
    }
}


public class Factory2 : CrossCuttingCorcernsFactory
{
    public override Caching CreateCaching()
    {
        return new RedisCache();
    }

    public override Logging CreateLogger()
    {
        return new NLogger();
    }
}

public class ProductManager {
    private CrossCuttingCorcernsFactory _crossCuttingCorcernsFactory;
    private Logging _logging;
    private Caching _caching;
    public ProductManager(CrossCuttingCorcernsFactory crossCuttingCorcernsFactory) {
        _crossCuttingCorcernsFactory = crossCuttingCorcernsFactory;
        _logging = _crossCuttingCorcernsFactory.CreateLogger();
        _caching = _crossCuttingCorcernsFactory.CreateCaching();
    }

    public void GetAll() {
        _logging.Log("Logged");
        _caching.Cache("Data");
        Console.WriteLine("Products Listed");
    }
}