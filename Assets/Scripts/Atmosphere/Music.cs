using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Music : MonoBehaviour
{
    [Serializable]
    public class AudioElement
    {
        public AudioClip clip;
        public float volume = 0.09f;
    }

    [SerializeField] private AudioSource _audioPlayer;
    [SerializeField] private AudioElement[] _music;
    [SerializeField] private Slider _modifier;

    private bool _stop = false;
    private int _index = 0;

    private static float ModifierValue = 0.5f;

    private void Awake()
    {
        _modifier.value = ModifierValue;
        _modifier.onValueChanged.AddListener((value) => 
        {
            ModifierValue = _modifier.value;
            _audioPlayer.volume = _music[_index].volume * (_modifier.value / _modifier.maxValue); 

        });  
    }

    private void Update()
    {
        if (_audioPlayer.isPlaying == false && _stop == false && Application.isFocused)
        {
            _audioPlayer.clip = _music[_index].clip;
            _audioPlayer.volume = _music[_index].volume * (_modifier.value / _modifier.maxValue);
            _audioPlayer.Play();
            _index = _index < _music.Length - 1 ? _index + 1 : 0;
        }
    }

    public void Stop()
    {
        _audioPlayer.Pause();
        _stop = true;
    }

    public void Continue()
    {
        _audioPlayer.UnPause();
        _stop = false;
    }
}
