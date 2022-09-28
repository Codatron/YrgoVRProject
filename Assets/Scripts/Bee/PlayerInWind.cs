using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWind : MonoBehaviour
{
    bool inWindZone = false;
    GameObject windZone;
    Rigidbody rb;
    [SerializeField] private AudioSource windAreaAudioSource;
    [SerializeField] private AudioClip windClip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        { 
            windZone = other.gameObject;
            inWindZone = true;
            SFXHandler.PlayOneShot(windAreaAudioSource, windClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            inWindZone = false;
        }
    }
}
