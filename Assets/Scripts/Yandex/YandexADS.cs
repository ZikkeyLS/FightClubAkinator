using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using System.Collections.Generic;

public class YandexADS : MonoBehaviour
{
    private IEnumerator Start()
    {
        DontDestroyOnLoad(this);
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        if (YandexGamesSdk.IsInitialized)
            yield break;

        // Always wait for it if invoking something immediately in scene.
        yield return YandexGamesSdk.Initialize();

        StickyAd.Show();
    }

    public void ShowInterstitialAd()
    {
        InterstitialAd.Show();
    }
}
