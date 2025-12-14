using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrentCollections.SellShirts
{
	class Program
	{
        static void Main(string[] args)
{
    StockController controller = new StockController(TShirtProvider.AllShirts);
    TimeSpan workDay = TimeSpan.FromMilliseconds(500);

    var salesPeople = new[]
    {
        new SalesPerson("Divya"),
        new SalesPerson("Hitha"),
        new SalesPerson("Vinay"),
        new SalesPerson("Sam")
    };

    var tasks = new List<Task>();

    foreach (var person in salesPeople)
    {
        tasks.Add(Task.Run(() => person.Work(workDay, controller)));
    }

    Task.WaitAll(tasks.ToArray());

    controller.DisplayStock();
}

    }
}
