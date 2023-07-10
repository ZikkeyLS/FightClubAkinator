using Agava.YandexGames;
using UnityEngine;

public class EnterAccount : MonoBehaviour
{
    public void Login()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif
        if (YandexGamesSdk.IsInitialized && PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }
    }
}
