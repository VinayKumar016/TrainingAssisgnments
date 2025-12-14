using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrentCollections.SellShirts
{
    public static class Rnd
    {
        public static int NextInt(int max) => Random.Shared.Next(max);

        public static bool TrueWithProb(double probOfTrue)
            => Random.Shared.NextDouble() < probOfTrue;
    }

}
