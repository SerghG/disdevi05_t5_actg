using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;


    public static AudioController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        SFXAudioSource.PlayOneShot(sfxClip);
    }

    public void ChangeMusic(AudioClip musicClip)
    {
        MusicAudioSource.Stop();
        MusicAudioSource.clip = musicClip;
        MusicAudioSource.Play();
    }


}
