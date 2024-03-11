
namespace CreateKnowledgeGraph
{
  using System;
    using System.Globalization;
    using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
    using CsvHelper;
    using CsvHelper.Configuration.Attributes;

    public partial class EdgarForm13
  {

    [Name("source")]
    public string Source { get; set; }

    [Name("managerCik")]
    public string ManagerCik { get; set; }

    [Name("managerAddress")]
    public string ManagerAddress { get; set; }

    [Name("managerName")]
    public string ManagerName { get; set; }

    [Name("reportCalendarOrQuarter")]
    public string ReportCalendarOrQuarter { get; set; }


    [Name("cusip")]
    public string Cusip { get; set; }

    [Name("cusip6")]
    public string Cusip6 { get; set; }

    [Name("companyName")]
    public string CompanyName { get; set; }

    [Name("value")]
    public float Value { get; set; }

    [Name("shares")]
    public int Shares { get; set; } 

    public void Show()
    {
      Console.WriteLine($"Source: {Source}");
      Console.WriteLine($"ManagerName: {ManagerName}");
      Console.WriteLine($"ManagerCik: {ManagerCik}");
      Console.WriteLine($"Cusip6: {Cusip6}");
      Console.WriteLine($"Cusip: {Cusip}");
      Console.WriteLine($"CompanyName: {CompanyName}");
      Console.WriteLine($"Value: {Value}");
      Console.WriteLine($"Shares: {Shares}");
    }
  }


  public partial class EdgarForm13
  {
    public static List<EdgarForm13> Load(string filePath)
    {
      using (var reader = new StreamReader(filePath))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
          var records = csv.GetRecords<EdgarForm13>();
          return records.ToList();
      }
    }
  }

}
