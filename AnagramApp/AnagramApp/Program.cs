using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var anagramBL = new AnagramBL();
            var displayBL = new DisplayBl();

            var words = File.ReadAllLines("input.txt").ToList();

            var allAnagramLists = anagramBL.FindAllAnagramLists(words, new List<List<string>>());

            var longestWordAnagrams = anagramBL.FindLongestWordAnagram(allAnagramLists);
            var mostWordAnagrams = anagramBL.FindMostWordAnagram(allAnagramLists);

            Console.WriteLine();
            Console.WriteLine("result: ");
            Console.WriteLine();
            Console.WriteLine(displayBL.PrepareAnagramListsToDisplay(allAnagramLists));
            Console.WriteLine();
            Console.WriteLine("longest words anagram:");
            Console.WriteLine();
            Console.WriteLine(displayBL.PrepareAnagramListsToDisplay(longestWordAnagrams));
            Console.WriteLine();
            Console.WriteLine("most words anagram:");
            Console.WriteLine();
            Console.WriteLine(displayBL.PrepareAnagramListsToDisplay(mostWordAnagrams));
            Console.ReadLine();
        }
    }
}
