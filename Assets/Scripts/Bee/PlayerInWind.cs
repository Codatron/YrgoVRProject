using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWind : MonoBehaviour
{
    bool inWindZoon = false;
    GameObject windZone;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (inWindZoon)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        { 
            windZone = other.gameObject;
            inWindZoon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            inWindZoon = false;
        }
    }
}
