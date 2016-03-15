using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SRMCards
    {
        public int maxCards(int[] cards)
        {
            return maxCards(new HashSet<int>(cards));
        }

        internal int maxCards(ISet<int> cards)
        {
            if (!cards.Any())
                return 0;
            else
                return -1;
        }

        internal IEnumerable<int> GroupOf(int card, ISet<int> cards)
        {
            yield return card;

            if (cards.Contains(card - 1))
                yield return card - 1;

            if (cards.Contains(card + 1))
                yield return card + 1;
        }
    }
}
