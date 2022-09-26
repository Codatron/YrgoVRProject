using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SFXHandler
{
    public static void PlayOneShot(AudioSource source, AudioClip clip, float minPitch = 0.0f, float maxPitch = 0.0f)
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        source.pitch = randomPitch;
        source.PlayOneShot(clip);
    }

    public static void PlayOneShot(AudioSource source, AudioClip[] clips, float minPitch = 0.0f, float maxPitch = 0.0f)
    {
        int randomClip = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(minPitch, maxPitch);
        source.pitch = randomPitch;
        source.PlayOneShot(clips[randomClip]);
    }
}
