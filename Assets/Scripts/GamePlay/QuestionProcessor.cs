using System.Collections.Generic;
using UnityEngine;

public class QuestionProcessor : MonoBehaviour
{
    [SerializeField] private QuestionRequest _request;
    [SerializeField] private Character[] _characters;
    [SerializeField] private Question[] _questions;
    [SerializeField] private ResultProcessor _result;
    [SerializeField] private GameObject _previousPanel;
    [SerializeField] private GameObject _nextPanel;
    private Character[] _answers;

    private int _questionIndex = -1;

    public Question Current { get; private set; }

    public void OnEnable()
    {
        _answers = new Character[_questions.Length];
        UpdateQuestion();
    }

    public bool UpdateQuestion()
    {
        if(_questionIndex == _questions.Length - 1)
        {
            Dictionary<Character, int> values = new Dictionary<Character, int>();
            int mainIndex = 0;
            Character mainCharacter = null;

            for (int i = 0; i < _answers.Length; i++)
            {
                if (values.ContainsKey(_answers[i]) == false)
                    values.Add(_answers[i], 1);
                else
                    values[_answers[i]] = values[_answers[i]] + 1;

                if (mainIndex <= values[_answers[i]])
                {
                    mainIndex = values[_answers[i]];
                    mainCharacter = _answers[i];
                }
            }

            _previousPanel.SetActive(false);
            _nextPanel.SetActive(true);
            _result.Initialize(mainCharacter);
            return false;
        }

        _questionIndex += 1;
        _request.MakeRequest(_questionIndex + 1, _questions[_questionIndex]);
        return true;
    }

    public void WriteAnswer(int answerIndex)
    {
        _answers[_questionIndex] = _questions[_questionIndex].Answers[answerIndex].Character;
    }
}
