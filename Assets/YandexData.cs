using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Data
{
    public bool FirstGame { get; private set; } = true;

    public void SetFirstGame(bool value)
    {
        FirstGame = value;
    }
}

public class YandexData : MonoBehaviour
{
    public Data Data { get; private set; }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        Data = new Data();
        yield break;
#endif
        yield return new WaitUntil(() => YandexGamesSdk.IsInitialized == true);

        Data = new Data();
    }
}
