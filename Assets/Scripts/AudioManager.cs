using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------------Audio Source-----------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SfxSource;

    [Header("----------------Audio Clip-----------------")]
    public AudioClip[] backgroundMusic;
    public AudioClip deathSound;
    public AudioClip jumpSound;
    public AudioClip healSound;
    public AudioClip damageSound;


    private void Start()
    {
        musicSource.clip = backgroundMusic[0];
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }

}
