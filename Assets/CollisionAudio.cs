using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collisionClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CollisionAudio"))
        {
            SFXHandler.PlayOneShot(audioSource, collisionClip, 0.8f, 1.0f);
        }
    }
}
