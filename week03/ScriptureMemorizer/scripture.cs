using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());

        foreach (Word word in _words)
        {
            Console.Write(word + " ");
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

        for (int i = 0; i < count; i++)
        {
            if (visibleWords.Count == 0)
                return;

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllHidden()
    {
        return _words.TrueForAll(w => w.IsHidden());
    }
}
