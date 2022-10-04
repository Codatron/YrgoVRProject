using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake() => particle = GetComponent<ParticleSystem>();

    private void OnEnable() => PickUpNectar.onNectarPickup += PlayParticle;

    private void OnDisable() => PickUpNectar.onNectarPickup -= PlayParticle;

    private void PlayParticle() => particle.Play();
}
