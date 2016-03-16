using System;
using System.Collections.Generic;
using System.Linq;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SRMCards
    {
        public int maxTurns(int[] cards)
        {
            return maxTurns(new HashSet<int>(cards));
        }

        private static int maxTurns(ISet<int> cards)
        {
            int turns = 0;
            while (cards.Any())
            {
                int optimalCard = FindMin(cards, c => GetCardGroup(c, cards).Count());
                cards.ExceptWith(GetCardGroup(optimalCard, cards));
                turns++;
            }

            return turns;
        }

        internal static IEnumerable<int> GetCardGroup(int card, ISet<int> cardSet)
        {
            var group = new List<int>();

            group.Add(card);

            if (cardSet.Contains(card + 1))
                group.Add(card + 1);

            if (cardSet.Contains(card - 1))
                group.Add(card - 1);

            return group;
        }

        internal static T FindMin<T, U>(IEnumerable<T> collection, Func<T, U> GetMetric) where U : IComparable<U>
        {
            T min = collection.First();

            foreach(T item in collection)
            {
                if (GetMetric(item).CompareTo(GetMetric(min)) <= 0)
                    min = item;
            }

            return min;
        }
    }
}
