using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        _audioSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        if( clip == null) return;

        _audioSource.clip = clip;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
