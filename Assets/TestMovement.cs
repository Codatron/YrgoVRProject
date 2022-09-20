using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //We don't need to multiply with Time.deltaTime since it's already the right unit.
        Vector3 movement = new Vector3(x, 0,y) * speed;

        rb2d.velocity = movement;
    }

}
