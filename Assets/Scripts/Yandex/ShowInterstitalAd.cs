using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowInterstitalAd : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private YandexADS _ads;
    [SerializeField] private YandexData _data;

    void Start()
    {
        _button.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        ChangeContext();
        ChangeScene();
    }

    public void ChangeContext()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif
        if (_data.Data.FirstGame)
        {
            YandexGamesSdk.RateGame();
            _data.Data.SetFirstGame(false);
        }
        else
        {
            _ads.ShowInterstitialAd();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
