namespace CreateKnowledgeGraph;

public class Program
{
    public static async Task Main()
    {
        // EdgarForm10K? single = SingleFile.Load();
        // if (single != null) { single.Show(); }

        var form10Ks = await LoadForm10KSamples.LoadAsync();
        foreach (var form10K in form10Ks)
        {
            // print a header before showing the form
            Console.WriteLine(new string('-', 80));
            Console.WriteLine(form10K);
        }

        var form13s = await EdgarForm13.LoadAsync("data/single/form13.csv");
        foreach (var form13 in form13s.Take(10))
        {
            // print a header before showing the form
            Console.WriteLine(new string('-', 80));
            Console.WriteLine(form13);
        }
    }
}