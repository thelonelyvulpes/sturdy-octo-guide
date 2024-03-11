
namespace CreateKnowledgeGraph
{
  using System;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
    public class SingleFile
  {
    public static EdgarForm10K? Load()
    {
      string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "single", "form10k", "0000950170-23-027948.json");

      return EdgarForm10K.Load(filePath);

    }
  }
}
