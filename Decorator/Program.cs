﻿namespace Decorator;

class Program
{
    static void Main(string[] args)
    {
       var personelCar = new PersonelCar { Make = "Honda" ,Model = "Cordcord", HirePrice = 3500};
       SpecialOffer specialOffer = new SpecialOffer(personelCar);
       specialOffer.DiscountPercertage = 10;
       
       Console.WriteLine("Concrete {0}", personelCar.HirePrice);
       Console.WriteLine("SpecialOffer {0}", specialOffer.HirePrice);
    }
}


abstract class CarBase {
    public abstract string Make { get; set; }
    public abstract string Model { get; set; }
    public abstract decimal HirePrice { get; set; }

}

class PersonelCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}

class CommercialCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}


abstract class CarDecoratorBase : CarBase {
    private CarBase _carBase;
    protected CarDecoratorBase(CarBase carBase) {
        _carBase = carBase;
    }
}

class SpecialOffer : CarDecoratorBase
{
    private readonly CarBase _carBase;
    public int DiscountPercertage;

    public SpecialOffer(CarBase carBase) : base(carBase)
    {
        _carBase = carBase;
    }
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice {
        get {
            return _carBase.HirePrice - (_carBase.HirePrice * DiscountPercertage / 100);
        }
        set {

        }
    }
}