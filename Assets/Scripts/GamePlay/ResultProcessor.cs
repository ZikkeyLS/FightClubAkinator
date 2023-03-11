using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultProcessor : MonoBehaviour
{
    [SerializeField] private TMP_Text _info;
    [SerializeField] private Image _image;

    public void Initialize(Character character)
    {
        _info.text = $"{character.CharacterName}\n{GetClassification(character.PersonalityType)}\n{character.Description}";
        _image.sprite = character.CharacterImage;
    }

    public string GetClassification(PersonalityType personality)
    {
        switch (personality)
        {
            case PersonalityType.Alpha:
                return "Альфа";
            case PersonalityType.Beta:
                return "Бета";
            case PersonalityType.Sigma:
                return "Сигма";
            case PersonalityType.Omega:
                return "Омега";
            default:
                return "Неизвестно";
        }
    }
}
