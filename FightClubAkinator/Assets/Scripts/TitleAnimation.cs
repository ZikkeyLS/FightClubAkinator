using System.Collections;
using TMPro;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay = 2;
    [SerializeField] private float _initial = -30;
    [SerializeField] private float _final = 0;
    [SerializeField] private float _speed = 1;

    private void Awake()
    {
        Run();
    }

    public void Run()
    {
        _text.characterSpacing = _initial;
        _text.maxVisibleLines = 0;

        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(_delay);
        _text.maxVisibleLines = int.MaxValue;

        float animSpeed = 0.1f;

        while (Mathf.Abs(_text.characterSpacing - _final) >= 0.1f)
        {
            _text.characterSpacing = Mathf.MoveTowards(_text.characterSpacing, _final, Time.deltaTime * _speed * animSpeed);
            animSpeed += 0.01f;
            animSpeed = animSpeed > 1 ? 1 : animSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
