using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class TextUnit
{
    public TMPro.TMP_Text Text;
    public VariativeText Content;
}

public class TextInitializer : MonoBehaviour
{
    [SerializeField] private TextUnit[] _units;
    [SerializeField] private string _russianLocalizationName = "FightClubRU";

    public static LocalizationParser _russianLocalization;
    public static int QuestionCount => _russianLocalization.QuestionCount;
    // public LocalizationParser _englishLocalization;
    // public LocalizationParser _turkishLocalization;

    public static TemplateQuestion GetProperQuestionData(int questionIndex)
    {
        return _russianLocalization.GetQuestionByIndex(questionIndex);
    }

    private void Awake()
    {
        _russianLocalization = new LocalizationParser(_russianLocalizationName);
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => YandexLanguage.Initialized == true);

        foreach (TextUnit unit in _units)
            unit.Text.text = unit.Content.GetText(YandexLanguage.Language);
    }
}
