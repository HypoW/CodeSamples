using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] sounds, music;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.name == name);
        if(s != null)
        {
            _musicSource.clip = s.clip;
            _musicSource.loop = true;
            _musicSource.Play();
        }
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, x => x.name == name);
        if (s != null)
        {
            _effectsSource.PlayOneShot(s.clip);
        }
    }
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
