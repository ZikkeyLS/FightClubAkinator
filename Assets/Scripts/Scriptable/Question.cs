using System;
using UnityEngine;

[Serializable]
public class Answer
{
    public VariativeText Text;
    public Character Character;
}

[CreateAssetMenu(fileName = "Question", menuName = "Game/Question")]
public class Question : ScriptableObject
{
    public VariativeText Text;
    public Answer[] Answers = new Answer[4];
}
