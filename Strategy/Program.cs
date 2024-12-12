namespace Strategy;

class Program
{
    static void Main(string[] args)
    {
       CustomerManager customerManager = new CustomerManager();
       customerManager.CreditCalculatorBase = new AfterPandemicCreditCalculator();
       customerManager.SaveCredit();
    }
}


abstract class CreditCalculatorBase {
    public abstract void Calculate();
}

class BeforePandemicCreditCalculator : CreditCalculatorBase
{
    public override void Calculate()
    {
         Console.WriteLine("Credit calculated before pandemic!");
    }
}

class AfterPandemicCreditCalculator : CreditCalculatorBase
{
    public override void Calculate()
    {
         Console.WriteLine("Credit calculated after pandemic!");
    }
}

class CustomerManager {
    public CreditCalculatorBase CreditCalculatorBase { get; set;}
    public void SaveCredit () {
        Console.WriteLine("CustomerManager business code");
        CreditCalculatorBase.Calculate();
    }

}