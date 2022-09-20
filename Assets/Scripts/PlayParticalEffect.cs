using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticalEffect : MonoBehaviour
{
    public Rigidbody playerRB;
    public ParticleSystem nectarParticleSystem;
    [SerializeField]
    private float maxSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower")) //&& playerRB.velocity.magnitude < maxSpeed)
        { 
            nectarParticleSystem.Play();
        }
    }
}
