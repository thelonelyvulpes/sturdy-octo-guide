namespace CreateKnowledgeGraph;

public static class LoadForm10KSamples
{
    public static async Task<List<EdgarForm10K>> LoadAsync()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "single", "form10k",
            "0000950170-23-027948.json");

        var singleForm = await EdgarForm10K.LoadAsync(filePath);
        
        if (singleForm != null)
            return [singleForm];

        return [];
    }
}