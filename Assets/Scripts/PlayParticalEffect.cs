using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticalEffect : MonoBehaviour
{
    public Rigidbody playerRB;
    [SerializeField]
    private ParticleSystem nectarParticleSystem;
    [SerializeField]
    private ParticleSystem WindParticleSystem;
    [SerializeField]
    private float maxSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower")) //&& playerRB.velocity.magnitude < maxSpeed)
        { 
            nectarParticleSystem.Play();
        }

        if (other.gameObject.CompareTag("WindArea")) //&& playerRB.velocity.magnitude < maxSpeed)
        {
            WindParticleSystem.Play();
        }
    }
}
