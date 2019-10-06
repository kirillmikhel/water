using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip discoveryClip;
    public AudioClip diggingClip;

    public AudioSource discoverySource;
    public AudioSource diggingSource;

    public void Awake()
    {
        discoverySource = AddAudioSource(discoveryClip, false, true, 0.5f);
        diggingSource = AddAudioSource(diggingClip, false, false, 0.3f);
    }

    private AudioSource AddAudioSource(AudioClip clip, bool loop, bool playAwake, float volume)
    {
        var newAudioSource = gameObject.AddComponent<AudioSource>();

        newAudioSource.clip = clip;
        newAudioSource.loop = loop;
        newAudioSource.playOnAwake = playAwake;
        newAudioSource.volume = volume;

        return newAudioSource;
    }
}
