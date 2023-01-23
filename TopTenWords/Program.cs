using System;
using System.Linq;
using System.Text;

namespace TopTenWords;

internal class Program
{
   private static void Main(string[] args)
   {
      string text = File.ReadAllText(@"C:/Programming/csproj/CsHomeworkCollections/Book.txt");

      string noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

      Console.OutputEncoding = Encoding.Unicode;

      var orderedWords = noPunctuationText
      .Split()
      .GroupBy(x => x)
      .Select(x => new {
         KeyField = x.Key,
         Count = x.Count()
      })
      .OrderByDescending(x => x.Count)
      .Take(10);

      foreach (var word in orderedWords) {
         Console.WriteLine(word);
      }
   }
}