using UnityEngine;

public enum FilmCharacter : byte
{
    Narrator = 0,
    Tyler,
    Marla,
    AngelFace,
    DetectiveStern,
    RaymondKHessel,
    RichardChesler,
    RobertPaulson
}

public enum PersonalityType : byte
{
    Sigma = 0,
    Alpha,
    Beta,
    Omega
}

[CreateAssetMenu(fileName = "FilmCharacter", menuName = "Game/Character")]
public class Character : ScriptableObject
{
    public FilmCharacter FilmCharacter;
    public string CharacterName;
    public PersonalityType PersonalityType;
    public Sprite CharacterImage;
    [Multiline] public string Description;
}
