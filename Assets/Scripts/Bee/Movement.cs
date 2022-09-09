using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

// What this script does:
// Should be obvious by the class name.
// This was only a test script to get a feel for constant movement within VR,
//      so it can be built upon or discarded depending on requirements.

public class Movement : MonoBehaviour
{
    private Vector3 newLocation;

    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float speed;

    void Start()
    {
        newLocation = new Vector3(0.0f, 0.0f, 1.0f);
    }

    void Update()
    {
        transform.position += newLocation * speed * Time.deltaTime;
    }
}
