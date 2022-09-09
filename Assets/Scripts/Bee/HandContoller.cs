using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandContoller : MonoBehaviour
{
    public Camera head;
    public GameObject body;
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Vector3 flightPath;

    [SerializeField] private BeeState beeState;
    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float speed;
    [SerializeField] private float liftForce;
    private Vector3 targetForward;
    private Rigidbody rb;

    private void Awake()
    {
        rb = body.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        beeState = BeeState.NotFlying;
    }

    private void FixedUpdate()
    {
        if (GetTriggerButton() > 0.1f)
        {
            beeState = BeeState.Flying;

            if (GetRightThumbAxisValue().y > 0.1f)
            {
                speed += GetRightThumbAxisValue().y * 0.02f;
            }
            else if (GetRightThumbAxisValue().y > -0.1f)
            {
                speed -= GetRightThumbAxisValue().y * 0.02f;
            }

            Debug.Log(GetRightThumbAxisValue().y);
        }
        else
        {
            beeState = BeeState.NotFlying;
            rb.rotation = GetHeadRotation();
        }

        if (beeState == BeeState.Flying)
        {
            Fly();
        }


    }

    private Quaternion GetRightControllerRotation()
    {
        return rightController.rotationAction.action.ReadValue<Quaternion>();
    }
    private Vector3 GetRightControllerPosition()
    {
        return rightController.positionAction.action.ReadValue<Vector3>();
    }

    private float GetTriggerButton()
    {
        return rightController.activateAction.action.ReadValue<float>();
    }

    private Quaternion GetHeadRotation()
    {
        return head.transform.localRotation;
    }

    private Vector2 GetRightThumbAxisValue()
    {
        return rightController.translateAnchorAction.action.ReadValue<Vector2>();
    }

    private void ChangeFlightPathWithController()
    {
        body.transform.localRotation = GetRightControllerRotation();
        targetForward = GetRightControllerRotation() * body.transform.forward;
        body.transform.localPosition += targetForward * speed * Time.deltaTime;
    }

    private void ChangeFlightPathWithHeadset()
    {
        body.transform.localRotation = GetHeadRotation();
        targetForward = GetHeadRotation() * body.transform.forward;
        body.transform.localPosition += targetForward * speed * Time.deltaTime;
    }

    private void Fly()
    {
        rb.rotation = GetHeadRotation();
        //rb.velocity = Camera.main.transform.forward.normalized * speed;
        rb.velocity = GetHeadRotation() * body.transform.forward * speed;
        //rb.MovePosition(body.transform.localPosition + (GetHeadRotation() * body.transform.forward * speed));
        flightPath = rb.velocity;
        rb.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
    }
}