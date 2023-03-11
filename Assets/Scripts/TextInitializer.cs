using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class TextUnit
{
    public TMPro.TMP_Text Text;
    public VariativeText Content;
}

public class TextInitializer : MonoBehaviour
{
    [SerializeField] private TextUnit[] _units;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => YandexLanguage.Initialized == true);

        foreach (TextUnit unit in _units)
        {
            unit.Text.text = unit.Content.GetText(YandexLanguage.Language);
        }
    }
}
