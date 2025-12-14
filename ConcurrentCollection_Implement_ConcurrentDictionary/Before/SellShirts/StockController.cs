using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.ObjectModel;

namespace ConcurrentCollections.SellShirts
{
    public class StockController
    {
        private readonly ConcurrentDictionary<string, TShirt> _stock;

        public StockController(IEnumerable<TShirt> shirts)
        {
            _stock = new ConcurrentDictionary<string, TShirt>(
                shirts.ToDictionary(x => x.Code)
            );
        }

        public bool Sell(string code)
        {
            return _stock.TryRemove(code, out _);
        }

        public TShirt SelectRandomShirt()
        {
            var keys = _stock.Keys.ToList();
            if (keys.Count == 0)
                return null;

            Thread.Sleep(Random.Shared.Next(10));

            string selectedCode = keys[Random.Shared.Next(keys.Count)];

            return _stock.TryGetValue(selectedCode, out var shirt)
                ? shirt
                : null;
        }

        public void DisplayStock()
        {
            Console.WriteLine($"\r\n{_stock.Count} items left in stock:");
            foreach (var shirt in _stock.Values)
                Console.WriteLine(shirt);
        }
    }

}
