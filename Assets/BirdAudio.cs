using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAudio : MonoBehaviour
{
    [SerializeField] private AudioClip birdSongClip;
    private AudioSource audioSource;
    [SerializeField] private float minPlayDelay;
    [SerializeField] private float maxPlayDelay;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        SFXHandler.PlayDelayed(audioSource, birdSongClip, minPlayDelay, maxPlayDelay, minPitch, maxPitch);
    }
}
