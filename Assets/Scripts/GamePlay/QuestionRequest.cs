using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionRequest : MonoBehaviour
{
    [SerializeField] private TMP_Text _questionNumber;
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private Button[] _answers;
    [SerializeField] private VariativeText _questionNumberText;
    private TMP_Text[] _answersText;

    public void MakeRequest(int id, Question question)
    {
        if(_answersText == null)
        {
            _answersText = new TMP_Text[_answers.Length];
            for (int i = 0; i < _answers.Length; i++)
                _answersText[i] = _answers[i].GetComponentInChildren<TMP_Text>();
        }

        _questionNumber.text = $"{_questionNumberText.GetText(YandexLanguage.Language)} {id}";
        _questionText.text = question.Text.GetText(YandexLanguage.Language);

        for (int i = 0; i < _answers.Length; i++)
            _answersText[i].text = question.Answers[i].Text.GetText(YandexLanguage.Language);
    }
}
