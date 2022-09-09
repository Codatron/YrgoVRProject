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

    [SerializeField] private BeeState beeState;
    private Vector3 rightControllerPosition;
    private Quaternion rightControllerRotation;
    private Vector3 targetForward;
    private Rigidbody rb;

    public Vector3 flightPath;

    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float speed;
    [SerializeField] private float liftForce;

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
            //  rb.isKinematic = true;
            rb.rotation = GetHeadRotation();
            //rb.velocity = Camera.main.transform.forward.normalized * speed;
            rb.velocity = GetHeadRotation() * body.transform.forward * speed;
            //rb.MovePosition(body.transform.localPosition + (GetHeadRotation() * body.transform.forward * speed));
           
            flightPath = rb.velocity;
            rb.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
        }
        else
        {
            beeState = BeeState.NotFlying;
            rb.isKinematic = false;
            rb.rotation = GetHeadRotation();
        }

        if (beeState == BeeState.Flying)
        {
            //ChangeFlightPathWithController();
            //ChangeFlightPathWithHeadset();
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
}