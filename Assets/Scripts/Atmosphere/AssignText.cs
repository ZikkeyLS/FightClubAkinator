using UnityEngine;

public class AssignText : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private VariativeText _content;

    public void Assign(LanguageYandex language)
    {
        _text.text = _content.GetText(language);        
    }
}
