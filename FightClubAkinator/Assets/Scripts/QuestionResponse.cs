using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestionResponse : MonoBehaviour
{
    [SerializeField] private QuestionProcessor _processor;
    [SerializeField] private QuestionAnimations _animations;
    [SerializeField] private Button[] _answers;

    public void OnEnable()
    {
        for (int i = 0; i < _answers.Length; i++)
            _answers[i].onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _answers.Length; i++)
            _answers[i].onClick.RemoveAllListeners();
    }

    public void OnClick()
    {
        _processor.WriteAnswer(GetClickedButtonIndex());

        if (_processor.UpdateQuestion())
            _animations.Run();
    }

    public int GetClickedButtonIndex()
    {
        GameObject clickedObject = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < _answers.Length; i++)
            if (_answers[i].gameObject == clickedObject)
                return i;

        return -1;
    }
}
