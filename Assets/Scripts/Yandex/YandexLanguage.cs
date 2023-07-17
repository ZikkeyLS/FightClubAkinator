using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class YandexLanguage : MonoBehaviour
{
    [SerializeField] private TextInitializer _textInitializer;

#if !UNITY_WEBGL || UNITY_EDITOR
    [SerializeField] private LanguageYandex _testLanguage = LanguageYandex.en;
#endif

    public static LanguageYandex Language = LanguageYandex.en;
    public static bool Initialized = false;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        Language = _testLanguage;
        Initialized = true;
        yield break;
#endif
        Initialized = false;
        yield return new WaitUntil(() => YandexGamesSdk.IsInitialized == true);

        switch (YandexGamesSdk.Environment.i18n.lang.ToLower())
        {
            case "ru":
                Language = LanguageYandex.ru;
                break;
            case "en":
                Language = LanguageYandex.en;
                break;
            case "tr":
                Language = LanguageYandex.tr;
                break;
        }

        Initialized = true;
    }
}
