using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
        random = new Random();
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{reference.GetReferenceText()} - {string.Join(" ", words.Select(w => w.GetDisplayText()))}";
    }
}
