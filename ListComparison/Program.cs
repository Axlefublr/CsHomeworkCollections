using System.Diagnostics;

namespace ListComparison;

internal class Program
{
   private static void Main(string[] args)
   {
      string text = File.ReadAllText(@"C:/Programming/csproj/CsHomeworkCollections/Book.txt");
      string[] words = text.Split();

      Stopwatch listStopwatch = new();
      listStopwatch.Start();

      List<string> listedWords = new();
      foreach (string word in words) {
         listedWords.Add(word);
      }

      listStopwatch.Stop();

      Stopwatch linkedStopwatch = new();
      linkedStopwatch.Start();

      LinkedList<string> linkedWords = new();
      foreach (string word in words) {
         linkedWords.AddLast(word);
      }

      linkedStopwatch.Stop();

      TimeSpan listTimespan = listStopwatch.Elapsed;

      string listTime = string.Format("{0:00}:{1:00}.{2:00}",
         listTimespan.Minutes,
         listTimespan.Seconds,
         listTimespan.Milliseconds
      );
      Console.WriteLine(listTime); // 2 ms

      TimeSpan linkedTimespan = linkedStopwatch.Elapsed;

      string linkedTime = string.Format("{0:00}:{1:00}.{2:00}",
         linkedTimespan.Minutes,
         linkedTimespan.Seconds,
         linkedTimespan.Milliseconds
      );
      Console.WriteLine(linkedTime); // 20 ms

      // LinkedList медленнее List
   }
}