using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SFXHandler
{
    public static void Play(AudioSource source, AudioClip clip, float minPitch = 1.0f, float maxPitch = 1.0f)
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        source.pitch = randomPitch;
        source.clip = clip;
        source.Play();
    }

    public static void PlayOneShot(AudioSource source, AudioClip clip, float minPitch = 1.0f, float maxPitch = 1.0f)
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        source.pitch = randomPitch;
        source.PlayOneShot(clip);
    }

    public static void PlayOneShot(AudioSource source, AudioClip[] clips, float minPitch = 1.0f, float maxPitch = 1.0f)
    {
        int randomClip = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(minPitch, maxPitch);
        source.pitch = randomPitch;
        source.PlayOneShot(clips[randomClip]);
    }

    public static void PlayDelayed(AudioSource source, AudioClip clip, float minDelay, float maxDelay, float minPitch = 1.0f, float maxPitch = 1.0f)
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        float randomPitch = Random.Range(minPitch, maxPitch);
        source.pitch = randomPitch;
        source.clip = clip;
        source.PlayDelayed(randomDelay);
    }
}
