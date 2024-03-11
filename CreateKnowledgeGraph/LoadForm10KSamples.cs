
namespace CreateKnowledgeGraph
{
  using System;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
    public class LoadForm10KSamples
  {
    public static List<EdgarForm10K> Load()
    {
      List<EdgarForm10K> form10Ks = new List<EdgarForm10K>();

      string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "single", "form10k", "0000950170-23-027948.json");

      EdgarForm10K? singleForm = EdgarForm10K.Load(filePath);

      if (singleForm != null)
      {
        form10Ks.Add(singleForm);
      }

      return form10Ks;

    }
  }
}
