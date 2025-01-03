﻿namespace DependencyInjection;

using Ninject;

class Program
{
    static void Main(string[] args)
    {
        IKernel kernel = new StandardKernel();
        kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

        ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
        //ProductManager productManager = new ProductManager(new EfProductDal());
        productManager.Save();
        
    }
}

interface IProductDal {
    void Save();
}
class EfProductDal: IProductDal {
    public void Save() {
        Console.WriteLine("Saved with EF");
    }
}

class NhProductDal: IProductDal {
    public void Save() {
        Console.WriteLine("Saved with Nhibernate");
    }
}

class ProductManager {
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void Save() {
        
        _productDal.Save();
    }
}