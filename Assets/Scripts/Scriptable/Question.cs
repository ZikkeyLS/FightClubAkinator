using System;
using UnityEngine;

[Serializable]
public class Answer
{
    public string Text;
    public VariativeText NewText;
    public Character Character;
}

[CreateAssetMenu(fileName = "Question", menuName = "Game/Question")]
public class Question : ScriptableObject
{
    [Multiline] public string Text;
    public VariativeText NewText;
    public Answer[] Answers = new Answer[4];
}
