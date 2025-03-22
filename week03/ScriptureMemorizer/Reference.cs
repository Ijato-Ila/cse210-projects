using System;

class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int? endVerse; // Nullable to handle single or multiple verses

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetReferenceText()
    {
        return endVerse == null
            ? $"{book} {chapter}:{startVerse}"
            : $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}
