using System;
using System.Collections.Generic;
using System.Linq;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SRMCards
    {
        public int maxTurns(int[] cards)
        {
            Array.Sort(cards);
            LinkedList<int> cardInfos = new LinkedList<int>(cards);

            int turns = 0;
            while (cardInfos.Any())
            {
                LinkedListNode<int> optimalNode = FindMinNode(cardInfos, node => GetCardGroup(node).Count());

                foreach (var cardNode in GetCardGroup(optimalNode))
                    cardInfos.Remove(cardNode);

                turns++;
            }

            return turns;
        }

        internal static IEnumerable<LinkedListNode<int>> GetCardGroup(LinkedListNode<int> cardNode)
        {
            var group = new List<LinkedListNode<int>>();

            group.Add(cardNode);

            if (cardNode.Next != null && cardNode.Next.Value == cardNode.Value + 1)
                group.Add(cardNode.Next);

            if (cardNode.Previous != null && cardNode.Previous.Value == cardNode.Value - 1)
                group.Add(cardNode.Previous);

            return group;
        }

        internal static LinkedListNode<T> FindMinNode<T>(LinkedList<T> list, Func<LinkedListNode<T>, int> GetMetric) where T : IComparable<T>
        {
            LinkedListNode<T> minNode = null;
            LinkedListNode<T> node = list.First;

            while (node != null)
            {
                if (minNode == null || (GetMetric(node) - GetMetric(minNode) <= 0))
                    minNode = node;

                node = node.Next;
            }

            return minNode;
        }
    }
}
