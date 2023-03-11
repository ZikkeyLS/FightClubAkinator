using UnityEngine;
using UnityEngine.UI;

public class ShowNextMenu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject oldMenu;
    [SerializeField] private GameObject newMenu;

    public void Awake()
    {
        _button.onClick.AddListener(ShowNewMenu);
    }

    public void ShowNewMenu()
    {
        oldMenu.SetActive(false);
        newMenu.SetActive(true);
    }
}
