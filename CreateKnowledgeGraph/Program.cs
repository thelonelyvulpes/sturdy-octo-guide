
namespace CreateKnowledgeGraph
{
  using System;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;


  public class Program
  {
    public static void Main()
    {
      // EdgarForm10K? single = SingleFile.Load();
      // if (single != null) { single.Show(); }

      List<EdgarForm10K> form10Ks = LoadForm10KSamples.Load();
      foreach (EdgarForm10K form10K in form10Ks)
      {
        // print a header before showing the form
        Console.WriteLine(new string('-', 80));
        Console.WriteLine($"Form 10-K {form10K.Source}...");
        form10K.Show();
      }

      var form13s = EdgarForm13.Load("data/single/form13.csv");
      foreach (EdgarForm13 form13 in form13s.Take(10))
      {
        // print a header before showing the form
        Console.WriteLine(new string('-', 80));
        Console.WriteLine($"Form 13 {form13.Source}...");
        form13.Show();
      }
    }
  }
}
