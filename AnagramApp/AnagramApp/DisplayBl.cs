using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramApp
{
    public class DisplayBl
    {
        public string PrepareAnagramListsToDisplay(List<List<string>> allAnagramLists)
        {
            var sortedResult = allAnagramLists.OrderByDescending(x => x.Count);

            var stringBuilder = new StringBuilder();

            foreach (var list in sortedResult)
            {
                foreach (var word in list)
                {
                    stringBuilder.Append(word + " ");
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
