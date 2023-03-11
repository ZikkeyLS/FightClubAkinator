using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTransparancy : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private Image[] _images;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] [Range(0, 1)] private float _initialTransparancy;
    [SerializeField][Range(0, 1)] private float _finalTransparancy;

    private bool work = false;

    private void Start()
    {
        Run();
    }

    public void Run()
    {
        foreach (TMP_Text text in _texts)
        {
            Color final = text.color;
            final.a = 0;
            text.color = final;
        }

        foreach (Image image in _images)
        {
            Color final = image.color;
            final.a = 0;
            image.color = final;
        }

        StartCoroutine(CompleteDelay());
    }

    private IEnumerator CompleteDelay()
    {
        yield return new WaitForSeconds(_delay);
        work = true;
    }

    private void Update()
    {
        if (!work)
            return;

        int completed = 0;

        foreach (TMP_Text text in _texts)
        {
            Color final = text.color;
            final.a = Mathf.MoveTowards(final.a, 1, Time.deltaTime * _speed);
            text.color = final;

            if (final.a == 1)
                completed += 1;
        }

        foreach (Image image in _images)
        {
            Color final = image.color;
            final.a = Mathf.MoveTowards(final.a, 1, Time.deltaTime * _speed);
            image.color = final;

            if (final.a == 1)
                completed += 1;
        }

        if (completed == _texts.Length + _images.Length)
            work = false;
    }
}
