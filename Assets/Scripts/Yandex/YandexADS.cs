using System.Collections;
using UnityEngine;
using Agava.YandexGames;

public class YandexADS : MonoBehaviour
{
    private IEnumerator Start()
    {
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
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif

        InterstitialAd.Show();
    }
}
