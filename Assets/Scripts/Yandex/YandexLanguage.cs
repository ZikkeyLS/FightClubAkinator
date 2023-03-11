using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class YandexLanguage : MonoBehaviour
{
    [SerializeField] private TextInitializer _textInitializer;

    public static LanguageYandex Language = LanguageYandex.ru;

    public static bool Initialized = false;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
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
        }

        Initialized = true;
    }

}
