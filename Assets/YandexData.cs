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
        PlayerAccount.SetPlayerData(JsonUtility.ToJson(this));
    }
}

public class YandexData : MonoBehaviour
{
    public Data Data { get; private set; }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        yield return new WaitUntil(() => YandexGamesSdk.IsInitialized == true && PlayerAccount.IsAuthorized);

        Data = new Data();
        GetData();
    }

    private void GetData()
    {
        PlayerAccount.GetPlayerData((data) =>
        {
            if (data != null || data != string.Empty || data.Length > 6)
            {
                Data = JsonUtility.FromJson<Data>(data);
            }
        });
    }
}
