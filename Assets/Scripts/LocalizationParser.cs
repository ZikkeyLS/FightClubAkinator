
using System.Collections.Generic;
using UnityEngine;

public class TemplateAnswer
{
    public string Data;
    public FilmCharacter Character;

    public static Dictionary<FilmCharacter, int> Analytics = new Dictionary<FilmCharacter, int>();

    public TemplateAnswer(string value)
    {
        string[] parsedData = value.Split("(");
        parsedData[1].Replace(")", "");

        Data = parsedData[0];
        FilmCharacter character = GetFilmCharacter(parsedData[1]);
        if (Analytics.ContainsKey(character))
        {
            Analytics[character] += 1;
        }
        else
        {
            Analytics.Add(character, 0);
        }

        Character = character;
    }

    public FilmCharacter GetFilmCharacter(string characterUnparsed)
    {
        if (characterUnparsed.Contains("Рассказч"))
            return FilmCharacter.Narrator;
        else if (characterUnparsed.Contains("Марл"))
            return FilmCharacter.Marla;
        else if (characterUnparsed.Contains("Тайлер"))
            return FilmCharacter.Tyler;
        else if (characterUnparsed.Contains("Рэймонд"))
            return FilmCharacter.RaymondKHessel;
        else if (characterUnparsed.Contains("Ричард"))
            return FilmCharacter.RichardChesler;
        else if (characterUnparsed.Contains("Роберт"))
            return FilmCharacter.RobertPaulson;
        else if (characterUnparsed.Contains("Ангел"))
            return FilmCharacter.AngelFace;
        else if (characterUnparsed.Contains("Детектив"))
            return FilmCharacter.DetectiveStern;
        else
        {
            Debug.Log($"Unknown: {characterUnparsed}");
            return FilmCharacter.Tyler;
        }
    }
}

public class TemplateQuestion
{
    public string Question;
    public TemplateAnswer[] Answers = new TemplateAnswer[4];
    
    public TemplateQuestion(string question, params string[] answers)
    {
        Question = question;

        for (int i = 0; i < answers.Length; i++)
        {
            Answers[i] = new TemplateAnswer(answers[i]);
        }
    }
}

public class LocalizationParser
{
    private List<TemplateQuestion> _questions = new List<TemplateQuestion>();
    public int QuestionCount => _questions.Count;
    public TemplateQuestion GetQuestionByIndex(int index) => _questions[index];

    public LocalizationParser(string fileName)
    {
        TextAsset txt = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
        List<string> lines = new List<string>(txt.text.Split('\n'));

        for (int i = 1; i < lines.Count; i += 6)
        {
            _questions.Add(new TemplateQuestion(lines[i], lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4]));
        }

        foreach (KeyValuePair<FilmCharacter, int> value in TemplateAnswer.Analytics)
        {
            // Debug.Log(value.Key + " " + value.Value);
        }
    }
}