
namespace CreateKnowledgeGraph
{
  using System;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;

  public partial class EdgarForm10K
  {
    [JsonPropertyName("item1")]
    public string Item1 { get; set; }

    [JsonPropertyName("item1a")]
    public string Item1A { get; set; }

    [JsonPropertyName("item7")]
    public string Item7 { get; set; }

    [JsonPropertyName("item7a")]
    public string Item7A { get; set; }

    [JsonPropertyName("cik")]
    public string Cik { get; set; }

    [JsonPropertyName("cusip6")]
    public string Cusip6 { get; set; }

    [JsonPropertyName("cusip")]
    public string[] Cusip { get; set; }

    [JsonPropertyName("names")]
    public string[] Names { get; set; }

    [JsonPropertyName("source")]
    public Uri Source { get; set; }

    private string SampleText(string text)
    {
      string sampleText = (text != null) ? text.Substring(0, Math.Min(text.Length, 80)) : "";
      return Regex.Replace(sampleText, @"\s+", " ");
    }

    private string ArrayToString(string[] array)
    {
      return (array != null) ? string.Join(", ", array) : "";
    }

    public void Show()
    {
      Console.WriteLine($"Names: {ArrayToString(Names)}");
      Console.WriteLine($"Source: {Source}");
      Console.WriteLine($"Item1: {SampleText(Item1)}");
      Console.WriteLine($"Item1A: {SampleText(Item1A)}");
      Console.WriteLine($"Item7: {SampleText(Item7)}");
      Console.WriteLine($"Item7A: {SampleText(Item7A)}");
      Console.WriteLine($"Cik: {Cik}");
      Console.WriteLine($"Cusip6: {Cusip6}");
      Console.WriteLine($"Cusip: {ArrayToString(Cusip)}");
    }
  }


  public partial class EdgarForm10K
  {
    public static EdgarForm10K? Load(string filePath)
    {
      using (StreamReader r = new StreamReader(filePath))
      {
        string json = r.ReadToEnd();
        
        return JsonSerializer.Deserialize<EdgarForm10K>(json);
      }

    }
  }

}
