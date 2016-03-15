using System;
using System.Collections.Generic;
using System.Linq;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SRMCards
    {
        public int maxCards(int[] cards)
        {
            Array.Sort(cards);
            LinkedList<int> cardInfos = new LinkedList<int>(cards);

            int turns = 0;
            while (cardInfos.Any())
            {
                LinkedListNode<int> optimalNode = FindMinNode(cardInfos, node => GetCardGroup(node).Count());
                var cardGroup = GetCardGroup(optimalNode).ToArray();

                foreach (var cardNode in cardGroup)
                    cardInfos.Remove(cardNode);

                turns++;
            }

            return turns;
        }

        internal static IEnumerable<LinkedListNode<int>> GetCardGroup(LinkedListNode<int> cardNode)
        {
            var Next = cardNode.Next;
            var Prev = cardNode.Previous;

            yield return cardNode;

            if (Next != null && Next.Value == cardNode.Value + 1)
                yield return Next;

            if (Prev != null && Prev.Value == cardNode.Value - 1)
                yield return Prev;
        }

        internal static LinkedListNode<T> FindMinNode<T>(LinkedList<T> list, Func<LinkedListNode<T>, int> Metric) where T : IComparable<T>
        {
            LinkedListNode<T> minNode = null;
            LinkedListNode<T> node = list.First;

            while (node != null)
            {
                if (minNode == null || (Metric(node) - Metric(minNode) <= 0))
                    minNode = node;

                node = node.Next;
            }

            return minNode;
        }
    }
}
