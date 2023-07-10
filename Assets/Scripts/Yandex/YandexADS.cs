using System.Collections;
using UnityEngine;
using Agava.YandexGames;

public class YandexADS : MonoBehaviour
{
    [SerializeField] private Music _music;

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
        InterstitialAd.Show(() => { _music.Stop(); }, (r) => { _music.Continue(); });
    }

   
}
