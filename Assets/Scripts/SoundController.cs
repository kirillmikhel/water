using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip backgroundMusicClip;
    public AudioClip backgroundVisionMusicClip;
    public AudioClip discoveryClip;
    public AudioClip diggingClip;
    public AudioClip wellCoverMovingClip;
    public AudioClip pyramidDoorClip;
    public AudioClip outroClip;

    public AudioSource backgroundMusicSource;
    public AudioSource discoverySource;
    public AudioSource diggingSource;
    public AudioSource wellCoverMovingSource;
    public AudioSource pyramidDoorSource;
    public AudioSource outroSource;

    public void Awake()
    {
        backgroundMusicSource = AddAudioSource(backgroundMusicClip, true, true, 1f);
        discoverySource = AddAudioSource(discoveryClip, false, true, 0.5f);
        diggingSource = AddAudioSource(diggingClip, false, false, 0.3f);
        wellCoverMovingSource = AddAudioSource(wellCoverMovingClip, false, false, 1f);
        pyramidDoorSource = AddAudioSource(pyramidDoorClip, false, false, 0.5f);
        outroSource = AddAudioSource(outroClip, false, false, 0.5f);
    }

    public void Start()
    {
        backgroundMusicSource.Play();
    }

    public void SwitchBackgroundMusic(bool vision)
    {
        backgroundMusicSource.clip = vision ? backgroundVisionMusicClip : backgroundMusicClip;
        backgroundMusicSource.Play();
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
