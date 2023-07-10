using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwiper : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Toggle _animate;
    [SerializeField] private Sprite[] _images;
    [SerializeField] private float _delay = 10f;
    [SerializeField] private float _swipeAnimationTime = 4f;

    private static bool LastAnimate = true;

    private void Awake()
    {
        _animate.isOn = LastAnimate;
        _animate.onValueChanged.AddListener((value) => { LastAnimate = _animate.isOn; });
        StartCoroutine(ChangeImage(0));
    }

    private IEnumerator ChangeImage(int nextIndex)
    {
        while (nextIndex != -1)
        {
            yield return new WaitForSeconds(_delay);
            nextIndex = nextIndex >= _images.Length - 1 ? 0 : nextIndex + 1;
            if (_animate.isOn)
                StartCoroutine(PlaySwipeAnimation(nextIndex));
            else
                ApplyImage(nextIndex);
        }
    }

    private void ApplyImage(int index)
    {
        _background.sprite = _images[index];
    }

    private IEnumerator PlaySwipeAnimation(int index)
    {
        float initial = _swipeAnimationTime / 2;
        float current = _swipeAnimationTime;

        while (current > 0)
        {
            current -= Time.deltaTime;
            Color finalColor = _background.color;
            finalColor.a = current / initial;
            _background.color = finalColor;
            
            yield return new WaitForEndOfFrame();
        }

        ApplyImage(index);

        while (current <= initial)
        {
            current += Time.deltaTime;
            Color finalColor = _background.color;
            finalColor.a = current / initial;
            _background.color = finalColor;

            yield return new WaitForEndOfFrame();
        }
    }
}
