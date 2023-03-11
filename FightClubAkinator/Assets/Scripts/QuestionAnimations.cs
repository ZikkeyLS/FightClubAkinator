using UnityEngine;

public class QuestionAnimations : MonoBehaviour
{
    [SerializeField] private ChangeTransparancy _changeTransparancy;
    [SerializeField] private TitleAnimation[] _titleAnimations;
    
    public void Run()
    {
        _changeTransparancy.Run();
        for (int i = 0; i < _titleAnimations.Length; i++)
            _titleAnimations[i].Run();
    }
}
