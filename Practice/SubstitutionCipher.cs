using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SubstitutionCipher
    {
        public string decode(string a, string b, string y)
        {
            IDictionary<char, char> decryptionTable = GetDecryptionTable(a, b, GetEnglishAlphabet());

            var result = new StringBuilder();
            foreach(char c in y)
            {
                char x;
                if (decryptionTable.TryGetValue(c, out x))
                    result.Append(x);
                else
                    return string.Empty;
            }

            return result.ToString();
        }

        private IEnumerable<char> GetEnglishAlphabet()
        {
            var r = new List<char>();
            for(char c = 'A'; c <= 'Z'; c++)
            {
                r.Add(c);
            }

            return r;
        }

        private IDictionary<char, char> GetDecryptionTable(string a, string b, IEnumerable<char> allowableChars)
        {
            var table = new Dictionary<char, char>();

            for(int i = 0; i < a.Length; i++)
            {
                table[b[i]] = a[i];
            }

            if(table.Keys.Count == allowableChars.Count() -1) // edge case
            {
                char missingKey = allowableChars.Except(b).First();
                char missingValue = allowableChars.Except(a).First();

                table[missingKey] = missingValue;
            }

            return table;
        }
    }
}
