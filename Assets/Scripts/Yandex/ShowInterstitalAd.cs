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
        _button.onClick.AddListener(() => 
        {
            if (_data.Data.FirstGame)
            {
                YandexGamesSdk.RateGame();
                _data.Data.SetFirstGame(false);
            }
            else
            {
                _ads.ShowInterstitialAd();
            }

            Restart();
        });
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
