using System.Collections;
using UnityEngine;

public class EnableDelay : MonoBehaviour
{
    [SerializeField] private float _delayInSeconds = 2;
    [SerializeField] private MonoBehaviour[] _elements;

    private void Awake()
    {
        foreach (MonoBehaviour component in _elements)
            component.enabled = false;

        StartCoroutine(LoadAfterDelay());
    }

    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(_delayInSeconds);

        foreach (MonoBehaviour component in _elements)
            component.enabled = true;
    }
}
