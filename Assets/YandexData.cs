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
        // PlayerAccount.SetPlayerData(JsonUtility.ToJson(this));
    }
}

public class YandexData : MonoBehaviour
{
    public Data Data { get; private set; }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => YandexGamesSdk.IsInitialized == true);

        Data = new Data();

      //  if (PlayerAccount.IsAuthorized == false)
      //      PlayerAccount.Authorize(GetData);
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
