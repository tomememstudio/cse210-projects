using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What moment today made you pause and really notice your surroundings?",
        "What is something you avoided today, and why do you think that is?",
        "What thought kept returning to your mind today?",
        "When did you feel most like yourself today?",
        "What is one small win you experienced today, even if no one else noticed it?",
        "What drained your energy today, and what gave you energy?",
        "What conversation today stayed with you after it ended?",
        "What belief about yourself was challenged today?",
        "What are you grateful for today that you usually overlook?",
        "What emotion did you feel but did not express today?",
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "What challenged you emotionally today?",
        "What did you learn about yourself today?",
        "Write what is on your mind."
    };
    public string GetPrompt()
    {
        if (_prompts.Count == 1)
        {
            return _prompts[0];
        }
        Random random = new Random();
        int index = random.Next(_prompts.Count - 1);

        string prompt = _prompts[index];
        _prompts.RemoveAt(index);

        return prompt;
    }
}