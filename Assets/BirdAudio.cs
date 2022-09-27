using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAudio : MonoBehaviour
{
    [SerializeField] private AudioClip birdSongClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        SFXHandler.Play(audioSource, birdSongClip, 0.8f, 1.0f);
    }
}
