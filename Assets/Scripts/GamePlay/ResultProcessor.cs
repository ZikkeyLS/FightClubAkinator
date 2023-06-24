using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultProcessor : MonoBehaviour
{
    [SerializeField] private TMP_Text _info;
    [SerializeField] private Image _image;

    [Header("Classifications")]
    [SerializeField] private VariativeText _alpha;
    [SerializeField] private VariativeText _beta;
    [SerializeField] private VariativeText _sigma;
    [SerializeField] private VariativeText _omega;

    public void Initialize(Character character)
    {
        _info.text = $"{character.CharacterName.GetText(YandexLanguage.Language)}\n" +
            $"{GetClassification(character.PersonalityType)}" +
            $"\n{character.Description.GetText(YandexLanguage.Language)}";
        _image.sprite = character.CharacterImage;
    }

    public string GetClassification(PersonalityType personality)
    {
        switch (personality)
        {
            case PersonalityType.Alpha:
                return _alpha.GetText(YandexLanguage.Language);
            case PersonalityType.Beta:
                return _beta.GetText(YandexLanguage.Language);
            case PersonalityType.Sigma:
                return _sigma.GetText(YandexLanguage.Language);
            case PersonalityType.Omega:
                return _omega.GetText(YandexLanguage.Language);
            default:
                return "Unknown";
        }
    }
}
