using UnityEngine;

public enum LanguageYandex
{
    ru = 0,
    en = 1,
    tr = 2
}

[CreateAssetMenu(fileName = "VariativeText", menuName = "Game/Text")]
public class VariativeText : ScriptableObject
{
    [Header("�������")] [InspectorName("")] [Multiline] [SerializeField] private string _ru;
    [Header("����������")] [InspectorName("")] [Multiline] [SerializeField] private string _en;
    [Header("��������")] [InspectorName("")] [Multiline] [SerializeField] private string _tr;

    public string GetText(LanguageYandex language) 
    {
        return language switch
        {
            LanguageYandex.ru => _ru,
            LanguageYandex.en => _en,
            LanguageYandex.tr => _tr,
            _ => _en,
        };
    }
}
