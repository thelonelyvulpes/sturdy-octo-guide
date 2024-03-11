namespace CreateKnowledgeGraph;

public static class SingleFile
{
    public static Task<EdgarForm10K?> Load()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "single", "form10k",
            "0000950170-23-027948.json");

        return EdgarForm10K.LoadAsync(filePath);
    }
}